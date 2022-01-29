using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjektArbeitSuS.Model.Verwaltung
{
    internal class datenFachLehrerverwaltung
    {
        public Lehrer? Lehrer;

        public List<FehlzeitenFachLehrer> FehlzeitenFachLehrerList = new List<FehlzeitenFachLehrer>();
        Model.SUSContext DBConnection = new Model.SUSContext();
        public void Init(Lehrer lehrer)
        {

            Lehrer = lehrer;

            try
            {
                FehlzeitenFachLehrerList.Clear();
                foreach(var item in DBConnection.Fehlzeitens)
                {
                    if(item.LehrerMatrikelnummer == Lehrer.Matrikelnummer)
                    {
                        FehlzeitenFachLehrerList.Add(new FehlzeitenFachLehrer(item));
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
        public void Fach(string fach)
        {
            Init(Lehrer);
            List<FehlzeitenFachLehrer> newFehlzeitenFachLehrerList = new List<FehlzeitenFachLehrer>();

            foreach (var item in FehlzeitenFachLehrerList)
            {
                if (item.FachName.Contains(fach))
                {
                    newFehlzeitenFachLehrerList.Add(item);
                }
            }

            FehlzeitenFachLehrerList = newFehlzeitenFachLehrerList;
        }
        public void Klasse(string klasse)
        {
            Init(Lehrer);
            List<FehlzeitenFachLehrer> newFehlzeitenFachLehrerList = new List<FehlzeitenFachLehrer>();

            foreach (var item in FehlzeitenFachLehrerList)
            {
                if (item.Klasse.Contains(klasse))
                {
                    newFehlzeitenFachLehrerList.Add(item);
                }
            }

            FehlzeitenFachLehrerList = newFehlzeitenFachLehrerList;
        }
        public void Schueler(string schuelerVorname)
        {
            Init(Lehrer);
            List<FehlzeitenFachLehrer> newFehlzeitenFachLehrerList = new List<FehlzeitenFachLehrer>();

            foreach (var item in FehlzeitenFachLehrerList)
            {
                if (item.SchuelerVorname.Contains(schuelerVorname))
                {
                    newFehlzeitenFachLehrerList.Add(item);
                }
            }

            FehlzeitenFachLehrerList = newFehlzeitenFachLehrerList;
        }
        public void Datum(string datum)
        {
            Init(Lehrer);
            List<FehlzeitenFachLehrer> newFehlzeitenFachLehrerList = new List<FehlzeitenFachLehrer>();

            foreach (var item in FehlzeitenFachLehrerList)
            {
                if (Convert.ToString(item.DatumVon).Contains(datum))
                {
                    newFehlzeitenFachLehrerList.Add(item);
                }
                else if (Convert.ToString(item.DatumBis).Contains(datum))
                {
                    newFehlzeitenFachLehrerList.Add(item);
                }
            }

            FehlzeitenFachLehrerList = newFehlzeitenFachLehrerList;
        }
    }
}
