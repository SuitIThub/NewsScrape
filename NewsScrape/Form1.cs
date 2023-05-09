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
            public String id { get; }
            private StreamWriter file;
            public double size { get; private set; }
            public String text { get; private set; }
            private string path;

            public DownloadFile(String id, String basePath)
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

            public double addText(String text)
            {
                text = Helper.refineText(text);
                file.WriteLine(text);
                this.text = text;
                long length = file.BaseStream.Length;

                size = (double)length;

                return size;
            }

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

        public Form1()
        {
            InitializeComponent();

            initializeSettings();

            initializeLinkField();

            setMessage("Press Start to begin Download.");

            btnStart.Enabled = true;
            //btnStop.Enabled = false;
        }

        private void initializeSettings()
        {
            appSettings = ConfigurationManager.AppSettings;
            destinPath.Text = appSettings["savePath"];
            depth.Value = int.Parse(appSettings["depth"]);
            maxSize.Value = int.Parse(appSettings["maxSize"]);
            maxDown.Value = int.Parse(appSettings["maxDown"]);
        }

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

        private void saveLinks(object sender, EventArgs e)
        {
            string text = linkList.Text.Replace("\r\n", "\n");
            File.WriteAllLines(Directory.GetCurrentDirectory() + "\\online.ztg", text.Split('\n'));
        }

        /// <summary>
        /// Open Dialog-Box to select Folder
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
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

        public void startNextDownload()
        {
            if (nextDownload < pages.Length)
            {
                pages[nextDownload].startDownload();
                nextDownload++;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            linkList.Enabled = false;
            destinPath.Enabled = false;
            browseDest.Enabled = false;
            depth.Enabled = false;
            maxSize.Enabled = false;
            maxDown.Enabled = false;

            PanelList.Controls.Clear();

            setMessage("Downloading...");

            fullText = "";

            string links = linkList.Text.Replace("\r\n", "\n");
            string[] linkArr = links.Split('\n').Where(x => x != "").ToArray();

            pages = new Webpage[linkArr.Length];

            totalLinks = pages.Length;

            for (int i = 0; i < linkArr.Length; i++)
            {
                Webpage wp = new Webpage(linkArr[i], i, PanelList, this);

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

        double bytesRecieved = 0.0;
        DateTime timeStamp = DateTime.Now;
        

        public double addText(string key, string text)
        {
            double size = files[key].addText(text);
            bytesRecieved += size;

            double timeDiff = DateTime.Now.Subtract(timeStamp).TotalSeconds;
            Console.WriteLine($"bytesRecieved: {bytesRecieved}; timeDiff: {timeDiff}");

            if (timeDiff > 2)
            {
                bytesRecieved /= 20;
                bytesRecieved /= timeDiff;

                updateDownSpeed(bytesRecieved);
                timeStamp = DateTime.Now;
                bytesRecieved = 0.0;
            }

            updateFileSize();

            return size;
        }

        public void updateFileSize()
        {
            double total = 0.0;

            files.Values.ToList().ForEach(file => total += file.size);

            if (lFileSize.InvokeRequired)
            {
                lFileSize.Invoke(new Action(updateFileSize));
                return;
            }

            string sizeText = Helper.ConvertBytesToReadableSize(total);

            lFileSize.Text = $"File Size:\n{sizeText}";
        }

        public void updateTotalLinks()
        {
            if (lTotalLinks.InvokeRequired)
            {
                lTotalLinks.Invoke(new Action(updateTotalLinks));
                return;
            }
            lTotalLinks.Text = $"Total Links:\n{totalLinks}";
        }

        public void updateTotalDownloaded()
        {
            if (lTotalDown.InvokeRequired)
            {
                lTotalDown.Invoke(new Action(updateTotalDownloaded));
                return;
            }
            lTotalDown.Text = $"Total Links Downloaded:\n{finishedLinks}";
        }

        public void updateDownSpeed(double size)
        {
            if (lDownSpeed.InvokeRequired)
            {
                lDownSpeed.Invoke(new Action<double>(updateDownSpeed), size);
                return;
            }

            string speedText = Helper.ConvertBytesToReadableSize(size);

            lDownSpeed.Text = $"Download Speed:\n{speedText}/s";
        }

        public void setMessage(string text)
        {
            if (lMessage.InvokeRequired)
            {
                lMessage.Invoke(new Action<string>(setMessage), text);
                return;
            }

            lMessage.Text = text;
        }

        public void finishFile(string key)
        {
            if (btnStart.InvokeRequired)
            {
                btnStart.Invoke(new Action<string>(finishFile), key);
                return;
            }

            string text = files[key].killFile();
            files.Remove(key);
            fullText += $"\n{text}";

            updateTotalDownloaded();

            if (files.Count == 0)
            {
                setMessage("Saving downloaded Text to output-file.");

                string[] codingText = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\encoding.cd", Encoding.UTF8);
                Dictionary<string, string> codingVals = new Dictionary<string, string>();
                foreach (string s in codingText)
                {
                    string[] sSplit = s.Split(new string[] { "->" }, StringSplitOptions.None);
                    codingVals.Add(sSplit[0], sSplit[1]);
                }
                codingVals.Keys.ToList().ForEach(rKey => fullText = fullText.Replace(rKey, codingVals[rKey]));

                byte[] utf8Bytes = Encoding.UTF8.GetBytes(fullText);
                byte[] w1252Bytes = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding("windows-1252"), utf8Bytes);

                File.WriteAllBytes(destinPath.Text + $"\\output.txt", w1252Bytes);

                foreach (Webpage page in pages)
                {
                    page.endDownload(null, null);
                }

                setMessage("Finished download.");

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

        private void btnStop_Click(object sender, EventArgs e)
        {
            setMessage("Waiting for remaining pages to finish the download.");
            foreach(Webpage page in pages)
            {
                page.endDownload(null, null);
            }
        }
    }
}
