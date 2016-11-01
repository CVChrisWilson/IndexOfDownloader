using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Globalization;

namespace IndexOfDownloader
{
    public partial class MainControl : Form
    {
        public MainControl()
        {
            InitializeComponent();
            tbUrl.GotFocus += GotFocus_RemoveText;
            tbSearchTerm.GotFocus += GotFocus_RemoveText;
        }


        public void GotFocus_RemoveText(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                switch (((TextBox)sender).Name)
                {
                    case "tbUrl":
                        tbUrl.Text = "";
                        tbUrl.GotFocus -= GotFocus_RemoveText;
                        break;
                    case "tbSearchTerm":
                        tbSearchTerm.Text = "";
                        tbSearchTerm.GotFocus -= GotFocus_RemoveText;
                        break;
                }
            }
        }

        private void downloadMp3Files(string dlLink, string filePath)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(dlLink, filePath);
            }
            string newName = filePath.Replace("%20", " ");

            if (File.Exists(newName))
            {
                System.IO.File.Delete(newName);
            }

            System.IO.File.Move(filePath, newName);
        }

        private void downloadHandler()
        {
            string baseUrl = tbUrl.Text;
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                string[] files = Directory.GetFiles(fbd.SelectedPath);

                //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                // Enter key pressed
                using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
                {
                    //client.DownloadFile("http://yoursite.com/page.html", @"C:\localfile.html");

                    // Or you can get the file content without saving it:
                    string htmlCode = client.DownloadString(tbUrl.Text);
                    //...

                    List<string> fileList = findMp3Files(htmlCode);

                    foreach (string file in fileList)
                    {
                        new Task(() => { downloadMp3Files(baseUrl + file, fbd.SelectedPath + @"\" + file); }).Start();
                        //client.DownloadFile(textBox1.Text + file, fbd.SelectedPath + @"\" + file);

                    }
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Uri uriResult;
            if (!string.IsNullOrWhiteSpace(tbUrl.Text) && (Uri.TryCreate(tbUrl.Text, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps)))
            {
                if (!string.Equals(cbSearchExt.SelectedIndex.ToString(), "File Extension...", StringComparison.InvariantCultureIgnoreCase))
                {
                    downloadHandler();
                }
                else
                {
                    MessageBox.Show("Please enter or select a file extension from the list.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid url.");
            }
        }
        private List<string> findMp3Files(string HtmlCode)
        {
            List<string> files = new List<string>();
            if (!string.IsNullOrWhiteSpace(HtmlCode))
            {
                string[] splitCode = HtmlCode.Split('<');
                foreach (string tagLine in splitCode)
                {
                    if (tagLine.IndexOf("href", StringComparison.InvariantCultureIgnoreCase) >= 0)
                    {
                        if (tagLine.IndexOf(cbSearchExt.SelectedIndex.ToString(), StringComparison.InvariantCultureIgnoreCase) > 0)
                        {
                            var file = new StringBuilder();
                            bool started = false;
                            bool ended = false;
                            for (int i = 0; i < tagLine.Length; ++i)
                            {
                                bool startChar = false;
                                if (tagLine[i] == '"' && !started)
                                {
                                    started = true;
                                    startChar = true;
                                }
                                if (tagLine[i] == '"' && started && !startChar)
                                {
                                    ended = true;
                                }
                                if (started && !ended && !startChar)
                                {
                                    file.Append(tagLine[i]);
                                }
                            }
                            files.Add(file.ToString());
                        }
                    }
                }
            }
            return files;
        }

        private void tbUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                Uri uriResult;
                if (!string.IsNullOrWhiteSpace(tbUrl.Text) && (Uri.TryCreate(tbUrl.Text, UriKind.Absolute, out uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps)))
                {
                    downloadHandler();
                }
                else
                {
                    MessageBox.Show("Please enter a valid url.");
                }
            }
        }

        private void tbSearchTerm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (!string.Equals(cbSearchExt.SelectedIndex.ToString(), "File Extension...", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!string.IsNullOrWhiteSpace(tbSearchTerm.Text))
                    {
                        System.Diagnostics.ProcessStartInfo sInfo = new System.Diagnostics.ProcessStartInfo();
                        DialogResult dialogResult = MessageBox.Show("Use search tags?", "Search Type", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            sInfo = new System.Diagnostics.ProcessStartInfo(
                                "https://www.google.com/#q=intitle:+index+of+directory+filetype:+" + cbSearchExt.Text
                                + "+" + tbSearchTerm.Text);
                        }
                        else
                        {
                            sInfo = new System.Diagnostics.ProcessStartInfo(
                                "https://www.google.com/#q=index+of+directory" + cbSearchExt.Text
                                + "+" + tbSearchTerm.Text);
                        }
                        System.Diagnostics.Process.Start(sInfo);
                    }
                    else
                    {
                        MessageBox.Show("Please enter a search term.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter or select a file extension from the list.");
                }
            }
        }

        private void cbSearchExt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.Equals(cbSearchExt.SelectedIndex.ToString(), "File Extension...", StringComparison.InvariantCultureIgnoreCase))
            {
                MessageBox.Show("Please enter or select a file extension from the list.");
            }
            else
            {
                tbSearchTerm.Focus();
            }
        }
    }
}
