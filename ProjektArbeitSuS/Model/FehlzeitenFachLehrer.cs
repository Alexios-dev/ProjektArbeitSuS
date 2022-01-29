using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektArbeitSuS.Model
{
    internal class FehlzeitenFachLehrer
    {
        SUSContext DBConnection = new SUSContext();
        public long Id { get; set; }
        public string Schueler { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime DatumBis { get; set; }

        public FehlzeitenFachLehrer(Fehlzeiten fehlzeiten)
        {
            try
            {

            }

        }
    }
}
