using System;
using System.Collections.Generic;

namespace ProjektArbeitSuS.Model
{
    public partial class Stundenplan
    {
        public Stundenplan()
        {
            StundenplanStundens = new HashSet<StundenplanStunden>();
        }

        public long Id { get; set; }
        public long SchulKlassenId { get; set; }

        public virtual SchulKlassen SchulKlassen { get; set; } = null!;
        public virtual ICollection<StundenplanStunden> StundenplanStundens { get; set; }
    }
}
