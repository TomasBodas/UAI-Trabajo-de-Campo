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
    public partial class frmProposal : Form, IObserver
    {
        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();
        BLL_LanguageManager bllLanguage;
        List<Profile> profiles;
        BLL_UserManager bllUser = new BLL_UserManager();
        List<UserPropuesto> usuarioPropuestos;
        Equipo eq;
        IProfile pu;
        frmEquipoManager frm;
        Language selectedLanguage;
        public frmProposal()
        {
            InitializeComponent();
        }
        public frmProposal(Equipo equipo, IProfile puesto, frmEquipoManager frmEquipoManager)
        {
            InitializeComponent();
            eq = equipo;
            pu = puesto;
            frm = frmEquipoManager;
            fillRecommended(equipo, puesto);
            bllLanguage = new BLL_LanguageManager();

            SetControllerTags();

            if (UserInstance.getInstance().user != null)
            {
                UserInstance.getInstance().user.Add(this);
                Update();
            }
        }

        private void frmProposal_Load(object sender, EventArgs e)
        {
            profiles = bllUser.getBusinessProfileList();


            comboBoxPosition.Items.Clear();
            foreach (var item in profiles)
            {
                comboBoxPosition.Items.Add(item.ProfileName);
            }
        }

        private void fillRecommended(Equipo equipo, IProfile puesto)
        {

            dataGridViewProposal.Rows.Clear();

            usuarioPropuestos = BLL_PropuestaManager.GetPropuesta(equipo, 5, equipo.Value, puesto);

            foreach (UserPropuesto up in usuarioPropuestos)
            {
                dataGridViewProposal.Rows.Add(up.Id, up.Username, BLL_UserManager.getUserProfile(up).ProfileName, up.ValorTotal,
                    up.PromedioReconocimientoDeSuperiores,
                    up.PorcentajeObjetivosCumplidos,
                    up.PromedioReconocimiento,
                    up.CantidadObjetivosNoCumplidos,
                    up.CantidadReconocimientos
                    );
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            dataGridViewProposal.Rows.Clear();
            UserPropuesto up = BLL_PropuestaManager.GetSpecific(textBox1.Text, false);
            dataGridViewProposal.Rows.Add(up.Id, up.Username, BLL_UserManager.getUserProfile(up).ProfileName, up.ValorTotal,
                    up.PromedioReconocimientoDeSuperiores,
                    up.PorcentajeObjetivosCumplidos,
                    up.PromedioReconocimiento,
                    up.CantidadObjetivosNoCumplidos,
                    up.CantidadReconocimientos
                    );
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            fillRecommended(eq, pu);
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if (dataGridViewProposal.SelectedRows.Count == 0)
            {
                return;
            }

            var user = BLL_UserManager.FindById(int.Parse(dataGridViewProposal.SelectedRows[0].Cells["Id"].Value.ToString())); ;

            var position = BLL_UserManager.getProfileById(eq.puestos.FindAll(p => p.Key == pu && p.Value == null)[0].Key.ProfileId);

           eq.puestos.Remove(eq.puestos.FindAll(p => p.Key == pu && p.Value == null)[0]);
           eq.puestos.Add(new KeyValuePair<IProfile, IUser>(position, user));
           

            frm.updateGrid();
            this.Close();
        }

        //private void buttonFilter_Click(object sender, EventArgs e)
        //{
        //    dataGridViewProposal.Rows.Clear();
        //    List<UserPropuesto> filteredlist = usuarioPropuestos.Where(x => x.profileList.Any(y => y.ProfileName == comboBoxPosition.Text)).ToList();


        //    foreach (UserPropuesto up in filteredlist)
        //    {
        //        dataGridViewProposal.Rows.Add(up.Id, up.Username, BLL_UserManager.getUserProfile(up).ProfileName, up.ValorTotal,
        //            up.PromedioReconocimientoDeSuperiores,
        //            up.PorcentajeObjetivosCumplidos,
        //            up.PromedioReconocimiento,
        //            up.CantidadObjetivosNoCumplidos,
        //            up.CantidadReconocimientos
        //            );
        //    }
        //}

        private void SetControllerTags()
        {
            //In here, we set each controller tag list.
            //This list wil be made out of keyvaluepairs, with a controller, and a tag
            //Each Tag will be made out of two values
            //First value: license required for it to show up to the user
            //Second value: Word Tag, used for language runtime changes

            //General controllers------------------------------------------------------------------------------------
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Proposal"), labelProposal));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Scores"), groupBoxScores));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Refresh"), buttonRefresh));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Filter"), buttonFilter));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Search"), groupBoxSearch));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Search"), buttonSearch));
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
