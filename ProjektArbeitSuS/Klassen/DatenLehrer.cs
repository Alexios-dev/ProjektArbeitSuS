using System;
using System.Collections.Generic;

namespace ProjektArbeitSuS.Klassen
{
    public partial class DatenLehrer
    {
        public int Id { get; set; }
        public DateTime? DatumVon { get; set; }
        public int LehrerMatrikelnummer { get; set; }
        public int RfidleserId { get; set; }

        public virtual Lehrer LehrerMatrikelnummerNavigation { get; set; } = null!;
        public virtual Rfidleser Rfidleser { get; set; } = null!;
    }
}
