using System.IO.Compression;

namespace scrcpy_UI.Helpers
{
    internal class HelperMethods
    {
        public static async Task UnzipFile(string zipFilePath, string extractPath, string renamedFolderName, IProgress<int> progress = null)
        {
            await Task.Run(() =>
            {
                using (ZipArchive archive = ZipFile.OpenRead(zipFilePath))
                {
                    string rootFolderName = archive.Entries
                                            .Select(e => e.FullName.Split('/')[0])
                                            .FirstOrDefault(folder => !string.IsNullOrEmpty(folder));

                    if (string.IsNullOrEmpty(rootFolderName))
                    {
                        throw new InvalidOperationException("The zip file does not contain a root folder.");
                    }

                    string tempExtractPath = Path.Combine(extractPath, rootFolderName);

                    int totalEntries = archive.Entries.Count;
                    int processedEntries = 0;

                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (string.IsNullOrEmpty(entry.Name)) continue;

                        string destinationPath = Path.Combine(extractPath, entry.FullName);

                        Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
                        entry.ExtractToFile(destinationPath, overwrite: true);

                        processedEntries++;
                        progress?.Report((processedEntries * 100) / totalEntries);
                    }

                    string renamedFolderPath = Path.Combine(extractPath, renamedFolderName);
                    if (Directory.Exists(renamedFolderPath))
                    {
                        try
                        {
                            Directory.Delete(renamedFolderPath, true);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Unable to delete {renamedFolderPath}\nError: {ex.Message}",
                                            "Error",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                    }

                    Directory.Move(tempExtractPath, renamedFolderPath);
                }
            });
        }


        public static void AppendTextToRichTextBox(RichTextBox richTextBox, string text, Color color)
        {
            try
            {
                richTextBox.Invoke(new Action(() =>
                {
                    richTextBox.SelectionStart = richTextBox.TextLength;
                    richTextBox.SelectionLength = 0;

                    richTextBox.SelectionColor = color;
                    richTextBox.AppendText(text);
                    richTextBox.SelectionColor = richTextBox.ForeColor;
                    richTextBox.ScrollToCaret();
                }));
            }
            catch (Exception ex) { }
        }
    }
}
