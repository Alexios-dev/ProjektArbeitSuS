using System;
using System.Collections.Generic;

namespace ProjektArbeitSuS.Klassen
{
    public partial class Fach
    {
        public Fach()
        {
            StundenplanStundens = new HashSet<StundenplanStunden>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<StundenplanStunden> StundenplanStundens { get; set; }
    }
}
