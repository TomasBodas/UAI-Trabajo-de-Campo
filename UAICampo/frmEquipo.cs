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
    public partial class frmEquipo : Form, IObserver
    {
        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();
        BLL_LanguageManager bllLanguage;
        BLL_EquipoManager bllEquipo;
        List<Equipo> equipos;
        frmEquipoManager frmEquipoManager = null;
        public frmEquipo()
        {
            InitializeComponent();

            bllEquipo = new BLL_EquipoManager();

            bllLanguage = new BLL_LanguageManager();

            SetControllerTags();

            if (UserInstance.getInstance().user != null)
            {
                UserInstance.getInstance().user.Add(this);
                Update();
            }
        }

        private void frmEquipo_Load(object sender, EventArgs e)
        {
            updateEquipoList();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (frmEquipoManager == null)
            {
                frmEquipoManager = new frmEquipoManager();
                frmEquipoManager.FormClosed += new FormClosedEventHandler(frmEquipoManager_FormClosed);
                frmEquipoManager.Show();
            }
            else
            {
                frmEquipoManager.BringToFront();
            }
        }

        private void frmEquipoManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmEquipoManager = null;
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            if (frmEquipoManager == null)
            {
                frmEquipoManager = new frmEquipoManager();
                Equipo selectedEquipo = BLL_EquipoManager.FindByName(comboBox1.SelectedItem.ToString());

                if (selectedEquipo == null)
                {
                    return;
                }

                frmEquipoManager.selectedEquipo = selectedEquipo;
                frmEquipoManager.FormClosed += new FormClosedEventHandler(frmEquipoManager_FormClosed);
                frmEquipoManager.Show();
            }
            else
            {
                frmEquipoManager.BringToFront();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                return;
            }
            bllEquipo.Delete(int.Parse((comboBox1.SelectedItem as ComboboxItem).Value.ToString()));
            updateEquipoList();
        }

        private void updateEquipoList()
        {
            equipos = bllEquipo.getAll().ToList();

            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";

            var items = new List<Object>();
            foreach (Equipo equipo in equipos)
            {
                items.Add(new ComboboxItem { Text = equipo.Name, Value = equipo.Id });
            }

            comboBox1.DataSource = items;
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
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "TeamList"), labelTeamList));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Add"), buttonAdd));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Modify"), buttonModify));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Delete"), buttonDelete));

        }
    }
}
