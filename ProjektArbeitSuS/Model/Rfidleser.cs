using System;
using System.Collections.Generic;

namespace ProjektArbeitSuS.Model
{
    public partial class Rfidleser
    {
        public Rfidleser()
        {
            Datens = new HashSet<Daten>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Daten> Datens { get; set; }
    }
}
