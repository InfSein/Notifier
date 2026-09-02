# Notifier 定时提醒工具

Notifier 是一个轻量级、开箱即用的 Windows 定时提醒桌面小工具（基于 .NET 10 WinForms）。专门设计用于满足日常打卡、日程提醒等需求。

---

## ✨ 核心特性

- **自定义提醒事务**：支持添加多个提醒项（如早 08:45、晚 17:59 打卡提醒），可单独启用/停用或删除。
- **开机延迟补提醒**：若设定时间已过但今天尚未开机/未提醒（如 8:45 提醒，8:55 才开机），程序启动后会自动触发补提醒。
- **每日仅提醒一次**：同一提醒项当天触发后即记录状态，即使中途多次重启电脑也不会产生重复干扰，次日自动重置。
- **开机自启动 & 静默托盘运行**：支持开机自启；开启静默启动后，开机不弹主界面直接驻留系统右下角托盘。
- **单实例运行保护**：通过系统互斥体防止重复多开。
- **置顶醒目弹窗**：到点置顶弹窗并播放提示音，支持快捷关闭。

---

## 🛠️ 项目结构

```
Notifier/
├── Notifier.sln
├── README.md
├── .gitignore
├── ARCHITECTURE.md
└── Notifier/
    ├── Models/
    │   ├── ReminderItem.cs     # 提醒事务模型
    │   └── AppSettings.cs      # 全局配置模型
    ├── Services/
    │   ├── SettingsService.cs  # 配置读写与持久化（JSON）
    │   ├── ReminderService.cs  # 定时轮询、延迟补提醒、每日去重
    │   └── StartupService.cs   # Windows 开机启动注册表管理
    ├── Forms/
    │   ├── MainForm.cs         # 主设置界面与系统托盘
    │   └── AlertForm.cs        # 醒目置顶提醒弹窗
    └── Program.cs              # 应用程序入口（单实例与静默参数处理）
```

---

## 🚀 编译与运行

### 环境要求
- Windows 10 / 11
- .NET 10 SDK

### 构建命令
```bash
dotnet build Notifier.sln
```

### 运行
```bash
# 正常启动
dotnet run --project Notifier/Notifier.csproj

# 静默模式启动（仅托盘图标）
dotnet run --project Notifier/Notifier.csproj -- --silent
```

---

## 🔍 方案调研与搜索记录

- **调研结论**：
  - 针对 Windows 桌面轻量提醒工具，采用 .NET 10 WinForms 原生方案，通过 `System.Windows.Forms.Timer` 定时检查 + JSON 状态持久化方案最为轻量可靠。
  - 开机自启采用注册表 `HKCU\Software\Microsoft\Windows\CurrentVersion\Run` 挂载，配合 `--silent` 参数实现无缝静默托盘驻留。
  - 使用 `Global\Mutex` 保证进程单实例，避免多开冲突。
