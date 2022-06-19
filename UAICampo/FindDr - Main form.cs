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
using UAICampo.Services.Observer;

namespace UAICampo.UI
{
    public partial class FindDr___Main_form : Form, IObserver
    {
        private Form activeForm = null;

        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();
        List<Services.Composite.Component> licenses = new List<Services.Composite.Component>();

        BLL_SessionManager sessionBLL;
        BLL_LanguageManager languageBLL;

        public FindDr___Main_form()
        {
            InitializeComponent();

            sessionBLL = new BLL_SessionManager();
            languageBLL = new BLL_LanguageManager();

            //Get all user licenses [All profiles]
            if (UserInstance.getInstance().userIsLoggedIn())
            {
                foreach (Profile profile in UserInstance.getInstance().user.profileList)
                {
                    licenses.AddRange(profile.getAllLicenses());
                }
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

        private void FindDr___Main_form_Load(object sender, EventArgs e)
        {

        }
        #region Form events [Button clicks...]
        //Button profile----------------------------------------------------------------------------------------
        private void button_profile_Click(object sender, EventArgs e)
        {
            openChildSubForm(new FindDr___User_Tab());
        }
        //button search ----------------------------------------------------------------------------------------
        private void button_userSearch_Click(object sender, EventArgs e)
        {
            openChildSubForm(new FindDr___Search());
        }
        //button Admin ----------------------------------------------------------------------------------------
        private void button_adminPanel_Click(object sender, EventArgs e)
        {
            openChildSubForm(new FindDr___Admin());
        }
        //Button Logout-----------------------------------------------------------------------------------------
        private void button_logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sessionBLL.Logout();
                this.Close();
                frmLogin login = new frmLogin();
                login.Show();
            }
        }
        //Button Office ---------------------------------------------------------------------------------------
        private void button_DoctorsOffice_Click(object sender, EventArgs e)
        {
            openChildSubForm(new FindDr___Office_manager());
        }
        //------------------------------------------------------------------------------------------------------
        #endregion
        private void ValidateForm()
        {
            try
            {
                if (UserInstance.getInstance().userIsLoggedIn())
                {
                    //set Labels text
                    this.label_userName.Text = UserInstance.getInstance().user.Username;

                    //showing or hiding controllers according to user licences
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
            }
            catch (Exception)
            { }
        }
        public void Update()
        {
            //Get user saver language
            Language selectedLanguage = UserInstance.getInstance().user.language;
            languageBLL.loadLanguageWords(selectedLanguage);

            //Updating each controller accordingly
            foreach (var controller in controllers)
            {
                try
                {
                    if (controller.Key.Word != null)
                    {
                        KeyValuePair<string, string> textValue = selectedLanguage.words.SingleOrDefault(kvp => kvp.Key == controller.Key.Word);
                        if (textValue.Value != null)
                        {
                            //If the tag is in the DB and has a word for the selected language
                            controller.Value.Text = textValue.Value;
                        }
                        else
                        {
                            //If there is no translation
                            controller.Value.Text = "Not found";
                        }
                    }
                }
                catch (Exception)
                { }
            }
        }
        private void SetControllerTags()
        {
            //In here, we set each controller tag list.
            //This list wil be made out of keyvaluepairs, with a controller, and a tag
            //Each Tag will be made out of two values
            //First value: license required for it to show up to the user
            //Second value: Word Tag, used for language runtime changes

            ////General controllers------------------------------------------------------------------------------------
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Logout"), button_logout));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Search"), button_userSearch));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Profile"), button_profile));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Appointments"), button_Appointment));
            ////-------------------------------------------------------------------------------------------------------
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(26, "Office"), button_DoctorsOffice));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(27, "Practices"), button_Practices));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(2, "Admin"), button_adminPanel));

            //controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(14, ""), profile_Manager1));
            //controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(15, ""), languageEditorController1));
        }
        private void openChildSubForm(Form subForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = subForm;
            subForm.TopLevel = false;
            subForm.FormBorderStyle = FormBorderStyle.None;
            subForm.Dock = DockStyle.Fill;
            panel_subForm.Controls.Add(subForm);
            panel_subForm.Tag = subForm;
            subForm.BringToFront();
            subForm.Show();
        }

        private void panel_lateralRow_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_subForm_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
