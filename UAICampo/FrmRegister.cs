using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UAICampo.BLL;
using UAICampo.Services;
using UAICampo.Abstractions;
using Microsoft.VisualBasic;
using UAICampo.Services.Observer;
using UAICampo.Abstractions.Observer;

namespace UAICampo.UI
{
    public partial class FrmRegister : Form, IObserver
    {
        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();
        BLL_LanguageManager bllLanguage;
        private static BLL_UserManager bllUserManager;
        private static UI_Validation validations;


        private string USERNAME = "";
        private string PASSWORD = "";
        private string EMAIL = "";
        public FrmRegister()
        {
            InitializeComponent();
            bllLanguage = new BLL_LanguageManager();

            SetControllerTags();

            if (UserInstance.getInstance().user != null)
            {
                UserInstance.getInstance().user.Add(this);
                Update();
            }
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {
            bllUserManager = new BLL_UserManager();
            validations = new UI_Validation();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            USERNAME = textBoxUsername.Text;
            PASSWORD = textBoxPassword.Text;
            EMAIL = textBoxEmail.Text;

            if (!string.IsNullOrEmpty(textBoxPassword.Text) || !string.IsNullOrEmpty(textBoxConfirmPassword.Text))
            {
                if (textBoxPassword.Text == textBoxConfirmPassword.Text)
                {
                    if (bllUserManager.createUser(USERNAME, PASSWORD, EMAIL) != null)
                    {

                        this.Close();
                    }
                    else
                    {
                        Interaction.MsgBox("This Username already exists. Please try a different one.");
                    }
                }
                else
                {
                    Interaction.MsgBox("Password doesn't match. Please try again.");
                }
            }
            else
            {
                Interaction.MsgBox("Please enter a password.");
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
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Username"), labelUserName));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Password"), labelPassword));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "ConfirmPassword"), label1));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Register"), buttonRegister));

        }
    }
}
