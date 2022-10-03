using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UAICampo.Services;
using UAICampo.BLL;
using UAICampo.Abstractions.Observer;
using UAICampo.Services.Observer;
using Microsoft.VisualBasic;

namespace UAICampo.UI.Controllers
{
    public partial class Password_Change : UserControl, IObserver
    {
        BLL_UserManager bllUserManager;
        BLL_LanguageManager languageBLL;

        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();

        public Password_Change()
        {
            InitializeComponent();
            button_Confirm.Enabled = false;

            bllUserManager = new BLL_UserManager();
            languageBLL = new BLL_LanguageManager();

            SetControllerTags();

            if (UserInstance.getInstance().user != null)
            {
                UserInstance.getInstance().user.Add(this);
                Update();
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            validatePassFields();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            validatePassFields();
        }
        private void validatePassFields()
        {
            if (this.textBox_password.Text != "" && textBox_passwordConfirm.Text != "")
            {
                if (textBox_password.Text == textBox_passwordConfirm.Text)
                {
                    button_Confirm.Enabled = true;
                }
                else
                {
                    button_Confirm.Enabled = false;
                }
            }
            else
            {
                button_Confirm.Enabled = false;
            }
        }

        private void button_Confirm_Click(object sender, EventArgs e)
        {
            string password = textBox_password.Text;

            if (UserInstance.getInstance().userIsLoggedIn())
            {
                if (bllUserManager.changePassword(UserInstance.getInstance().user, password))
                {
                    textBox_password.Text = "";
                    textBox_passwordConfirm.Text = "";

                    //Log password change success
                    BLL_LogManager.addMessage(new Log
                    {
                        Date = DateTime.Now,
                        Code = "PASSWORD_CHANGE_OK",
                        Description = String.Format($"Account {UserInstance.getInstance().user.Username} changed its password successfully"),
                        Type = LogType.Control,
                        User = UserInstance.getInstance().user.Id
                    });
                }
                else 
                {
                    Interaction.MsgBox("Error");
                    //Log password change error
                    BLL_LogManager.addMessage(new Log
                    {
                        Date = DateTime.Now,
                        Code = "PASSWORD_CHANGE_ERROR",
                        Description = String.Format($"Account {UserInstance.getInstance().user.Username} COULD NOT CHANGE ITS PASSWORD"),
                        Type = LogType.Control,
                        User = UserInstance.getInstance().user.Id
                    });
                }
            }
        }

        private void button_showPassword_Click(object sender, EventArgs e)
        {
            changePasswordVisibility(textBox_password);
            changePasswordVisibility(textBox_passwordConfirm);
        }
        private void changePasswordVisibility(TextBox textbox)
        {
            textbox.UseSystemPasswordChar = !textbox.UseSystemPasswordChar;
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
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Password"), label_Password));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "PasswordConfirm"), label_PasswordConfirm));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Accept"), button_Confirm));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "ShowPassword"), button_showPassword));
        }
        private void Password_Change_Load(object sender, EventArgs e)
        {

        }
    }
}
