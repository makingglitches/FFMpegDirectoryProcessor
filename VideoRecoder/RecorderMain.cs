using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace VideoRecoder
{
    public partial class RecoderMain : Form
    {
        public RecoderMain()
        {
            InitializeComponent();
        }

        private void FFMPegLogo_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.ffmpeg.org");
        }

        private void InputDirButton_Click(object sender, EventArgs e)
        {
            SelectDirectoryDialog.SelectedPath = InputDirText.Text;

            if (SelectDirectoryDialog.ShowDialog() == DialogResult.OK)
            {
                InputDirText.Text = SelectDirectoryDialog.SelectedPath;
            }
        }

        private void OuputDirButton_Click(object sender, EventArgs e)
        {
            SelectDirectoryDialog.SelectedPath = OutputDirText.Text;;

            if (SelectDirectoryDialog.ShowDialog() == DialogResult.OK)
            {
                OutputDirText.Text = SelectDirectoryDialog.SelectedPath;
            }

        }

        private void StartButton_Click(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {

        }

        private void AddFilesButton_Click(object sender, EventArgs e)
        {
            if (OpenMultiFilesDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string s in OpenMultiFilesDialog.FileNames)
                {
                    if (BatchBox.Items.Contains(s))
                    {
                        StatusMessageText.AppendText("\r\nFile: " + s + "\r\nIs already in batch list.");
                    }
                    else
                    {
                        BatchBox.Items.Add(s);
                    }
                }
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (BatchBox.SelectedItems.Count > 0)
            {
                // heres some shit that needs simplified.
                List<string> items = new List<string>();

                foreach (string s in BatchBox.SelectedItems)
                {
                    items.Add(s);

                    // this doesnt work to indicate a shortcut microsoft in its failure avoided
                    // which is why vs code is fucking desigend in electron instead of fucking 
                    // wpf because noone in their right fucking mind would EVER USE WPF !!!!!
                    // THEY ABORT ANYTHING THAT MAKES SENSE !
                    // WINDOWS FORMS SHOULD BE BEAUTIFUL AND MULTI ENVIRONMENT LINKED BY NOW !
                    // I SHOULD BE WRITING FUCKING WINDOWS FORMS ON GODDAMNED LINUX AND MAC !
                    // I SHOULD SEE FUCKING WINDOWS FORMS ON FUCKING ANDROID !!
                    // FUCK BILL GATES AND THE HINDI FUCKING PROJECT MANAGERS AT MICRO DICK FUCKING 
                    // SUCKING SOFT ASSHOLES IN THEIR GODDAMN HEADS !
                   // StatusMessageText.AppendText("\r\n Removed Item: " + s + "\r\n from Batch.");
                   // BatchBox.Items.Remove(s);
                }

                foreach (string s in items)
                {
                    StatusMessageText.AppendText("\r\n Removed Item: " + s + "\r\n from Batch.");
                    BatchBox.Items.Remove(s);

                }
            }
        }

        private void RecodeForSizeCheck_CheckedChanged(object sender, EventArgs e)
        {

           // CRFNumeric.Enabled = RecodeForSizeCheck.Checked;

        }

        private void SplitFileCheck_CheckedChanged(object sender, EventArgs e)
        {
           // SplitTimeText.Enabled = SplitFileCheck.Checked;
        }

        private void ExtractMetaDataCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = FileNameText.Text;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileNameText.Text = openFileDialog1.FileName;
            }

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
