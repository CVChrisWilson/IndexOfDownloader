namespace IndexOfDownloader
{
    partial class MainControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDownload = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.tbSearchTerm = new System.Windows.Forms.TextBox();
            this.cbSearchExt = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 181F));
            this.tableLayoutPanel1.Controls.Add(this.btnDownload, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbUrl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbSearchTerm, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbSearchExt, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(454, 93);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnDownload, 3);
            this.btnDownload.Location = new System.Drawing.Point(3, 63);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(448, 27);
            this.btnDownload.TabIndex = 3;
            this.btnDownload.Text = "Save .mp3 Files...";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tbUrl
            // 
            this.tbUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUrl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbUrl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tableLayoutPanel1.SetColumnSpan(this.tbUrl, 3);
            this.tbUrl.Location = new System.Drawing.Point(3, 37);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(448, 20);
            this.tbUrl.TabIndex = 2;
            this.tbUrl.Text = "Index of /... Download URL";
            this.tbUrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbUrl_KeyDown);
            // 
            // tbSearchTerm
            // 
            this.tbSearchTerm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.tbSearchTerm, 2);
            this.tbSearchTerm.Location = new System.Drawing.Point(139, 3);
            this.tbSearchTerm.Name = "tbSearchTerm";
            this.tbSearchTerm.Size = new System.Drawing.Size(312, 20);
            this.tbSearchTerm.TabIndex = 1;
            this.tbSearchTerm.Text = "Enter Search Term...";
            this.tbSearchTerm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearchTerm_KeyDown);
            // 
            // cbSearchExt
            // 
            this.cbSearchExt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearchExt.FormattingEnabled = true;
            this.cbSearchExt.Items.AddRange(new object[] {
            ".mp3",
            ".flac",
            ".mp4",
            ".avi",
            ".flv",
            ".mov",
            ".avi",
            ".wmv",
            ".zip"});
            this.cbSearchExt.Location = new System.Drawing.Point(3, 3);
            this.cbSearchExt.Name = "cbSearchExt";
            this.cbSearchExt.Size = new System.Drawing.Size(130, 21);
            this.cbSearchExt.TabIndex = 0;
            this.cbSearchExt.Text = "File Extension...";
            this.cbSearchExt.SelectedIndexChanged += new System.EventHandler(this.cbSearchExt_SelectedIndexChanged);
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 118);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "MainControl";
            this.Text = "Index of Download helper";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.TextBox tbSearchTerm;
        private System.Windows.Forms.ComboBox cbSearchExt;
    }
}

