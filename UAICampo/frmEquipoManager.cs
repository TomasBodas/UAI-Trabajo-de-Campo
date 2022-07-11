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

namespace UAICampo.UI
{
    public partial class frmEquipoManager : Form, IObserver
    {
        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();
        public Equipo selectedEquipo = new Equipo();
        BLL_LanguageManager bllLanguage;
        BLL_UserManager bllUser;
        List<Profile> profiles;
        public frmEquipoManager()
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

        private void frmEquipoManager_Load(object sender, EventArgs e)
        {

            profiles = bllUser.getBusinessProfileList();


            comboBoxPosition.Items.Clear();
            foreach (var item in profiles)
            {
                comboBoxPosition.Items.Add(item.ProfileName);
            }


            if (selectedEquipo.Id != 0)
            {
                //btnPropose.Visible = false;

                textBoxTeamName.Text = selectedEquipo.Name;
                textBoxLevel.Text = selectedEquipo.Value.ToString();

                //List<IUser> users = BLL_UserManager.getPositions(selectedEquipo.Id);
                selectedEquipo.puestos = BLL_EquipoManager.getTeam(selectedEquipo);
                updateGrid();
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

        public void updateGrid()
        {
            dataGridView1.Rows.Clear();

            foreach (KeyValuePair<IProfile, IUser> puesto in selectedEquipo.puestos)
            {
                dataGridView1.Rows.Add(puesto.Key.ProfileName, puesto.Value != null ? puesto.Value.Username : "");
            }
        }


        private void buttonAddPosition_Click_1(object sender, EventArgs e)
        {

            if (comboBoxPosition.SelectedIndex == -1)
            {
                return;
            }

            Profile newPosition = bllUser.getProfileByName(comboBoxPosition.SelectedItem.ToString());
            selectedEquipo.puestos.Add(new KeyValuePair<IProfile, IUser>(newPosition, null));

            updateGrid();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0 || dataGridView1.SelectedRows[0].Cells[1].Value.ToString() != "")
            {
                Interaction.MsgBox("please_add_position");
                return;
            }

            frmProposal pe = new frmProposal(selectedEquipo, selectedEquipo.puestos[dataGridView1.SelectedRows[0].Index].Key, this);
            pe.Show();
        }

        private void btnPropose_Click_1(object sender, EventArgs e)
        {

            if (textBoxLevel.Text == "" || !textBoxLevel.Text.All(char.IsDigit))
            {
                Interaction.MsgBox("Please add level");
                return;
            }
            BLL_PropuestaManager.proposeTeam(selectedEquipo, int.Parse(textBoxLevel.Text));

            updateGrid();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0 || dataGridView1.SelectedRows[0].Index == -1)
            {
                Interaction.MsgBox("");
                return;
            }
            // BUG empty selectedRows
            selectedEquipo.puestos.RemoveAt(dataGridView1.SelectedRows[0].Index);
            updateGrid();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0 || dataGridView1.SelectedRows[0].Index == -1 || selectedEquipo.puestos[dataGridView1.SelectedRows[0].Index].Value == null)
            {
                Interaction.MsgBox("add employee");
                return;
            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {

            selectedEquipo.Name = textBoxTeamName.Text;

            if (selectedEquipo.Id != 0)
            {
                BLL_EquipoManager.Update(selectedEquipo);
            }
            else
            {
                if (BLL_EquipoManager.ifExists(textBoxTeamName.Text))
                {
                    Interaction.MsgBox("Team name already exists");
                    return;
                }

                BLL_EquipoManager.createTeam(selectedEquipo);
            }

            this.Close();
        }

        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
