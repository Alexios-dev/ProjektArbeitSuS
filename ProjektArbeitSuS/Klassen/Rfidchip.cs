using System;
using System.Collections.Generic;

namespace ProjektArbeitSuS.Klassen
{
    public partial class Rfidchip
    {
        public Rfidchip()
        {
            Lehrers = new HashSet<Lehrer>();
            Schuelers = new HashSet<Schueler>();
        }

        public int Uid { get; set; }
        public int Number { get; set; }

        public virtual ICollection<Lehrer> Lehrers { get; set; }
        public virtual ICollection<Schueler> Schuelers { get; set; }
    }
}
