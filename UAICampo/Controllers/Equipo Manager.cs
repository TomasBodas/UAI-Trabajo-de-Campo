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
    public partial class Equipo_Manager : UserControl, IObserver
    {
        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();
        BLL_LanguageManager bllLanguage;
        frmEpicaDetalle frmEpica;
        frmEquipoManager frmEquipoManager = null;
        public Equipo_Manager()
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

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            if (frmEquipoManager == null)
            {
                frmEquipoManager = new frmEquipoManager();
                IEquipo selectedEquipo = BLL_EquipoManager.getUserTeam(UserInstance.getInstance().user);

                if (selectedEquipo == null)
                {
                    return;
                }

                frmEquipoManager.selectedEquipo = (Equipo)selectedEquipo;
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

        private void button2_Click(object sender, EventArgs e)
        {

            if (frmEpica == null)
            {
                frmEpica = new frmEpicaDetalle();
                frmEpica.FormClosed += new FormClosedEventHandler(frmEpica_FormClosed);
                frmEpica.Show();
            }
            else
            {
                frmEpica.BringToFront();
            }
        }
        private void frmEpica_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmEpica = null;
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
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Details"), buttonDetails));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "CreateEpic"), button2));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "ManageTeams"), groupBoxTeams));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "LeaderActions"), groupBoxLeader));

        }
    }
}
