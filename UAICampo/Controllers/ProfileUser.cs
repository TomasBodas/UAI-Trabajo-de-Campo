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
    public partial class ProfileUser : UserControl, IObserver
    {
        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();
        BLL_LanguageManager bllLanguage;

        public ProfileUser()
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
            //controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "LicenseList"), label_Title_License));
            //controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "ProfileList"), label_Title_Profile));
            //controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "LicenseList"), label_Title_ProfileLicenses));
        }

        private void ProfileUser_Load(object sender, EventArgs e)
        {
            textBox1.Text = UserInstance.getInstance().user.Username;
            textBox2.Text = UserInstance.getInstance().user.Email;
            textBox3.Text = UserInstance.getInstance().user.profileList.Count() == 0 ? "" : UserInstance.getInstance().user.profileList.FirstOrDefault().ProfileName;
            textBox4.Text = UserInstance.getInstance().user.Equipo.Name == null ? "" : UserInstance.getInstance().user.Equipo.Name;

        }
    }
}
