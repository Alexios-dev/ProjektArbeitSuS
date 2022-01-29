using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace ProjektArbeitSuS.Model.Verwaltung
{
    internal class datenSchuelersverwaltung
    {
        public Schueler Schueler;
        public List<DatenSchueler> ListdatenSchuelers = new List<DatenSchueler>();
        Model.SUSContext DBConnection = new Model.SUSContext();
        public void Init(Schueler schueler)
        {
            Schueler = schueler;

            try
            {
                ListdatenSchuelers.Clear();
                foreach (var a in DBConnection.Datens)
                {
                    if (a.RfidchipUid == Schueler.RfidchipUid)
                    {

                        Model.DatenSchueler ITEM = new Model.DatenSchueler(a);
                        ListdatenSchuelers.Add(ITEM);

                    }


                }

            }
            catch
            {
                MessageBox.Show("Failed get List Infos");
                return;
            }
            return;

        }
        public datenSchuelersverwaltung()
        {

        }
        public void RaumList(string Raum)
        {
            
            List<DatenSchueler> newListdatenSchuelers = new List<DatenSchueler>();
            
            foreach (var item in ListdatenSchuelers)
            {
                if(item.Raum.Contains(Raum))
                {
                    newListdatenSchuelers.Add(item);
                }
            }

            ListdatenSchuelers = newListdatenSchuelers;
        }
        public void DatumVonList(string DatumVon)
        {

            List<DatenSchueler> newListdatenSchuelers = new List<DatenSchueler>();

            foreach (var item in ListdatenSchuelers)
            {
                if (Convert.ToString(item.DatumVon).Contains(DatumVon))
                {
                    newListdatenSchuelers.Add(item);
                }
            }

            ListdatenSchuelers = newListdatenSchuelers;
        }
    }
}
