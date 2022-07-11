using Microsoft.VisualBasic;
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

namespace UAICampo.UI.Controllers
{
    public partial class User_Manager : UserControl, IObserver
    {
        BLL_UserManager bll_userManager;
        BLL_LanguageManager languageBLL;
        Profile selectedProfile = null;
        List<Profile> profileList;

        User selectedUser;
        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();

        public User_Manager()
        {
            InitializeComponent();

            bll_userManager = new BLL_UserManager();
            languageBLL = new BLL_LanguageManager();


            SetControllerTags();

            if (UserInstance.getInstance().user != null)
            {
                UserInstance.getInstance().user.Add(this);
                Update();
            }
        }

        private void User_Manager_Load(object sender, EventArgs e)
        {
            updateUserList();
        }
        //User selection change event
        private void dataGridView_user_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_user.SelectedRows[0] != null)
                {
                    selectedUser = dataGridView_user.SelectedRows[0].DataBoundItem as User;

                    updateUserPofileList(selectedUser);
                    updateGeneralProfileList(selectedUser);
                }
            }
            catch (Exception)
            {  }
        }

        //DataGridView info dump
        private void updateUserList()
        {
            dataGridView_user.DataSource = null;
            dataGridView_user.DataSource = bll_userManager.GetUsers();

            dataGridView_user.Columns["Password"].Visible = false;
            dataGridView_user.Columns["language"].Visible = false;
        }
        private void updateUserPofileList(User selectedUser)
        {
            dataGridView_userProfile.DataSource = null;
            dataGridView_userProfile.DataSource = bll_userManager.getUserProfiles(selectedUser);
        }

        private void updateGeneralProfileList(User selectedUser)
        {
            dataGridView_GeneralProfileList.DataSource = null;
            dataGridView_GeneralProfileList.DataSource = bll_userManager.getNonAsignedProfileList(selectedUser);
        }

        private void button_BlockUser_Click(object sender, EventArgs e)
        {
            if (selectedUser != null)
            {
                if (bll_userManager.BlockAccount(selectedUser))
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
                if (bll_userManager.unblockAccount(selectedUser))
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
        private void button_assignProfile_Click(object sender, EventArgs e)
        {
            Profile selectedProfile = null;

            try
            {
                if (dataGridView_GeneralProfileList.Rows[0] != null)
                {
                    selectedProfile = dataGridView_GeneralProfileList.SelectedRows[0].DataBoundItem as Profile;
                }

                if (selectedProfile != null & selectedUser != null)
                {
                    bll_userManager.AssignProfile(selectedUser, selectedProfile);
                    updateUserPofileList(selectedUser);
                    updateGeneralProfileList(selectedUser);
                }
            }
            catch (Exception)
            {  }
        }

        private void button_revokeProfile_Click(object sender, EventArgs e)
        {
            Profile selectedProfile = null;
            try
            {
                if (dataGridView_userProfile.Rows[0] != null)
                {
                    selectedProfile = dataGridView_userProfile.SelectedRows[0].DataBoundItem as Profile;
                }

                if (selectedProfile != null & selectedUser != null)
                {
                    bll_userManager.RevokeProfile(selectedUser, selectedProfile);
                    updateUserPofileList(selectedUser);
                    updateGeneralProfileList(selectedUser);
                }
            }
            catch (Exception)
            {  }
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
            //-------------------------------------------------------------------------------------------------------
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "UserList"), label_title_UserList));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "UserProfileList"), label_title_UserProfile));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "ProfileList"), label_title_ProfilePool));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "AddProfile"), button_addProfile));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "RemoveProfile"), button_removeProfile));
        }

        private void dataGridView_user_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_addProfile_Click(object sender, EventArgs e)
        {
            string profileName = Interaction.InputBox("Profile", "profile name");
            string description = Interaction.InputBox("Description", "profile description");
            string value = Interaction.InputBox("Value", "value");

            if (profileName != "" && description != "" && value != "")
            {
                if (bll_userManager.createProfile(profileName, description, int.Parse(value)))
                {
                    loadProfileList();
                }
            }
        }

        private void button_removeProfile_Click(object sender, EventArgs e)
        {

            Profile selectedProfile = null;
            try
            {
                if (dataGridView_GeneralProfileList.Rows[0] != null)
                {
                    selectedProfile = dataGridView_GeneralProfileList.SelectedRows[0].DataBoundItem as Profile;
                }

                if (selectedProfile != null & selectedUser != null)
                {
                    if (bll_userManager.deleteProfile(selectedProfile))
                    {
                        loadProfileList();
                    }
                }
            }
            catch (Exception)
            { }
        }
        private void loadProfileList()
        {
            profileList = bll_userManager.getProfileList();
            dataGridView_GeneralProfileList.DataSource = null;
            dataGridView_GeneralProfileList.DataSource = profileList;
        }

    }
}
