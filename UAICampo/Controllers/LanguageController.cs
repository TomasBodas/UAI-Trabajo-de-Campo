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

        public static List<Language> languages;

        public LanguageController()
        {
            InitializeComponent();
            languageBLL = new BLL_LanguageManager();

            languages = languageBLL.getAll().ToList();

            languagesToolStripMenuItem.DropDownItems.Clear();
            foreach (var item in languages)
            {
                languagesToolStripMenuItem.DropDownItems.Add(item.Name, null, DropDown_Click);
            }
        }

        private void DropDown_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;

            if(item!=null)
            {
                foreach (Language language in languages)
                {
                    if (language.Name == sender.ToString())
                    {
                        //Update user class property language
                        UserInstance.getInstance().user.language = languageBLL.getLanguage(language.Id);

                        //Update user language in DB
                        languageBLL.UpdateUserLanguage();

                        //Notify user observers
                        UserInstance.getInstance().user.Notification();
                    }
                }
            }
        }

    }
}
