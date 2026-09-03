namespace Notifier.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.GroupBox grpGeneral;
    private System.Windows.Forms.CheckBox chkAutoStart;
    private System.Windows.Forms.CheckBox chkSilentStart;

    private System.Windows.Forms.GroupBox grpReminders;
    private System.Windows.Forms.DataGridView dgvReminders;

    private System.Windows.Forms.GroupBox grpAdd;
    private System.Windows.Forms.Label lblTime;
    private System.Windows.Forms.DateTimePicker dtpTime;
    private System.Windows.Forms.Label lblText;
    private System.Windows.Forms.TextBox txtText;
    private System.Windows.Forms.Button btnAdd;

    private System.Windows.Forms.Button btnMinimizeToTray;
    private System.Windows.Forms.NotifyIcon notifyIcon;
    private System.Windows.Forms.ContextMenuStrip contextMenuStripTray;
    private System.Windows.Forms.ToolStripMenuItem menuOpen;
    private System.Windows.Forms.ToolStripSeparator menuSep;
    private System.Windows.Forms.ToolStripMenuItem menuExit;

    private System.Windows.Forms.DataGridViewCheckBoxColumn colEnabled;
    private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
    private System.Windows.Forms.DataGridViewTextBoxColumn colText;
    private System.Windows.Forms.DataGridViewButtonColumn colEdit;
    private System.Windows.Forms.DataGridViewButtonColumn colDelete;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        DataGridViewCellStyle dgvHeaderStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle dgvRowStyle = new DataGridViewCellStyle();

        grpGeneral = new GroupBox();
        chkSilentStart = new CheckBox();
        chkAutoStart = new CheckBox();
        grpReminders = new GroupBox();
        dgvReminders = new DataGridView();
        colEnabled = new DataGridViewCheckBoxColumn();
        colTime = new DataGridViewTextBoxColumn();
        colText = new DataGridViewTextBoxColumn();
        colEdit = new DataGridViewButtonColumn();
        colDelete = new DataGridViewButtonColumn();
        grpAdd = new GroupBox();
        btnAdd = new Button();
        txtText = new TextBox();
        lblText = new Label();
        dtpTime = new DateTimePicker();
        lblTime = new Label();
        btnMinimizeToTray = new Button();
        notifyIcon = new NotifyIcon(components);
        contextMenuStripTray = new ContextMenuStrip(components);
        menuOpen = new ToolStripMenuItem();
        menuSep = new ToolStripSeparator();
        menuExit = new ToolStripMenuItem();

        grpGeneral.SuspendLayout();
        grpReminders.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvReminders).BeginInit();
        grpAdd.SuspendLayout();
        contextMenuStripTray.SuspendLayout();
        SuspendLayout();

        // 
        // grpGeneral
        // 
        grpGeneral.Controls.Add(chkSilentStart);
        grpGeneral.Controls.Add(chkAutoStart);
        grpGeneral.Font = new Font("Microsoft YaHei UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
        grpGeneral.ForeColor = Color.FromArgb(40, 40, 40);
        grpGeneral.Location = new Point(16, 12);
        grpGeneral.Name = "grpGeneral";
        grpGeneral.Size = new Size(540, 68);
        grpGeneral.TabIndex = 0;
        grpGeneral.TabStop = false;
        grpGeneral.Text = "通用设置";
        // 
        // chkSilentStart
        // 
        chkSilentStart.AutoSize = true;
        chkSilentStart.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        chkSilentStart.Location = new Point(200, 30);
        chkSilentStart.Name = "chkSilentStart";
        chkSilentStart.Size = new Size(279, 21);
        chkSilentStart.TabIndex = 1;
        chkSilentStart.Text = "静默启动（开机启动时不弹窗，隐藏在系统托盘）";
        chkSilentStart.UseVisualStyleBackColor = true;
        chkSilentStart.CheckedChanged += chkSilentStart_CheckedChanged;
        // 
        // chkAutoStart
        // 
        chkAutoStart.AutoSize = true;
        chkAutoStart.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        chkAutoStart.Location = new Point(20, 30);
        chkAutoStart.Name = "chkAutoStart";
        chkAutoStart.Size = new Size(123, 21);
        chkAutoStart.TabIndex = 0;
        chkAutoStart.Text = "跟随系统开机启动";
        chkAutoStart.UseVisualStyleBackColor = true;
        chkAutoStart.CheckedChanged += chkAutoStart_CheckedChanged;
        // 
        // grpReminders
        // 
        grpReminders.Controls.Add(dgvReminders);
        grpReminders.Font = new Font("Microsoft YaHei UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
        grpReminders.ForeColor = Color.FromArgb(40, 40, 40);
        grpReminders.Location = new Point(16, 88);
        grpReminders.Name = "grpReminders";
        grpReminders.Size = new Size(540, 240);
        grpReminders.TabIndex = 1;
        grpReminders.TabStop = false;
        grpReminders.Text = "提醒事务列表";
        // 
        // dgvReminders
        // 
        dgvReminders.AllowUserToAddRows = false;
        dgvReminders.AllowUserToDeleteRows = false;
        dgvReminders.AllowUserToResizeRows = false;
        dgvReminders.BackgroundColor = Color.White;
        dgvReminders.BorderStyle = BorderStyle.Fixed3D;
        dgvHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dgvHeaderStyle.BackColor = Color.FromArgb(240, 243, 246);
        dgvHeaderStyle.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        dgvHeaderStyle.ForeColor = Color.FromArgb(50, 50, 50);
        dgvReminders.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
        dgvReminders.ColumnHeadersHeight = 30;
        dgvReminders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        dgvReminders.Columns.AddRange(new DataGridViewColumn[] { colEnabled, colTime, colText, colEdit, colDelete });
        dgvRowStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dgvRowStyle.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dgvRowStyle.SelectionBackColor = Color.FromArgb(225, 238, 254);
        dgvRowStyle.SelectionForeColor = Color.Black;
        dgvReminders.DefaultCellStyle = dgvRowStyle;
        dgvReminders.Dock = DockStyle.Fill;
        dgvReminders.EnableHeadersVisualStyles = false;
        dgvReminders.Location = new Point(3, 20);
        dgvReminders.MultiSelect = false;
        dgvReminders.Name = "dgvReminders";
        dgvReminders.RowHeadersVisible = false;
        dgvReminders.RowTemplate.Height = 32;
        dgvReminders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvReminders.Size = new Size(534, 217);
        dgvReminders.TabIndex = 0;
        dgvReminders.CellContentClick += dgvReminders_CellContentClick;
        dgvReminders.CellValueChanged += dgvReminders_CellValueChanged;
        // 
        // colEnabled
        // 
        colEnabled.HeaderText = "启用";
        colEnabled.Name = "colEnabled";
        colEnabled.Width = 50;
        // 
        // colTime
        // 
        colTime.HeaderText = "提醒时间";
        colTime.Name = "colTime";
        colTime.ReadOnly = true;
        colTime.Width = 90;
        // 
        // colText
        // 
        colText.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        colText.HeaderText = "提醒文本";
        colText.Name = "colText";
        colText.ReadOnly = true;
        // 
        // colEdit
        // 
        colEdit.HeaderText = "编辑";
        colEdit.Name = "colEdit";
        colEdit.Text = "编辑";
        colEdit.UseColumnTextForButtonValue = true;
        colEdit.Width = 60;
        // 
        // colDelete
        // 
        colDelete.HeaderText = "删除";
        colDelete.Name = "colDelete";
        colDelete.Text = "删除";
        colDelete.UseColumnTextForButtonValue = true;
        colDelete.Width = 60;
        // 
        // grpAdd
        // 
        grpAdd.Controls.Add(btnAdd);
        grpAdd.Controls.Add(txtText);
        grpAdd.Controls.Add(lblText);
        grpAdd.Controls.Add(dtpTime);
        grpAdd.Controls.Add(lblTime);
        grpAdd.Font = new Font("Microsoft YaHei UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
        grpAdd.ForeColor = Color.FromArgb(40, 40, 40);
        grpAdd.Location = new Point(16, 336);
        grpAdd.Name = "grpAdd";
        grpAdd.Size = new Size(540, 75);
        grpAdd.TabIndex = 2;
        grpAdd.TabStop = false;
        grpAdd.Text = "添加新提醒";
        // 
        // btnAdd
        // 
        btnAdd.BackColor = Color.FromArgb(0, 122, 204);
        btnAdd.Cursor = Cursors.Hand;
        btnAdd.FlatStyle = FlatStyle.Flat;
        btnAdd.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        btnAdd.ForeColor = Color.White;
        btnAdd.Location = new Point(445, 27);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(80, 32);
        btnAdd.TabIndex = 4;
        btnAdd.Text = "添加";
        btnAdd.UseVisualStyleBackColor = false;
        btnAdd.Click += btnAdd_Click;
        // 
        // txtText
        // 
        txtText.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        txtText.Location = new Point(235, 32);
        txtText.Name = "txtText";
        txtText.PlaceholderText = "例如：打卡（上班）";
        txtText.Size = new Size(195, 23);
        txtText.TabIndex = 3;
        // 
        // lblText
        // 
        lblText.AutoSize = true;
        lblText.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblText.Location = new Point(170, 35);
        lblText.Name = "lblText";
        lblText.Size = new Size(68, 17);
        lblText.TabIndex = 2;
        lblText.Text = "提醒内容：";
        // 
        // dtpTime
        // 
        dtpTime.CustomFormat = "HH:mm";
        dtpTime.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dtpTime.Format = DateTimePickerFormat.Custom;
        dtpTime.Location = new Point(85, 32);
        dtpTime.Name = "dtpTime";
        dtpTime.ShowUpDown = true;
        dtpTime.Size = new Size(75, 23);
        dtpTime.TabIndex = 1;
        // 
        // lblTime
        // 
        lblTime.AutoSize = true;
        lblTime.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblTime.Location = new Point(18, 35);
        lblTime.Name = "lblTime";
        lblTime.Size = new Size(68, 17);
        lblTime.TabIndex = 0;
        lblTime.Text = "提醒时间：";
        // 
        // btnMinimizeToTray
        // 
        btnMinimizeToTray.BackColor = Color.FromArgb(235, 238, 242);
        btnMinimizeToTray.Cursor = Cursors.Hand;
        btnMinimizeToTray.FlatStyle = FlatStyle.Flat;
        btnMinimizeToTray.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnMinimizeToTray.ForeColor = Color.FromArgb(40, 40, 40);
        btnMinimizeToTray.Location = new Point(416, 422);
        btnMinimizeToTray.Name = "btnMinimizeToTray";
        btnMinimizeToTray.Size = new Size(140, 32);
        btnMinimizeToTray.TabIndex = 3;
        btnMinimizeToTray.Text = "隐藏到系统托盘";
        btnMinimizeToTray.UseVisualStyleBackColor = false;
        btnMinimizeToTray.Click += btnMinimizeToTray_Click;
        // 
        // notifyIcon
        // 
        notifyIcon.ContextMenuStrip = contextMenuStripTray;
        notifyIcon.Text = "Notifier - 定时提醒";
        notifyIcon.Visible = true;
        notifyIcon.DoubleClick += notifyIcon_DoubleClick;
        // 
        // contextMenuStripTray
        // 
        contextMenuStripTray.Items.AddRange(new ToolStripItem[] { menuOpen, menuSep, menuExit });
        contextMenuStripTray.Name = "contextMenuStripTray";
        contextMenuStripTray.Size = new Size(137, 54);
        // 
        // menuOpen
        // 
        menuOpen.Name = "menuOpen";
        menuOpen.Size = new Size(136, 22);
        menuOpen.Text = "打开设置";
        menuOpen.Click += menuOpen_Click;
        // 
        // menuSep
        // 
        menuSep.Name = "menuSep";
        menuSep.Size = new Size(133, 6);
        // 
        // menuExit
        // 
        menuExit.Name = "menuExit";
        menuExit.Size = new Size(136, 22);
        menuExit.Text = "退出程序";
        menuExit.Click += menuExit_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(246, 248, 250);
        ClientSize = new Size(572, 466);
        Controls.Add(btnMinimizeToTray);
        Controls.Add(grpAdd);
        Controls.Add(grpReminders);
        Controls.Add(grpGeneral);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Notifier - 定时提醒设置";
        FormClosing += MainForm_FormClosing;
        Load += MainForm_Load;
        grpGeneral.ResumeLayout(false);
        grpGeneral.PerformLayout();
        grpReminders.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvReminders).EndInit();
        grpAdd.ResumeLayout(false);
        grpAdd.PerformLayout();
        contextMenuStripTray.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion
}
