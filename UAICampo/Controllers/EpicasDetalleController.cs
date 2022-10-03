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
using UAICampo.BE;
using UAICampo.BLL;
using UAICampo.Services;

namespace UAICampo.UI.Controllers
{
    public partial class EpicasDetalleController : UserControl
    {
        Epica epica;
        public EpicasDetalleController()
        {
            InitializeComponent();
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
    }
}
