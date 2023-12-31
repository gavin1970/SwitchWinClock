﻿using System;
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
            this.StyleShadowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StyleBorderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.StyleCounterMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FontSetupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.AlwaysOnTopMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.WinAlignmentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WinAlignManualMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WinAlignTopLeftMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WinAlignTopCenterMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WinAlignTopRightMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WinAlignMiddleLeftMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WinAlignMiddleCenterMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WinAlignMiddleRightMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WinAlignBottomLeftMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WinAlignBottomCenterMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WinAlignBottomRightMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DateFormattingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomDateFormatMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomDateTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.CounterFormattingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CounterYMDHMSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VisualSetupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ForeColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ForeColorSetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ForeColorTransparentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FontBorderColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextBorderSetColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextBorderTransparentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BackColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BackColorSetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BackColorTransparentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BorderColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BorderColorSetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BorderColorTransparentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.AvailableInstanceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RenameInstanceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteInstanceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FontBGImageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingsContextMenu
            // 
            this.SettingsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClockStyleMenuItem,
            this.FontSetupMenuItem,
            this.toolStripSeparator3,
            this.AlwaysOnTopMenuItem,
            this.toolStripSeparator4,
            this.WinAlignmentMenuItem,
            this.DateFormattingMenuItem,
            this.CounterFormattingMenuItem,
            this.VisualSetupMenuItem,
            this.TextDepthpMenuItem,
            this.ToolStripSeparator1,
            this.NewInstanceMenuItem,
            this.AvailableInstanceMenuItem,
            this.RenameInstanceMenuItem,
            this.DeleteInstanceMenuItem,
            this.toolStripSeparator2,
            this.ExitAllMenuItem,
            this.ExitMenuItem});
            this.SettingsContextMenu.Name = "SettingsContextMenu";
            this.SettingsContextMenu.Size = new System.Drawing.Size(181, 358);
            this.SettingsContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.SettingsContextMenu_Opening);
            this.SettingsContextMenu.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            // 
            // ClockStyleMenuItem
            // 
            this.ClockStyleMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StyleDeptMenuItem,
            this.StyleShadowMenuItem,
            this.StyleBorderMenuItem,
            this.toolStripSeparator5,
            this.StyleCounterMenuItem});
            this.ClockStyleMenuItem.Name = "ClockStyleMenuItem";
            this.ClockStyleMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ClockStyleMenuItem.Text = "Clock &Style";
            // 
            // StyleDeptMenuItem
            // 
            this.StyleDeptMenuItem.CheckOnClick = true;
            this.StyleDeptMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StyleDeptMenuItem.Name = "StyleDeptMenuItem";
            this.StyleDeptMenuItem.Size = new System.Drawing.Size(141, 22);
            this.StyleDeptMenuItem.Text = "&Depth";
            this.StyleDeptMenuItem.Click += new System.EventHandler(this.StyleDeptMenuItem_Click);
            // 
            // StyleShadowMenuItem
            // 
            this.StyleShadowMenuItem.CheckOnClick = true;
            this.StyleShadowMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StyleShadowMenuItem.Name = "StyleShadowMenuItem";
            this.StyleShadowMenuItem.Size = new System.Drawing.Size(141, 22);
            this.StyleShadowMenuItem.Text = "&Shadowed";
            this.StyleShadowMenuItem.Click += new System.EventHandler(this.StyleShadowMenuItem_Click);
            // 
            // StyleBorderMenuItem
            // 
            this.StyleBorderMenuItem.CheckOnClick = true;
            this.StyleBorderMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StyleBorderMenuItem.Name = "StyleBorderMenuItem";
            this.StyleBorderMenuItem.Size = new System.Drawing.Size(141, 22);
            this.StyleBorderMenuItem.Text = "&Border";
            this.StyleBorderMenuItem.Click += new System.EventHandler(this.StyleBorderMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(138, 6);
            this.toolStripSeparator5.Visible = false;
            // 
            // StyleCounterMenuItem
            // 
            this.StyleCounterMenuItem.CheckOnClick = true;
            this.StyleCounterMenuItem.Name = "StyleCounterMenuItem";
            this.StyleCounterMenuItem.Size = new System.Drawing.Size(141, 22);
            this.StyleCounterMenuItem.Text = "&Count Down";
            this.StyleCounterMenuItem.Visible = false;
            this.StyleCounterMenuItem.Click += new System.EventHandler(this.StyleCounterMenuItem_Click);
            // 
            // FontSetupMenuItem
            // 
            this.FontSetupMenuItem.Name = "FontSetupMenuItem";
            this.FontSetupMenuItem.Size = new System.Drawing.Size(180, 22);
            this.FontSetupMenuItem.Text = "&Font Settings";
            this.FontSetupMenuItem.Click += new System.EventHandler(this.FontSetupMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // AlwaysOnTopMenuItem
            // 
            this.AlwaysOnTopMenuItem.CheckOnClick = true;
            this.AlwaysOnTopMenuItem.Name = "AlwaysOnTopMenuItem";
            this.AlwaysOnTopMenuItem.Size = new System.Drawing.Size(180, 22);
            this.AlwaysOnTopMenuItem.Text = "&Always On Top";
            this.AlwaysOnTopMenuItem.Click += new System.EventHandler(this.AlwaysOnTopMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
            // 
            // WinAlignmentMenuItem
            // 
            this.WinAlignmentMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WinAlignManualMenuItem,
            this.WinAlignTopLeftMenuItem,
            this.WinAlignTopCenterMenuItem,
            this.WinAlignTopRightMenuItem,
            this.WinAlignMiddleLeftMenuItem,
            this.WinAlignMiddleCenterMenuItem,
            this.WinAlignMiddleRightMenuItem,
            this.WinAlignBottomLeftMenuItem,
            this.WinAlignBottomCenterMenuItem,
            this.WinAlignBottomRightMenuItem});
            this.WinAlignmentMenuItem.Name = "WinAlignmentMenuItem";
            this.WinAlignmentMenuItem.Size = new System.Drawing.Size(180, 22);
            this.WinAlignmentMenuItem.Text = "&Window Alignment";
            // 
            // WinAlignManualMenuItem
            // 
            this.WinAlignManualMenuItem.CheckOnClick = true;
            this.WinAlignManualMenuItem.Name = "WinAlignManualMenuItem";
            this.WinAlignManualMenuItem.Size = new System.Drawing.Size(152, 22);
            this.WinAlignManualMenuItem.Text = "&Manual";
            this.WinAlignManualMenuItem.Click += new System.EventHandler(this.WinAlignMenuItems_Click);
            // 
            // WinAlignTopLeftMenuItem
            // 
            this.WinAlignTopLeftMenuItem.CheckOnClick = true;
            this.WinAlignTopLeftMenuItem.Name = "WinAlignTopLeftMenuItem";
            this.WinAlignTopLeftMenuItem.Size = new System.Drawing.Size(152, 22);
            this.WinAlignTopLeftMenuItem.Text = "&Top Left";
            this.WinAlignTopLeftMenuItem.Click += new System.EventHandler(this.WinAlignMenuItems_Click);
            // 
            // WinAlignTopCenterMenuItem
            // 
            this.WinAlignTopCenterMenuItem.CheckOnClick = true;
            this.WinAlignTopCenterMenuItem.Name = "WinAlignTopCenterMenuItem";
            this.WinAlignTopCenterMenuItem.Size = new System.Drawing.Size(152, 22);
            this.WinAlignTopCenterMenuItem.Text = "&Top Center";
            this.WinAlignTopCenterMenuItem.Click += new System.EventHandler(this.WinAlignMenuItems_Click);
            // 
            // WinAlignTopRightMenuItem
            // 
            this.WinAlignTopRightMenuItem.CheckOnClick = true;
            this.WinAlignTopRightMenuItem.Name = "WinAlignTopRightMenuItem";
            this.WinAlignTopRightMenuItem.Size = new System.Drawing.Size(152, 22);
            this.WinAlignTopRightMenuItem.Text = "&Top Right";
            this.WinAlignTopRightMenuItem.Click += new System.EventHandler(this.WinAlignMenuItems_Click);
            // 
            // WinAlignMiddleLeftMenuItem
            // 
            this.WinAlignMiddleLeftMenuItem.CheckOnClick = true;
            this.WinAlignMiddleLeftMenuItem.Name = "WinAlignMiddleLeftMenuItem";
            this.WinAlignMiddleLeftMenuItem.Size = new System.Drawing.Size(152, 22);
            this.WinAlignMiddleLeftMenuItem.Text = "&Middle Left";
            this.WinAlignMiddleLeftMenuItem.Click += new System.EventHandler(this.WinAlignMenuItems_Click);
            // 
            // WinAlignMiddleCenterMenuItem
            // 
            this.WinAlignMiddleCenterMenuItem.CheckOnClick = true;
            this.WinAlignMiddleCenterMenuItem.Name = "WinAlignMiddleCenterMenuItem";
            this.WinAlignMiddleCenterMenuItem.Size = new System.Drawing.Size(152, 22);
            this.WinAlignMiddleCenterMenuItem.Text = "&Middle Center";
            this.WinAlignMiddleCenterMenuItem.Click += new System.EventHandler(this.WinAlignMenuItems_Click);
            // 
            // WinAlignMiddleRightMenuItem
            // 
            this.WinAlignMiddleRightMenuItem.CheckOnClick = true;
            this.WinAlignMiddleRightMenuItem.Name = "WinAlignMiddleRightMenuItem";
            this.WinAlignMiddleRightMenuItem.Size = new System.Drawing.Size(152, 22);
            this.WinAlignMiddleRightMenuItem.Text = "&Middle Right";
            this.WinAlignMiddleRightMenuItem.Click += new System.EventHandler(this.WinAlignMenuItems_Click);
            // 
            // WinAlignBottomLeftMenuItem
            // 
            this.WinAlignBottomLeftMenuItem.CheckOnClick = true;
            this.WinAlignBottomLeftMenuItem.Name = "WinAlignBottomLeftMenuItem";
            this.WinAlignBottomLeftMenuItem.Size = new System.Drawing.Size(152, 22);
            this.WinAlignBottomLeftMenuItem.Text = "&Bottom Left";
            this.WinAlignBottomLeftMenuItem.Click += new System.EventHandler(this.WinAlignMenuItems_Click);
            // 
            // WinAlignBottomCenterMenuItem
            // 
            this.WinAlignBottomCenterMenuItem.CheckOnClick = true;
            this.WinAlignBottomCenterMenuItem.Name = "WinAlignBottomCenterMenuItem";
            this.WinAlignBottomCenterMenuItem.Size = new System.Drawing.Size(152, 22);
            this.WinAlignBottomCenterMenuItem.Text = "&Bottom Center";
            this.WinAlignBottomCenterMenuItem.Click += new System.EventHandler(this.WinAlignMenuItems_Click);
            // 
            // WinAlignBottomRightMenuItem
            // 
            this.WinAlignBottomRightMenuItem.CheckOnClick = true;
            this.WinAlignBottomRightMenuItem.Name = "WinAlignBottomRightMenuItem";
            this.WinAlignBottomRightMenuItem.Size = new System.Drawing.Size(152, 22);
            this.WinAlignBottomRightMenuItem.Text = "&Bottom Right";
            this.WinAlignBottomRightMenuItem.Click += new System.EventHandler(this.WinAlignMenuItems_Click);
            // 
            // DateFormattingMenuItem
            // 
            this.DateFormattingMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomDateFormatMenuItem,
            this.toolStripSeparator6});
            this.DateFormattingMenuItem.Name = "DateFormattingMenuItem";
            this.DateFormattingMenuItem.Size = new System.Drawing.Size(180, 22);
            this.DateFormattingMenuItem.Text = "&Date Formating";
            // 
            // CustomDateFormatMenuItem
            // 
            this.CustomDateFormatMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomDateTextBox});
            this.CustomDateFormatMenuItem.Name = "CustomDateFormatMenuItem";
            this.CustomDateFormatMenuItem.Size = new System.Drawing.Size(157, 22);
            this.CustomDateFormatMenuItem.Text = "&Custom Format";
            this.CustomDateFormatMenuItem.ToolTipText = "Pressing Enter will save.";
            // 
            // CustomDateTextBox
            // 
            this.CustomDateTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CustomDateTextBox.Name = "CustomDateTextBox";
            this.CustomDateTextBox.Size = new System.Drawing.Size(300, 23);
            this.CustomDateTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CustomDateTextBox_KeyUp);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(154, 6);
            // 
            // CounterFormattingMenuItem
            // 
            this.CounterFormattingMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CounterYMDHMSMenuItem});
            this.CounterFormattingMenuItem.Name = "CounterFormattingMenuItem";
            this.CounterFormattingMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CounterFormattingMenuItem.Text = "&Counter Formatting";
            this.CounterFormattingMenuItem.Visible = false;
            // 
            // CounterYMDHMSMenuItem
            // 
            this.CounterYMDHMSMenuItem.Name = "CounterYMDHMSMenuItem";
            this.CounterYMDHMSMenuItem.Size = new System.Drawing.Size(316, 22);
            this.CounterYMDHMSMenuItem.Tag = "yy(\\y), MM(\\mo), dd(\\d), HH(h), mm(\\mi), ss(\\s)";
            this.CounterYMDHMSMenuItem.Text = "Years, Months, Days, Hours, Minutes, Seconds";
            // 
            // VisualSetupMenuItem
            // 
            this.VisualSetupMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ForeColorMenuItem,
            this.FontBorderColorMenuItem,
            this.BackColorMenuItem,
            this.BorderColorMenuItem});
            this.VisualSetupMenuItem.Name = "VisualSetupMenuItem";
            this.VisualSetupMenuItem.Size = new System.Drawing.Size(180, 22);
            this.VisualSetupMenuItem.Text = "&Visual Settings";
            // 
            // ForeColorMenuItem
            // 
            this.ForeColorMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ForeColorSetMenuItem,
            this.ForeColorTransparentMenuItem,
            this.FontBGImageMenuItem});
            this.ForeColorMenuItem.Name = "ForeColorMenuItem";
            this.ForeColorMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ForeColorMenuItem.Text = "&Font";
            // 
            // ForeColorSetMenuItem
            // 
            this.ForeColorSetMenuItem.Name = "ForeColorSetMenuItem";
            this.ForeColorSetMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ForeColorSetMenuItem.Text = "&Pick Color";
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
            // FontBorderColorMenuItem
            // 
            this.FontBorderColorMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TextBorderSetColorMenuItem,
            this.TextBorderTransparentMenuItem});
            this.FontBorderColorMenuItem.Name = "FontBorderColorMenuItem";
            this.FontBorderColorMenuItem.Size = new System.Drawing.Size(180, 22);
            this.FontBorderColorMenuItem.Text = "&Font Border";
            // 
            // TextBorderSetColorMenuItem
            // 
            this.TextBorderSetColorMenuItem.Name = "TextBorderSetColorMenuItem";
            this.TextBorderSetColorMenuItem.Size = new System.Drawing.Size(167, 22);
            this.TextBorderSetColorMenuItem.Text = "&Pick Color";
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
            // BackColorMenuItem
            // 
            this.BackColorMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BackColorSetMenuItem,
            this.BackColorTransparentMenuItem});
            this.BackColorMenuItem.Name = "BackColorMenuItem";
            this.BackColorMenuItem.Size = new System.Drawing.Size(180, 22);
            this.BackColorMenuItem.Text = "For&m";
            // 
            // BackColorSetMenuItem
            // 
            this.BackColorSetMenuItem.Name = "BackColorSetMenuItem";
            this.BackColorSetMenuItem.Size = new System.Drawing.Size(167, 22);
            this.BackColorSetMenuItem.Text = "&Pick Color";
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
            this.BorderColorMenuItem.Text = "For&m Border";
            // 
            // BorderColorSetMenuItem
            // 
            this.BorderColorSetMenuItem.Name = "BorderColorSetMenuItem";
            this.BorderColorSetMenuItem.Size = new System.Drawing.Size(167, 22);
            this.BorderColorSetMenuItem.Text = "&Pick Color";
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
            this.TextDepthpMenuItem.Size = new System.Drawing.Size(180, 22);
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
            this.ToolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // NewInstanceMenuItem
            // 
            this.NewInstanceMenuItem.Name = "NewInstanceMenuItem";
            this.NewInstanceMenuItem.Size = new System.Drawing.Size(180, 22);
            this.NewInstanceMenuItem.Text = "&New Instance";
            this.NewInstanceMenuItem.Click += new System.EventHandler(this.NewInstanceMenuItem_Click);
            // 
            // AvailableInstanceMenuItem
            // 
            this.AvailableInstanceMenuItem.Name = "AvailableInstanceMenuItem";
            this.AvailableInstanceMenuItem.Size = new System.Drawing.Size(180, 22);
            this.AvailableInstanceMenuItem.Text = "A&vailable Instance";
            // 
            // RenameInstanceMenuItem
            // 
            this.RenameInstanceMenuItem.Name = "RenameInstanceMenuItem";
            this.RenameInstanceMenuItem.Size = new System.Drawing.Size(180, 22);
            this.RenameInstanceMenuItem.Text = "&Rename Instance";
            this.RenameInstanceMenuItem.Click += new System.EventHandler(this.RenameInstanceMenuItem_Click);
            // 
            // DeleteInstanceMenuItem
            // 
            this.DeleteInstanceMenuItem.Name = "DeleteInstanceMenuItem";
            this.DeleteInstanceMenuItem.Size = new System.Drawing.Size(180, 22);
            this.DeleteInstanceMenuItem.Text = "D&elete Instance";
            this.DeleteInstanceMenuItem.Click += new System.EventHandler(this.DeleteInstanceMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // ExitAllMenuItem
            // 
            this.ExitAllMenuItem.Name = "ExitAllMenuItem";
            this.ExitAllMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ExitAllMenuItem.Text = "E&xit All Instances";
            this.ExitAllMenuItem.Click += new System.EventHandler(this.ExitAllMenuItem_Click);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ExitMenuItem.Text = "E&xit";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // FontBGImageMenuItem
            // 
            this.FontBGImageMenuItem.Name = "FontBGImageMenuItem";
            this.FontBGImageMenuItem.Size = new System.Drawing.Size(180, 22);
            this.FontBGImageMenuItem.Text = "&Background Image";
            this.FontBGImageMenuItem.Click += new System.EventHandler(this.FontBGImageMenuItem_Click);
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
            this.LostFocus += new System.EventHandler(this.Form_LostFocus);
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
        private System.Windows.Forms.ToolStripMenuItem VisualSetupMenuItem;
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
        private System.Windows.Forms.ToolStripTextBox CustomDateTextBox;
        private System.Windows.Forms.ToolStripMenuItem ForeColorTransparentMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ForeColorSetMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClockStyleMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StyleDeptMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StyleBorderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FontBorderColorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TextBorderSetColorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TextBorderTransparentMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewInstanceMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem WinAlignmentMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WinAlignManualMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WinAlignTopLeftMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WinAlignTopCenterMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WinAlignTopRightMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WinAlignMiddleLeftMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WinAlignMiddleCenterMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WinAlignMiddleRightMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WinAlignBottomLeftMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WinAlignBottomCenterMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WinAlignBottomRightMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem AlwaysOnTopMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem DeleteInstanceMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem StyleCounterMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CounterFormattingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CounterYMDHMSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AvailableInstanceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RenameInstanceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StyleShadowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitAllMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem FontBGImageMenuItem;
    }
}

