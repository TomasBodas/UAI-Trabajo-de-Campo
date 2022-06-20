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
using UAICampo.BE;
using UAICampo.BLL;
using UAICampo.Services;
using UAICampo.Services.Observer;

namespace UAICampo.UI
{
    public partial class FindRd___PromoteAccount : Form, IObserver
    {
        private Form activeForm = null;

        public event EventHandler promotion;

        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();
        List<Services.Composite.Component> licenses = new List<Services.Composite.Component>();

        List<Speciality> Specialities = new List<Speciality>();
        Speciality selectedSpeciality;

        BLL_SessionManager sessionBLL;
        BLL_LanguageManager languageBLL;
        BLL_UserManager userManagerBLL;

        public FindRd___PromoteAccount()
        {
            InitializeComponent();

            sessionBLL = new BLL_SessionManager();
            languageBLL = new BLL_LanguageManager();
            userManagerBLL = new BLL_UserManager();

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

            button_Accept.Enabled = false;
        }
        private void FindRd___PromoteAccount_Load(object sender, EventArgs e)
        {
            getAllSpecialities();
        }

        //Button promote account -------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            int numeroMatricula = int.Parse(textBox_Matricula.Text);
            if (userManagerBLL.promoteAccount(numeroMatricula, UserInstance.getInstance().user))
            {
                userManagerBLL.addSpeciality(selectedSpeciality, UserInstance.getInstance().user);
                BLL_LogManager.addMessage(new Log
                {
                    Date = DateTime.Now,
                    Code = "USER_ACCOUNT_PROMOTION_OK",
                    Description = String.Format($"Account {UserInstance.getInstance().user.Username} promoted the account"),
                    Type = LogType.Control,
                    User = UserInstance.getInstance().user
                });
                this.Close();
            }
            else
            {
                BLL_LogManager.addMessage(new Log
                {
                    Date = DateTime.Now,
                    Code = "USER_ACCOUNT_PROMOTION_ERROR",
                    Description = String.Format($"Account {UserInstance.getInstance().user.Username} could not promote the account"),
                    Type = LogType.Control,
                    User = UserInstance.getInstance().user
                });
                Interaction.MsgBox("Error!");
                this.Close();
            }
            promotion?.Invoke(this, null);
        }
        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Event textbox change - matricula ---------------------------------------------------------------------
        private void textBox_Matricula_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_Matricula.Text, out _) && textBox_Matricula.Text != "")
            {
                button_Accept.Enabled = true;
            }
            else
            {
                button_Accept.Enabled = false;
            }
        }
        // Get all speicalities --------------------------------------------------------------------------------
        private void getAllSpecialities()
        {
            comboBox1.Items.Clear();
            Specialities = userManagerBLL.getAllSpecialities();
            foreach (Speciality speciality in Specialities)
            {
                comboBox1.Items.Add(speciality.Name);
            }
        }
        //select speciality -------------------------------------------------------------------------------------
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Speciality speciality in Specialities)
            {
                if (speciality.Name == comboBox1.Text)
                {
                    selectedSpeciality = speciality;
                }
            }
        }
        //------------------------------------------------------------------------------------------------------

        private void ValidateForm()
        {
            try
            {
                if (UserInstance.getInstance().userIsLoggedIn())
                {
                    //set Labels text
                    label_Username.Text = UserInstance.getInstance().user.Username;

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
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Accept"), button_Accept));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Cancel"), button_cancel));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Promote"), label_Title));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Username"), label_Title_Username));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Name"), label_Title_Name));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "License"), label_Matricula));
        }

        
    }
}
