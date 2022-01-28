using System;
using System.Collections.Generic;

namespace ProjektArbeitSuS.Model
{
    public partial class Schueler
    {
        public Schueler()
        {
            Fehlzeitens = new HashSet<Fehlzeiten>();
        }

        public long Matrikelnummer { get; set; }
        public string? Vorname { get; set; }
        public string? Nachname { get; set; }
        public DateTime? Geburtsdatum { get; set; }
        public string Password { get; set; } = null!;
        public long RfidchipUid { get; set; }
        public long SchulKlassenId { get; set; }

        public virtual Rfidchip RfidchipU { get; set; } = null!;
        public virtual SchulKlassen SchulKlassen { get; set; } = null!;
        public virtual ICollection<Fehlzeiten> Fehlzeitens { get; set; }
    }
}
