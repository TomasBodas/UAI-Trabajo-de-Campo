using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UAICampo.BLL;
using UAICampo.Services.Observer;
using UAICampo.Services;

namespace UAICampo.UI.Controllers
{
    public partial class LanguageController : UserControl
    {
        BLL_LanguageManager languageBLL;

        public LanguageController()
        {
            InitializeComponent();
            languageBLL = new BLL_LanguageManager();
        }

        private void languagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            languagesToolStripMenuItem.DropDownItems.Clear();
            IList<Language> languages = languageBLL.getAll();
            foreach (var item in languages)
            {
                languagesToolStripMenuItem.DropDownItems.Add(item.Name,null, DropDown_Click);
            }
        }

        private void DropDown_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;
            if(item!=null)
            {
                IList<Language> languages = languageBLL.getAll();
                int Id;

                foreach (Language language in languages)
                {
                    if (language.Name == sender.ToString())
                    {
                        UserInstance.getInstance().user.language = languageBLL.getLanguage(language.Id);
                    }
                }

                if (UserInstance.getInstance().user != null)
                {

                    UserInstance.getInstance().user.Notification();
                }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }

        //AGREGAR EVENTO DE CLICK Y LLAMAR BLL.SETLANGUAGE
        //subscribir al usuario?
        //Cambio de contraseña
        //Asignacion de perisos

    }
}
