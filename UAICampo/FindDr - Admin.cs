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
    public partial class FindDr___Admin : Form, IObserver
    {
        private Form activeForm = null;

        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();
        List<Services.Composite.Component> licenses = new List<Services.Composite.Component>();

        BLL_SessionManager sessionBLL;
        BLL_LanguageManager languageBLL;

        public FindDr___Admin()
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

        private void FindDr___Admin_Load(object sender, EventArgs e)
        {
            profile_Manager1.Visible = false;
            license_Manager1.Visible = false;
            user_Manager1.Visible = false;
            languageEditorController1.Visible = false;
        }

        #region Button console
        private void button_LicenseManager_Click(object sender, EventArgs e)
        {
            profile_Manager1.Visible = false;
            license_Manager1.Visible = true;
            user_Manager1.Visible = false;
            languageEditorController1.Visible = false;
        }

        private void button_UserManager_Click(object sender, EventArgs e)
        {
            profile_Manager1.Visible = false;
            license_Manager1.Visible = false;
            user_Manager1.Visible = true;
            languageEditorController1.Visible = false;
        }

        private void button_LanguageManager_Click(object sender, EventArgs e)
        {
            profile_Manager1.Visible = false;
            license_Manager1.Visible = false;
            user_Manager1.Visible = false;
            languageEditorController1.Visible = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            profile_Manager1.Visible = true;
            license_Manager1.Visible = false;
            user_Manager1.Visible = false;
            languageEditorController1.Visible = false;
        }
        #endregion
        private void ValidateForm()
        {
            try
            {
                if (UserInstance.getInstance().userIsLoggedIn())
                {
                    //set Labels text

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
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "ProfileManager"), button_ProfileManager));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "LicenseManager"), button_LicenseManager));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "UserManager"), button_UserManager));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "LanguageManager"), button_LanguageManager));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Admin"), label_Title_Admin));
        }

        private void user_Manager1_Load(object sender, EventArgs e)
        {
            profile_Manager1.Visible = false;
            license_Manager1.Visible = false;
            user_Manager1.Visible = true;
            languageEditorController1.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
