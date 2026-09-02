using System.Text.Json;
using Notifier.Models;

namespace Notifier.Services;

/// <summary>
/// 负责配置文件的加载与持久化存储服务
/// </summary>
public class SettingsService
{
    private readonly string _filePath;

    public SettingsService()
    {
        var appDataFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Notifier"
        );

        if (!Directory.Exists(appDataFolder))
        {
            Directory.CreateDirectory(appDataFolder);
        }

        _filePath = Path.Combine(appDataFolder, "settings.json");
    }

    /// <summary>
    /// 加载配置，若文件不存在或读取失败则返回默认配置
    /// </summary>
    public AppSettings LoadSettings()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                var settings = JsonSerializer.Deserialize<AppSettings>(json);
                if (settings != null)
                {
                    return settings;
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"加载配置文件失败: {ex.Message}");
        }

        // 默认配置并保存一次
        var defaultSettings = new AppSettings();
        SaveSettings(defaultSettings);
        return defaultSettings;
    }

    /// <summary>
    /// 保存配置到 JSON 文件
    /// </summary>
    public void SaveSettings(AppSettings settings)
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(settings, options);
            File.WriteAllText(_filePath, json);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"保存配置文件失败: {ex.Message}");
        }
    }
}
