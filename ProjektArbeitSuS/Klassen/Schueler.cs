using System;
using System.Collections.Generic;

namespace ProjektArbeitSuS.Klassen
{
    public partial class Schueler
    {
        public Schueler()
        {
            DatenSchuelers = new HashSet<DatenSchueler>();
            Fehlzeitens = new HashSet<Fehlzeiten>();
        }

        public int Matrikelnummer { get; set; }
        public string? Vorname { get; set; }
        public string? Nachname { get; set; }
        public DateTime? Geburtsdatum { get; set; }
        public string? Password { get; set; }
        public int RfidchipUid { get; set; }
        public int SchuhlKlassenId { get; set; }

        public virtual Rfidchip RfidchipU { get; set; } = null!;
        public virtual SchuhlKlassen SchuhlKlassen { get; set; } = null!;
        public virtual ICollection<DatenSchueler> DatenSchuelers { get; set; }
        public virtual ICollection<Fehlzeiten> Fehlzeitens { get; set; }
    }
}
