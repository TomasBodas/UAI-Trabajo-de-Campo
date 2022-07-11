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
using UAICampo.BE;
using UAICampo.BLL;
using UAICampo.Services;

namespace UAICampo.UI
{
    public partial class Equipo_Manager : UserControl
    {
        frmEpicaDetalle frmEpica;
        frmEquipoManager frmEquipoManager = null;
        public Equipo_Manager()
        {
            InitializeComponent();
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
    }
}
