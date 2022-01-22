using System;
using System.Collections.Generic;

namespace ProjektArbeitSuS.Klassen
{
    public partial class DatenSchueler
    {
        public int Id { get; set; }
        public DateTime? DatumVon { get; set; }
        public int SchuelerMatrikelnummer { get; set; }
        public int RfidleserId { get; set; }

        public virtual Rfidleser Rfidleser { get; set; } = null!;
        public virtual Schueler SchuelerMatrikelnummerNavigation { get; set; } = null!;
    }
}
