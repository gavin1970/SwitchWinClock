namespace SwitchWinClock
{
    partial class InstanceNameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstanceNameForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.TimeZoneComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtInstanceName = new System.Windows.Forms.TextBox();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.LblTitle = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 10, 3, 5);
            this.groupBox1.Size = new System.Drawing.Size(356, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.TimeZoneComboBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(5, 53);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel2.Size = new System.Drawing.Size(348, 30);
            this.panel2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 5);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(67, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Time Zone:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TimeZoneComboBox
            // 
            this.TimeZoneComboBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.TimeZoneComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimeZoneComboBox.FormattingEnabled = true;
            this.TimeZoneComboBox.Location = new System.Drawing.Point(73, 5);
            this.TimeZoneComboBox.Name = "TimeZoneComboBox";
            this.TimeZoneComboBox.Size = new System.Drawing.Size(275, 21);
            this.TimeZoneComboBox.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TxtInstanceName);
            this.panel1.Controls.Add(this.BtnOK);
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 23);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(348, 30);
            this.panel1.TabIndex = 3;
            // 
            // TxtInstanceName
            // 
            this.TxtInstanceName.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtInstanceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtInstanceName.Location = new System.Drawing.Point(3, 3);
            this.TxtInstanceName.MaxLength = 64;
            this.TxtInstanceName.Name = "TxtInstanceName";
            this.TxtInstanceName.Size = new System.Drawing.Size(284, 24);
            this.TxtInstanceName.TabIndex = 0;
            // 
            // BtnOK
            // 
            this.BtnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BtnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnOK.Location = new System.Drawing.Point(287, 3);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(29, 24);
            this.BtnOK.TabIndex = 1;
            this.BtnOK.Text = "✔";
            this.BtnOK.UseVisualStyleBackColor = false;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancel.Location = new System.Drawing.Point(316, 3);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(29, 24);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "✖";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // LblTitle
            // 
            this.LblTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.LblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle.Location = new System.Drawing.Point(5, 5);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(356, 19);
            this.LblTitle.TabIndex = 0;
            this.LblTitle.Text = "Provide a name for instance reference.";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.LblTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            this.LblTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Control_MouseUp);
            // 
            // InstanceNameForm
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(366, 96);
            this.Controls.Add(this.LblTitle);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InstanceNameForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SwitchWinClock";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.InstanceNameForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.TextBox TxtInstanceName;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TimeZoneComboBox;
    }
}