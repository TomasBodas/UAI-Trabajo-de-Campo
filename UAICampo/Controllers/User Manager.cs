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

        User selectedUser;
        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();

        public User_Manager()
        {
            InitializeComponent();

            bll_userManager = new BLL_UserManager();
            languageBLL = new BLL_LanguageManager();

            button_BlockUser.Enabled = false;
            button_unblockUser.Enabled = false;

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

                    if (selectedUser.IsBlocked)
                    {
                        button_unblockUser.Enabled = true;
                        button_BlockUser.Enabled = false;
                    }
                    else
                    {
                        button_unblockUser.Enabled = false;
                        button_BlockUser.Enabled = true;
                    }
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

            dataGridView_user.Columns["Licenses"].Visible = false;
            dataGridView_user.Columns["Password"].Visible = false;
            dataGridView_user.Columns["language"].Visible = false;
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
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Block"), button_BlockUser));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Unblock"), button_unblockUser));
            //-------------------------------------------------------------------------------------------------------
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "UserList"), label_title_UserList));
        }
    }
}
