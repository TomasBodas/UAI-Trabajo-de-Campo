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
    public partial class ProposalController : UserControl
    {
        public Equipo equipo;
        public IProfile puesto;
        public ProposalController()
        {
            InitializeComponent();
        }

        private void fillRecommended(Equipo equipo, IProfile puesto)
        {
            dataGridViewProposal.Rows.Clear();

            List<UserPropuesto> usuarioPropuestos = BLL_PropuestaManager.GetPropuesta(equipo, 5, equipo.Value, puesto);

            foreach (UserPropuesto up in usuarioPropuestos)
            {
                dataGridViewProposal.Rows.Add(up.Id, up.Username, BLL_UserManager.getUserProfile(up).ProfileName, up.ValorTotal,
                    up.PromedioReconocimientoDeSuperiores,
                    up.PorcentajeObjetivosCumplidos,
                    up.PromedioReconocimiento,
                    up.CantidadObjetivosNoCumplidos,
                    up.CantidadReconocimientos
                    );
            }
        }

        private void ProposalController_Load(object sender, EventArgs e)
        {

            fillRecommended(equipo, puesto);
        }
    }
}
