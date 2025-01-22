namespace scrcpy_UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            richTextBox1 = new RichTextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            clearToolStripMenuItem = new ToolStripMenuItem();
            checkBox1 = new CheckBox();
            maskedTextBox1 = new MaskedTextBox();
            label1 = new Label();
            textBox1 = new TextBox();
            panelMaskedTextBox1 = new Panel();
            panelTextBox1 = new Panel();
            customButton1 = new Helpers.CustomButton();
            customButton2 = new Helpers.CustomButton();
            customButton3 = new Helpers.CustomButton();
            customButton4 = new Helpers.CustomButton();
            panelDownloader = new Panel();
            labelDownload = new Label();
            progressBar1 = new ProgressBar();
            contextMenuStrip1.SuspendLayout();
            panelMaskedTextBox1.SuspendLayout();
            panelTextBox1.SuspendLayout();
            panelDownloader.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.Black;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.ContextMenuStrip = contextMenuStrip1;
            richTextBox1.ForeColor = Color.White;
            richTextBox1.Location = new Point(12, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox1.Size = new Size(548, 284);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            richTextBox1.LinkClicked += richTextBox1_LinkClicked;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { clearToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(102, 26);
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.Size = new Size(101, 22);
            clearToolStripMenuItem.Text = "Clear";
            clearToolStripMenuItem.Click += clearToolStripMenuItem_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.ForeColor = Color.White;
            checkBox1.Location = new Point(174, 307);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(79, 19);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "Screen off";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.BackColor = Color.FromArgb(25, 27, 28);
            maskedTextBox1.BorderStyle = BorderStyle.None;
            maskedTextBox1.Dock = DockStyle.Fill;
            maskedTextBox1.ForeColor = Color.White;
            maskedTextBox1.Location = new Point(4, 3);
            maskedTextBox1.Mask = "\\1\\9\\2\\.\\1\\6\\8\\.\\1\\.###";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.PromptChar = '-';
            maskedTextBox1.Size = new Size(72, 16);
            maskedTextBox1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Black;
            label1.ForeColor = Color.White;
            label1.Location = new Point(303, 308);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 7;
            label1.Text = "Device IP:";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(25, 27, 28);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Dock = DockStyle.Fill;
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(4, 3);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Custom command...";
            textBox1.Size = new Size(427, 16);
            textBox1.TabIndex = 10;
            // 
            // panelMaskedTextBox1
            // 
            panelMaskedTextBox1.BackColor = Color.FromArgb(25, 27, 28);
            panelMaskedTextBox1.BorderStyle = BorderStyle.FixedSingle;
            panelMaskedTextBox1.Controls.Add(maskedTextBox1);
            panelMaskedTextBox1.Location = new Point(367, 304);
            panelMaskedTextBox1.Name = "panelMaskedTextBox1";
            panelMaskedTextBox1.Padding = new Padding(4, 3, 0, 0);
            panelMaskedTextBox1.Size = new Size(78, 23);
            panelMaskedTextBox1.TabIndex = 15;
            // 
            // panelTextBox1
            // 
            panelTextBox1.BackColor = Color.FromArgb(25, 27, 28);
            panelTextBox1.BorderStyle = BorderStyle.FixedSingle;
            panelTextBox1.Controls.Add(textBox1);
            panelTextBox1.Location = new Point(12, 335);
            panelTextBox1.Name = "panelTextBox1";
            panelTextBox1.Padding = new Padding(4, 3, 0, 0);
            panelTextBox1.Size = new Size(433, 23);
            panelTextBox1.TabIndex = 16;
            // 
            // customButton1
            // 
            customButton1.BackColor = Color.FromArgb(25, 27, 28);
            customButton1.BorderColor = Color.FromArgb(25, 27, 28);
            customButton1.BorderSize = 1;
            customButton1.FlatAppearance.BorderSize = 0;
            customButton1.FlatAppearance.MouseDownBackColor = Color.FromArgb(25, 27, 28);
            customButton1.FlatAppearance.MouseOverBackColor = Color.FromArgb(35, 35, 35);
            customButton1.FlatStyle = FlatStyle.Flat;
            customButton1.ForeColor = Color.White;
            customButton1.Location = new Point(12, 304);
            customButton1.Name = "customButton1";
            customButton1.Size = new Size(75, 23);
            customButton1.TabIndex = 17;
            customButton1.Text = "Connect";
            customButton1.UseVisualStyleBackColor = false;
            customButton1.Click += customButton1_Click;
            // 
            // customButton2
            // 
            customButton2.BackColor = Color.FromArgb(25, 27, 28);
            customButton2.BorderColor = Color.FromArgb(25, 27, 28);
            customButton2.BorderSize = 1;
            customButton2.FlatAppearance.BorderSize = 0;
            customButton2.FlatAppearance.MouseDownBackColor = Color.FromArgb(25, 27, 28);
            customButton2.FlatAppearance.MouseOverBackColor = Color.FromArgb(35, 35, 35);
            customButton2.FlatStyle = FlatStyle.Flat;
            customButton2.ForeColor = Color.White;
            customButton2.Location = new Point(93, 304);
            customButton2.Name = "customButton2";
            customButton2.Size = new Size(75, 23);
            customButton2.TabIndex = 18;
            customButton2.Text = "Run";
            customButton2.UseVisualStyleBackColor = false;
            customButton2.Click += customButton2_Click;
            // 
            // customButton3
            // 
            customButton3.BackColor = Color.FromArgb(25, 27, 28);
            customButton3.BorderColor = Color.FromArgb(25, 27, 28);
            customButton3.BorderSize = 1;
            customButton3.FlatAppearance.BorderSize = 0;
            customButton3.FlatAppearance.MouseDownBackColor = Color.FromArgb(25, 27, 28);
            customButton3.FlatAppearance.MouseOverBackColor = Color.FromArgb(35, 35, 35);
            customButton3.FlatStyle = FlatStyle.Flat;
            customButton3.ForeColor = Color.White;
            customButton3.Location = new Point(451, 304);
            customButton3.Name = "customButton3";
            customButton3.Size = new Size(109, 23);
            customButton3.TabIndex = 19;
            customButton3.Text = "Disconnect";
            customButton3.UseVisualStyleBackColor = false;
            customButton3.Click += customButton3_Click;
            // 
            // customButton4
            // 
            customButton4.BackColor = Color.FromArgb(25, 27, 28);
            customButton4.BorderColor = Color.FromArgb(25, 27, 28);
            customButton4.BorderSize = 1;
            customButton4.FlatAppearance.BorderSize = 0;
            customButton4.FlatAppearance.MouseDownBackColor = Color.FromArgb(25, 27, 28);
            customButton4.FlatAppearance.MouseOverBackColor = Color.FromArgb(35, 35, 35);
            customButton4.FlatStyle = FlatStyle.Flat;
            customButton4.ForeColor = Color.White;
            customButton4.Location = new Point(451, 335);
            customButton4.Name = "customButton4";
            customButton4.Size = new Size(109, 23);
            customButton4.TabIndex = 20;
            customButton4.Text = "Run command";
            customButton4.UseVisualStyleBackColor = false;
            customButton4.Click += customButton4_Click;
            // 
            // panelDownloader
            // 
            panelDownloader.Controls.Add(labelDownload);
            panelDownloader.Controls.Add(progressBar1);
            panelDownloader.Location = new Point(12, 12);
            panelDownloader.Name = "panelDownloader";
            panelDownloader.Size = new Size(548, 346);
            panelDownloader.TabIndex = 21;
            panelDownloader.Visible = false;
            // 
            // labelDownload
            // 
            labelDownload.AutoSize = true;
            labelDownload.ForeColor = Color.White;
            labelDownload.Location = new Point(212, 143);
            labelDownload.Name = "labelDownload";
            labelDownload.Size = new Size(125, 15);
            labelDownload.TabIndex = 1;
            labelDownload.Text = "Downloading Scrcpy...";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(0, 162);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(548, 23);
            progressBar1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(572, 370);
            Controls.Add(richTextBox1);
            Controls.Add(customButton4);
            Controls.Add(customButton3);
            Controls.Add(customButton2);
            Controls.Add(customButton1);
            Controls.Add(panelTextBox1);
            Controls.Add(panelMaskedTextBox1);
            Controls.Add(label1);
            Controls.Add(checkBox1);
            Controls.Add(panelDownloader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "scrcpy UI";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            contextMenuStrip1.ResumeLayout(false);
            panelMaskedTextBox1.ResumeLayout(false);
            panelMaskedTextBox1.PerformLayout();
            panelTextBox1.ResumeLayout(false);
            panelTextBox1.PerformLayout();
            panelDownloader.ResumeLayout(false);
            panelDownloader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CheckBox checkBox1;
        private MaskedTextBox maskedTextBox1;
        private Label label1;
        private TextBox textBox1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem clearToolStripMenuItem;
        private Panel panelMaskedTextBox1;
        private Panel panelTextBox1;
        private Helpers.CustomButton customButton1;
        private Helpers.CustomButton customButton2;
        private Helpers.CustomButton customButton3;
        private Helpers.CustomButton customButton4;
        public ProgressBar progressBar1;
        public Label labelDownload;
        public RichTextBox richTextBox1;
        public Panel panelDownloader;
    }
}
