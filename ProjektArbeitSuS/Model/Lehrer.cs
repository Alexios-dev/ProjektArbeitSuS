using System;
using System.Collections.Generic;

namespace ProjektArbeitSuS.Model
{
    public partial class Lehrer
    {
        public Lehrer()
        {
            Fehlzeitens = new HashSet<Fehlzeiten>();
            SchulKlassens = new HashSet<SchulKlassen>();
            StundenplanStundens = new HashSet<StundenplanStunden>();
        }

        public long Matrikelnummer { get; set; }
        public string? Vorname { get; set; }
        public string? Nachname { get; set; }
        public DateTime? Geburtsdatum { get; set; }
        public string? Kuerzel { get; set; }
        public string? Password { get; set; }
        public long RfidchipUid { get; set; }

        public virtual Rfidchip RfidchipU { get; set; } = null!;
        public virtual ICollection<Fehlzeiten> Fehlzeitens { get; set; }
        public virtual ICollection<SchulKlassen> SchulKlassens { get; set; }

        public virtual ICollection<StundenplanStunden> StundenplanStundens { get; set; }
    }
}
