using System.Diagnostics;
using scrcpy_UI.Helpers;
using scrcpy_UI.Models;

namespace scrcpy_UI
{
    public partial class Form1 : Form
    {
        private Services.ScrcpyService scrcpyService;
        private Services.ConfigService configService;
        private string workingDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\scrcpy";

        public Form1()
        {
            InitializeComponent();
            scrcpyService = new Services.ScrcpyService(this);
            configService = new Services.ConfigService();

            scrcpyService.OnTextReceived += ScrcpyService_OnTextReceived;
            configService.OnTextReceived += ConfigService_OnTextReceived;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var config = await configService.LoadConfig();

            if (config != null && config.Count > 0)
            {
                checkBox1.Checked = config[0].ScreenOff;
                maskedTextBox1.Text = config[0].DeviceIP;
                scrcpyService.scrcpyCurrent = config[0].ScrcpyVersion;
            }

            HelperMethods.AppendTextToRichTextBox(richTextBox1, "- Version check...\n", Color.White);
            scrcpyService.ScrcpyVersionCheck();
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var config = new ConfigData()
            {
                ScreenOff = checkBox1.Checked,
                DeviceIP = maskedTextBox1.Text,
                ScrcpyVersion = scrcpyService.scrcpyCurrent
            };

            await configService.SaveConfig(config);

            scrcpyService.TerminateScrcpyProcess();
            await scrcpyService.RunCommandAsync("adb disconnect");

            string[] processNames = { "adb", "scrcpy" };

            foreach (string processName in processNames)
            {
                Process[] processes = Process.GetProcessesByName(processName);

                if (processes.Length > 0)
                {
                    foreach (Process process in processes)
                    {
                        try
                        {
                            process.Kill();
                            process.WaitForExit();
                        }
                        catch (Exception ex) { }
                    }
                }
            }
        }

        private void ScrcpyService_OnTextReceived(string text, Color color)
        {
            HelperMethods.AppendTextToRichTextBox(richTextBox1, text, color);
        }

        private void ConfigService_OnTextReceived(string text, Color color)
        {
            HelperMethods.AppendTextToRichTextBox(richTextBox1, text, color);
        }

        private async void customButton1_Click(object sender, EventArgs e)
        {
            if (!File.Exists(workingDirectory + @"\scrcpy.exe"))
            {
                HelperMethods.AppendTextToRichTextBox(richTextBox1, "- Scrcpy not installed!\n", Color.Red);
                scrcpyService.ScrcpyVersionCheck();
                return;
            }
            await scrcpyService.RunCommandAsync("adb tcpip 5555");
            await scrcpyService.RunCommandAsync("adb connect " + maskedTextBox1.Text + ":5555");
        }

        private async void customButton2_Click(object sender, EventArgs e)
        {
            if (!File.Exists(workingDirectory + @"\scrcpy.exe"))
            {
                HelperMethods.AppendTextToRichTextBox(richTextBox1, "- Scrcpy not installed!\n", Color.Red);
                scrcpyService.ScrcpyVersionCheck();
                return;
            }
            await scrcpyService.RunCommandAsync("", (checkBox1.Checked ? "-S " : "") + "--pause-on-exit=if-error", true);
        }

        private async void customButton3_Click(object sender, EventArgs e)
        {
            if (!File.Exists(workingDirectory + @"\scrcpy.exe"))
            {
                HelperMethods.AppendTextToRichTextBox(richTextBox1, "- Scrcpy not installed!\n", Color.Red);
                scrcpyService.ScrcpyVersionCheck();
                return;
            }
            await scrcpyService.RunCommandAsync("adb disconnect");
            scrcpyService.TerminateScrcpyProcess();
        }

        private async void customButton4_Click(object sender, EventArgs e)
        {
            if (!File.Exists(workingDirectory + @"\scrcpy.exe"))
            {
                HelperMethods.AppendTextToRichTextBox(richTextBox1, "- Scrcpy not installed!\n", Color.Red);
                scrcpyService.ScrcpyVersionCheck();
                return;
            }
            await scrcpyService.RunCommandAsync(textBox1.Text);
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            var result = MessageBox.Show($"Do you want to open this website?\n{e.LinkText}",
                                         "Open Website",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = e.LinkText,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    HelperMethods.AppendTextToRichTextBox(richTextBox1, $"- Failed to open link: {ex.Message}\n", Color.Red);
                }
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }
}
