using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

using Newtonsoft.Json;

namespace NewsScrape
{
    public partial class Form1 : Form
    {
        public class DownloadFile
        {
            public string id { get; }
            private StreamWriter file;
            public double size { get; private set; }
            public string text { get; private set; }
            private string path;

            public DownloadFile(string id, string basePath)
            {
                this.id = id;
                path = basePath + $"\\NewsScrape_TMP";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                path += $"\\{id}.txt";
                file = File.CreateText(path);
                size = 0.0;
                text = "";
            }

            /// <summary>
            /// Adds Text to System. Refines the Text and saves the text into the corresponding File
            /// </summary>
            /// <param name="text">The text to be added</param>
            /// <returns>the size of the file after appending in bytes</returns>
            public double addText(string text)
            {
                long old_length = file.BaseStream.Length;

                text = Helper.refineText(text);
                file.WriteLine(text);
                this.text = text;
                long length = file.BaseStream.Length;

                size = (double)length;

                return (double)length - (double)old_length;
            }

            /// <summary>
            /// deletes the file and returns its content
            /// </summary>
            /// <returns>the text saved in the file before deleting it</returns>
            public string killFile()
            {
                file.Close();
                File.Delete(path);
                return text;
            }
        }

        NameValueCollection appSettings;

        Webpage[] pages;

        List<Task> downloadPipe = new List<Task>();

        public int maxDepth { get => (int)depth.Value; }
        public int maxFileSize { get => (int)maxSize.Value; }
        public int maxDownload { get => (int)maxDown.Value; }

        int nextDownload = 0;

        public int totalLinks = 0;
        public int finishedLinks = 0;

        public Dictionary<string, DownloadFile> files = new Dictionary<string, DownloadFile>();

        private string fullText;

        double bytesRecieved = 0.0;
        DateTime timeStamp = DateTime.Now;

        public Form1()
        {
            InitializeComponent();

            initializeSettings();

            initializeLinkField();

            setMessage("Press Start to begin Download.");

            btnStart.Enabled = true;
            //btnStop.Enabled = false;
        }

        /// <summary>
        /// Initializes the Program by loading all the Settings
        /// </summary>
        private void initializeSettings()
        {
            appSettings = ConfigurationManager.AppSettings;
            destinPath.Text = appSettings["savePath"];
            depth.Value = int.Parse(appSettings["depth"]);
            maxSize.Value = int.Parse(appSettings["maxSize"]);
            maxDown.Value = int.Parse(appSettings["maxDown"]);
        }

        /// <summary>
        /// loads all webpage-links from file
        /// </summary>
        private void initializeLinkField()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "\\online.ztg"))
            {
                string[] links = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\online.ztg");
                string linksStr = String.Join("\r\n", links);
                linkList.Text = linksStr;
            }

            linkList.ScrollBars = ScrollBars.Vertical;

            linkList.TextChanged += saveLinks;
        }

        /// <summary>
        /// saves the current link configuration to link file
        /// </summary>
        private void saveLinks(object _sender, EventArgs _e)
        {
            string text = linkList.Text.Replace("\r\n", "\n");
            File.WriteAllLines(Directory.GetCurrentDirectory() + "\\online.ztg", text.Split('\n'));
        }

        /// <summary>
        /// Open Dialog-Box to select Folder
        /// </summary>
        private void button1_Click(object _sender, EventArgs _e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (Directory.Exists(destinPath.Text))
                    fbd.SelectedPath = destinPath.Text;
                else if (!Directory.Exists("C:\\t"))
                {
                    Directory.CreateDirectory("C:\\t");
                    fbd.SelectedPath = "C:\\t";
                }

                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    destinPath.Text = fbd.SelectedPath;
            }
        }

        /// <summary>
        /// is called if one Webpage is fully downloaded to start the next queued domain
        /// </summary>
        public void startNextDownload()
        {
            if (nextDownload < pages.Length)
            {
                pages[nextDownload].startDownload();
                nextDownload++;
            }
        }

        /// <summary>
        /// Starts the download-process
        /// </summary>
        private void btnStart_Click(object _sender, EventArgs _e)
        {
            //disable GUI to prevent intervention by user
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            linkList.Enabled = false;
            destinPath.Enabled = false;
            browseDest.Enabled = false;
            depth.Enabled = false;
            maxSize.Enabled = false;
            maxDown.Enabled = false;

            //clears list panel for new download
            PanelList.Controls.Clear();

            setMessage("Downloading...");

            fullText = "";

            //prepare links for use
            string links = linkList.Text.Replace("\r\n", "\n");
            string[] linkArr = links.Split('\n').Where(x => x != "").ToArray();

            pages = new Webpage[linkArr.Length];

            totalLinks = pages.Length;

            for (int i = 0; i < linkArr.Length; i++)
            {
                //create download-class for link
                Webpage wp = new Webpage(linkArr[i], i, PanelList, this);

                //create file-class for temporary storage and text management while downloading
                DownloadFile file = new DownloadFile(wp.id, destinPath.Text);
                files.Add(file.id, file);

                pages[i] = wp;
                if (i < maxDownload)
                {
                    wp.startDownload();
                    nextDownload++;
                }
            }
        }

        /// <summary>
        /// add Text to system. Gets called by Download-Manager. Method reroutes the text to the corresponding file and
        /// calculates the download rate with the returned byte sizes.
        /// </summary>
        /// <param name="key">the key used by the download- and file-manager to identify each other</param>
        /// <param name="text">the text to be added</param>
        /// <returns>the size of the added text</returns>
        public double addText(string key, string text)
        {
            double size = files[key].addText(text);
            bytesRecieved += size;

            double timeDiff = DateTime.Now.Subtract(timeStamp).TotalSeconds;
            Console.WriteLine($"bytesRecieved: {bytesRecieved}; timeDiff: {timeDiff}");

            if (timeDiff > 2)
            {
                bytesRecieved /= timeDiff;

                updateDownSpeed(bytesRecieved);
                timeStamp = DateTime.Now;
                bytesRecieved = 0.0;
            }

            updateFileSize();

            return size;
        }

        /// <summary>
        /// Updates TextView to display the estimated File Size of the final output file
        /// </summary>
        public void updateFileSize()
        {
            double total = 0.0;

            files.Values.ToList().ForEach(file => total += file.size);

            if (lFileSize.InvokeRequired) //needed for call from non-main-thread
            {
                lFileSize.Invoke(new Action(updateFileSize));
                return;
            }

            string sizeText = Helper.ConvertBytesToReadableSize(total);

            lFileSize.Text = $"File Size:\n{sizeText}";
        }

        /// <summary>
        /// Updates TextView to show the amount of links that have been queued for download
        /// </summary>
        public void updateTotalLinks()
        {
            if (lTotalLinks.InvokeRequired) //needed for call from non-main-thread
            {
                lTotalLinks.Invoke(new Action(updateTotalLinks));
                return;
            }
            lTotalLinks.Text = $"Total Links:\n{totalLinks}";
        }

        /// <summary>
        /// Updates TextView to show the amount of links that have been downloaded so far
        /// </summary>
        public void updateTotalDownloaded()
        {
            if (lTotalDown.InvokeRequired) //needed for call from non-main-thread
            {
                lTotalDown.Invoke(new Action(updateTotalDownloaded));
                return;
            }
            lTotalDown.Text = $"Total Links Downloaded:\n{finishedLinks}";
        }

        /// <summary>
        /// Updates TextView to show the current download rate of the pages
        /// </summary>
        /// <param name="size">the amount of bytes downloaded in the last second</param>
        public void updateDownSpeed(double size)
        {
            if (lDownSpeed.InvokeRequired) //needed for call from non-main-thread
            {
                lDownSpeed.Invoke(new Action<double>(updateDownSpeed), size);
                return;
            }

            string speedText = Helper.ConvertBytesToReadableSize(size);

            lDownSpeed.Text = $"Download Speed:\n{speedText}/s";
        }

        /// <summary>
        /// Updates TextView to show system messages
        /// </summary>
        /// <param name="text">string to be displayed</param>
        public void setMessage(string text)
        {
            if (lMessage.InvokeRequired) //needed for call from non-main-thread
            {
                lMessage.Invoke(new Action<string>(setMessage), text);
                return;
            }

            lMessage.Text = text;
        }

        /// <summary>
        /// last call to finalize the download of a domain
        /// </summary>
        /// <param name="key">the identity-key to get the necessary data from the classes and to clean these up</param>
        public void finishFile(string key)
        {
            if (btnStart.InvokeRequired) //needed for call from non-main-thread
            {
                btnStart.Invoke(new Action<string>(finishFile), key);
                return;
            }

            string text = files[key].killFile();
            files.Remove(key);
            fullText += $"\n{text}";

            updateTotalDownloaded();

            //if last domain was finalized start finishing up download
            if (files.Count == 0)
            {
                setMessage("Saving downloaded Text to output-file.");

                //load encoding converter data

                if (File.Exists(Directory.GetCurrentDirectory() + "\\encoding.cd"))
                {
                    string[] codingText = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\encoding.cd", Encoding.UTF8);
                    Dictionary<string, string> codingVals = new Dictionary<string, string>();
                    foreach (string s in codingText)
                    {
                        string[] sSplit = s.Split(new string[] { "->" }, StringSplitOptions.None);
                        codingVals.Add(sSplit[0], sSplit[1]);
                    }
                    codingVals.Keys.ToList().ForEach(rKey => fullText = fullText.Replace(rKey, codingVals[rKey]));
                }

                //convert text t o windows-1252 encoding
                byte[] utf8Bytes = Encoding.UTF8.GetBytes(fullText);
                byte[] w1252Bytes = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding("windows-1252"), utf8Bytes);

                //write text to output file
                File.WriteAllBytes(destinPath.Text + $"\\output.txt", w1252Bytes);

                foreach (Webpage page in pages)
                {
                    page.endDownload(null, null);
                }

                setMessage("Finished download.");

                //reactivate GUI
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                
                linkList.Enabled = true;
                destinPath.Enabled = true;
                browseDest.Enabled = true;
                depth.Enabled = true;
                maxSize.Enabled = true;
                maxDown.Enabled = true;
            }
        }

        /// <summary>
        /// used to stop all download processes
        /// </summary>
        private void btnStop_Click(object _sender, EventArgs _e)
        {
            setMessage("Waiting for remaining pages to finish the download.");
            foreach(Webpage page in pages)
            {
                page.endDownload(null, null);
            }
        }
    }
}
