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
using UAICampo.BE;
using UAICampo.BLL;
using UAICampo.Services;
using UAICampo.Services.Observer;

namespace UAICampo.UI
{
    public partial class FindDr___User_Tab : Form, IObserver
    {
        private readonly string PRACTITIONER_PROFILE = "Practitioner";
        private Form activeForm = null;

        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();
        List<Services.Composite.Component> licenses = new List<Services.Composite.Component>();

        BLL_SessionManager sessionBLL;
        BLL_LanguageManager languageBLL;
        BLL_UserManager userBll;
        BLL_Address addressBll;

        public FindDr___User_Tab()
        {
            InitializeComponent();

            sessionBLL = new BLL_SessionManager();
            languageBLL = new BLL_LanguageManager();
            userBll = new BLL_UserManager();
            addressBll = new BLL_Address();

            label_Adress.Visible = false;
            label_Title_Address.Visible = false;
            label_NonExistingAdress.Visible = false;

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

        private void FindDr___User_Tab_Load(object sender, EventArgs e)
        {
            // Show/hide promote account button
            if (UserInstance.getInstance().user.profileList.Any(x => x.ProfileName == PRACTITIONER_PROFILE))
            {
                pictureBox2.Visible = true;
                pictureBox1.Visible = false;
            }
            else 
            {
                pictureBox2.Visible = false;
                pictureBox1.Visible = true;
            }

            // Show address / Address warning

            Address userAddress = addressBll.getUserAddress(UserInstance.getInstance().user);
            if (userAddress != null)
            {
                label_Adress.Visible = true;
                label_Title_Address.Visible = true;
                label_NonExistingAdress.Visible = false;
                button_addAddress.Visible = false;
                label_Adress.Text = $"{userAddress.Address1} - {userAddress.Address2}, {userAddress.AddressNumber}, {userAddress.Province.name}";
            }
            else
            {
                label_Adress.Visible = false;
                label_Title_Address.Visible = false;
                label_NonExistingAdress.Visible = true;
                button_addAddress.Visible = true;
            }

        }
        //Button promote account ------------------------------------------------------------------------------
        private void button_PromoteAccount_Click(object sender, EventArgs e)
        {
            FindRd___PromoteAccount promoteForm = new FindRd___PromoteAccount();
            promoteForm.promotion += PromoteForm_promotion;
            openChildSubForm(promoteForm);
        }
        // Add address ----------------------------------------------------------------------------------------
        private void button_addAddress_Click(object sender, EventArgs e)
        {
            openChildSubForm(new FindDr___AddAddress());
        }
        //-------------------------------------------------------------------------------------------------------
        private void PromoteForm_promotion(object sender, EventArgs e)
        {
            ValidateForm();
            this.Close();
        }

        //-----------------------------------------------------------------------------------------------------
        private void ValidateForm()
        {
            try
            {
                if (UserInstance.getInstance().userIsLoggedIn())
                {
                    //set Labels text
                    label_userName.Text = UserInstance.getInstance().user.Username;
                    label_name.Text = UserInstance.getInstance().user.LastName + " " + UserInstance.getInstance().user.Name;

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

                    //If user has Practotioner rol, promote button will not show
                    if (UserInstance.getInstance().user.profileList.Any(x => x.ProfileName == PRACTITIONER_PROFILE))
                    {
                        button_PromoteAccount.Visible = false;
                    }
                    else
                    {
                        button_PromoteAccount.Visible = true;
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
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(25, "Promote"), button_PromoteAccount));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Welcome"), label_Title_Welcome));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Username"), label_Title_Username));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Name"), label_Title_name));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Address"), label_Title_Address));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "NonAddress"), label_NonExistingAdress));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "AddAddress"), button_addAddress));
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
            this.Controls.Add(subForm);
            this.Tag = subForm;
            subForm.BringToFront();
            subForm.Show();
        }

        
    }
}
