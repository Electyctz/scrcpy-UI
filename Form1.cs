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
            var config = await configService.LoadConfigAsync();

            if (config != null && config.Count > 0)
            {
                screenCheckBox.Checked = config[0].ScreenOff;
                ipTextBox.Text = config[0].DeviceIP;
                scrcpyService.scrcpyCurrent = config[0].ScrcpyVersion;
            }

            HelperMethods.SendMessage(consoleTextBox, "- Version check...\n", Color.White);
            scrcpyService.VersionCheckAsync();
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var config = new ConfigData()
            {
                ScreenOff = screenCheckBox.Checked,
                DeviceIP = ipTextBox.Text,
                ScrcpyVersion = scrcpyService.scrcpyCurrent
            };

            await configService.SaveConfigAsync(config);

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
            HelperMethods.SendMessage(consoleTextBox, text, color);
        }

        private void ConfigService_OnTextReceived(string text, Color color)
        {
            HelperMethods.SendMessage(consoleTextBox, text, color);
        }

        private async void connectButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(workingDirectory + @"\scrcpy.exe"))
            {
                HelperMethods.SendMessage(consoleTextBox, "- Scrcpy not installed!\n", Color.Red);
                scrcpyService.VersionCheckAsync();
                return;
            }
            await scrcpyService.RunCommandAsync("adb tcpip 5555");
            await scrcpyService.RunCommandAsync("adb connect " + ipTextBox.Text + ":5555");
        }

        private async void runButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(workingDirectory + @"\scrcpy.exe"))
            {
                HelperMethods.SendMessage(consoleTextBox, "- Scrcpy not installed!\n", Color.Red);
                scrcpyService.VersionCheckAsync();
                return;
            }
            await scrcpyService.RunCommandAsync("", (screenCheckBox.Checked ? "-S " : "") + "--pause-on-exit=if-error", true);
        }

        private async void disconnectButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(workingDirectory + @"\scrcpy.exe"))
            {
                HelperMethods.SendMessage(consoleTextBox, "- Scrcpy not installed!\n", Color.Red);
                scrcpyService.VersionCheckAsync();
                return;
            }
            await scrcpyService.RunCommandAsync("adb disconnect");
            scrcpyService.TerminateScrcpyProcess();
        }

        private async void commandButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(workingDirectory + @"\scrcpy.exe"))
            {
                HelperMethods.SendMessage(consoleTextBox, "- Scrcpy not installed!\n", Color.Red);
                scrcpyService.VersionCheckAsync();
                return;
            }
            await scrcpyService.RunCommandAsync(commandTextBox.Text);
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
                    HelperMethods.SendMessage(consoleTextBox, $"- Failed to open link: {ex.Message}\n", Color.Red);
                }
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consoleTextBox.Clear();
        }
    }
}
