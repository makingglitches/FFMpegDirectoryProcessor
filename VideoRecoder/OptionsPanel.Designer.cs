namespace VideoRecoder
{
    partial class OptionsPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SplitFileCheck = new System.Windows.Forms.CheckBox();
            this.ExtractMetaDataCheck = new System.Windows.Forms.CheckBox();
            this.RecodeForSizeCheck = new System.Windows.Forms.CheckBox();
            this.CRFNumeric = new System.Windows.Forms.NumericUpDown();
            this.ExifOutputFileText = new System.Windows.Forms.TextBox();
            this.SplitTimeText = new System.Windows.Forms.MaskedTextBox();
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CRFNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // SplitFileCheck
            // 
            this.SplitFileCheck.AutoSize = true;
            this.SplitFileCheck.Location = new System.Drawing.Point(6, 91);
            this.SplitFileCheck.Name = "SplitFileCheck";
            this.SplitFileCheck.Size = new System.Drawing.Size(145, 17);
            this.SplitFileCheck.TabIndex = 5;
            this.SplitFileCheck.Text = "Split Files Into Max Times";
            this.SplitFileCheck.UseVisualStyleBackColor = true;
         //   this.SplitFileCheck.CheckedChanged += new System.EventHandler(this.SplitFileCheck_CheckedChanged);
            // 
            // ExtractMetaDataCheck
            // 
            this.ExtractMetaDataCheck.AutoSize = true;
            this.ExtractMetaDataCheck.Location = new System.Drawing.Point(6, 42);
            this.ExtractMetaDataCheck.Name = "ExtractMetaDataCheck";
            this.ExtractMetaDataCheck.Size = new System.Drawing.Size(168, 17);
            this.ExtractMetaDataCheck.TabIndex = 4;
            this.ExtractMetaDataCheck.Text = "Extract MetaData with Exiftool";
            this.ExtractMetaDataCheck.UseVisualStyleBackColor = true;
           // this.ExtractMetaDataCheck.CheckedChanged += new System.EventHandler(this.ExtractMetaDataCheck_CheckedChanged);
            // 
            // RecodeForSizeCheck
            // 
            this.RecodeForSizeCheck.AutoSize = true;
            this.RecodeForSizeCheck.Location = new System.Drawing.Point(6, 19);
            this.RecodeForSizeCheck.Name = "RecodeForSizeCheck";
            this.RecodeForSizeCheck.Size = new System.Drawing.Size(146, 17);
            this.RecodeForSizeCheck.TabIndex = 3;
            this.RecodeForSizeCheck.Text = "Reencode to Target CRF";
            this.RecodeForSizeCheck.UseVisualStyleBackColor = true;
         //   this.RecodeForSizeCheck.CheckedChanged += new System.EventHandler(this.RecodeForSizeCheck_CheckedChanged);
            // 
            // CRFNumeric
            // 
            this.CRFNumeric.Enabled = false;
            this.CRFNumeric.Location = new System.Drawing.Point(158, 16);
            this.CRFNumeric.Maximum = new decimal(new int[] {
            51,
            0,
            0,
            0});
            this.CRFNumeric.Name = "CRFNumeric";
            this.CRFNumeric.Size = new System.Drawing.Size(34, 20);
            this.CRFNumeric.TabIndex = 6;
            this.CRFNumeric.Value = new decimal(new int[] {
            19,
            0,
            0,
            0});
            // 
            // ExifOutputFileText
            // 
            this.ExifOutputFileText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExifOutputFileText.Enabled = false;
            this.ExifOutputFileText.Location = new System.Drawing.Point(25, 65);
            this.ExifOutputFileText.Name = "ExifOutputFileText";
            this.ExifOutputFileText.Size = new System.Drawing.Size(171, 20);
            this.ExifOutputFileText.TabIndex = 7;
            this.ExifOutputFileText.Text = "VideoMetaData.txt";
            // 
            // SplitTimeText
            // 
            this.SplitTimeText.Enabled = false;
            this.SplitTimeText.Location = new System.Drawing.Point(25, 114);
            this.SplitTimeText.Mask = "00\\ \\minutes :00 seconds";
            this.SplitTimeText.Name = "SplitTimeText";
            this.SplitTimeText.PromptChar = ' ';
            this.SplitTimeText.Size = new System.Drawing.Size(126, 20);
            this.SplitTimeText.TabIndex = 8;
            // 
            // SelectFileButton
            // 
            this.SelectFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectFileButton.Location = new System.Drawing.Point(202, 61);
            this.SelectFileButton.Name = "SelectFileButton";
            this.SelectFileButton.Size = new System.Drawing.Size(39, 23);
            this.SelectFileButton.TabIndex = 9;
            this.SelectFileButton.Text = "...";
            this.SelectFileButton.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(6, 141);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(145, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Skip Existing Output Files";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(3, 189);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(235, 20);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "_recode";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Output File Suffix";
            // 
            // OptionsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.SelectFileButton);
            this.Controls.Add(this.SplitTimeText);
            this.Controls.Add(this.ExifOutputFileText);
            this.Controls.Add(this.CRFNumeric);
            this.Controls.Add(this.SplitFileCheck);
            this.Controls.Add(this.ExtractMetaDataCheck);
            this.Controls.Add(this.RecodeForSizeCheck);
            this.Name = "OptionsPanel";
            this.Size = new System.Drawing.Size(259, 221);
            ((System.ComponentModel.ISupportInitialize)(this.CRFNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox SplitFileCheck;
        private System.Windows.Forms.CheckBox ExtractMetaDataCheck;
        private System.Windows.Forms.CheckBox RecodeForSizeCheck;
        private System.Windows.Forms.NumericUpDown CRFNumeric;
        private System.Windows.Forms.TextBox ExifOutputFileText;
        private System.Windows.Forms.MaskedTextBox SplitTimeText;
        private System.Windows.Forms.Button SelectFileButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}
