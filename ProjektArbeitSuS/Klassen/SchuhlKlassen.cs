using System;
using System.Collections.Generic;

namespace ProjektArbeitSuS.Klassen
{
    public partial class SchuhlKlassen
    {
        public SchuhlKlassen()
        {
            Schuelers = new HashSet<Schueler>();
            Stundenplans = new HashSet<Stundenplan>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int LehrerMatrikelnummer { get; set; }

        public virtual Lehrer LehrerMatrikelnummerNavigation { get; set; } = null!;
        public virtual ICollection<Schueler> Schuelers { get; set; }
        public virtual ICollection<Stundenplan> Stundenplans { get; set; }
    }
}
