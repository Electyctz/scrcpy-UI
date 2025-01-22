using Newtonsoft.Json;
using scrcpy_UI.Models;

namespace scrcpy_UI.Services
{
    public class ConfigService
    {
        private string configFilePath = Path.Combine(Environment.CurrentDirectory, "config.json");
        public event Action<string, Color> OnTextReceived;

        public async Task<List<ConfigData>> LoadConfigAsync()
        {
            try
            {
                if (File.Exists(configFilePath))
                {
                    string json = await File.ReadAllTextAsync(configFilePath);
                    return JsonConvert.DeserializeObject<List<ConfigData>>(json);
                }
                else
                {
                    return null;
                }
            }
            catch (JsonSerializationException ex)
            {
                OnTextReceived?.Invoke($"- Error reading config: {ex.Message}", Color.Red);
                return null;
            }
        }

        public async Task SaveConfigAsync(ConfigData config)
        {
            var configList = new List<ConfigData> { config };

            try
            {
                string json = JsonConvert.SerializeObject(configList, Formatting.Indented);

                await File.WriteAllTextAsync(configFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving config: {ex.Message}",
                                "Error!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
