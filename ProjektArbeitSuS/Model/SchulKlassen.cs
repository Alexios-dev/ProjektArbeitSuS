using System;
using System.Collections.Generic;

namespace ProjektArbeitSuS.Model
{
    public partial class SchulKlassen
    {
        public SchulKlassen()
        {
            Schuelers = new HashSet<Schueler>();
            Stundenplans = new HashSet<Stundenplan>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public long LehrerMatrikelnummer { get; set; }

        public virtual Lehrer LehrerMatrikelnummerNavigation { get; set; } = null!;
        public virtual ICollection<Schueler> Schuelers { get; set; }
        public virtual ICollection<Stundenplan> Stundenplans { get; set; }
    }
}
