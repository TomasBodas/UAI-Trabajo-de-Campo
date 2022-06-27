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
using UAICampo.Abstractions;
using UAICampo.Abstractions.Observer;
using UAICampo.BE;
using UAICampo.BLL;
using UAICampo.Services;
using UAICampo.Services.Observer;

namespace UAICampo.UI.Controllers
{
    public partial class EquipoController : UserControl, IObserver
    {
        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();
        Equipo selectedEquipo = new Equipo();
        BLL_LanguageManager bllLanguage;
        BLL_UserManager bllUser;
        List<Profile> profiles;
        private frmEquipoManager f1;
        public frmEquipoManager F1
        {
            get { return f1; }
            set { f1 = value; }
        }
        public EquipoController()
        {
            InitializeComponent();

            bllLanguage = new BLL_LanguageManager();
            bllUser = new BLL_UserManager();
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Close();
        }

        private void EquipoController_Load(object sender, EventArgs e)
        {
            profiles = bllUser.getBusinessProfileList();


            comboBoxPosition.Items.Clear();
            foreach (var item in profiles)
            {
                comboBoxPosition.Items.Add(item.ProfileName);
            }
        }

        private void buttonAddPosition_Click(object sender, EventArgs e)
        {
            if (comboBoxPosition.SelectedIndex == -1)
            {
                return;
            }

            Profile newPosition = bllUser.getProfileByName(comboBoxPosition.SelectedItem.ToString());
            selectedEquipo.puestos.Add(new KeyValuePair<IProfile, IUser>(newPosition, null));

            updateGrid();
        }

        public void updateGrid()
        {
            dataGridView1.Rows.Clear();

            foreach (KeyValuePair<IProfile, IUser> puesto in selectedEquipo.puestos)
            {
                dataGridView1.Rows.Add(puesto.Key.ProfileName, puesto.Value != null ? puesto.Value.Username : "");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0 || dataGridView1.SelectedRows[0].Cells[1].Value.ToString() != "")
            {
                Interaction.MsgBox("please_add_position");
                return;
            }

            frmProposal pe = new frmProposal(selectedEquipo, selectedEquipo.puestos[dataGridView1.SelectedRows[0].Index].Key, f1);
            pe.Show();

        }

        private void btnPropose_Click(object sender, EventArgs e)
        {
            if (textBoxLevel.Text == "" || !textBoxLevel.Text.All(char.IsDigit))
            {
                Interaction.MsgBox("Please add level");
                return;
            }
            BLL_PropuestaManager.proposeTeam(selectedEquipo, int.Parse(textBoxLevel.Text));

            updateGrid();
        }
    }
}
