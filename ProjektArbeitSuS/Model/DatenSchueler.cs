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
        SUSContext DBConnection = new SUSContext();
        public long Id { get; set; }
        public string DatumVon { get; set; }
        public string Raum { get; set; }

        public DatenSchueler(Daten daten)
        {
            try
            {
                Id = daten.Id;
                DatumVon = Convert.ToString(daten.DatumVon);
                foreach (var item in DBConnection.Rfidlesers)
                {
                    if (item.Id == daten.RfidleserId)
                    {
                        Raum = item.Name;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ein Datensatz mit der ID " + Convert.ToString(Id) + "ist fehlerhaft bitte kontaktiere den Admin");
            }



        }
    }
}
