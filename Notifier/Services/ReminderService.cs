using System.Text.Json;
using Notifier.Models;

namespace Notifier.Services;

/// <summary>
/// 当日已提醒状态持久化模型
/// </summary>
public class DailyState
{
    /// <summary>
    /// 记录日期
    /// </summary>
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Today);

    /// <summary>
    /// 今日已经触发过的提醒 ID 集合
    /// </summary>
    public HashSet<Guid> TriggeredReminderIds { get; set; } = new();
}

/// <summary>
/// 负责定时轮询、延迟补提醒、每日去重的提醒调度服务
/// </summary>
public class ReminderService : IDisposable
{
    private readonly System.Windows.Forms.Timer _timer;
    private readonly string _stateFilePath;
    private DailyState _dailyState;
    private AppSettings _settings;

    /// <summary>
    /// 提醒触发事件
    /// </summary>
    public event Action<ReminderItem>? OnReminderTriggered;

    public ReminderService(AppSettings settings)
    {
        _settings = settings;

        var appDataFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Notifier"
        );
        _stateFilePath = Path.Combine(appDataFolder, "daily_state.json");

        _dailyState = LoadDailyState();

        _timer = new System.Windows.Forms.Timer
        {
            Interval = 5000 // 每 5 秒检查一次
        };
        _timer.Tick += (s, e) => CheckReminders();
    }

    /// <summary>
    /// 启动提醒服务定时器并执行一次即时检查
    /// </summary>
    public void Start()
    {
        _timer.Start();
        // 启动时立即执行一次检查（支持开机延迟补提醒）
        CheckReminders();
    }

    /// <summary>
    /// 停止定时器
    /// </summary>
    public void Stop()
    {
        _timer.Stop();
    }

    /// <summary>
    /// 更新当前配置引用
    /// </summary>
    public void UpdateSettings(AppSettings settings)
    {
        _settings = settings;
        CheckReminders();
    }

    /// <summary>
    /// 检查是否有需要触发的提醒（支持到点提醒与开机延迟补提醒）
    /// </summary>
    private void CheckReminders()
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        var nowTime = TimeOnly.FromDateTime(DateTime.Now);

        // 如果跨天了，重置今日触发状态
        if (_dailyState.Date != today)
        {
            _dailyState.Date = today;
            _dailyState.TriggeredReminderIds.Clear();
            SaveDailyState();
        }

        if (_settings.Reminders == null || _settings.Reminders.Count == 0)
        {
            return;
        }

        foreach (var item in _settings.Reminders)
        {
            if (!item.Enabled) continue;

            // 如果今天尚未触发，且当前时间已经到达或超过设定时间
            if (!_dailyState.TriggeredReminderIds.Contains(item.Id) && nowTime >= item.Time)
            {
                // 标记为已触发并持久化记录，防止重启后再次重复触发
                _dailyState.TriggeredReminderIds.Add(item.Id);
                SaveDailyState();

                // 触发事件通知
                OnReminderTriggered?.Invoke(item);
            }
        }
    }

    /// <summary>
    /// 加载当日触发状态
    /// </summary>
    private DailyState LoadDailyState()
    {
        try
        {
            if (File.Exists(_stateFilePath))
            {
                var json = File.ReadAllText(_stateFilePath);
                var state = JsonSerializer.Deserialize<DailyState>(json);
                if (state != null)
                {
                    var today = DateOnly.FromDateTime(DateTime.Today);
                    if (state.Date == today)
                    {
                        return state;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"加载今日状态失败: {ex.Message}");
        }

        return new DailyState { Date = DateOnly.FromDateTime(DateTime.Today) };
    }

    /// <summary>
    /// 保存当日触发状态
    /// </summary>
    private void SaveDailyState()
    {
        try
        {
            var json = JsonSerializer.Serialize(_dailyState);
            File.WriteAllText(_stateFilePath, json);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"保存今日状态失败: {ex.Message}");
        }
    }

    public void Dispose()
    {
        _timer.Stop();
        _timer.Dispose();
    }
}
