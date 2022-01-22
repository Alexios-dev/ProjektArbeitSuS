using System;
using System.Collections.Generic;

namespace ProjektArbeitSuS.Klassen
{
    public partial class Rfidleser
    {
        public Rfidleser()
        {
            DatenLehrers = new HashSet<DatenLehrer>();
            DatenSchuelers = new HashSet<DatenSchueler>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<DatenLehrer> DatenLehrers { get; set; }
        public virtual ICollection<DatenSchueler> DatenSchuelers { get; set; }
    }
}
