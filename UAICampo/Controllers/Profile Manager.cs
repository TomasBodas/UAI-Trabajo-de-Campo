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
        
        User selectedUser = null;
        Component selectedLicense = null;
        Component selectedProfileLicense = null;

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
            updateUserList();


        }
        private void updateUserList()
        {
            dataGridView_user.DataSource = null;
            dataGridView_user.DataSource = bllUser.GetUsers();

            dataGridView_user.Columns["Password"].Visible = false;
            dataGridView_user.Columns["language"].Visible = false;
        }

        private void loadProfileList()
        {
            profileList = bllUser.getProfileList();
            dataGridView_user.DataSource = null;
            dataGridView_user.DataSource = profileList;
        }
        private void loadLicenseList()
        {
            licenseList = bllLicense.getAll();
            dataGridView_Lincense.DataSource = null;
            dataGridView_Lincense.DataSource = licenseList;
        }

        private void dataGridView_Profile_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_user.SelectedRows != null)
            {
                try
                {
                    selectedUser = dataGridView_user.SelectedRows[0].DataBoundItem as User;
                    selectedUser.Licenses.Clear();
                    bllLicense.getUserLicences(selectedUser);
                    dataGridView_ProfileLicense.DataSource = null;
                    dataGridView_ProfileLicense.DataSource = selectedUser.Licenses;
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
            bool found = false;
            foreach (DataGridViewRow row in dataGridView_ProfileLicense.Rows)
            {
                if (row.Cells[1].Value.ToString().Contains(selectedLicense.Name))
                {
                    found = true;
                }
            }
            if (selectedUser != null && selectedLicense != null && found == false)
            {
                if (bllLicense.setUserLicense(selectedUser, selectedLicense))
                {
                    loadLicenseList();
                    updateUserList();
                }
            }
        }
        private void button_revokeLicense_Click(object sender, EventArgs e)
        {
            if (selectedUser != null && selectedProfileLicense != null)
            {
                if (bllLicense.revokeUserLicense(selectedUser, selectedProfileLicense))
                {
                    loadLicenseList();
                    updateUserList();
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
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Block"), button_BlockUser));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Unblock"), button_unblockUser));
        }

        private void button_BlockUser_Click(object sender, EventArgs e)
        {
            if (selectedUser != null)
            {
                if (bllUser.BlockAccount(selectedUser))
                {
                    updateUserList();

                    BLL_LogManager.addMessage(new Log
                    {
                        Date = DateTime.Now,
                        Code = "ACCOUNT_BLOCKED_OK",
                        Description = String.Format($"Account {UserInstance.getInstance().user.Username} blocked the account ID:{selectedUser.Id} - Username:{selectedUser.Username}"),
                        Type = LogType.Control,
                        User = UserInstance.getInstance().user
                    });
                }
            }
        }

        private void button_unblockUser_Click(object sender, EventArgs e)
        {
            if (selectedUser != null)
            {
                if (bllUser.unblockAccount(selectedUser))
                {
                    updateUserList();

                    BLL_LogManager.addMessage(new Log
                    {
                        Date = DateTime.Now,
                        Code = "ACCOUNT_UNBLOCKED_OK",
                        Description = String.Format($"Account {UserInstance.getInstance().user.Username} unblocked the account ID:{selectedUser.Id} - Username:{selectedUser.Username}"),
                        Type = LogType.Control,
                        User = UserInstance.getInstance().user
                    });
                }
            }
        }
    }
}
