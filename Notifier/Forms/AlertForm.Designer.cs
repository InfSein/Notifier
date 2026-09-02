namespace Notifier.Forms;

partial class AlertForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label lblHeader;
    private System.Windows.Forms.Label lblTime;
    private System.Windows.Forms.Label lblText;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Panel panelTop;

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
        lblHeader = new Label();
        lblTime = new Label();
        lblText = new Label();
        btnOk = new Button();
        panelTop = new Panel();
        panelTop.SuspendLayout();
        SuspendLayout();
        // 
        // panelTop
        // 
        panelTop.BackColor = Color.FromArgb(0, 122, 204);
        panelTop.Controls.Add(lblHeader);
        panelTop.Dock = DockStyle.Top;
        panelTop.Location = new Point(0, 0);
        panelTop.Name = "panelTop";
        panelTop.Size = new Size(420, 50);
        panelTop.TabIndex = 0;
        // 
        // lblHeader
        // 
        lblHeader.AutoSize = true;
        lblHeader.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
        lblHeader.ForeColor = Color.White;
        lblHeader.Location = new Point(16, 14);
        lblHeader.Name = "lblHeader";
        lblHeader.Size = new Size(110, 22);
        lblHeader.TabIndex = 0;
        lblHeader.Text = "⏰ 定时提醒";
        // 
        // lblTime
        // 
        lblTime.AutoSize = true;
        lblTime.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblTime.ForeColor = Color.FromArgb(100, 100, 100);
        lblTime.Location = new Point(20, 68);
        lblTime.Name = "lblTime";
        lblTime.Size = new Size(95, 20);
        lblTime.TabIndex = 1;
        lblTime.Text = "时间：08:45";
        // 
        // lblText
        // 
        lblText.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 134);
        lblText.ForeColor = Color.FromArgb(30, 30, 30);
        lblText.Location = new Point(20, 96);
        lblText.Name = "lblText";
        lblText.Size = new Size(380, 60);
        lblText.TabIndex = 2;
        lblText.Text = "打卡（上班）";
        // 
        // btnOk
        // 
        btnOk.BackColor = Color.FromArgb(0, 122, 204);
        btnOk.Cursor = Cursors.Hand;
        btnOk.FlatStyle = FlatStyle.Flat;
        btnOk.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
        btnOk.ForeColor = Color.White;
        btnOk.Location = new Point(145, 175);
        btnOk.Name = "btnOk";
        btnOk.Size = new Size(130, 38);
        btnOk.TabIndex = 3;
        btnOk.Text = "知道了";
        btnOk.UseVisualStyleBackColor = false;
        btnOk.Click += btnOk_Click;
        // 
        // AlertForm
        // 
        AcceptButton = btnOk;
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(248, 249, 250);
        CancelButton = btnOk;
        ClientSize = new Size(420, 230);
        Controls.Add(btnOk);
        Controls.Add(lblText);
        Controls.Add(lblTime);
        Controls.Add(panelTop);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "AlertForm";
        ShowIcon = false;
        ShowInTaskbar = true;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Notifier 提醒";
        TopMost = true;
        Load += AlertForm_Load;
        panelTop.ResumeLayout(false);
        panelTop.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}
