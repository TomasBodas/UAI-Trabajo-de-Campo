﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UAICampo.Abstractions;
using UAICampo.Abstractions.Observer;
using UAICampo.BLL;
using UAICampo.Services;
using UAICampo.Services.Composite;
using UAICampo.Services.Observer;
using UAICampo.UI.Administrator;

namespace UAICampo.UI
{
    public partial class frmMain : Form, IObserver
    {
        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();

        frmLanguageEditor frmLanguageEditor = null;
        frmLicenseManager frmLicenseManager = null;
        frmProfileManager frmProfileManager = null;
        FrmRegister FrmRegister = null;
        frmEquipo frmEquipo = null;
        frmUserManager frmUserManager = null;
        frmProfile frmChangePassword = null;
        frmBitacora frmBitacora = null;
        frmChangelog frmChangelog = null;
        frmBackup frmBackup = null;
        BLL_SessionManager sessionBLL;
        BLL_LanguageManager languageBLL;
        Language selectedLanguage;

        public frmMain()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.w;
            sessionBLL = new BLL_SessionManager();
            languageBLL = new BLL_LanguageManager();

            if (UserInstance.getInstance().userIsLoggedIn())
            {
            }

            SetControllerTags();

            ValidateForm();

            //subscribe form as observer to user subject
            if (UserInstance.getInstance().user != null)
            {
                UserInstance.getInstance().user.Add(this);
                Update();
            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }
        private void itemLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(selectedLanguage.translate("Confirmation"), selectedLanguage.translate("Confirm"), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sessionBLL.Logout();
                ValidateForm();
            }
        }

        public void Update()
        {
            selectedLanguage = UserInstance.getInstance().user.language;

            languageBLL.loadLanguageWords(selectedLanguage);

            foreach (var controller in controllers)
            {
                try
                {
                    if (controller.Key.Word != null)
                    {
                        KeyValuePair<string, string> textValue = selectedLanguage.words.SingleOrDefault(kvp => kvp.Key == controller.Key.Word);
                        if (textValue.Value != null)
                        {
                            controller.Value.Text = textValue.Value;
                        }
                        else
                        {
                            controller.Value.Text = "Not found";
                        }

                    }
                }
                catch (Exception)
                {}
            }

            profileToolStripMenuItem.Text = selectedLanguage.translate("Profile");
            helpToolStripMenuItem.Text = selectedLanguage.translate("Help");
            userManualToolStripMenuItem.Text = selectedLanguage.translate("UserManual");
            detailsToolStripMenuItem.Text = selectedLanguage.translate("Details");
            mainMenuToolStripMenuItem.Text = selectedLanguage.translate("MainMenu");
            teamCreationToolStripMenuItem.Text = selectedLanguage.translate("TeamCreation");
            taskCreationToolStripMenuItem.Text = selectedLanguage.translate("TaskCreation");
            achievementsToolStripMenuItem.Text = selectedLanguage.translate("Achievements");
            administrativeOptionsToolStripMenuItem.Text = selectedLanguage.translate("Administrator");
            administratorToolStripMenuItem.Text = selectedLanguage.translate("Administrator");
            changePasswordToolStripMenuItem.Text = selectedLanguage.translate("Information");
            languageEditorToolStripMenuItem.Text = selectedLanguage.translate("LanguageEditor");
            licenseManagerToolStripMenuItem.Text = selectedLanguage.translate("LicenseManager");
            userManagerToolStripMenuItem.Text = selectedLanguage.translate("ProfileManager");
            logoutToolStripMenuItem.Text = selectedLanguage.translate("Logout");
            profileManagerToolStripMenuItem.Text = selectedLanguage.translate("UserManager");
            supervisorToolStripMenuItem.Text = selectedLanguage.translate("Options");
            teamManagerToolStripMenuItem.Text = selectedLanguage.translate("TeamManager");
            addNewAccountToolStripMenuItem.Text = selectedLanguage.translate("AddAccount");
            tabPageTask.Text = selectedLanguage.translate("MyTasks");
            tabPageLeader.Text = selectedLanguage.translate("TeamSettings");
            tabAchievements.Text = selectedLanguage.translate("Achievements");
        }
        private void ValidateForm()
        {
            try
            {

                List<Services.Composite.Component> licenses = new List<Services.Composite.Component>();
                IEquipo selectedEquipo = BLL_EquipoManager.getUserTeam(UserInstance.getInstance().user);
                licenses = UserInstance.getInstance().user.getAllLicenses();
                var adminCheck = licenses.Find(x => x.Id == 2);
                var supervisorCheck = licenses.Find(x => x.Id == 16);
                var teamOwnerCheck = licenses.Find(x => x.Id == 17);
                if (selectedEquipo.Id == 0)
                {
                    tabControl1.Visible = false;
                }
                if (supervisorCheck != null)
                {
                    supervisorToolStripMenuItem.Visible = true;
                }
                if (adminCheck != null)
                {
                    administratorToolStripMenuItem.Visible = true;
                    supervisorToolStripMenuItem.Visible = true;
                }
                if (teamOwnerCheck == null)
                {
                    tabControl1.TabPages.Remove(tabPageLeader);
                }
                foreach (var controller in controllers)
                {
                    if (controller.Key.LicenseId == 0 || licenses.Any(t => t.Id == controller.Key.LicenseId))
                    {
                        controller.Value.Visible = true;
                    }

                    else
                    {
                        controller.Value.Visible = false;
                    }
                }
            }
            catch (Exception)
            { }
        }
        private void SetControllerTags()
        {
            //In here, we set each controller tag list.
            //This list wil be made out of keyvaluepairs, with a controller, and a tag
            //Each Tag will be made out of two values
            //First value: license required for it to show up to the user
            //Second value: Word Tag, used for language runtime changes

            //General controllers------------------------------------------------------------------------------------
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Main"), this));
            //-------------------------------------------------------------------------------------------------------

        }
        private void languageController1_Load(object sender, EventArgs e)
        {

        }

        private void user_Manager1_Load(object sender, EventArgs e)
        {

        }

        #region Form Buttons
        private void languageEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmLanguageEditor == null)
            {
                frmLanguageEditor = new frmLanguageEditor();
                frmLanguageEditor.FormClosed += new FormClosedEventHandler(frmLanguage_FormClosed);
                frmLanguageEditor.Show();
            }
            else
            {
                frmLanguageEditor.BringToFront();
            }
        }

        private void userManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmUserManager == null)
            {
                frmUserManager = new frmUserManager();
                frmUserManager.FormClosed += new FormClosedEventHandler(frmUser_FormClosed);
                frmUserManager.Show();
            }
            else
            {
                frmUserManager.BringToFront();
            }
        }

        private void profileManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmProfileManager == null)
            {
                frmProfileManager = new frmProfileManager();
                frmProfileManager.FormClosed += new FormClosedEventHandler(frmProfile_FormClosed);
                frmProfileManager.Show();
            }
            else
            {
                frmProfileManager.BringToFront();
            }
        }

        private void licenseManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmLicenseManager == null)
            {
                frmLicenseManager = new frmLicenseManager();
                frmLicenseManager.FormClosed += new FormClosedEventHandler(frmLicense_FormClosed);
                frmLicenseManager.Show();
            }
            else
            {
                frmLicenseManager.BringToFront();
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmChangePassword == null)
            {
                frmChangePassword = new frmProfile();
                frmChangePassword.FormClosed += new FormClosedEventHandler(frmPassword_FormClosed);
                frmChangePassword.Show();
            }
            else
            {
                frmChangePassword.BringToFront();
            }
        }

        private void teamManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmEquipo == null)
            {
                frmEquipo = new frmEquipo();
                frmEquipo.FormClosed += new FormClosedEventHandler(frmEquipo_FormClosed);
                frmEquipo.Show();
            }
            else
            {
                frmEquipo.BringToFront();
            }
        }

        private void addNewAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FrmRegister == null)
            {
                FrmRegister = new FrmRegister();
                FrmRegister.FormClosed += new FormClosedEventHandler(FrmRegister_FormClosed);
                FrmRegister.Show();
            }
            else
            {
                FrmRegister.BringToFront();
            }
        }

        private void FrmRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmRegister = null;
        }

        private void frmEquipo_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmEquipo = null;
        }
        private void frmUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmUserManager = null;
        }

        private void frmProfile_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmProfileManager = null;
        }

        private void frmLicense_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLicenseManager = null;
        }

        private void frmPassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmChangePassword = null;
        }
        private void frmLanguage_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLanguageEditor = null;
        }
        private void frmBitacora_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmBitacora = null;
        }
        private void frmChangelog_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmChangelog = null;
        }
        private void frmBackup_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmBackup = null;
        }
        #endregion

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserInstance.getInstance().userIsLoggedIn())
            {
                if (MessageBox.Show(selectedLanguage.translate("Confirmation"), selectedLanguage.translate("Confirm"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    sessionBLL.Logout();
                    this.Close();
                    frmLogin login = new frmLogin();
                    for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                    {
                        if (Application.OpenForms[i].Name != "frmLogin")
                            Application.OpenForms[i].Close();
                    }
                    login.Show();
                }
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (UserInstance.getInstance().user != null)
            {
                if (MessageBox.Show(selectedLanguage.translate("Confirmation"), selectedLanguage.translate("Confirm"), MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void profileManagerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (frmProfileManager == null)
            {
                frmProfileManager = new frmProfileManager();
                frmProfileManager.FormClosed += new FormClosedEventHandler(frmProfile_FormClosed);
                frmProfileManager.Show();
            }
            else
            {
                frmProfileManager.BringToFront();
            }
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void backupRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmBackup == null)
            {
                frmBackup = new frmBackup();
                frmBackup.FormClosed += new FormClosedEventHandler(frmBackup_FormClosed);
                frmBackup.Show();
            }
            else
            {
                frmBackup.BringToFront();
            }
        }

        private void eventLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmBitacora == null)
            {
                frmBitacora = new frmBitacora();
                frmBitacora.FormClosed += new FormClosedEventHandler(frmBitacora_FormClosed);
                frmBitacora.Show();
            }
            else
            {
                frmBitacora.BringToFront();
            }
        }

        private void changelogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmChangelog == null)
            {
                frmChangelog = new frmChangelog();
                frmChangelog.FormClosed += new FormClosedEventHandler(frmChangelog_FormClosed);
                frmChangelog.Show();
            }
            else
            {
                frmChangelog.BringToFront();
            }
        }

        String ruta = Application.StartupPath.ToString();
        private void userManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(ruta + "\\Ayuda\\Manual De Apoyo.pdf");
        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(ruta + "\\Ayuda\\1. Main Menu.pdf");
        }

        private void teamCreationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(ruta + "\\Ayuda\\2. Team Creation.pdf");
        }

        private void taskCreationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(ruta + "\\Ayuda\\3. Task Creation.pdf");
        }

        private void achievementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(ruta + "\\Ayuda\\4. Achievements.pdf");
        }

        private void administrativeOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(ruta + "\\Ayuda\\5. Administrator.pdf");
        }
    }
}
