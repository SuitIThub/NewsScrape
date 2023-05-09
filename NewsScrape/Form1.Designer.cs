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
            this.lDownSpeed = new System.Windows.Forms.Label();
            this.lTotalDown = new System.Windows.Forms.Label();
            this.lTotalLinks = new System.Windows.Forms.Label();
            this.lFileSize = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.PanelList = new System.Windows.Forms.Panel();
            this.lMessage = new System.Windows.Forms.Label();
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
            this.title1.Location = new System.Drawing.Point(12, 9);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(191, 39);
            this.title1.TabIndex = 2;
            this.title1.Text = "NewsScalp";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 387);
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
            this.groupBox5.Location = new System.Drawing.Point(6, 282);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(250, 99);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Download Settings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Anzahl Downloads:";
            // 
            // maxDown
            // 
            this.maxDown.Location = new System.Drawing.Point(154, 71);
            this.maxDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxDown.Name = "maxDown";
            this.maxDown.Size = new System.Drawing.Size(96, 20);
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
            this.label2.Location = new System.Drawing.Point(7, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
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
            this.maxSize.Location = new System.Drawing.Point(154, 45);
            this.maxSize.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.maxSize.Name = "maxSize";
            this.maxSize.Size = new System.Drawing.Size(96, 20);
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
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Download-Tiefe";
            // 
            // depth
            // 
            this.depth.Location = new System.Drawing.Point(154, 19);
            this.depth.Name = "depth";
            this.depth.Size = new System.Drawing.Size(96, 20);
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
            this.groupBox4.Location = new System.Drawing.Point(6, 237);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(250, 39);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Destination Folder";
            // 
            // destinPath
            // 
            this.destinPath.Location = new System.Drawing.Point(0, 19);
            this.destinPath.Name = "destinPath";
            this.destinPath.Size = new System.Drawing.Size(148, 20);
            this.destinPath.TabIndex = 0;
            this.destinPath.Text = "C:\\t";
            // 
            // browseDest
            // 
            this.browseDest.Location = new System.Drawing.Point(154, 18);
            this.browseDest.Name = "browseDest";
            this.browseDest.Size = new System.Drawing.Size(96, 21);
            this.browseDest.TabIndex = 2;
            this.browseDest.Text = "Browse";
            this.browseDest.UseVisualStyleBackColor = true;
            this.browseDest.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.linkList);
            this.groupBox3.Location = new System.Drawing.Point(6, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 212);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Links";
            // 
            // linkList
            // 
            this.linkList.Location = new System.Drawing.Point(0, 19);
            this.linkList.Multiline = true;
            this.linkList.Name = "linkList";
            this.linkList.Size = new System.Drawing.Size(250, 193);
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
            this.groupBox2.Location = new System.Drawing.Point(280, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(611, 387);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // lDownSpeed
            // 
            this.lDownSpeed.Location = new System.Drawing.Point(521, 172);
            this.lDownSpeed.Name = "lDownSpeed";
            this.lDownSpeed.Size = new System.Drawing.Size(77, 59);
            this.lDownSpeed.TabIndex = 7;
            // 
            // lTotalDown
            // 
            this.lTotalDown.Location = new System.Drawing.Point(521, 115);
            this.lTotalDown.Name = "lTotalDown";
            this.lTotalDown.Size = new System.Drawing.Size(77, 57);
            this.lTotalDown.TabIndex = 6;
            // 
            // lTotalLinks
            // 
            this.lTotalLinks.Location = new System.Drawing.Point(521, 89);
            this.lTotalLinks.Name = "lTotalLinks";
            this.lTotalLinks.Size = new System.Drawing.Size(77, 26);
            this.lTotalLinks.TabIndex = 5;
            // 
            // lFileSize
            // 
            this.lFileSize.Location = new System.Drawing.Point(521, 63);
            this.lFileSize.Name = "lFileSize";
            this.lFileSize.Size = new System.Drawing.Size(77, 26);
            this.lFileSize.TabIndex = 4;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(521, 38);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(81, 22);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(521, 17);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(81, 22);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // PanelList
            // 
            this.PanelList.AutoScroll = true;
            this.PanelList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelList.Location = new System.Drawing.Point(6, 17);
            this.PanelList.Name = "PanelList";
            this.PanelList.Size = new System.Drawing.Size(509, 364);
            this.PanelList.TabIndex = 0;
            // 
            // lMessage
            // 
            this.lMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lMessage.Location = new System.Drawing.Point(395, -46);
            this.lMessage.Name = "lMessage";
            this.lMessage.Size = new System.Drawing.Size(216, 43);
            this.lMessage.TabIndex = 8;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyDocuments;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.title1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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

