# Notifier 架构设计文档

本文档记录 Notifier 项目的模块职责、调用关系以及关键设计决定。

---

## 模块职责说明

- [Program.cs](file:///d:/Repo/.net/Notifier/Notifier/Program.cs)：程序入口，负责 Mutex 单实例互斥控制、命令行参数解析及主窗体启动。
- [Models/ReminderItem.cs](file:///d:/Repo/.net/Notifier/Notifier/Models/ReminderItem.cs)：定义单个提醒事务的数据结构（唯一标识、时间、文本、启用状态）。
- [Models/AppSettings.cs](file:///d:/Repo/.net/Notifier/Notifier/Models/AppSettings.cs)：定义软件全局设置（自启、静默、提醒列表）。
- [Services/SettingsService.cs](file:///d:/Repo/.net/Notifier/Notifier/Services/SettingsService.cs)：负责读取和保存用户设置至本地 JSON 文件（`%APPDATA%/Notifier/settings.json`）。
- [Services/StartupService.cs](file:///d:/Repo/.net/Notifier/Notifier/Services/StartupService.cs)：管理 Windows 注册表自启动项（`HKCU/.../Run`）。
- [Services/ReminderService.cs](file:///d:/Repo/.net/Notifier/Notifier/Services/ReminderService.cs)：核心调度器，负责定时轮询、开机延迟补提醒、每日已触发状态去重与跨天重置。
- [Forms/MainForm.cs](file:///d:/Repo/.net/Notifier/Notifier/Forms/MainForm.cs)：主界面与托盘控制器，提供提醒列表编辑、全局参数开关与托盘菜单。
- [Forms/AlertForm.cs](file:///d:/Repo/.net/Notifier/Notifier/Forms/AlertForm.cs)：提醒弹窗，负责到点置顶醒目展示提醒内容并播放提示音。

---

## 模块调用关系

```
                    ┌──────────────┐
                    │  Program.cs  │ (Mutex 单实例 / --silent 解析)
                    └──────┬───────┘
                           │ 启动
                           ▼
                    ┌──────────────┐
              ┌─────┤  MainForm    ├─────────────────┐
              │     └──────┬───────┘                 │
              │            │                         │
              ▼            ▼                         ▼
      ┌──────────────┐ ┌──────────────┐       ┌──────────────┐
      │StartupService│ │SettingsServ. │       │ReminderServ. │
      └──────────────┘ └──────────────┘       └──────┬───────┘
                                                     │ 触发提醒
                                                     ▼
                                              ┌──────────────┐
                                              │  AlertForm   │ (置顶弹窗)
                                              └──────────────┘
```

---

## 关键设计决定与原因

1. **每日状态独立持久化（`daily_state.json`）**：
   - *决定*：当日已触发的提醒 ID 记录在独立的 `daily_state.json` 中，跨天自动重置。
   - *原因*：用户如果 8:45 触发过提醒，10:00 重启电脑，若只存内存会丢失状态导致重启后再次延迟误报。持久化记录可确保即使多次重启电脑，当天也绝对只提醒一次。

2. **静默启动机制（重写 `SetVisibleCore` 与服务生命周期解耦）**：
   - *决定*：在 `MainForm` 中通过控制 `SetVisibleCore` 在静默模式下阻止窗体首次显示。同时将后台提醒服务的启动挂载在 `OnHandleCreated` 并在消息泵就绪后异步触发，而非绑定在 `Form.Load` 上。
   - *原因*：阻止窗体显示会导致 WinForms 的 `Load` 事件不被触发；将提醒服务解耦至句柄与消息泵就绪时启动，既能保证无窗口闪烁的托盘静默常驻，又能确保开机后第一时间进行提醒检查与准时弹窗。

3. **Mutex 单实例控制**：
   - *决定*：使用 `Global\Notifier_SingleInstance_Mutex_8F7D3A` 进行互斥。
   - *原因*：防止用户重复多次启动应用导致多套定时器并发弹窗。
