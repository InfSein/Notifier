namespace Notifier.Models;

/// <summary>
/// 提醒事务模型
/// </summary>
public class ReminderItem
{
    /// <summary>
    /// 唯一标识
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// 提醒时间（小时:分钟）
    /// </summary>
    public TimeOnly Time { get; set; }

    /// <summary>
    /// 提醒文本内容
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// 是否启用此项提醒
    /// </summary>
    public bool Enabled { get; set; } = true;
}
