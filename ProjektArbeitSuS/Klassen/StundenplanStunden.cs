using System;
using System.Collections.Generic;

namespace ProjektArbeitSuS.Klassen
{
    public partial class StundenplanStunden
    {
        public StundenplanStunden()
        {
            LehrerMatrikelnummers = new HashSet<Lehrer>();
        }

        public int Id { get; set; }
        public DateTime DateTimeVon { get; set; }
        public DateTime DateTimeBis { get; set; }
        public int FachId { get; set; }
        public int StundenplanId { get; set; }

        public virtual Fach Fach { get; set; } = null!;
        public virtual Stundenplan Stundenplan { get; set; } = null!;

        public virtual ICollection<Lehrer> LehrerMatrikelnummers { get; set; }
    }
}
