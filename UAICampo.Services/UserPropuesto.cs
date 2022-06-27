using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;

namespace UAICampo.Services
{
    public class UserPropuesto : User
    {
        public UserPropuesto()
        {

        }
        public UserPropuesto(object[] itemArray) : base()
        {
            this.Id = (int)itemArray[0];
            this.Username = (string)itemArray[1];
        }
        public int Ranking { get; set; }
        public double ValorTotal { get; set; }
        public double PromedioReconocimientoDeSuperiores { get; set; }
        public double PorcentajeObjetivosCumplidos { get; set; }
        public double CantidadObjetivosNoCumplidos { get; set; }
        public int CantidadReconocimientos { get; set; }
        public double PromedioReconocimiento { get; set; }
        
    }
}
