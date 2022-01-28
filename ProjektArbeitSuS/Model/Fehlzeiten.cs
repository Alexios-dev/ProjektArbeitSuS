using System;
using System.Collections.Generic;

namespace ProjektArbeitSuS.Model
{
    public partial class Fehlzeiten
    {
        public long Id { get; set; }
        public DateTime? DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public int Entschuldigt { get; set; }
        public long LehrerMatrikelnummer { get; set; }
        public long SchuelerMatrikelnummer { get; set; }

        public virtual Lehrer LehrerMatrikelnummerNavigation { get; set; } = null!;
        public virtual Schueler SchuelerMatrikelnummerNavigation { get; set; } = null!;
    }
}
