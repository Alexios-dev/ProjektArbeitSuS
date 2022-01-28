using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace ProjektArbeitSuS.Model
{
    internal class DatenSchueler
    {
        public long Id { get; set; }
        public string DatumVon { get; set; }
        public string Raum { get; set; }

        public DatenSchueler(Daten daten)
        {
            
            Id = daten.Id;
            DatumVon = Convert.ToString(daten.DatumVon);
            if (daten.Rfidleser != null)
            {
                Raum = daten.Rfidleser.Name;
            }
            else
            {
                Raum = " ";
            }
            

        }
    }
}
