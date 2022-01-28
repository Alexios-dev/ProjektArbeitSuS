using System;
using System.Collections.Generic;

namespace ProjektArbeitSuS.Model
{
    public partial class StundenplanStunden
    {
        public StundenplanStunden()
        {
            LehrerMatrikelnummers = new HashSet<Lehrer>();
        }

        public long Id { get; set; }
        public DateTime? DateTimeVon { get; set; }
        public DateTime? DateTimeBis { get; set; }
        public string Bemerkung { get; set; } = null!;
        public long FachId { get; set; }
        public long StundenplanId { get; set; }

        public virtual Fach Fach { get; set; } = null!;
        public virtual Stundenplan Stundenplan { get; set; } = null!;

        public virtual ICollection<Lehrer> LehrerMatrikelnummers { get; set; }
    }
}
