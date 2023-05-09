using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsScrape
{
    public class Webpage
    {
        public string id;

        public List<(string, int)> urls;

        public Panel panel;
        public Label title;
        public ProgressBar progress;
        public Button cancel;
        public Label amount;
        public Label size;

        private Panel parent;

        private Form1 context;

        private List<string> usedLinks;

        private Task downloadTask;

        public CancellationTokenSource cts;

        public Webpage(string url, int order, Panel parent, Form1 context)
        {
            id = Helper.id;

            cts = new CancellationTokenSource();

            this.parent = parent;
            this.context = context;

            urls = new List<(string, int)>();

            urls.Add((url, 0));

            usedLinks = new List<string> { url };

            panel = new Panel();
            panel.Size = new Size(488, 22);
            panel.Location = new Point(0, 22 * order);
            panel.BorderStyle = BorderStyle.FixedSingle;

            title = new Label();
            title.Size = new Size(180, 22);
            title.Padding = new Padding(0, 3, 0, 3);
            title.Location = new Point(0, 0);
            title.Text = url;
            title.AutoEllipsis = true;
            panel.Controls.Add(title);

            progress = new ProgressBar();
            progress.Size = new Size(100, 15);
            progress.Location = new Point(180, 3);
            progress.Minimum = 0;
            progress.Maximum = 100;
            progress.Value = 0;
            panel.Controls.Add(progress);

            cancel = new Button();
            cancel.Size = new Size(22, 20);
            cancel.Location = new Point(280, 0);
            cancel.Padding = new Padding(0, 0, 0, 0);
            cancel.Text = "x";
            cancel.TextAlign = ContentAlignment.MiddleCenter;
            cancel.Click += endDownload;
            panel.Controls.Add(cancel);

            amount = new Label();
            amount.Size = new Size(100, 22);
            amount.Padding = new Padding(0, 3, 0, 3);
            amount.Location = new Point(305, 0);
            amount.Text = "0 (+1)";
            amount.AutoEllipsis = true;
            panel.Controls.Add(amount);

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

        public Task startDownload()
        {
            downloadTask = Task.Run(() => downloadLink(cts.Token));
            return downloadTask;
        }

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
                        client.Headers.Add("UserAgent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                        client.Headers.Add("Cache-Control", "no-cache");

                        client.DownloadProgressChanged += WebClientDownloadProgressChanged;
                        client.Encoding = Encoding.UTF8;

                        //string result = client.DownloadString(url);

                        string result = await client.DownloadStringTaskAsync(new Uri(url));

                        //System.Diagnostics.Debug.WriteLine(result);

                        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                        doc.LoadHtml(result);

                        //get text from html without tags
                        string text = doc.DocumentNode.InnerText;
                        double size = context.addText(id, text);
                        updateSizeText(size);

                        context.finishedLinks++;
                        context.updateTotalDownloaded();

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

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (progress.InvokeRequired)
            {
                progress.Invoke(new Action<object, DownloadProgressChangedEventArgs>(WebClientDownloadProgressChanged), sender, e);
                return;
            }
            progress.Value = e.ProgressPercentage;
        }

        private void updateAmountText(string text)
        {
            if (amount.InvokeRequired)
            {
                amount.Invoke(new Action<string>(updateAmountText), text);
                return;
            }

            amount.Text = text;
        }

        private void updateSizeText(double size)
        {
            if (amount.InvokeRequired)
            {
                amount.Invoke(new Action<double>(updateSizeText), size);
                return;
            }

            this.size.Text = Helper.ConvertBytesToReadableSize(size);

            context.updateFileSize();
        }

        public void endDownload(object sender, EventArgs e)
        {
            cts.Cancel();
        }
    }
}
