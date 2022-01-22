using System;
using System.Collections.Generic;

namespace ProjektArbeitSuS.Klassen
{
    public partial class Fehlzeiten
    {
        public int Id { get; set; }
        public DateTime? DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public int Entschuldigt { get; set; }
        public int LehrerMatrikelnummer { get; set; }
        public int SchuelerMatrikelnummer { get; set; }

        public virtual Lehrer LehrerMatrikelnummerNavigation { get; set; } = null!;
        public virtual Schueler SchuelerMatrikelnummerNavigation { get; set; } = null!;
    }
}
