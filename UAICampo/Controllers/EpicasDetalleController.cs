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
using UAICampo.Abstractions.Observer;
using UAICampo.BE;
using UAICampo.BLL;
using UAICampo.Services;
using UAICampo.Services.Observer;

namespace UAICampo.UI.Controllers
{
    public partial class EpicasDetalleController : UserControl, IObserver
    {
        Epica epica;
        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();
        BLL_LanguageManager bllLanguage;
        public EpicasDetalleController()
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
            if (txtDescription.Text.Equals("") || txtTitle.Text.Equals(""))
            {
                Interaction.MsgBox("Please complete all fields");
                return;
            }

            epica = new Epica
            {
                Name = txtTitle.Text,
                Description = txtDescription.Text
            };

            BLL_TareasManager.SaveEpic(epica);

            Interaction.MsgBox("Epic created");
            BLL_LogManager.addMessage(new Log
            {
                Date = DateTime.Now,
                Code = "EPIC_CREATED",
                Description = String.Format("Epic created."),
                Type = LogType.Control,
                User = UserInstance.getInstance().user.Id
            });
            ((Form)this.TopLevelControl).Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Close();
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
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "EpicDetails"), labelEpicDetail));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Title"), labelTitle));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Description"), labelDescription));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Accept"), buttonAccept));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Cancel"), buttonCancel));
        }
    }
}
