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
    public partial class TareasController : UserControl, IObserver
    {
        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();
        BLL_LanguageManager bllLanguage;
        public TareasController()
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
                items2.Add(new ComboboxItem { Text = tarea.Title, Value = tarea.Id });

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
                items2.Add(new ComboboxItem { Text = tarea.Title, Value = tarea.Id });

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

            frmTareaDetalle detObj = new frmTareaDetalle { tarea = BLL_TareasManager.FindById(objId), user = UserInstance.getInstance().user };
            detObj.Show();
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
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Details"), buttonDetails2));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "MyTasks"), labelTareas));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "TeamTasks"), labelEquipoTareas));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Refresh"), buttonRefresh));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "AddTask"), buttonAddTask));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Finalize"), buttonFinalize));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Delete"), button1));

        }

        private void buttonFinalize_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                return;
            }

            Tarea tarea = new Tarea
            {
                Id = int.Parse((listBox1.SelectedItem as ComboboxItem).Value.ToString())
            };
            BLL_TareasManager.archive(tarea);
            BLL_LogManager.addMessage(new Log
            {
                Date = DateTime.Now,
                Code = "TASK_FINISHED",
                Description = String.Format("Task finished"),
                Type = LogType.Control,
                User = UserInstance.getInstance().user.Id
            });

            updateMyList();
        }

        private void buttonAssign_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem == null)
            {
                return;
            }

            Tarea tarea = new Tarea
            {
                Id = int.Parse((listBox2.SelectedItem as ComboboxItem).Value.ToString())
            };
            BLL_TareasManager.assignMember(tarea, UserInstance.getInstance().user.Id);
            updateTeamList();
            updateMyList();
        }

        private void buttonDeassign_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                return;
            }

            Tarea tarea = new Tarea
            {
                Id = int.Parse((listBox1.SelectedItem as ComboboxItem).Value.ToString())
            };
            BLL_TareasManager.deassignMember(tarea, UserInstance.getInstance().user.Id);
            updateTeamList();
            updateMyList();
        }

        private void buttonArchive_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem == null)
            {
                return;
            }

            Tarea tarea = new Tarea
            {
                Id = int.Parse((listBox2.SelectedItem as ComboboxItem).Value.ToString())
            };
            BLL_TareasManager.delete(tarea);
            MessageBox.Show("Task deleted sucessfully.");
            updateTeamList();
            updateMyList();
        }
    }
}
