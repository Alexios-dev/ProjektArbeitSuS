using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektArbeitSuS.Model.Verwaltung
{
    internal class datenFachLehrerverwaltung
    {
        public Lehrer Lehrer;
        public List<DatenSchueler> ListdatenSchuelers = new List<DatenSchueler>();
        Model.SUSContext DBConnection = new Model.SUSContext();
        public void Init()
        {

        }
    }
}
