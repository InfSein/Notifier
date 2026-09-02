namespace Notifier.Models;

/// <summary>
/// 全局应用程序配置模型
/// </summary>
public class AppSettings
{
    /// <summary>
    /// 是否开机自动启动
    /// </summary>
    public bool AutoStart { get; set; } = false;

    /// <summary>
    /// 是否静默启动（开机启动时不显示主界面，直接最小化至托盘）
    /// </summary>
    public bool SilentStart { get; set; } = false;

    /// <summary>
    /// 提醒事务列表
    /// </summary>
    public List<ReminderItem> Reminders { get; set; } = new()
    {
        new ReminderItem
        {
            Time = new TimeOnly(8, 45),
            Text = "打卡（上班）",
            Enabled = true
        },
        new ReminderItem
        {
            Time = new TimeOnly(17, 59),
            Text = "打卡（下班）",
            Enabled = true
        }
    };
}
