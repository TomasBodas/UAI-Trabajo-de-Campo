﻿
namespace UAICampo.UI
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.itemLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.itemRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenseManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changelogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupRestoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supervisorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teamManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teamCreationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskCreationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.achievementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrativeOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTask = new System.Windows.Forms.TabPage();
            this.tareasController2 = new UAICampo.UI.Controllers.TareasController();
            this.tabPageLeader = new System.Windows.Forms.TabPage();
            this.equipo_Manager2 = new UAICampo.UI.Equipo_Manager();
            this.tabAchievements = new System.Windows.Forms.TabPage();
            this.achievementController1 = new UAICampo.UI.Controllers.AchievementController();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.languageController1 = new UAICampo.UI.Controllers.LanguageController();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageTask.SuspendLayout();
            this.tabPageLeader.SuspendLayout();
            this.tabAchievements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1700, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemLogin,
            this.itemLogout,
            this.toolStripSeparator1,
            this.itemRegister});
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // itemLogin
            // 
            this.itemLogin.Name = "itemLogin";
            this.itemLogin.Size = new System.Drawing.Size(154, 22);
            this.itemLogin.Text = "Login";
            // 
            // itemLogout
            // 
            this.itemLogout.Name = "itemLogout";
            this.itemLogout.Size = new System.Drawing.Size(154, 22);
            this.itemLogout.Text = "Logout";
            this.itemLogout.Click += new System.EventHandler(this.itemLogout_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(151, 6);
            // 
            // itemRegister
            // 
            this.itemRegister.Name = "itemRegister";
            this.itemRegister.Size = new System.Drawing.Size(154, 22);
            this.itemRegister.Text = "Create account";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 334);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(999, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 20);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileToolStripMenuItem,
            this.administratorToolStripMenuItem,
            this.supervisorToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1007, 24);
            this.menuStrip.TabIndex = 16;
            this.menuStrip.Text = "menuStrip2";
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.profileToolStripMenuItem.Text = "Profile";
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.changePasswordToolStripMenuItem.Text = "Information";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // administratorToolStripMenuItem
            // 
            this.administratorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageEditorToolStripMenuItem,
            this.userManagerToolStripMenuItem,
            this.licenseManagerToolStripMenuItem,
            this.profileManagerToolStripMenuItem,
            this.logToolStripMenuItem,
            this.backupRestoreToolStripMenuItem});
            this.administratorToolStripMenuItem.Name = "administratorToolStripMenuItem";
            this.administratorToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.administratorToolStripMenuItem.Text = "Administrator";
            this.administratorToolStripMenuItem.Visible = false;
            // 
            // languageEditorToolStripMenuItem
            // 
            this.languageEditorToolStripMenuItem.Name = "languageEditorToolStripMenuItem";
            this.languageEditorToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.languageEditorToolStripMenuItem.Text = "Language Editor";
            this.languageEditorToolStripMenuItem.Click += new System.EventHandler(this.languageEditorToolStripMenuItem_Click);
            // 
            // userManagerToolStripMenuItem
            // 
            this.userManagerToolStripMenuItem.Name = "userManagerToolStripMenuItem";
            this.userManagerToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.userManagerToolStripMenuItem.Text = "Profile Manager";
            this.userManagerToolStripMenuItem.Click += new System.EventHandler(this.userManagerToolStripMenuItem_Click);
            // 
            // licenseManagerToolStripMenuItem
            // 
            this.licenseManagerToolStripMenuItem.Name = "licenseManagerToolStripMenuItem";
            this.licenseManagerToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.licenseManagerToolStripMenuItem.Text = "License Manager";
            this.licenseManagerToolStripMenuItem.Click += new System.EventHandler(this.licenseManagerToolStripMenuItem_Click);
            // 
            // profileManagerToolStripMenuItem
            // 
            this.profileManagerToolStripMenuItem.Name = "profileManagerToolStripMenuItem";
            this.profileManagerToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.profileManagerToolStripMenuItem.Text = "User Manager";
            this.profileManagerToolStripMenuItem.Click += new System.EventHandler(this.profileManagerToolStripMenuItem_Click_1);
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eventLogToolStripMenuItem,
            this.changelogToolStripMenuItem});
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            this.logToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.logToolStripMenuItem.Text = "Log";
            this.logToolStripMenuItem.Click += new System.EventHandler(this.logToolStripMenuItem_Click);
            // 
            // eventLogToolStripMenuItem
            // 
            this.eventLogToolStripMenuItem.Name = "eventLogToolStripMenuItem";
            this.eventLogToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.eventLogToolStripMenuItem.Text = "Event Log";
            this.eventLogToolStripMenuItem.Click += new System.EventHandler(this.eventLogToolStripMenuItem_Click);
            // 
            // changelogToolStripMenuItem
            // 
            this.changelogToolStripMenuItem.Name = "changelogToolStripMenuItem";
            this.changelogToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.changelogToolStripMenuItem.Text = "Changelog";
            this.changelogToolStripMenuItem.Click += new System.EventHandler(this.changelogToolStripMenuItem_Click);
            // 
            // backupRestoreToolStripMenuItem
            // 
            this.backupRestoreToolStripMenuItem.Name = "backupRestoreToolStripMenuItem";
            this.backupRestoreToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.backupRestoreToolStripMenuItem.Text = "Backup/Restore";
            this.backupRestoreToolStripMenuItem.Click += new System.EventHandler(this.backupRestoreToolStripMenuItem_Click);
            // 
            // supervisorToolStripMenuItem
            // 
            this.supervisorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.teamManagerToolStripMenuItem,
            this.addNewAccountToolStripMenuItem});
            this.supervisorToolStripMenuItem.Name = "supervisorToolStripMenuItem";
            this.supervisorToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.supervisorToolStripMenuItem.Text = "Options";
            this.supervisorToolStripMenuItem.Visible = false;
            // 
            // teamManagerToolStripMenuItem
            // 
            this.teamManagerToolStripMenuItem.Name = "teamManagerToolStripMenuItem";
            this.teamManagerToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.teamManagerToolStripMenuItem.Text = "Team Manager";
            this.teamManagerToolStripMenuItem.Click += new System.EventHandler(this.teamManagerToolStripMenuItem_Click);
            // 
            // addNewAccountToolStripMenuItem
            // 
            this.addNewAccountToolStripMenuItem.Name = "addNewAccountToolStripMenuItem";
            this.addNewAccountToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.addNewAccountToolStripMenuItem.Text = "Add new account";
            this.addNewAccountToolStripMenuItem.Click += new System.EventHandler(this.addNewAccountToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userManualToolStripMenuItem,
            this.detailsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // userManualToolStripMenuItem
            // 
            this.userManualToolStripMenuItem.Name = "userManualToolStripMenuItem";
            this.userManualToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.userManualToolStripMenuItem.Text = "User Manual";
            this.userManualToolStripMenuItem.Click += new System.EventHandler(this.userManualToolStripMenuItem_Click);
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuToolStripMenuItem,
            this.teamCreationToolStripMenuItem,
            this.taskCreationToolStripMenuItem,
            this.achievementsToolStripMenuItem,
            this.administrativeOptionsToolStripMenuItem});
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.detailsToolStripMenuItem.Text = "Details";
            // 
            // mainMenuToolStripMenuItem
            // 
            this.mainMenuToolStripMenuItem.Name = "mainMenuToolStripMenuItem";
            this.mainMenuToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.mainMenuToolStripMenuItem.Text = "1. Main Menu";
            this.mainMenuToolStripMenuItem.Click += new System.EventHandler(this.mainMenuToolStripMenuItem_Click);
            // 
            // teamCreationToolStripMenuItem
            // 
            this.teamCreationToolStripMenuItem.Name = "teamCreationToolStripMenuItem";
            this.teamCreationToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.teamCreationToolStripMenuItem.Text = "2. Team Creation";
            this.teamCreationToolStripMenuItem.Click += new System.EventHandler(this.teamCreationToolStripMenuItem_Click);
            // 
            // taskCreationToolStripMenuItem
            // 
            this.taskCreationToolStripMenuItem.Name = "taskCreationToolStripMenuItem";
            this.taskCreationToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.taskCreationToolStripMenuItem.Text = "3. Task Creation";
            this.taskCreationToolStripMenuItem.Click += new System.EventHandler(this.taskCreationToolStripMenuItem_Click);
            // 
            // achievementsToolStripMenuItem
            // 
            this.achievementsToolStripMenuItem.Name = "achievementsToolStripMenuItem";
            this.achievementsToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.achievementsToolStripMenuItem.Text = "4. Achievements";
            this.achievementsToolStripMenuItem.Click += new System.EventHandler(this.achievementsToolStripMenuItem_Click);
            // 
            // administrativeOptionsToolStripMenuItem
            // 
            this.administrativeOptionsToolStripMenuItem.Name = "administrativeOptionsToolStripMenuItem";
            this.administrativeOptionsToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.administrativeOptionsToolStripMenuItem.Text = "5. Administrative Options";
            this.administrativeOptionsToolStripMenuItem.Click += new System.EventHandler(this.administrativeOptionsToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageTask);
            this.tabControl1.Controls.Add(this.tabPageLeader);
            this.tabControl1.Controls.Add(this.tabAchievements);
            this.tabControl1.Location = new System.Drawing.Point(12, 37);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(957, 385);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPageTask
            // 
            this.tabPageTask.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tabPageTask.BackgroundImage = global::UAICampo.UI.Properties.Resources.background;
            this.tabPageTask.Controls.Add(this.tareasController2);
            this.tabPageTask.Location = new System.Drawing.Point(4, 22);
            this.tabPageTask.Name = "tabPageTask";
            this.tabPageTask.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTask.Size = new System.Drawing.Size(949, 359);
            this.tabPageTask.TabIndex = 0;
            this.tabPageTask.Text = "My Tasks";
            // 
            // tareasController2
            // 
            this.tareasController2.BackColor = System.Drawing.SystemColors.Control;
            this.tareasController2.Location = new System.Drawing.Point(24, 17);
            this.tareasController2.Name = "tareasController2";
            this.tareasController2.Size = new System.Drawing.Size(896, 326);
            this.tareasController2.TabIndex = 0;
            // 
            // tabPageLeader
            // 
            this.tabPageLeader.BackgroundImage = global::UAICampo.UI.Properties.Resources.background;
            this.tabPageLeader.Controls.Add(this.equipo_Manager2);
            this.tabPageLeader.Location = new System.Drawing.Point(4, 22);
            this.tabPageLeader.Name = "tabPageLeader";
            this.tabPageLeader.Size = new System.Drawing.Size(949, 359);
            this.tabPageLeader.TabIndex = 1;
            this.tabPageLeader.Text = "Team Leader";
            this.tabPageLeader.UseVisualStyleBackColor = true;
            // 
            // equipo_Manager2
            // 
            this.equipo_Manager2.BackColor = System.Drawing.SystemColors.Control;
            this.equipo_Manager2.Location = new System.Drawing.Point(24, 15);
            this.equipo_Manager2.Name = "equipo_Manager2";
            this.equipo_Manager2.Size = new System.Drawing.Size(238, 169);
            this.equipo_Manager2.TabIndex = 0;
            // 
            // tabAchievements
            // 
            this.tabAchievements.BackgroundImage = global::UAICampo.UI.Properties.Resources.background;
            this.tabAchievements.Controls.Add(this.achievementController1);
            this.tabAchievements.Location = new System.Drawing.Point(4, 22);
            this.tabAchievements.Name = "tabAchievements";
            this.tabAchievements.Padding = new System.Windows.Forms.Padding(3);
            this.tabAchievements.Size = new System.Drawing.Size(949, 359);
            this.tabAchievements.TabIndex = 2;
            this.tabAchievements.Text = "Achievements";
            this.tabAchievements.UseVisualStyleBackColor = true;
            // 
            // achievementController1
            // 
            this.achievementController1.Location = new System.Drawing.Point(76, 60);
            this.achievementController1.Name = "achievementController1";
            this.achievementController1.Size = new System.Drawing.Size(279, 141);
            this.achievementController1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UAICampo.UI.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(284, 93);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(406, 229);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // languageController1
            // 
            this.languageController1.Location = new System.Drawing.Point(0, 424);
            this.languageController1.Name = "languageController1";
            this.languageController1.Size = new System.Drawing.Size(36, 32);
            this.languageController1.TabIndex = 20;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1007, 452);
            this.Controls.Add(this.languageController1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageTask.ResumeLayout(false);
            this.tabPageLeader.ResumeLayout(false);
            this.tabAchievements.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemLogin;
        private System.Windows.Forms.ToolStripMenuItem itemLogout;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem itemRegister;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageEditorToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTask;
        private System.Windows.Forms.ToolStripMenuItem userManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licenseManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private Controllers.LanguageController languageController2;
        private System.Windows.Forms.TabPage tabPageLeader;
        private System.Windows.Forms.ToolStripMenuItem supervisorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teamManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileManagerToolStripMenuItem;
        private Equipo_Manager equipo_Manager1;
        private Controllers.TareasController tareasController1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupRestoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changelogToolStripMenuItem;
        private System.Windows.Forms.TabPage tabAchievements;
        private Controllers.AchievementController achievementController1;
        private Controllers.TareasController tareasController2;
        private Equipo_Manager equipo_Manager2;
        private Controllers.LanguageController languageController1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teamCreationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taskCreationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem achievementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrativeOptionsToolStripMenuItem;
    }
}