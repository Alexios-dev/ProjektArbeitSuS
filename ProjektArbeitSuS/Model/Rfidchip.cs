using System;
using System.Collections.Generic;

namespace ProjektArbeitSuS.Model
{
    public partial class Rfidchip
    {
        public Rfidchip()
        {
            Datens = new HashSet<Daten>();
            Lehrers = new HashSet<Lehrer>();
            Schuelers = new HashSet<Schueler>();
        }

        public long Uid { get; set; }
        public long? Number { get; set; }

        public virtual ICollection<Daten> Datens { get; set; }
        public virtual ICollection<Lehrer> Lehrers { get; set; }
        public virtual ICollection<Schueler> Schuelers { get; set; }
    }
}
