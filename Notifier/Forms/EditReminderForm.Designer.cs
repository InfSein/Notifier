namespace Notifier.Forms;

partial class EditReminderForm
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Label lblTime;
    private System.Windows.Forms.DateTimePicker dtpTime;
    private System.Windows.Forms.Label lblText;
    private System.Windows.Forms.TextBox txtText;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;

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
        lblTime = new Label();
        dtpTime = new DateTimePicker();
        lblText = new Label();
        txtText = new TextBox();
        btnSave = new Button();
        btnCancel = new Button();
        SuspendLayout();
        // 
        // lblTime
        // 
        lblTime.AutoSize = true;
        lblTime.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblTime.Location = new Point(24, 26);
        lblTime.Name = "lblTime";
        lblTime.Size = new Size(68, 17);
        lblTime.TabIndex = 0;
        lblTime.Text = "提醒时间：";
        // 
        // dtpTime
        // 
        dtpTime.CustomFormat = "HH:mm";
        dtpTime.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        dtpTime.Format = DateTimePickerFormat.Custom;
        dtpTime.Location = new Point(96, 23);
        dtpTime.Name = "dtpTime";
        dtpTime.ShowUpDown = true;
        dtpTime.Size = new Size(80, 23);
        dtpTime.TabIndex = 1;
        // 
        // lblText
        // 
        lblText.AutoSize = true;
        lblText.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        lblText.Location = new Point(24, 66);
        lblText.Name = "lblText";
        lblText.Size = new Size(68, 17);
        lblText.TabIndex = 2;
        lblText.Text = "提醒内容：";
        // 
        // txtText
        // 
        txtText.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        txtText.Location = new Point(96, 63);
        txtText.Name = "txtText";
        txtText.Size = new Size(245, 23);
        txtText.TabIndex = 3;
        // 
        // btnSave
        // 
        btnSave.BackColor = Color.FromArgb(0, 122, 204);
        btnSave.Cursor = Cursors.Hand;
        btnSave.FlatStyle = FlatStyle.Flat;
        btnSave.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        btnSave.ForeColor = Color.White;
        btnSave.Location = new Point(171, 115);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(80, 32);
        btnSave.TabIndex = 4;
        btnSave.Text = "保存";
        btnSave.UseVisualStyleBackColor = false;
        btnSave.Click += btnSave_Click;
        // 
        // btnCancel
        // 
        btnCancel.BackColor = Color.FromArgb(235, 238, 242);
        btnCancel.Cursor = Cursors.Hand;
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.FlatStyle = FlatStyle.Flat;
        btnCancel.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnCancel.ForeColor = Color.FromArgb(40, 40, 40);
        btnCancel.Location = new Point(261, 115);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(80, 32);
        btnCancel.TabIndex = 5;
        btnCancel.Text = "取消";
        btnCancel.UseVisualStyleBackColor = false;
        btnCancel.Click += btnCancel_Click;
        // 
        // EditReminderForm
        // 
        AcceptButton = btnSave;
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(246, 248, 250);
        CancelButton = btnCancel;
        ClientSize = new Size(368, 168);
        Controls.Add(btnCancel);
        Controls.Add(btnSave);
        Controls.Add(txtText);
        Controls.Add(lblText);
        Controls.Add(dtpTime);
        Controls.Add(lblTime);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "EditReminderForm";
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "编辑提醒";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}
