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

namespace UAICampo.UI.Controllers
{
    public partial class TareasController : UserControl
    {

        public TareasController()
        {
            InitializeComponent();
        }

        private void buttonAddTask_Click(object sender, EventArgs e)
        {
            frmTareaDetalle tarea = new frmTareaDetalle();
            tarea.Show();
        }

        private void TareasController_Load(object sender, EventArgs e)
        {
            updateTeamList();
            updateMyList();  

        }
        public void updateTeamList()
        { 
            IEquipo selectedEquipo = BLL_EquipoManager.getUserTeam(UserInstance.getInstance().user);
            List<Tarea> tareas = BLL_TareasManager.getTasksByTeam((Equipo)selectedEquipo);
            var items2 = new List<Object>();
            foreach (Tarea tarea in tareas)
            {
                items2.Add(new ComboboxItem { Text = tarea.Description, Value = tarea.Id });

            }

            listBox2.DisplayMember = "Text";
            listBox2.ValueMember = "Value";
            listBox2.DataSource = items2;
        }

        public void updateMyList()
        {
            IEquipo selectedEquipo = BLL_EquipoManager.getUserTeam(UserInstance.getInstance().user);
            List<Tarea> tareas = BLL_TareasManager.getTasksByUser((Equipo)selectedEquipo, UserInstance.getInstance().user);
            var items2 = new List<Object>();
            foreach (Tarea tarea in tareas)
            {
                    items2.Add(new ComboboxItem { Text = tarea.Description, Value = tarea.Id });
                
            }

            listBox1.DisplayMember = "Text";
            listBox1.ValueMember = "Value";
            listBox1.DataSource = items2;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            updateTeamList();
            updateMyList();
        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem as ComboboxItem == null)
            {
                return;
            }

            int objId = int.Parse((listBox2.SelectedItem as ComboboxItem).Value.ToString());

            frmTareaDetalle detObj = new frmTareaDetalle { tarea = BLL_TareasManager.FindById(objId) };
            detObj.Show();
        }

        private void buttonDetails2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem as ComboboxItem == null)
            {
                return;
            }

            int objId = int.Parse((listBox1.SelectedItem as ComboboxItem).Value.ToString());

            frmTareaDetalle detObj = new frmTareaDetalle { tarea = BLL_TareasManager.FindById(objId) };
            detObj.Show();
        }
    }
}
