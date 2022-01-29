using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace ProjektArbeitSuS.Model
{
    internal class FehlzeitenFachLehrer
    {
        SUSContext DBConnection = new SUSContext();
        public Schueler Schueler { get; set; }
        public Fehlzeiten Fehlzeiten { get; set; }
        public SchulKlassen SchulKlassen { get; set; }
        public StundenplanStunden StundenplanStunden { get; set; }
        public Fach Fach { get; set; }
        public long Id { get; set; }
        public string Entschuldigt { get; set; }
        public string FachName { get; set; }
        public string SchuelerVorname { get; set; }
        public string Klasse { get; set; }
        public DateTime? DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }

        public FehlzeitenFachLehrer(Fehlzeiten fehlzeiten)
        {
            try
            {
                Fehlzeiten = fehlzeiten;
                Id = fehlzeiten.Id;
                foreach(var item in DBConnection.Schuelers)
                {
                    
                    if(item.Matrikelnummer == fehlzeiten.SchuelerMatrikelnummer)
                    {
                        
                        Schueler = item;
                        SchuelerVorname = item.Vorname+" "+item.Nachname;
                        break;
                    }
                }
                foreach(var item in DBConnection.SchulKlassens)
                {
                    if(item.Id == Schueler.SchulKlassenId)
                    {
                        SchulKlassen = item;
                        Klasse = SchulKlassen.Name;
                        break;
                    }
                }
                foreach (var item in DBConnection.StundenplanStundens)
                {
                    if(item.Id == fehlzeiten.StundenplanStundenId)
                    {
                        
                        StundenplanStunden = item;
                        break;
                    }
                }
                foreach(var item in DBConnection.Faches)
                {
                    if(item.Id == StundenplanStunden.FachId)
                    {
                        MessageBox.Show(Convert.ToString(item.Name));
                        Fach = item;
                        FachName = item.Name;
                        break;
                    }
                }
                
                if (fehlzeiten.Entschuldigt == true)
                {
                    Entschuldigt = "Ja";
                }
                else if (fehlzeiten.Entschuldigt == false)
                {
                    Entschuldigt = "Nein";
                }
                DatumVon = fehlzeiten.DatumVon;
                DatumBis = fehlzeiten.DatumBis;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
