using System;
using System.Collections.Generic;

namespace ProjektArbeitSuS.Klassen
{
    public partial class Lehrer
    {
        public Lehrer()
        {
            DatenLehrers = new HashSet<DatenLehrer>();
            Fehlzeitens = new HashSet<Fehlzeiten>();
            SchuhlKlassens = new HashSet<SchuhlKlassen>();
            StundenplanStundens = new HashSet<StundenplanStunden>();
        }

        public int Matrikelnummer { get; set; }
        public string Vorname { get; set; } = null!;
        public string Nachname { get; set; } = null!;
        public DateTime Geburtsdatum { get; set; }
        public string Kuerzel { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RfidchipUid { get; set; }

        public virtual Rfidchip RfidchipU { get; set; } = null!;
        public virtual ICollection<DatenLehrer> DatenLehrers { get; set; }
        public virtual ICollection<Fehlzeiten> Fehlzeitens { get; set; }
        public virtual ICollection<SchuhlKlassen> SchuhlKlassens { get; set; }

        public virtual ICollection<StundenplanStunden> StundenplanStundens { get; set; }
    }
}
