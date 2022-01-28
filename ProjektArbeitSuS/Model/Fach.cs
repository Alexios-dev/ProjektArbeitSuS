using System;
using System.Collections.Generic;

namespace ProjektArbeitSuS.Model
{
    public partial class Fach
    {
        public Fach()
        {
            StundenplanStundens = new HashSet<StundenplanStunden>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public string Kuerzel { get; set; } = null!;

        public virtual ICollection<StundenplanStunden> StundenplanStundens { get; set; }
    }
}
