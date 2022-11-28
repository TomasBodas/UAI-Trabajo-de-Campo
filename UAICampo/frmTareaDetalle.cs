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
using static UAICampo.BE.Tarea;

namespace UAICampo.UI
{
    public partial class frmTareaDetalle : Form, IObserver
    {
		public IEquipo equipo;
		public Tarea tarea;
		public Tarea tareaUpdated;
		public User user;
		BLL_EquipoManager bllEquipo = new BLL_EquipoManager();
		List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();
		BLL_LanguageManager bllLanguage;
		public frmTareaDetalle()
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

        private void buttonAccept_Click(object sender, EventArgs e)
        {
			dateTimePickerCreated.Value = DateTime.Now;

			if (DateTime.Parse(dateTimePickerDeadline.Value.ToString("yyyy-MM-dd")).Ticks < DateTime.Now.Ticks)
			{
				Interaction.MsgBox("Please pick a valid date.");
				return;
			}

			if (txtDescription.Text.Equals("") || txtValue.Text.Equals(""))
			{
				Interaction.MsgBox("Please complete all fields");
				return;
			}

            if (tarea == null)
            {
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
            }
            else
            {
				tareaUpdated = new Tarea
				{
					Id = tarea.Id,
					Title = txtTitle.Text,
					Description = txtDescription.Text,
					DateCreated = DateTime.Parse(dateTimePickerCreated.Value.ToString("MM/dd/yyyy")),
					DateFinished = null,
					Archived = false,
					Value = int.Parse(txtValue.Text),
					DateDeadline = DateTime.Parse(dateTimePickerDeadline.Value.ToString("MM/dd/yyyy")),
					Equipo = this.equipo,
					EpicaId = int.Parse(comboBoxEpic.SelectedValue.ToString())
				};
				if (comboBoxAssigned.SelectedValue != null)
				{
					tareaUpdated.State = (StateType)1;
					tareaUpdated.User = new User {  Id = int.Parse(comboBoxAssigned.SelectedValue.ToString()) };
				}
				else
				{
					tareaUpdated.State = 0;
				}
				BLL_TareasManager.updateTask(tareaUpdated);
            }


			if (comboBoxAssigned.SelectedItem != null)
			{
				int userId = int.Parse((comboBoxAssigned.SelectedItem as ComboboxItem).Value.ToString());
				if (userId != 0)
				{
					BLL_TareasManager.assignMember(tarea, userId);
				}
			}

			Interaction.MsgBox("Task created");
			BLL_LogManager.addMessage(new Log
			{
				Date = DateTime.Now,
				Code = "TASK_CREATED",
				Description = String.Format("Task created"),
				Type = LogType.Control,
				User = UserInstance.getInstance().user.Id
			});
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

			if (tarea != null)
			{
				//btnPropose.Visible = false;

				txtTitle.Text = tarea.Title;
				txtDescription.Text = tarea.Description;
				txtValue.Text = tarea.Value.ToString();
				comboBoxEpic.SelectedValue = tarea.EpicaId;
				dateTimePickerCreated.Value = Convert.ToDateTime(tarea.DateCreated);
				dateTimePickerDeadline.Value = Convert.ToDateTime(tarea.DateDeadline);
				//dateTimePickerFinshed.Value = Convert.ToDateTime(tarea.DateFinished);
				if (user != null)
                {
					comboBoxAssigned.SelectedValue = user.Id;
                }
			}
		}

        private void buttonCancel_Click(object sender, EventArgs e)
        {
			this.Close();
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
			controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "TaskDetails"), labelTaskDetail));
			controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Title"), labelTitle));
			controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Description"), labelDescription));
			controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Value"), labelValue));
			controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Epic"), labelEpic));
			controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "AssignedTo"), labelAssigned));
			controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "DateCreated"), labelDateCreated));
			controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "DateFinished"), labelDateFinished));
			controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Deadline"), labelDateDeadline));
			controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Accept"), buttonAccept));
			controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Cancel"), buttonCancel));

		}
	}
}
