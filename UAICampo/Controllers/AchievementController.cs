using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UAICampo.Abstractions;
using UAICampo.Abstractions.Observer;
using UAICampo.BE;
using UAICampo.BLL;
using UAICampo.Services;
using UAICampo.Services.Observer;

namespace UAICampo.UI.Controllers
{
    public partial class AchievementController : UserControl, IObserver
    {
		BLL_EquipoManager bllEquipo;
        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();
        BLL_LanguageManager bllLanguage;
        Language selectedLanguage;
        public AchievementController()
		{
			InitializeComponent();
            bllLanguage = new BLL_LanguageManager();
            bllEquipo = new BLL_EquipoManager();

            SetControllerTags();

            if (UserInstance.getInstance().user != null)
            {
                UserInstance.getInstance().user.Add(this);
                Update();
            }
        }

        private void updateTrabajadoresList()
        {
            IEquipo equipo = BLL_EquipoManager.getUserTeam(UserInstance.getInstance().user);
            List<User> trabajadores = bllEquipo.getMembers(equipo);

            if (trabajadores == null || trabajadores.Count == 0)
            {
                return;
            }

            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";

            var items = new List<Object> { new ComboboxItem { Text = "", Value = 0 } };
            foreach (User trabajador in trabajadores)
            {
                if (trabajador.Username == UserInstance.getInstance().user.Username)
                {
                    continue;
                }
                items.Add(new ComboboxItem { Text = trabajador.Username, Value = trabajador.Id });
            }

            comboBox1.DataSource = items;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AchievementController_Load(object sender, EventArgs e)
        {
            updateTrabajadoresList();
            var achievSource = new List<Reconocimiento>();
            achievSource.Add(new Reconocimiento() { Description = "MVP", Value = 10 });
            achievSource.Add(new Reconocimiento() { Description = "Teamwork", Value = 5 });
            achievSource.Add(new Reconocimiento() { Description = "Communication", Value = 5 });
            achievSource.Add(new Reconocimiento() { Description = "Leadership", Value = 10 });
            this.comboBox2.DataSource = achievSource;
            this.comboBox2.DisplayMember = "Description";
            this.comboBox2.ValueMember = "Value";
            this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null || comboBox2.SelectedValue == null)
            {
                MessageBox.Show("Please complete all fields.");
            }
            else
            {
                if (MessageBox.Show(selectedLanguage.translate("Confirmation"), selectedLanguage.translate("Confirm"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    BLL_ReconocimientoManager.Send(UserInstance.getInstance().user.Id, (int)comboBox1.SelectedValue, comboBox2.Text, (int)comboBox2.SelectedValue, DateTime.Now);
                    MessageBox.Show(selectedLanguage.translate("AchievementSent"));
                }
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
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Member"), label1));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Achievements"), label2));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Achievements"), groupBox1));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Send"), button1));
            //controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "ProfileList"), label_Title_Profile));
            //controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "LicenseList"), label_Title_ProfileLicenses));
        }

        public void Update()
        {
            selectedLanguage = UserInstance.getInstance().user.language;
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
    }
}
