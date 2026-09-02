using Microsoft.Win32;

namespace Notifier.Services;

/// <summary>
/// 负责管理 Windows 开机启动注册表项
/// </summary>
public class StartupService
{
    private const string RunRegistryKey = @"Software\Microsoft\Windows\CurrentVersion\Run";
    private const string AppName = "NotifierApp";

    /// <summary>
    /// 设置开机启动状态
    /// </summary>
    /// <param name="enable">是否开机自启</param>
    /// <param name="silent">是否静默启动</param>
    public void SetStartup(bool enable, bool silent)
    {
        try
        {
            using var key = Registry.CurrentUser.OpenSubKey(RunRegistryKey, true);
            if (key == null) return;

            if (enable)
            {
                var exePath = Environment.ProcessPath ?? Application.ExecutablePath;
                var command = silent ? $"\"{exePath}\" --silent" : $"\"{exePath}\"";
                key.SetValue(AppName, command);
            }
            else
            {
                if (key.GetValue(AppName) != null)
                {
                    key.DeleteValue(AppName, false);
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"更新开机启动注册表失败: {ex.Message}");
        }
    }

    /// <summary>
    /// 查询当前注册表是否已配置开机自启
    /// </summary>
    public bool IsStartupEnabled()
    {
        try
        {
            using var key = Registry.CurrentUser.OpenSubKey(RunRegistryKey, false);
            return key?.GetValue(AppName) != null;
        }
        catch
        {
            return false;
        }
    }
}
