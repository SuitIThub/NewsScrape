namespace NewsScrape
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.title1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.maxDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.maxSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.depth = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.destinPath = new System.Windows.Forms.TextBox();
            this.browseDest = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.linkList = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lMessage = new System.Windows.Forms.Label();
            this.lDownSpeed = new System.Windows.Forms.Label();
            this.lTotalDown = new System.Windows.Forms.Label();
            this.lTotalLinks = new System.Windows.Forms.Label();
            this.lFileSize = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.PanelList = new System.Windows.Forms.Panel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depth)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // title1
            // 
            this.title1.AutoSize = true;
            this.title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title1.Location = new System.Drawing.Point(24, 17);
            this.title1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(432, 79);
            this.title1.TabIndex = 2;
            this.title1.Text = "NewsScrape";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(24, 98);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(524, 744);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.maxDown);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.maxSize);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.depth);
            this.groupBox5.Location = new System.Drawing.Point(12, 542);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox5.Size = new System.Drawing.Size(500, 190);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Download Settings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Anzahl Downloads:";
            // 
            // maxDown
            // 
            this.maxDown.Location = new System.Drawing.Point(308, 137);
            this.maxDown.Margin = new System.Windows.Forms.Padding(6);
            this.maxDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxDown.Name = "maxDown";
            this.maxDown.Size = new System.Drawing.Size(192, 31);
            this.maxDown.TabIndex = 4;
            this.maxDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(285, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Beende bei Dateigröße (MB)";
            // 
            // maxSize
            // 
            this.maxSize.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.maxSize.Location = new System.Drawing.Point(308, 87);
            this.maxSize.Margin = new System.Windows.Forms.Padding(6);
            this.maxSize.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.maxSize.Name = "maxSize";
            this.maxSize.Size = new System.Drawing.Size(192, 31);
            this.maxSize.TabIndex = 2;
            this.maxSize.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Download-Tiefe";
            // 
            // depth
            // 
            this.depth.Location = new System.Drawing.Point(308, 37);
            this.depth.Margin = new System.Windows.Forms.Padding(6);
            this.depth.Name = "depth";
            this.depth.Size = new System.Drawing.Size(192, 31);
            this.depth.TabIndex = 0;
            this.depth.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.destinPath);
            this.groupBox4.Controls.Add(this.browseDest);
            this.groupBox4.Location = new System.Drawing.Point(12, 456);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox4.Size = new System.Drawing.Size(500, 75);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Destination Folder";
            // 
            // destinPath
            // 
            this.destinPath.Location = new System.Drawing.Point(0, 37);
            this.destinPath.Margin = new System.Windows.Forms.Padding(6);
            this.destinPath.Name = "destinPath";
            this.destinPath.Size = new System.Drawing.Size(292, 31);
            this.destinPath.TabIndex = 0;
            this.destinPath.Text = "C:\\t";
            // 
            // browseDest
            // 
            this.browseDest.Location = new System.Drawing.Point(308, 35);
            this.browseDest.Margin = new System.Windows.Forms.Padding(6);
            this.browseDest.Name = "browseDest";
            this.browseDest.Size = new System.Drawing.Size(192, 40);
            this.browseDest.TabIndex = 2;
            this.browseDest.Text = "Browse";
            this.browseDest.UseVisualStyleBackColor = true;
            this.browseDest.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.linkList);
            this.groupBox3.Location = new System.Drawing.Point(12, 37);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox3.Size = new System.Drawing.Size(500, 408);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Links";
            // 
            // linkList
            // 
            this.linkList.Location = new System.Drawing.Point(0, 37);
            this.linkList.Margin = new System.Windows.Forms.Padding(6);
            this.linkList.Multiline = true;
            this.linkList.Name = "linkList";
            this.linkList.Size = new System.Drawing.Size(496, 367);
            this.linkList.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lMessage);
            this.groupBox2.Controls.Add(this.lDownSpeed);
            this.groupBox2.Controls.Add(this.lTotalDown);
            this.groupBox2.Controls.Add(this.lTotalLinks);
            this.groupBox2.Controls.Add(this.lFileSize);
            this.groupBox2.Controls.Add(this.btnStop);
            this.groupBox2.Controls.Add(this.btnStart);
            this.groupBox2.Controls.Add(this.PanelList);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Location = new System.Drawing.Point(560, 98);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(1222, 744);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // lMessage
            // 
            this.lMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lMessage.Location = new System.Drawing.Point(790, -88);
            this.lMessage.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lMessage.Name = "lMessage";
            this.lMessage.Size = new System.Drawing.Size(432, 83);
            this.lMessage.TabIndex = 8;
            // 
            // lDownSpeed
            // 
            this.lDownSpeed.Location = new System.Drawing.Point(1042, 331);
            this.lDownSpeed.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lDownSpeed.Name = "lDownSpeed";
            this.lDownSpeed.Size = new System.Drawing.Size(154, 113);
            this.lDownSpeed.TabIndex = 7;
            // 
            // lTotalDown
            // 
            this.lTotalDown.Location = new System.Drawing.Point(1042, 221);
            this.lTotalDown.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lTotalDown.Name = "lTotalDown";
            this.lTotalDown.Size = new System.Drawing.Size(154, 110);
            this.lTotalDown.TabIndex = 6;
            // 
            // lTotalLinks
            // 
            this.lTotalLinks.Location = new System.Drawing.Point(1042, 171);
            this.lTotalLinks.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lTotalLinks.Name = "lTotalLinks";
            this.lTotalLinks.Size = new System.Drawing.Size(154, 50);
            this.lTotalLinks.TabIndex = 5;
            // 
            // lFileSize
            // 
            this.lFileSize.Location = new System.Drawing.Point(1042, 121);
            this.lFileSize.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lFileSize.Name = "lFileSize";
            this.lFileSize.Size = new System.Drawing.Size(154, 50);
            this.lFileSize.TabIndex = 4;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(1042, 73);
            this.btnStop.Margin = new System.Windows.Forms.Padding(6);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(162, 42);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(1042, 33);
            this.btnStart.Margin = new System.Windows.Forms.Padding(6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(162, 42);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // PanelList
            // 
            this.PanelList.AutoScroll = true;
            this.PanelList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelList.Location = new System.Drawing.Point(12, 33);
            this.PanelList.Margin = new System.Windows.Forms.Padding(6);
            this.PanelList.Name = "PanelList";
            this.PanelList.Size = new System.Drawing.Size(1014, 696);
            this.PanelList.TabIndex = 0;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyDocuments;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1802, 865);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.title1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depth)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label title1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button browseDest;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox destinPath;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox linkList;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown depth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown maxSize;
        private System.Windows.Forms.Panel PanelList;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown maxDown;
        private System.Windows.Forms.Label lTotalDown;
        private System.Windows.Forms.Label lTotalLinks;
        private System.Windows.Forms.Label lFileSize;
        private System.Windows.Forms.Label lDownSpeed;
        private System.Windows.Forms.Label lMessage;
    }
}

