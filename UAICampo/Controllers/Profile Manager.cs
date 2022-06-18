using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UAICampo.Abstractions.Observer;
using UAICampo.Services;
using UAICampo.Services.Composite;
using UAICampo.BLL;
using UAICampo.Services.Observer;
using Microsoft.VisualBasic;

namespace UAICampo.UI.Controllers
{
    public partial class Profile_Manager : UserControl, IObserver
    {
        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();

        BLL_Licences bllLicense;
        BLL_UserManager bllUser;
        BLL_LanguageManager bllLanguage;

        List<Profile> profileList;
        List<Component> licenseList;

        Profile selectedProfile = null;
        Component selectedLicense = null;
        Component selectedProfileLicense = null;

        string PACIENT_PROFILE = "Pacient";
        string PRACTITIONER_PROFILE = "Practitioner";
        string ADMIN_PROFILE = "Admin";

        public Profile_Manager()
        {
            InitializeComponent();

            bllLicense = new BLL_Licences();
            bllUser = new BLL_UserManager();
            bllLanguage = new BLL_LanguageManager();

            profileList = new List<Profile>();
            licenseList = new List<Component>();

            SetControllerTags();

            if (UserInstance.getInstance().user != null)
            {
                UserInstance.getInstance().user.Add(this);
                Update();
            }
        }

        private void Profile_Manager_Load(object sender, EventArgs e)
        {
            loadLicenseList();
            loadProfileList();

        }

        private void loadProfileList()
        {
            profileList = bllUser.getProfileList();
            dataGridView_Profile.DataSource = null;
            dataGridView_Profile.DataSource = profileList;
        }
        private void loadLicenseList()
        {
            licenseList = bllLicense.getAll();
            dataGridView_Lincense.DataSource = null;
            dataGridView_Lincense.DataSource = licenseList;
        }

        private void dataGridView_Profile_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_Profile.SelectedRows != null)
            {
                try
                {
                    selectedProfile = dataGridView_Profile.SelectedRows[0].DataBoundItem as Profile;
                    selectedProfile.Licences.Clear();
                    bllLicense.getProfileLicences(selectedProfile);
                    dataGridView_ProfileLicense.DataSource = null;
                    dataGridView_ProfileLicense.DataSource = selectedProfile.Licences;

                    if (selectedProfile.ProfileName == PACIENT_PROFILE || selectedProfile.ProfileName == PRACTITIONER_PROFILE || selectedProfile.ProfileName == ADMIN_PROFILE)
                    {
                        button_removeProfile.Enabled = false;
                    }
                    else
                    {
                        button_removeProfile.Enabled = true;
                    }
                }
                catch (Exception)
                { }
                
            }
        }

        private void dataGridView_Lincense_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_Lincense.SelectedRows != null)
            {
                try
                {
                    selectedLicense = dataGridView_Lincense.SelectedRows[0].DataBoundItem as Component;
                }
                catch (Exception)
                { }

            }
        }
        private void dataGridView_ProfileLicense_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_ProfileLicense.SelectedRows != null)
            {
                try
                {
                    selectedProfileLicense = dataGridView_ProfileLicense.SelectedRows[0].DataBoundItem as Component;
                }
                catch (Exception)
                { }

            }
        }

        private void button_AssignLicense_Click(object sender, EventArgs e)
        {
            if (selectedProfile != null && selectedLicense != null)
            {
                if (bllUser.setProfileLicense(selectedProfile, selectedLicense))
                {
                    loadLicenseList();
                    loadProfileList();
                }
            }
        }
        private void button_revokeLicense_Click(object sender, EventArgs e)
        {
            if (selectedProfile != null && selectedProfileLicense != null)
            {
                if (bllUser.revokeProfileLicense(selectedProfile, selectedProfileLicense))
                {
                    loadLicenseList();
                    loadProfileList();
                }
            }
        }
        private void button_addProfile_Click(object sender, EventArgs e)
        {
            string profileName = Interaction.InputBox("Profile", "profile name");
            string description = Interaction.InputBox("Description", "profile description");

            if (profileName != "" && description != "")
            {
                if (bllUser.createProfile(profileName, description))
                {
                    loadLicenseList();
                    loadProfileList();
                }
            }
            
        }
        private void button_removeProfile_Click(object sender, EventArgs e)
        {
            if (selectedProfile != null)
            {
                if (bllUser.deleteProfile(selectedProfile))
                {
                    loadLicenseList();
                    loadProfileList();
                }
            }
        }
        public void Update()
        {
            Language selectedLanguage = UserInstance.getInstance().user.language;

            bllLanguage.loadLanguageWords(selectedLanguage);

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

            //General controllers------------------------------------------------------------------------------------
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "LicenseList"), label_Title_License));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "ProfileList"), label_Title_Profile));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "LicenseList"), label_Title_ProfileLicenses));
        }

        
    }
}
