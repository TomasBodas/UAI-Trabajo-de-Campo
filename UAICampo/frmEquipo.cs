using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UAICampo.BE;
using UAICampo.BLL;

namespace UAICampo.UI
{
    public partial class frmEquipo : Form
    {
        BLL_EquipoManager bllEquipo;
        List<Equipo> equipos;
        frmEquipoManager frmEquipoManager = null;
        public frmEquipo()
        {
            InitializeComponent();

            bllEquipo = new BLL_EquipoManager();
        }

        private void frmEquipo_Load(object sender, EventArgs e)
        {
            equipos = bllEquipo.getAll().ToList();

            comboBox1.Items.Clear();
            foreach (var item in equipos)
            {
                comboBox1.Items.Add(item.Name);
            }
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
    }
}
