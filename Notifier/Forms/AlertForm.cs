using System.Media;
using Notifier.Models;

namespace Notifier.Forms;

/// <summary>
/// 提醒通知置顶弹窗
/// </summary>
public partial class AlertForm : Form
{
    public AlertForm(ReminderItem item)
    {
        InitializeComponent();
        lblTime.Text = $"时间：{item.Time:HH:mm}";
        lblText.Text = item.Text;
    }

    private void AlertForm_Load(object sender, EventArgs e)
    {
        try
        {
            // 播放系统提示音
            SystemSounds.Exclamation.Play();
        }
        catch
        {
            // 忽略音频播放异常
        }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        Close();
    }
}
