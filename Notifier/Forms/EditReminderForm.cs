using Notifier.Models;

namespace Notifier.Forms;

/// <summary>
/// 编辑提醒事务对话框
/// </summary>
public partial class EditReminderForm : Form
{
    private readonly ReminderItem _currentItem;
    private readonly IEnumerable<ReminderItem> _allReminders;

    /// <summary>
    /// 修改后的提醒时间
    /// </summary>
    public TimeOnly ReminderTime { get; private set; }

    /// <summary>
    /// 修改后的提醒文本
    /// </summary>
    public string ReminderText { get; private set; } = string.Empty;

    public EditReminderForm(ReminderItem item, IEnumerable<ReminderItem> allReminders)
    {
        _currentItem = item;
        _allReminders = allReminders;

        InitializeComponent();

        // 加载初始数据
        dtpTime.Value = DateTime.Today.Add(item.Time.ToTimeSpan());
        txtText.Text = item.Text;
        txtText.SelectAll();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        var text = txtText.Text.Trim();
        if (string.IsNullOrWhiteSpace(text))
        {
            MessageBox.Show("请输入提醒内容！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtText.Focus();
            return;
        }

        var time = TimeOnly.FromDateTime(dtpTime.Value);

        // 检查除当前项以外是否存在相同时间和内容的提醒
        if (_allReminders.Any(r => r != _currentItem && r.Time == time && r.Text == text))
        {
            MessageBox.Show("已存在相同时间与内容的提醒！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        ReminderTime = time;
        ReminderText = text;
        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
