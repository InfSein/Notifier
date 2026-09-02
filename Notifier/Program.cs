using Notifier.Forms;

namespace Notifier;

static class Program
{
    private const string AppMutexName = "Global\\Notifier_SingleInstance_Mutex_8F7D3A";
    private static Mutex? _mutex;

    /// <summary>
    ///  应用程序主入口点
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        // 单实例检查
        _mutex = new Mutex(true, AppMutexName, out bool createdNew);
        if (!createdNew)
        {
            MessageBox.Show(
                "Notifier 已经在运行中！您可以在右下角系统托盘中找到它。",
                "提示",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            return;
        }

        ApplicationConfiguration.Initialize();

        // 检查是否以静默模式启动
        bool silent = args.Any(arg => 
            string.Equals(arg, "--silent", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(arg, "-s", StringComparison.OrdinalIgnoreCase));

        Application.Run(new MainForm(silent));

        // 释放 Mutex
        _mutex.ReleaseMutex();
    }
}