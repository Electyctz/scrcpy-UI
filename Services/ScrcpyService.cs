using System.Diagnostics;
using Newtonsoft.Json.Linq;
using scrcpy_UI.Helpers;

namespace scrcpy_UI.Services
{
    public class ScrcpyService
    {
        private readonly Form1 _form;
        private Process scrcpyProcess;
        private string workingDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\scrcpy";
        public string scrcpyLatest;
        public string scrcpyCurrent;

        public event Action<string, Color> OnTextReceived;
        public event Action<int> ProgressChanged;

        public ScrcpyService(Form1 form)
        {
            _form = form;
        }

        public async Task RunCommandAsync(string command, string arguments = "", bool isScrcpy = false)
        {
            try
            {
                string filePath = isScrcpy
                    ? Path.Combine(workingDirectory, "scrcpy.exe")
                    : "cmd.exe";

                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = filePath,
                        Arguments = isScrcpy ? arguments : $"/C {command}",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        WorkingDirectory = workingDirectory
                    }
                };

                if (isScrcpy)
                {
                    scrcpyProcess = process;
                }

                process.Start();

                process.OutputDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        OnTextReceived?.Invoke("- " + e.Data + Environment.NewLine, isScrcpy ? Color.Aqua : Color.White);
                    }
                };

                process.ErrorDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        OnTextReceived?.Invoke("- " + e.Data + Environment.NewLine, Color.Red);
                    }
                };

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                await process.WaitForExitAsync();
            }
            catch (Exception ex)
            {
                OnTextReceived?.Invoke("- Error: " + ex.Message + Environment.NewLine, Color.Red);
            }
        }

        public async void VersionCheckAsync()
        {
            if (File.Exists(workingDirectory + @"\scrcpy.exe"))
            {
                using HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "C# App");

                string apiUrl = "https://api.github.com/repos/Genymobile/scrcpy/releases/latest";
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (!response.IsSuccessStatusCode)
                {
                    OnTextReceived?.Invoke($"Failed to fetch Scrcpy version info: {response.ReasonPhrase}\n", Color.Red);
                    return;
                }

                string json = await response.Content.ReadAsStringAsync();
                JObject releaseInfo = JObject.Parse(json);

                string latestVersion = releaseInfo["tag_name"]?.ToString();
                if (latestVersion != null)
                {
                    scrcpyLatest = latestVersion;

                    if (scrcpyCurrent != scrcpyLatest && (scrcpyLatest != "" && scrcpyLatest != null))
                    {
                        var result = MessageBox.Show("A new version of Scrcpy is available! Download the new version?",
                                                     "New version available!",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            await ScrcpyDownloadAsync();
                        }
                        if (result == DialogResult.No)
                        {
                            OnTextReceived?.Invoke("- Skipped update.\n", Color.White);
                        }
                    }
                    else
                    {
                        OnTextReceived?.Invoke("- You're up-to-date!\n", Color.Green);
                    }
                }
            }
            else
            {
                var result = MessageBox.Show("Scrcpy not detected, download application?",
                                             "Missing Scrcpy!",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    await ScrcpyDownloadAsync();
                }
                if (result == DialogResult.No)
                {
                    OnTextReceived?.Invoke("- Skipped download.\n", Color.White);
                }
            }
        }

        public async Task ScrcpyDownloadAsync()
        {
            string targetFilePattern = "scrcpy-win64";
            string outputDirectory = AppDomain.CurrentDomain.BaseDirectory;

            try
            {
                using HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "C# App");

                string apiUrl = "https://api.github.com/repos/Genymobile/scrcpy/releases/latest";
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (!response.IsSuccessStatusCode)
                {
                    OnTextReceived?.Invoke($"Error fetching release info: {response.ReasonPhrase}\n", Color.Red);
                    return;
                }

                string json = await response.Content.ReadAsStringAsync();
                JObject releaseInfo = JObject.Parse(json);

                scrcpyCurrent = releaseInfo["tag_name"]?.ToString();

                foreach (var asset in releaseInfo["assets"])
                {
                    string fileName = asset["name"]?.ToString();

                    if (fileName != null && fileName.StartsWith(targetFilePattern) && fileName.EndsWith(".zip"))
                    {
                        string downloadUrl = asset["browser_download_url"]?.ToString();
                        string outputPath = Path.Combine(outputDirectory, fileName);

                        using HttpResponseMessage fileResponse = await client.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead);
                        fileResponse.EnsureSuccessStatusCode();

                        long? totalBytes = fileResponse.Content.Headers.ContentLength;

                        using (Stream contentStream = await fileResponse.Content.ReadAsStreamAsync(),
                                      fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            byte[] buffer = new byte[8192];
                            int bytesRead;
                            long totalBytesRead = 0;

                            _form.downloadPanel.Invoke(new Action(() => { _form.downloadPanel.Visible = true; }));
                            _form.downloadPanel.Invoke(new Action(() => { _form.downloadPanel.BringToFront(); }));

                            while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, bytesRead);
                                totalBytesRead += bytesRead;

                                if (totalBytes.HasValue)
                                {
                                    int progress = (int)((totalBytesRead * 100) / totalBytes.Value);

                                    _form.downloadLabel.Invoke(new Action(() => { _form.downloadLabel.Text = "Downloading Scrcpy..."; }));
                                    _form.downloadProgressBar.Invoke(new Action(() => { _form.downloadProgressBar.Value = progress; }));
                                }
                            }
                        }

                        _form.downloadLabel.Invoke(new Action(() => { _form.downloadLabel.Text = "Unzipping file..."; }));
                        var zipProgress = new Progress<int>(progress => _form.downloadProgressBar.Value = progress);
                        await HelperMethods.UnzipFileAsync(outputPath, outputDirectory, "scrcpy", zipProgress);

                        File.Delete(outputPath);
                        _form.downloadPanel.Invoke(new Action(() => { _form.downloadPanel.Visible = false; }));
                        OnTextReceived?.Invoke($"- Scrcpy installed to {outputDirectory}scrcpy!\n", Color.Green);

                        return;
                    }
                }

                OnTextReceived?.Invoke("- Error downloading Scrcpy: Target file not found in the latest release.\n", Color.Red);
            }
            catch (Exception ex)
            {
                OnTextReceived?.Invoke($"- Error downloading Scrcpy: {ex.Message}\n", Color.Red);
                Console.WriteLine();
            }
        }

        public void TerminateScrcpyProcess()
        {
            if (scrcpyProcess != null && !scrcpyProcess.HasExited)
            {
                scrcpyProcess.Kill();
                scrcpyProcess.Dispose();
                scrcpyProcess = null;
            }
        }
    }
}
