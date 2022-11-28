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
using UAICampo.BLL;
using UAICampo.Services;
using UAICampo.Services.Observer;

namespace UAICampo.UI.Controllers
{
    public partial class BitacoraController : UserControl, IObserver
    {
        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();
        BLL_LanguageManager bllLanguage;
        BLL_UserManager bllUser;
        BLL_LogManager bllLog;
        IList<Log> logList;
        public BitacoraController()
        {
            InitializeComponent();
            bllLanguage = new BLL_LanguageManager();
            bllUser = new BLL_UserManager();
            bllLog = new BLL_LogManager();
            logList = new List<Log>();

            SetControllerTags();

            if (UserInstance.getInstance().user != null)
            {
                UserInstance.getInstance().user.Add(this);
                Update();
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
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "From"), label1));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "To"), label2));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Type"), label3));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Search"), button1));
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

        private void BitacoraController_Load(object sender, EventArgs e)
        {
            updateGrid();
        }

        public void updateGrid()
        {
            dataGridView1.Rows.Clear();
            var filter = string.IsNullOrEmpty(textBox1.Text) ? null : textBox1.Text;
            logList = bllLog.getAll(dateTimePicker1.Value, dateTimePicker2.Value, filter);
            foreach (var item in logList)
            {
                dataGridView1.Rows.Add(item.Code, item.Description, item.Type, item.Date, item.User);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateGrid();
        }
    }
}
