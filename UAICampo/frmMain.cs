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

        BLL_SessionManager sessionBLL;
        BLL_LanguageManager languageBLL;

        public frmMain()
        {
            InitializeComponent();
        
            sessionBLL = new BLL_SessionManager();
            languageBLL = new BLL_LanguageManager();
            
            userSetProfile = UserInstance.getInstance().user.profileList[0];

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
            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sessionBLL.Logout();
                ValidateForm();
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (UserInstance.getInstance().userIsLoggedIn())
            {
                if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            Language selectedLanguage = UserInstance.getInstance().user.language;

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
        }
        private void ValidateForm()
        {
            if (UserInstance.getInstance().userIsLoggedIn())
            {
                this.toolStripStatusLabel.Text = UserInstance.getInstance().user.Username;
                this.label1.Text = UserInstance.getInstance().user.Id.ToString();
                this.label2.Text = UserInstance.getInstance().user.Username.ToString();
                this.label3.Text = UserInstance.getInstance().user.Email.ToString();
                this.label4.Text = UserInstance.getInstance().user.IsBlocked.ToString();
                this.label5.Text = UserInstance.getInstance().user.Attempts.ToString();
            }

            List<Services.Composite.Component> licenses = new List<Services.Composite.Component>();
            licenses =  userSetProfile.getAllLicenses();

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
        private void SetControllerTags()
        {
            //In here, we set each controller tag list.
            //This list wil be made out of keyvaluepairs, with a controller, and a tag
            //Each Tag will be made out of two values
            //First value: license required for it to show up to the user
            //Second value: Word Tag, used for language runtime changes

            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Logout"), button_logout));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(3, ""), treeView_Licenses));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(4, ""), listBox_User));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(3, ""), panel1));
        }

        private void languageController1_Load(object sender, EventArgs e)
        {

        }
    }
}
