using Notifier.Models;
using Notifier.Services;

namespace Notifier.Forms;

/// <summary>
/// 主设置界面与托盘托管窗体
/// </summary>
public partial class MainForm : Form
{
    private readonly bool _startSilent;
    private bool _allowVisible;
    private bool _isExplicitExit;

    private readonly SettingsService _settingsService;
    private readonly StartupService _startupService;
    private readonly ReminderService _reminderService;
    private AppSettings _settings;

    public MainForm(bool startSilent = false)
    {
        _startSilent = startSilent;
        _allowVisible = !startSilent;

        _settingsService = new SettingsService();
        _startupService = new StartupService();
        _settings = _settingsService.LoadSettings();

        _reminderService = new ReminderService(_settings);
        _reminderService.OnReminderTriggered += HandleReminderTriggered;

        InitializeComponent();

        // 设置图标
        Icon = SystemIcons.Application;
        notifyIcon.Icon = SystemIcons.Application;
    }

    protected override void SetVisibleCore(bool value)
    {
        if (!_allowVisible)
        {
            value = false;
            if (!IsHandleCreated) CreateHandle();
        }
        base.SetVisibleCore(value);
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        // 绑定通用设置状态
        chkAutoStart.Checked = _settings.AutoStart;
        chkSilentStart.Checked = _settings.SilentStart;

        // 绑定列表数据
        RefreshReminderGrid();

        // 启动提醒服务
        _reminderService.Start();
    }

    /// <summary>
    /// 处理提醒触发弹窗
    /// </summary>
    private void HandleReminderTriggered(ReminderItem item)
    {
        if (InvokeRequired)
        {
            BeginInvoke(new Action(() => HandleReminderTriggered(item)));
            return;
        }

        var alert = new AlertForm(item);
        alert.Show();
        alert.BringToFront();
    }

    /// <summary>
    /// 刷新提醒事务表格
    /// </summary>
    private void RefreshReminderGrid()
    {
        dgvReminders.Rows.Clear();
        foreach (var item in _settings.Reminders.OrderBy(r => r.Time))
        {
            var rowIndex = dgvReminders.Rows.Add(
                item.Enabled,
                item.Time.ToString("HH:mm"),
                item.Text,
                "删除"
            );
            dgvReminders.Rows[rowIndex].Tag = item;
        }
    }

    private void chkAutoStart_CheckedChanged(object sender, EventArgs e)
    {
        _settings.AutoStart = chkAutoStart.Checked;
        _settingsService.SaveSettings(_settings);
        _startupService.SetStartup(_settings.AutoStart, _settings.SilentStart);
    }

    private void chkSilentStart_CheckedChanged(object sender, EventArgs e)
    {
        _settings.SilentStart = chkSilentStart.Checked;
        _settingsService.SaveSettings(_settings);
        if (_settings.AutoStart)
        {
            _startupService.SetStartup(_settings.AutoStart, _settings.SilentStart);
        }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        var text = txtText.Text.Trim();
        if (string.IsNullOrWhiteSpace(text))
        {
            MessageBox.Show("请输入提醒内容！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtText.Focus();
            return;
        }

        var time = TimeOnly.FromDateTime(dtpTime.Value);

        // 检查是否已经存在相同时间的提醒
        if (_settings.Reminders.Any(r => r.Time == time && r.Text == text))
        {
            MessageBox.Show("已存在相同时间与内容的提醒！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var newItem = new ReminderItem
        {
            Id = Guid.NewGuid(),
            Time = time,
            Text = text,
            Enabled = true
        };

        _settings.Reminders.Add(newItem);
        _settingsService.SaveSettings(_settings);
        _reminderService.UpdateSettings(_settings);

        RefreshReminderGrid();
        txtText.Clear();
    }

    private void dgvReminders_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        // 点击删除按钮
        if (e.ColumnIndex == colDelete.Index)
        {
            var row = dgvReminders.Rows[e.RowIndex];
            if (row.Tag is ReminderItem item)
            {
                var result = MessageBox.Show(
                    $"确定要删除提醒【{item.Time:HH:mm} {item.Text}】吗？",
                    "确认删除",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    _settings.Reminders.Remove(item);
                    _settingsService.SaveSettings(_settings);
                    _reminderService.UpdateSettings(_settings);
                    RefreshReminderGrid();
                }
            }
        }
    }

    private void dgvReminders_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        // 改变启用状态勾选
        if (e.ColumnIndex == colEnabled.Index)
        {
            var row = dgvReminders.Rows[e.RowIndex];
            if (row.Tag is ReminderItem item)
            {
                var val = row.Cells[colEnabled.Index].Value;
                item.Enabled = val is true;
                _settingsService.SaveSettings(_settings);
                _reminderService.UpdateSettings(_settings);
            }
        }
    }

    private void ShowMainWindow()
    {
        _allowVisible = true;
        Show();
        WindowState = FormWindowState.Normal;
        BringToFront();
        Activate();
    }

    private void HideToTray()
    {
        Hide();
        notifyIcon.ShowBalloonTip(1500, "Notifier", "程序已最小化到系统托盘，将在后台继续守护您的提醒。", ToolTipIcon.Info);
    }

    private void btnMinimizeToTray_Click(object sender, EventArgs e)
    {
        HideToTray();
    }

    private void notifyIcon_DoubleClick(object sender, EventArgs e)
    {
        ShowMainWindow();
    }

    private void menuOpen_Click(object sender, EventArgs e)
    {
        ShowMainWindow();
    }

    private void menuExit_Click(object sender, EventArgs e)
    {
        _isExplicitExit = true;
        _reminderService.Stop();
        _reminderService.Dispose();
        notifyIcon.Visible = false;
        Application.Exit();
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        // 如果不是主动点击退出菜单或系统关机，关闭窗口时隐藏到托盘
        if (!_isExplicitExit && e.CloseReason == CloseReason.UserClosing)
        {
            e.Cancel = true;
            HideToTray();
        }
    }
}
