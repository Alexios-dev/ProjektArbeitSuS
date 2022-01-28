using System;
using System.Collections.Generic;

namespace ProjektArbeitSuS.Model
{
    public partial class Daten
    {
        public long Id { get; set; }
        public DateTime DatumVon { get; set; }
        public long RfidleserId { get; set; }
        public long RfidchipUid { get; set; }

        public virtual Rfidchip RfidchipU { get; set; } = null!;
        public virtual Rfidleser Rfidleser { get; set; } = null!;
    }
}
