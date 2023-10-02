using System;
using System.Drawing;

namespace SwitchWinClock
{
    partial class DisplayForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayForm));
            this.SettingsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ClockStyleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StyleDeptMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StyleBorderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FontSetupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DateFormattingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomDateFormatMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomDateTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.PresetDateFormatItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.PresetDateFormatItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.PresetDateFormatItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.PresetDateFormatItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorSetupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ForeColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ForeColorSetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ForeColorTransparentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BackColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BackColorSetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BackColorTransparentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BorderColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BorderColorSetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BorderColorTransparentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextBorderColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextBorderSetColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextBorderTransparentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextDepthpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.NewInstanceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingsContextMenu
            // 
            this.SettingsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClockStyleMenuItem,
            this.FontSetupMenuItem,
            this.DateFormattingMenuItem,
            this.ColorSetupMenuItem,
            this.TextDepthpMenuItem,
            this.ToolStripSeparator1,
            this.NewInstanceMenuItem,
            this.toolStripSeparator2,
            this.ExitMenuItem});
            this.SettingsContextMenu.Name = "SettingsContextMenu";
            this.SettingsContextMenu.Size = new System.Drawing.Size(157, 170);
            this.SettingsContextMenu.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            // 
            // ClockStyleMenuItem
            // 
            this.ClockStyleMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StyleDeptMenuItem,
            this.StyleBorderMenuItem});
            this.ClockStyleMenuItem.Name = "ClockStyleMenuItem";
            this.ClockStyleMenuItem.Size = new System.Drawing.Size(156, 22);
            this.ClockStyleMenuItem.Text = "Clock &Style";
            // 
            // StyleDeptMenuItem
            // 
            this.StyleDeptMenuItem.CheckOnClick = true;
            this.StyleDeptMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StyleDeptMenuItem.Name = "StyleDeptMenuItem";
            this.StyleDeptMenuItem.Size = new System.Drawing.Size(109, 22);
            this.StyleDeptMenuItem.Text = "&Depth";
            this.StyleDeptMenuItem.Click += new System.EventHandler(this.StyleDeptMenuItem_Click);
            // 
            // StyleBorderMenuItem
            // 
            this.StyleBorderMenuItem.CheckOnClick = true;
            this.StyleBorderMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StyleBorderMenuItem.Name = "StyleBorderMenuItem";
            this.StyleBorderMenuItem.Size = new System.Drawing.Size(109, 22);
            this.StyleBorderMenuItem.Text = "&Border";
            this.StyleBorderMenuItem.Click += new System.EventHandler(this.StyleBorderMenuItem_Click);
            // 
            // FontSetupMenuItem
            // 
            this.FontSetupMenuItem.Name = "FontSetupMenuItem";
            this.FontSetupMenuItem.Size = new System.Drawing.Size(156, 22);
            this.FontSetupMenuItem.Text = "&Font Settings";
            this.FontSetupMenuItem.Click += new System.EventHandler(this.FontSetupMenuItem_Click);
            // 
            // DateFormattingMenuItem
            // 
            this.DateFormattingMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomDateFormatMenuItem,
            this.PresetDateFormatItem1,
            this.PresetDateFormatItem2,
            this.PresetDateFormatItem3,
            this.PresetDateFormatItem4});
            this.DateFormattingMenuItem.Name = "DateFormattingMenuItem";
            this.DateFormattingMenuItem.Size = new System.Drawing.Size(156, 22);
            this.DateFormattingMenuItem.Text = "&Date Formating";
            // 
            // CustomDateFormatMenuItem
            // 
            this.CustomDateFormatMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomDateTextBox});
            this.CustomDateFormatMenuItem.Name = "CustomDateFormatMenuItem";
            this.CustomDateFormatMenuItem.Size = new System.Drawing.Size(227, 22);
            this.CustomDateFormatMenuItem.Text = "&Custom Format";
            // 
            // CustomDateTextBox
            // 
            this.CustomDateTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CustomDateTextBox.Name = "CustomDateTextBox";
            this.CustomDateTextBox.Size = new System.Drawing.Size(300, 23);
            this.CustomDateTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CustomDateTextBox_KeyUp);
            // 
            // PresetDateFormatItem1
            // 
            this.PresetDateFormatItem1.Name = "PresetDateFormatItem1";
            this.PresetDateFormatItem1.Size = new System.Drawing.Size(227, 22);
            this.PresetDateFormatItem1.Text = "dddd, MMM dd, hh:mm:ss tt";
            this.PresetDateFormatItem1.Click += new System.EventHandler(this.DateFormatItem_Click);
            // 
            // PresetDateFormatItem2
            // 
            this.PresetDateFormatItem2.Name = "PresetDateFormatItem2";
            this.PresetDateFormatItem2.Size = new System.Drawing.Size(227, 22);
            this.PresetDateFormatItem2.Text = "ddd, MMM dd, hh:mm:ss tt";
            this.PresetDateFormatItem2.Click += new System.EventHandler(this.DateFormatItem_Click);
            // 
            // PresetDateFormatItem3
            // 
            this.PresetDateFormatItem3.Name = "PresetDateFormatItem3";
            this.PresetDateFormatItem3.Size = new System.Drawing.Size(227, 22);
            this.PresetDateFormatItem3.Text = "hh:mm:ss tt";
            this.PresetDateFormatItem3.Click += new System.EventHandler(this.DateFormatItem_Click);
            // 
            // PresetDateFormatItem4
            // 
            this.PresetDateFormatItem4.Name = "PresetDateFormatItem4";
            this.PresetDateFormatItem4.Size = new System.Drawing.Size(227, 22);
            this.PresetDateFormatItem4.Text = "dddd, MMM dd";
            this.PresetDateFormatItem4.Click += new System.EventHandler(this.DateFormatItem_Click);
            // 
            // ColorSetupMenuItem
            // 
            this.ColorSetupMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ForeColorMenuItem,
            this.BackColorMenuItem,
            this.BorderColorMenuItem,
            this.TextBorderColorMenuItem});
            this.ColorSetupMenuItem.Name = "ColorSetupMenuItem";
            this.ColorSetupMenuItem.Size = new System.Drawing.Size(156, 22);
            this.ColorSetupMenuItem.Text = "&Color Settings";
            // 
            // ForeColorMenuItem
            // 
            this.ForeColorMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ForeColorSetMenuItem,
            this.ForeColorTransparentMenuItem});
            this.ForeColorMenuItem.Name = "ForeColorMenuItem";
            this.ForeColorMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ForeColorMenuItem.Text = "&ForeColor";
            // 
            // ForeColorSetMenuItem
            // 
            this.ForeColorSetMenuItem.Name = "ForeColorSetMenuItem";
            this.ForeColorSetMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ForeColorSetMenuItem.Text = "&Set Color";
            this.ForeColorSetMenuItem.Click += new System.EventHandler(this.ForeColorSetMenuItem_Click);
            // 
            // ForeColorTransparentMenuItem
            // 
            this.ForeColorTransparentMenuItem.CheckOnClick = true;
            this.ForeColorTransparentMenuItem.Name = "ForeColorTransparentMenuItem";
            this.ForeColorTransparentMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ForeColorTransparentMenuItem.Text = "&Make Transparent";
            this.ForeColorTransparentMenuItem.Click += new System.EventHandler(this.ColorTransparentMenuItem_Click);
            // 
            // BackColorMenuItem
            // 
            this.BackColorMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BackColorSetMenuItem,
            this.BackColorTransparentMenuItem});
            this.BackColorMenuItem.Name = "BackColorMenuItem";
            this.BackColorMenuItem.Size = new System.Drawing.Size(180, 22);
            this.BackColorMenuItem.Text = "Form B&ackColor";
            // 
            // BackColorSetMenuItem
            // 
            this.BackColorSetMenuItem.Name = "BackColorSetMenuItem";
            this.BackColorSetMenuItem.Size = new System.Drawing.Size(167, 22);
            this.BackColorSetMenuItem.Text = "&Set Color";
            this.BackColorSetMenuItem.Click += new System.EventHandler(this.BackColorSetMenuItem_Click);
            // 
            // BackColorTransparentMenuItem
            // 
            this.BackColorTransparentMenuItem.CheckOnClick = true;
            this.BackColorTransparentMenuItem.Name = "BackColorTransparentMenuItem";
            this.BackColorTransparentMenuItem.Size = new System.Drawing.Size(167, 22);
            this.BackColorTransparentMenuItem.Text = "&Make Transparent";
            this.BackColorTransparentMenuItem.Click += new System.EventHandler(this.ColorTransparentMenuItem_Click);
            // 
            // BorderColorMenuItem
            // 
            this.BorderColorMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BorderColorSetMenuItem,
            this.BorderColorTransparentMenuItem});
            this.BorderColorMenuItem.Name = "BorderColorMenuItem";
            this.BorderColorMenuItem.Size = new System.Drawing.Size(180, 22);
            this.BorderColorMenuItem.Text = "Form B&order Color";
            // 
            // BorderColorSetMenuItem
            // 
            this.BorderColorSetMenuItem.Name = "BorderColorSetMenuItem";
            this.BorderColorSetMenuItem.Size = new System.Drawing.Size(167, 22);
            this.BorderColorSetMenuItem.Text = "&Set Color";
            this.BorderColorSetMenuItem.Click += new System.EventHandler(this.BorderColorSetMenuItem_Click);
            // 
            // BorderColorTransparentMenuItem
            // 
            this.BorderColorTransparentMenuItem.CheckOnClick = true;
            this.BorderColorTransparentMenuItem.Name = "BorderColorTransparentMenuItem";
            this.BorderColorTransparentMenuItem.Size = new System.Drawing.Size(167, 22);
            this.BorderColorTransparentMenuItem.Text = "&Make Transparent";
            this.BorderColorTransparentMenuItem.Click += new System.EventHandler(this.ColorTransparentMenuItem_Click);
            // 
            // TextBorderColorMenuItem
            // 
            this.TextBorderColorMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TextBorderSetColorMenuItem,
            this.TextBorderTransparentMenuItem});
            this.TextBorderColorMenuItem.Name = "TextBorderColorMenuItem";
            this.TextBorderColorMenuItem.Size = new System.Drawing.Size(180, 22);
            this.TextBorderColorMenuItem.Text = "&Text Border Color";
            // 
            // TextBorderSetColorMenuItem
            // 
            this.TextBorderSetColorMenuItem.Name = "TextBorderSetColorMenuItem";
            this.TextBorderSetColorMenuItem.Size = new System.Drawing.Size(167, 22);
            this.TextBorderSetColorMenuItem.Text = "&Set Color";
            this.TextBorderSetColorMenuItem.Click += new System.EventHandler(this.TextBorderSetColorMenuItem_Click);
            // 
            // TextBorderTransparentMenuItem
            // 
            this.TextBorderTransparentMenuItem.CheckOnClick = true;
            this.TextBorderTransparentMenuItem.Name = "TextBorderTransparentMenuItem";
            this.TextBorderTransparentMenuItem.Size = new System.Drawing.Size(167, 22);
            this.TextBorderTransparentMenuItem.Text = "&Make Transparent";
            this.TextBorderTransparentMenuItem.Click += new System.EventHandler(this.ColorTransparentMenuItem_Click);
            // 
            // TextDepthpMenuItem
            // 
            this.TextDepthpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9});
            this.TextDepthpMenuItem.Name = "TextDepthpMenuItem";
            this.TextDepthpMenuItem.Size = new System.Drawing.Size(156, 22);
            this.TextDepthpMenuItem.Text = "&Text Depth";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.CheckOnClick = true;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem1.Text = "&1";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.TextDepthp_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.CheckOnClick = true;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem2.Text = "&2";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.TextDepthp_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.CheckOnClick = true;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem3.Text = "&3";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.TextDepthp_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.CheckOnClick = true;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem4.Text = "&4";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.TextDepthp_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.CheckOnClick = true;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem5.Text = "&5";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.TextDepthp_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.CheckOnClick = true;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem6.Text = "&6";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.TextDepthp_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.CheckOnClick = true;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem7.Text = "&7";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.TextDepthp_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.CheckOnClick = true;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem8.Text = "&8";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.TextDepthp_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.CheckOnClick = true;
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem9.Text = "&9";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.TextDepthp_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(153, 6);
            // 
            // NewInstanceMenuItem
            // 
            this.NewInstanceMenuItem.Name = "NewInstanceMenuItem";
            this.NewInstanceMenuItem.Size = new System.Drawing.Size(156, 22);
            this.NewInstanceMenuItem.Text = "&New Instance";
            this.NewInstanceMenuItem.Click += new System.EventHandler(this.NewInstanceMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(153, 6);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(156, 22);
            this.ExitMenuItem.Text = "E&xit";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // DisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(234, 65);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DisplayForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Switch Win Clock";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(254)))));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            this.SettingsContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip SettingsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem FontSetupMenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ForeColorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BackColorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ColorSetupMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BorderColorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TextDepthpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem BackColorTransparentMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BorderColorTransparentMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BackColorSetMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BorderColorSetMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DateFormattingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CustomDateFormatMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PresetDateFormatItem1;
        private System.Windows.Forms.ToolStripMenuItem PresetDateFormatItem2;
        private System.Windows.Forms.ToolStripMenuItem PresetDateFormatItem3;
        private System.Windows.Forms.ToolStripMenuItem PresetDateFormatItem4;
        private System.Windows.Forms.ToolStripTextBox CustomDateTextBox;
        private System.Windows.Forms.ToolStripMenuItem ForeColorTransparentMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ForeColorSetMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClockStyleMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StyleDeptMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StyleBorderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TextBorderColorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TextBorderSetColorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TextBorderTransparentMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewInstanceMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

