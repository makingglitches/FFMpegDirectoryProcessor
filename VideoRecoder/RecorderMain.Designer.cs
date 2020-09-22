namespace VideoRecoder
{
    partial class RecoderMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecoderMain));
            this.LayoutTabs = new System.Windows.Forms.TabControl();
            this.ByFileTab = new System.Windows.Forms.TabPage();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.FileNameText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ByBatchTab = new System.Windows.Forms.TabPage();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddFilesButton = new System.Windows.Forms.Button();
            this.BatchBox = new System.Windows.Forms.ListBox();
            this.ByDirTab = new System.Windows.Forms.TabPage();
            this.InputDirButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.InputDirText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BatchProgress = new System.Windows.Forms.ProgressBar();
            this.StepProgress = new System.Windows.Forms.ProgressBar();
            this.BatchLabel = new System.Windows.Forms.Label();
            this.StepLabel = new System.Windows.Forms.Label();
            this.SelectDirectoryDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.FFMPegLogo = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.StatusMessageText = new System.Windows.Forms.TextBox();
            this.OpenMultiFilesDialog = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.OuputDirButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.OutputDirText = new System.Windows.Forms.TextBox();
            this.OptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.FileSuffixText = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.SplitTimeText = new System.Windows.Forms.MaskedTextBox();
            this.ExifOutputFileText = new System.Windows.Forms.TextBox();
            this.CRFNumeric = new System.Windows.Forms.NumericUpDown();
            this.SplitFileCheck = new System.Windows.Forms.CheckBox();
            this.ExtractMetaDataCheck = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.LayoutTabs.SuspendLayout();
            this.ByFileTab.SuspendLayout();
            this.ByBatchTab.SuspendLayout();
            this.ByDirTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FFMPegLogo)).BeginInit();
            this.OptionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CRFNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutTabs
            // 
            this.LayoutTabs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LayoutTabs.Controls.Add(this.ByFileTab);
            this.LayoutTabs.Controls.Add(this.ByBatchTab);
            this.LayoutTabs.Controls.Add(this.ByDirTab);
            this.LayoutTabs.Location = new System.Drawing.Point(5, 22);
            this.LayoutTabs.Name = "LayoutTabs";
            this.LayoutTabs.SelectedIndex = 0;
            this.LayoutTabs.Size = new System.Drawing.Size(578, 172);
            this.LayoutTabs.TabIndex = 0;
            // 
            // ByFileTab
            // 
            this.ByFileTab.Controls.Add(this.OpenFileButton);
            this.ByFileTab.Controls.Add(this.FileNameText);
            this.ByFileTab.Controls.Add(this.label6);
            this.ByFileTab.Location = new System.Drawing.Point(4, 22);
            this.ByFileTab.Name = "ByFileTab";
            this.ByFileTab.Padding = new System.Windows.Forms.Padding(3);
            this.ByFileTab.Size = new System.Drawing.Size(570, 146);
            this.ByFileTab.TabIndex = 1;
            this.ByFileTab.Text = "By File";
            this.ByFileTab.UseVisualStyleBackColor = true;
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenFileButton.Location = new System.Drawing.Point(531, 17);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(33, 23);
            this.OpenFileButton.TabIndex = 2;
            this.OpenFileButton.Text = "...";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // FileNameText
            // 
            this.FileNameText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileNameText.Location = new System.Drawing.Point(9, 19);
            this.FileNameText.Name = "FileNameText";
            this.FileNameText.ReadOnly = true;
            this.FileNameText.Size = new System.Drawing.Size(516, 20);
            this.FileNameText.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Filename";
            // 
            // ByBatchTab
            // 
            this.ByBatchTab.Controls.Add(this.RemoveButton);
            this.ByBatchTab.Controls.Add(this.AddFilesButton);
            this.ByBatchTab.Controls.Add(this.BatchBox);
            this.ByBatchTab.Location = new System.Drawing.Point(4, 22);
            this.ByBatchTab.Name = "ByBatchTab";
            this.ByBatchTab.Padding = new System.Windows.Forms.Padding(3);
            this.ByBatchTab.Size = new System.Drawing.Size(570, 146);
            this.ByBatchTab.TabIndex = 2;
            this.ByBatchTab.Text = "By Batch";
            this.ByBatchTab.UseVisualStyleBackColor = true;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveButton.Location = new System.Drawing.Point(88, 117);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveButton.TabIndex = 2;
            this.RemoveButton.Text = "Remove Files";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // AddFilesButton
            // 
            this.AddFilesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddFilesButton.Location = new System.Drawing.Point(6, 117);
            this.AddFilesButton.Name = "AddFilesButton";
            this.AddFilesButton.Size = new System.Drawing.Size(75, 23);
            this.AddFilesButton.TabIndex = 1;
            this.AddFilesButton.Text = "Add Files ..";
            this.AddFilesButton.UseVisualStyleBackColor = true;
            this.AddFilesButton.Click += new System.EventHandler(this.AddFilesButton_Click);
            // 
            // BatchBox
            // 
            this.BatchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BatchBox.FormattingEnabled = true;
            this.BatchBox.Location = new System.Drawing.Point(6, 3);
            this.BatchBox.Name = "BatchBox";
            this.BatchBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.BatchBox.Size = new System.Drawing.Size(558, 108);
            this.BatchBox.TabIndex = 0;
            // 
            // ByDirTab
            // 
            this.ByDirTab.Controls.Add(this.InputDirButton);
            this.ByDirTab.Controls.Add(this.label2);
            this.ByDirTab.Controls.Add(this.InputDirText);
            this.ByDirTab.Location = new System.Drawing.Point(4, 22);
            this.ByDirTab.Name = "ByDirTab";
            this.ByDirTab.Padding = new System.Windows.Forms.Padding(3);
            this.ByDirTab.Size = new System.Drawing.Size(570, 146);
            this.ByDirTab.TabIndex = 0;
            this.ByDirTab.Text = "By Directory";
            this.ByDirTab.UseVisualStyleBackColor = true;
            // 
            // InputDirButton
            // 
            this.InputDirButton.Location = new System.Drawing.Point(510, 23);
            this.InputDirButton.Name = "InputDirButton";
            this.InputDirButton.Size = new System.Drawing.Size(46, 23);
            this.InputDirButton.TabIndex = 8;
            this.InputDirButton.Text = "...";
            this.InputDirButton.UseVisualStyleBackColor = true;
            this.InputDirButton.Click += new System.EventHandler(this.InputDirButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Input Directory";
            // 
            // InputDirText
            // 
            this.InputDirText.Location = new System.Drawing.Point(6, 27);
            this.InputDirText.Name = "InputDirText";
            this.InputDirText.ReadOnly = true;
            this.InputDirText.Size = new System.Drawing.Size(497, 20);
            this.InputDirText.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Process Video Files By..";
            // 
            // BatchProgress
            // 
            this.BatchProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BatchProgress.Location = new System.Drawing.Point(8, 476);
            this.BatchProgress.Name = "BatchProgress";
            this.BatchProgress.Size = new System.Drawing.Size(639, 23);
            this.BatchProgress.TabIndex = 2;
            // 
            // StepProgress
            // 
            this.StepProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StepProgress.Location = new System.Drawing.Point(8, 522);
            this.StepProgress.Name = "StepProgress";
            this.StepProgress.Size = new System.Drawing.Size(639, 23);
            this.StepProgress.TabIndex = 3;
            // 
            // BatchLabel
            // 
            this.BatchLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BatchLabel.AutoSize = true;
            this.BatchLabel.Location = new System.Drawing.Point(5, 459);
            this.BatchLabel.Name = "BatchLabel";
            this.BatchLabel.Size = new System.Drawing.Size(54, 13);
            this.BatchLabel.TabIndex = 4;
            this.BatchLabel.Text = "Video 0/0";
            // 
            // StepLabel
            // 
            this.StepLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StepLabel.AutoSize = true;
            this.StepLabel.Location = new System.Drawing.Point(4, 506);
            this.StepLabel.Name = "StepLabel";
            this.StepLabel.Size = new System.Drawing.Size(71, 13);
            this.StepLabel.TabIndex = 5;
            this.StepLabel.Text = "Current Video";
            // 
            // FFMPegLogo
            // 
            this.FFMPegLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FFMPegLogo.Image = ((System.Drawing.Image)(resources.GetObject("FFMPegLogo.Image")));
            this.FFMPegLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("FFMPegLogo.InitialImage")));
            this.FFMPegLogo.Location = new System.Drawing.Point(658, 476);
            this.FFMPegLogo.Name = "FFMPegLogo";
            this.FFMPegLogo.Size = new System.Drawing.Size(206, 69);
            this.FFMPegLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FFMPegLogo.TabIndex = 6;
            this.FFMPegLogo.TabStop = false;
            this.FFMPegLogo.DoubleClick += new System.EventHandler(this.FFMPegLogo_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(655, 459);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Powered By...";
            // 
            // StartButton
            // 
            this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StartButton.Location = new System.Drawing.Point(539, 243);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(325, 63);
            this.StartButton.TabIndex = 9;
            this.StartButton.Text = "Start Job";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Enabled = false;
            this.CancelButton.Location = new System.Drawing.Point(539, 312);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(325, 23);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Cancel Job";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(589, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Status Messages";
            // 
            // StatusMessageText
            // 
            this.StatusMessageText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusMessageText.Location = new System.Drawing.Point(592, 44);
            this.StatusMessageText.Multiline = true;
            this.StatusMessageText.Name = "StatusMessageText";
            this.StatusMessageText.ReadOnly = true;
            this.StatusMessageText.Size = new System.Drawing.Size(272, 193);
            this.StatusMessageText.TabIndex = 12;
            // 
            // OpenMultiFilesDialog
            // 
            this.OpenMultiFilesDialog.FileName = "x";
            this.OpenMultiFilesDialog.Filter = "MP4 Files|*.mp4";
            this.OpenMultiFilesDialog.Multiselect = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // OuputDirButton
            // 
            this.OuputDirButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OuputDirButton.Location = new System.Drawing.Point(526, 214);
            this.OuputDirButton.Name = "OuputDirButton";
            this.OuputDirButton.Size = new System.Drawing.Size(46, 23);
            this.OuputDirButton.TabIndex = 15;
            this.OuputDirButton.Text = "...";
            this.OuputDirButton.UseVisualStyleBackColor = true;
            this.OuputDirButton.Click += new System.EventHandler(this.OuputDirButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Ouput Directory";
            // 
            // OutputDirText
            // 
            this.OutputDirText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OutputDirText.Location = new System.Drawing.Point(13, 214);
            this.OutputDirText.Name = "OutputDirText";
            this.OutputDirText.ReadOnly = true;
            this.OutputDirText.Size = new System.Drawing.Size(507, 20);
            this.OutputDirText.TabIndex = 16;
            // 
            // OptionsGroupBox
            // 
            this.OptionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionsGroupBox.Controls.Add(this.label8);
            this.OptionsGroupBox.Controls.Add(this.label7);
            this.OptionsGroupBox.Controls.Add(this.FileSuffixText);
            this.OptionsGroupBox.Controls.Add(this.checkBox1);
            this.OptionsGroupBox.Controls.Add(this.SelectFileButton);
            this.OptionsGroupBox.Controls.Add(this.SplitTimeText);
            this.OptionsGroupBox.Controls.Add(this.ExifOutputFileText);
            this.OptionsGroupBox.Controls.Add(this.CRFNumeric);
            this.OptionsGroupBox.Controls.Add(this.SplitFileCheck);
            this.OptionsGroupBox.Controls.Add(this.ExtractMetaDataCheck);
            this.OptionsGroupBox.Location = new System.Drawing.Point(8, 240);
            this.OptionsGroupBox.Name = "OptionsGroupBox";
            this.OptionsGroupBox.Size = new System.Drawing.Size(525, 213);
            this.OptionsGroupBox.TabIndex = 17;
            this.OptionsGroupBox.TabStop = false;
            this.OptionsGroupBox.Text = "Options";
            this.OptionsGroupBox.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Output File Suffix";
            // 
            // FileSuffixText
            // 
            this.FileSuffixText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileSuffixText.Location = new System.Drawing.Point(6, 189);
            this.FileSuffixText.Name = "FileSuffixText";
            this.FileSuffixText.Size = new System.Drawing.Size(266, 20);
            this.FileSuffixText.TabIndex = 21;
            this.FileSuffixText.Text = "_recode";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(9, 141);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(145, 17);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "Skip Existing Output Files";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // SelectFileButton
            // 
            this.SelectFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectFileButton.Location = new System.Drawing.Point(217, 59);
            this.SelectFileButton.Name = "SelectFileButton";
            this.SelectFileButton.Size = new System.Drawing.Size(39, 23);
            this.SelectFileButton.TabIndex = 19;
            this.SelectFileButton.Text = "...";
            this.SelectFileButton.UseVisualStyleBackColor = true;
            // 
            // SplitTimeText
            // 
            this.SplitTimeText.Enabled = false;
            this.SplitTimeText.Location = new System.Drawing.Point(28, 114);
            this.SplitTimeText.Mask = "00\\ \\minutes :00 seconds";
            this.SplitTimeText.Name = "SplitTimeText";
            this.SplitTimeText.PromptChar = ' ';
            this.SplitTimeText.Size = new System.Drawing.Size(126, 20);
            this.SplitTimeText.TabIndex = 18;
            // 
            // ExifOutputFileText
            // 
            this.ExifOutputFileText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExifOutputFileText.Enabled = false;
            this.ExifOutputFileText.Location = new System.Drawing.Point(9, 61);
            this.ExifOutputFileText.Name = "ExifOutputFileText";
            this.ExifOutputFileText.Size = new System.Drawing.Size(202, 20);
            this.ExifOutputFileText.TabIndex = 17;
            this.ExifOutputFileText.Text = "VideoMetaData.txt";
            // 
            // CRFNumeric
            // 
            this.CRFNumeric.Location = new System.Drawing.Point(274, 19);
            this.CRFNumeric.Maximum = new decimal(new int[] {
            51,
            0,
            0,
            0});
            this.CRFNumeric.Name = "CRFNumeric";
            this.CRFNumeric.Size = new System.Drawing.Size(34, 20);
            this.CRFNumeric.TabIndex = 16;
            this.CRFNumeric.Value = new decimal(new int[] {
            19,
            0,
            0,
            0});
            // 
            // SplitFileCheck
            // 
            this.SplitFileCheck.AutoSize = true;
            this.SplitFileCheck.Location = new System.Drawing.Point(9, 91);
            this.SplitFileCheck.Name = "SplitFileCheck";
            this.SplitFileCheck.Size = new System.Drawing.Size(145, 17);
            this.SplitFileCheck.TabIndex = 15;
            this.SplitFileCheck.Text = "Split Files Into Max Times";
            this.SplitFileCheck.UseVisualStyleBackColor = true;
            // 
            // ExtractMetaDataCheck
            // 
            this.ExtractMetaDataCheck.AutoSize = true;
            this.ExtractMetaDataCheck.Location = new System.Drawing.Point(9, 42);
            this.ExtractMetaDataCheck.Name = "ExtractMetaDataCheck";
            this.ExtractMetaDataCheck.Size = new System.Drawing.Size(168, 17);
            this.ExtractMetaDataCheck.TabIndex = 14;
            this.ExtractMetaDataCheck.Text = "Extract MetaData with Exiftool";
            this.ExtractMetaDataCheck.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(-2, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(270, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Recode to Quality (0=Lossless,  51= Best Comprression)";
            // 
            // RecoderMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 557);
            this.Controls.Add(this.OptionsGroupBox);
            this.Controls.Add(this.OutputDirText);
            this.Controls.Add(this.OuputDirButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.StatusMessageText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FFMPegLogo);
            this.Controls.Add(this.StepLabel);
            this.Controls.Add(this.BatchLabel);
            this.Controls.Add(this.StepProgress);
            this.Controls.Add(this.BatchProgress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LayoutTabs);
            this.Name = "RecoderMain";
            this.Text = "MP4 Video Recoder HVEC 265";
            this.LayoutTabs.ResumeLayout(false);
            this.ByFileTab.ResumeLayout(false);
            this.ByFileTab.PerformLayout();
            this.ByBatchTab.ResumeLayout(false);
            this.ByDirTab.ResumeLayout(false);
            this.ByDirTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FFMPegLogo)).EndInit();
            this.OptionsGroupBox.ResumeLayout(false);
            this.OptionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CRFNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl LayoutTabs;
        private System.Windows.Forms.TabPage ByDirTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage ByFileTab;
        private System.Windows.Forms.TabPage ByBatchTab;
        private System.Windows.Forms.ProgressBar BatchProgress;
        private System.Windows.Forms.ProgressBar StepProgress;
        private System.Windows.Forms.Label BatchLabel;
        private System.Windows.Forms.Label StepLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox InputDirText;
        private System.Windows.Forms.FolderBrowserDialog SelectDirectoryDialog;
        private System.Windows.Forms.PictureBox FFMPegLogo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox StatusMessageText;
        private System.Windows.Forms.Button InputDirButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button AddFilesButton;
        private System.Windows.Forms.ListBox BatchBox;
        private System.Windows.Forms.OpenFileDialog OpenMultiFilesDialog;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.TextBox FileNameText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button OuputDirButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox OutputDirText;
        private System.Windows.Forms.GroupBox OptionsGroupBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox FileSuffixText;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button SelectFileButton;
        private System.Windows.Forms.MaskedTextBox SplitTimeText;
        private System.Windows.Forms.TextBox ExifOutputFileText;
        private System.Windows.Forms.NumericUpDown CRFNumeric;
        private System.Windows.Forms.CheckBox SplitFileCheck;
        private System.Windows.Forms.CheckBox ExtractMetaDataCheck;
        private System.Windows.Forms.Label label8;
    }
}

