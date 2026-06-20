using Newtonsoft.Json;
using TShockAPI;

namespace PluginTemplate;

public class Config
{
    private static readonly string configPath = Path.Combine(TShock.SavePath, "TemplatePlugin.json");

    public bool sampleBooleanSetting = false;
    public int sampleIntSetting = 5;

    public static Config Reload()
    {
        Config? config = null;

        if (File.Exists(configPath))
        {
            config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(configPath));
        }

        if (config == null)
        {
            config = new Config();
            File.WriteAllText(configPath, JsonConvert.SerializeObject(config, Formatting.Indented));
        }

        return config;
    }
}
