using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsScrape
{
    /// <summary>
    /// This class defines a full domain. The class fully manages the download if it's own domain.
    /// </summary>
    public class Webpage
    {
        public string id;

        private List<(string, int)> urls;

        private Panel panel;
        private Label title;
        private ProgressBar progress;
        private Button cancel;
        private Label amount;
        private Label size;

        private Panel parent;

        private Form1 context;

        private List<string> usedLinks;

        private Task downloadTask;

        public CancellationTokenSource cts { get; private set; }

        public Webpage(string url, int order, Panel parent, Form1 context)
        {
            id = Helper.id;

            cts = new CancellationTokenSource();

            this.parent = parent;
            this.context = context;

            urls = new List<(string, int)>
            {
                (url, 0)
            };

            usedLinks = new List<string> { url };

            //panel containing all components for frontend
            panel = new Panel();
            panel.Size = new Size(488, 22);
            panel.Location = new Point(0, 22 * order);
            panel.BorderStyle = BorderStyle.FixedSingle;

            //TextView displaying domain in frontend
            title = new Label();
            title.Size = new Size(180, 22);
            title.Padding = new Padding(0, 3, 0, 3);
            title.Location = new Point(0, 0);
            title.Text = url;
            title.AutoEllipsis = true;
            panel.Controls.Add(title);

            //ProgressBar showing download-progress of currently downloading page
            progress = new ProgressBar();
            progress.Size = new Size(100, 15);
            progress.Location = new Point(180, 3);
            progress.Minimum = 0;
            progress.Maximum = 100;
            progress.Value = 0;
            panel.Controls.Add(progress);

            //Button for cancelling the download of this domain
            cancel = new Button();
            cancel.Size = new Size(22, 20);
            cancel.Location = new Point(280, 0);
            cancel.Padding = new Padding(0, 0, 0, 0);
            cancel.Text = "x";
            cancel.TextAlign = ContentAlignment.MiddleCenter;
            cancel.Click += endDownload;
            panel.Controls.Add(cancel);

            //TextView showing the amount of downloaded Pages and the amount of queued pages
            amount = new Label();
            amount.Size = new Size(100, 22);
            amount.Padding = new Padding(0, 3, 0, 3);
            amount.Location = new Point(305, 0);
            amount.Text = "0 (+1)";
            amount.AutoEllipsis = true;
            panel.Controls.Add(amount);

            //TextView showing the size of already downloaded text for this domain
            size = new Label();
            size.Size = new Size(85, 22);
            size.Padding = new Padding(0, 3, 0, 3);
            size.Location = new Point(405, 0);
            size.Text = "-";
            size.AutoEllipsis = true;
            panel.Controls.Add(size);

            parent.Controls.Add(panel);

            downloadTask = null;
        }

        /// <summary>
        /// run to start the downloading process for the pages defined in this class
        /// </summary>
        /// <returns>the Task of the created Multithreading-Task</returns>
        public Task startDownload()
        {
            downloadTask = Task.Run(() => downloadLink(cts.Token));
            return downloadTask;
        }

        /// <summary>
        /// Multithreaded method to download all webpages saved in <see cref="urls"/>
        /// Scans downloaded pages for links to download next level of pages
        /// </summary>
        /// <param name="token">the <see cref="CancellationToken"/> used to kill the thread before regular end</param>
        private async void downloadLink(CancellationToken token)
        {
            int errorCount = 0;
            for (int i = 0; i < urls.Count; i++)
            {
                if (token.IsCancellationRequested)
                    break;

                string url = urls[i].Item1;
                int level = urls[i].Item2;

                try
                {
                    using (WebClient client = new WebClient())
                    {
                        //set Header for better access
                        client.Headers.Add("UserAgent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                        client.Headers.Add("Cache-Control", "no-cache");

                        //set listener for download progress
                        client.DownloadProgressChanged += WebClientDownloadProgressChanged;

                        //download in utf8
                        client.Encoding = Encoding.UTF8;

                        string result = await client.DownloadStringTaskAsync(new Uri(url));

                        //load downloaded text as html-document
                        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                        doc.LoadHtml(result);

                        //get inner-text from html without tags
                        string text = doc.DocumentNode.InnerText;

                        //load text into page-file
                        double size = context.addText(id, text);
                        updateSizeText(size);

                        context.finishedLinks++;
                        context.updateTotalDownloaded();

                        //check for next level links if max level is not reached
                        if (level < context.maxDepth)
                        {
                            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//a[@href]");
                            if (nodes != null)
                            {
                                //get all links from html
                                foreach (HtmlNode link in nodes)
                                {
                                    string href = link.Attributes["href"].Value.ToString();
                                    if (href.StartsWith("https") && !usedLinks.Contains(href))
                                    {
                                        usedLinks.Add(href);
                                        urls.Add((href, level + 1));
                                        context.totalLinks++;
                                        context.updateTotalLinks();
                                    }
                                }
                            }
                        }

                        updateAmountText($"{i} (+{urls.Count - i})");
                    }
                }
                catch (Exception ex)
                {
                    errorCount++;
                    if (errorCount > 5)
                    {
                        amount.Text = ex.Message;
                        return;
                    }
                }
            }

            updateAmountText("Finished");

            context.finishFile(id);
            context.startNextDownload();
        }

        /// <summary>
        /// Listener for Download-Progress. Needed for Progress Bar
        /// </summary>
        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (progress.InvokeRequired) //needed for call from non-main-thread
            {
                progress.Invoke(new Action<object, DownloadProgressChangedEventArgs>(WebClientDownloadProgressChanged), sender, e);
                return;
            }
            progress.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Updates TextView showing the amount of downloaded and queued pages
        /// </summary>
        /// <param name="text">Text to be displayed</param>
        private void updateAmountText(string text)
        {
            if (amount.InvokeRequired) //needed for call from non-main-thread
            {
                amount.Invoke(new Action<string>(updateAmountText), text);
                return;
            }

            amount.Text = text;
        }

        /// <summary>
        /// Updates TextView showing the size of the downloaded Text
        /// </summary>
        /// <param name="text">Text to be displayed</param>
        private void updateSizeText(double size)
        {
            if (amount.InvokeRequired) //needed for call from non-main-thread
            {
                amount.Invoke(new Action<double>(updateSizeText), size);
                return;
            }

            this.size.Text = Helper.ConvertBytesToReadableSize(size);

            context.updateFileSize();
        }

        /// <summary>
        /// kills the download thread
        /// </summary>
        public void endDownload(object _sender, EventArgs _e)
        {
            cts.Cancel();
        }
    }
}
