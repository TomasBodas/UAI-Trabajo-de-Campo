using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UAICampo.Abstractions.Observer;
using UAICampo.BLL;
using UAICampo.Services;
using UAICampo.Services.Composite;
using UAICampo.Services.Observer;

namespace UAICampo.UI
{
    public partial class frmMain : Form, IObserver
    {
        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();

        Profile userSetProfile;
        frmLanguageEditor frmLanguageEditor = null;
        frmLicenseManager frmLicenseManager = null;
        frmProfileManager frmProfileManager = null;
        frmUserManager frmUserManager = null;
        frmChangePassword frmChangePassword = null;
        BLL_SessionManager sessionBLL;
        BLL_LanguageManager languageBLL;
        Language selectedLanguage;

        public frmMain()
        {
            InitializeComponent();
        
            sessionBLL = new BLL_SessionManager();
            languageBLL = new BLL_LanguageManager();

            if (UserInstance.getInstance().userIsLoggedIn())
            {
                userSetProfile = UserInstance.getInstance().user.profileList[0];
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
        private void button3_Click(object sender, EventArgs e)
        {
            if (UserInstance.getInstance().userIsLoggedIn())
            {
                if (MessageBox.Show(selectedLanguage.translate("Confirmation"), selectedLanguage.translate("Confirm"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    sessionBLL.Logout();
                    this.Close();
                    frmLogin login = new frmLogin();
                    login.Show();
                }
            }
            else
            {
                button_logout.Enabled = false;
            }
        }
        private bool isWindowOpen(string name)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm != null && frm.Name == name)
                    return true;
            }

            return false;
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
        }
        private void ValidateForm()
        {
            try
            {
                if (UserInstance.getInstance().userIsLoggedIn())
                {
                    this.label1.Text = UserInstance.getInstance().user.Id.ToString();
                    this.label2.Text = UserInstance.getInstance().user.Username.ToString();
                    this.label3.Text = UserInstance.getInstance().user.Email.ToString();
                    this.label4.Text = UserInstance.getInstance().user.IsBlocked.ToString();
                    this.label5.Text = UserInstance.getInstance().user.Attempts.ToString();
                }

                List<Services.Composite.Component> licenses = new List<Services.Composite.Component>();

                licenses = userSetProfile.getAllLicenses();

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
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Logout"), button_logout));
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
                frmChangePassword = new frmChangePassword();
                frmChangePassword.FormClosed += new FormClosedEventHandler(frmPassword_FormClosed);
                frmChangePassword.Show();
            }
            else
            {
                frmChangePassword.BringToFront();
            }
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
                    login.Show();
                }
            }
            else
            {
                button_logout.Enabled = false;
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
    }
}
