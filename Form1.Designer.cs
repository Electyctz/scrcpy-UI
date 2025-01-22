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
            consoleTextBox = new RichTextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            clearToolStripMenuItem = new ToolStripMenuItem();
            screenCheckBox = new CheckBox();
            ipTextBox = new MaskedTextBox();
            ipLabel = new Label();
            commandTextBox = new TextBox();
            panelMaskedTextBox1 = new Panel();
            panelTextBox1 = new Panel();
            connectButton = new Helpers.CustomButton();
            runButton = new Helpers.CustomButton();
            disconnectButton = new Helpers.CustomButton();
            commandButton = new Helpers.CustomButton();
            downloadPanel = new Panel();
            downloadLabel = new Label();
            downloadProgressBar = new ProgressBar();
            contextMenuStrip1.SuspendLayout();
            panelMaskedTextBox1.SuspendLayout();
            panelTextBox1.SuspendLayout();
            downloadPanel.SuspendLayout();
            SuspendLayout();
            // 
            // consoleTextBox
            // 
            consoleTextBox.BackColor = Color.Black;
            consoleTextBox.BorderStyle = BorderStyle.None;
            consoleTextBox.ContextMenuStrip = contextMenuStrip1;
            consoleTextBox.ForeColor = Color.White;
            consoleTextBox.Location = new Point(12, 12);
            consoleTextBox.Name = "consoleTextBox";
            consoleTextBox.ReadOnly = true;
            consoleTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            consoleTextBox.Size = new Size(548, 284);
            consoleTextBox.TabIndex = 4;
            consoleTextBox.Text = "";
            consoleTextBox.LinkClicked += richTextBox1_LinkClicked;
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
            // screenCheckBox
            // 
            screenCheckBox.AutoSize = true;
            screenCheckBox.ForeColor = Color.White;
            screenCheckBox.Location = new Point(174, 307);
            screenCheckBox.Name = "screenCheckBox";
            screenCheckBox.Size = new Size(79, 19);
            screenCheckBox.TabIndex = 5;
            screenCheckBox.Text = "Screen off";
            screenCheckBox.UseVisualStyleBackColor = true;
            // 
            // ipTextBox
            // 
            ipTextBox.BackColor = Color.FromArgb(25, 27, 28);
            ipTextBox.BorderStyle = BorderStyle.None;
            ipTextBox.Dock = DockStyle.Fill;
            ipTextBox.ForeColor = Color.White;
            ipTextBox.Location = new Point(4, 3);
            ipTextBox.Mask = "\\1\\9\\2\\.\\1\\6\\8\\.\\1\\.###";
            ipTextBox.Name = "ipTextBox";
            ipTextBox.PromptChar = '-';
            ipTextBox.Size = new Size(72, 16);
            ipTextBox.TabIndex = 6;
            // 
            // ipLabel
            // 
            ipLabel.AutoSize = true;
            ipLabel.BackColor = Color.Black;
            ipLabel.ForeColor = Color.White;
            ipLabel.Location = new Point(303, 308);
            ipLabel.Name = "ipLabel";
            ipLabel.Size = new Size(58, 15);
            ipLabel.TabIndex = 7;
            ipLabel.Text = "Device IP:";
            // 
            // commandTextBox
            // 
            commandTextBox.BackColor = Color.FromArgb(25, 27, 28);
            commandTextBox.BorderStyle = BorderStyle.None;
            commandTextBox.Dock = DockStyle.Fill;
            commandTextBox.ForeColor = Color.White;
            commandTextBox.Location = new Point(4, 3);
            commandTextBox.Name = "commandTextBox";
            commandTextBox.PlaceholderText = "Custom command...";
            commandTextBox.Size = new Size(427, 16);
            commandTextBox.TabIndex = 10;
            // 
            // panelMaskedTextBox1
            // 
            panelMaskedTextBox1.BackColor = Color.FromArgb(25, 27, 28);
            panelMaskedTextBox1.BorderStyle = BorderStyle.FixedSingle;
            panelMaskedTextBox1.Controls.Add(ipTextBox);
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
            panelTextBox1.Controls.Add(commandTextBox);
            panelTextBox1.Location = new Point(12, 335);
            panelTextBox1.Name = "panelTextBox1";
            panelTextBox1.Padding = new Padding(4, 3, 0, 0);
            panelTextBox1.Size = new Size(433, 23);
            panelTextBox1.TabIndex = 16;
            // 
            // connectButton
            // 
            connectButton.BackColor = Color.FromArgb(25, 27, 28);
            connectButton.BorderColor = Color.FromArgb(25, 27, 28);
            connectButton.BorderSize = 1;
            connectButton.FlatAppearance.BorderSize = 0;
            connectButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(25, 27, 28);
            connectButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(35, 35, 35);
            connectButton.FlatStyle = FlatStyle.Flat;
            connectButton.ForeColor = Color.White;
            connectButton.Location = new Point(12, 304);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(75, 23);
            connectButton.TabIndex = 17;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = false;
            connectButton.Click += connectButton_Click;
            // 
            // runButton
            // 
            runButton.BackColor = Color.FromArgb(25, 27, 28);
            runButton.BorderColor = Color.FromArgb(25, 27, 28);
            runButton.BorderSize = 1;
            runButton.FlatAppearance.BorderSize = 0;
            runButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(25, 27, 28);
            runButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(35, 35, 35);
            runButton.FlatStyle = FlatStyle.Flat;
            runButton.ForeColor = Color.White;
            runButton.Location = new Point(93, 304);
            runButton.Name = "runButton";
            runButton.Size = new Size(75, 23);
            runButton.TabIndex = 18;
            runButton.Text = "Run";
            runButton.UseVisualStyleBackColor = false;
            runButton.Click += runButton_Click;
            // 
            // disconnectButton
            // 
            disconnectButton.BackColor = Color.FromArgb(25, 27, 28);
            disconnectButton.BorderColor = Color.FromArgb(25, 27, 28);
            disconnectButton.BorderSize = 1;
            disconnectButton.FlatAppearance.BorderSize = 0;
            disconnectButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(25, 27, 28);
            disconnectButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(35, 35, 35);
            disconnectButton.FlatStyle = FlatStyle.Flat;
            disconnectButton.ForeColor = Color.White;
            disconnectButton.Location = new Point(451, 304);
            disconnectButton.Name = "disconnectButton";
            disconnectButton.Size = new Size(109, 23);
            disconnectButton.TabIndex = 19;
            disconnectButton.Text = "Disconnect";
            disconnectButton.UseVisualStyleBackColor = false;
            disconnectButton.Click += disconnectButton_Click;
            // 
            // commandButton
            // 
            commandButton.BackColor = Color.FromArgb(25, 27, 28);
            commandButton.BorderColor = Color.FromArgb(25, 27, 28);
            commandButton.BorderSize = 1;
            commandButton.FlatAppearance.BorderSize = 0;
            commandButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(25, 27, 28);
            commandButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(35, 35, 35);
            commandButton.FlatStyle = FlatStyle.Flat;
            commandButton.ForeColor = Color.White;
            commandButton.Location = new Point(451, 335);
            commandButton.Name = "commandButton";
            commandButton.Size = new Size(109, 23);
            commandButton.TabIndex = 20;
            commandButton.Text = "Run command";
            commandButton.UseVisualStyleBackColor = false;
            commandButton.Click += commandButton_Click;
            // 
            // downloadPanel
            // 
            downloadPanel.Controls.Add(downloadLabel);
            downloadPanel.Controls.Add(downloadProgressBar);
            downloadPanel.Location = new Point(12, 12);
            downloadPanel.Name = "downloadPanel";
            downloadPanel.Size = new Size(548, 346);
            downloadPanel.TabIndex = 21;
            downloadPanel.Visible = false;
            // 
            // downloadLabel
            // 
            downloadLabel.AutoSize = true;
            downloadLabel.ForeColor = Color.White;
            downloadLabel.Location = new Point(212, 143);
            downloadLabel.Name = "downloadLabel";
            downloadLabel.Size = new Size(125, 15);
            downloadLabel.TabIndex = 1;
            downloadLabel.Text = "Downloading Scrcpy...";
            // 
            // downloadProgressBar
            // 
            downloadProgressBar.Location = new Point(0, 162);
            downloadProgressBar.Name = "downloadProgressBar";
            downloadProgressBar.Size = new Size(548, 23);
            downloadProgressBar.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(572, 370);
            Controls.Add(consoleTextBox);
            Controls.Add(commandButton);
            Controls.Add(disconnectButton);
            Controls.Add(runButton);
            Controls.Add(connectButton);
            Controls.Add(panelTextBox1);
            Controls.Add(panelMaskedTextBox1);
            Controls.Add(ipLabel);
            Controls.Add(screenCheckBox);
            Controls.Add(downloadPanel);
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
            downloadPanel.ResumeLayout(false);
            downloadPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CheckBox screenCheckBox;
        private MaskedTextBox ipTextBox;
        private Label ipLabel;
        private TextBox commandTextBox;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem clearToolStripMenuItem;
        private Panel panelMaskedTextBox1;
        private Panel panelTextBox1;
        private Helpers.CustomButton connectButton;
        private Helpers.CustomButton runButton;
        private Helpers.CustomButton disconnectButton;
        private Helpers.CustomButton commandButton;
        public ProgressBar downloadProgressBar;
        public Label downloadLabel;
        public RichTextBox consoleTextBox;
        public Panel downloadPanel;
    }
}
