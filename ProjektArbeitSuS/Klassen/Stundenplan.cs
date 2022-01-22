using System;
using System.Collections.Generic;

namespace ProjektArbeitSuS.Klassen
{
    public partial class Stundenplan
    {
        public Stundenplan()
        {
            StundenplanStundens = new HashSet<StundenplanStunden>();
        }

        public int Id { get; set; }
        public int SchuhlKlassenId { get; set; }

        public virtual SchuhlKlassen SchuhlKlassen { get; set; } = null!;
        public virtual ICollection<StundenplanStunden> StundenplanStundens { get; set; }
    }
}
