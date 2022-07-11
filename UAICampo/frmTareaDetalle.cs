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
using UAICampo.BE;
using UAICampo.BLL;
using UAICampo.Services;

namespace UAICampo.UI
{
    public partial class frmTareaDetalle : Form
    {
		public IEquipo equipo;
		public Tarea tarea;
		BLL_EquipoManager bllEquipo = new BLL_EquipoManager();
        public frmTareaDetalle()
        {
            InitializeComponent();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
			dateTimePickerCreated.Value = DateTime.Now;

			if (DateTime.Parse(dateTimePickerDeadline.Value.ToString("yyyy-MM-dd")).Ticks < DateTime.Now.Ticks)
			{
				Interaction.MsgBox("pick valid date");
				return;
			}

			if (txtDescription.Text.Equals("") || txtValue.Text.Equals(""))
			{
				Interaction.MsgBox("Please complete all fields");
				return;
			}

			tarea = new Tarea
			{
				Title = txtTitle.Text,
				Description = txtDescription.Text,
				DateCreated = DateTime.Parse(dateTimePickerCreated.Value.ToString("MM/dd/yyyy")),
				DateFinished = null,
				State = 0,
				Archived = false,
				Value = int.Parse(txtValue.Text),
				DateDeadline = DateTime.Parse(dateTimePickerDeadline.Value.ToString("MM/dd/yyyy")),
				Equipo = this.equipo,
				EpicaId = int.Parse(comboBoxEpic.SelectedValue.ToString())
			};

			BLL_TareasManager.Save(tarea);

			if (comboBoxAssigned.SelectedItem != null)
			{
				int userId = int.Parse((comboBoxAssigned.SelectedItem as ComboboxItem).Value.ToString());
				if (userId != 0)
				{
					BLL_TareasManager.assignMember(tarea, userId);
				}
			}

			Interaction.MsgBox("Task created");
			this.Close();
		}

		private void updateTrabajadoresList()
		{
			if (this.equipo == null)
			{
				this.equipo = BLL_EquipoManager.getUserTeam(UserInstance.getInstance().user);
			}

			if (equipo == null)
			{
				return;
			}

			List<User> trabajadores = bllEquipo.getMembers(equipo);
			List<Epica> epics = BLL_TareasManager.getAllEpics();

			if (epics != null)
			{
				comboBoxEpic.DisplayMember = "Text";
				comboBoxEpic.ValueMember = "Value";

				var epicItem = new List<Object> { new ComboboxItem { Text = "", Value = 0 } };
				foreach (Epica epic in epics)
				{
					epicItem.Add(new ComboboxItem { Text = epic.Name, Value = epic.Id });
				}

				comboBoxEpic.DataSource = epicItem;
			}
			if (trabajadores == null || trabajadores.Count == 0)
			{
				return;
			}

			comboBoxAssigned.DisplayMember = "Text";
			comboBoxAssigned.ValueMember = "Value";

			var items = new List<Object> { new ComboboxItem { Text = "", Value = 0 } };
			foreach (User trabajador in trabajadores)
			{
				items.Add(new ComboboxItem { Text = trabajador.Username, Value = trabajador.Id });
			}

			comboBoxAssigned.DataSource = items;
		}

        private void frmTareaDetalle_Load(object sender, EventArgs e)
        {
			updateTrabajadoresList();

			if (tarea.Id != 0)
			{
				//btnPropose.Visible = false;

				txtTitle.Text = tarea.Title;
				txtDescription.Text = tarea.Description;
				txtValue.Text = tarea.Value.ToString();
				comboBoxEpic.SelectedValue = tarea.EpicaId;
				dateTimePickerCreated.Value = Convert.ToDateTime(tarea.DateCreated);
				dateTimePickerDeadline.Value = Convert.ToDateTime(tarea.DateDeadline);
				//dateTimePickerFinshed.Value = Convert.ToDateTime(tarea.DateFinished);
			}
		}
    }
}
