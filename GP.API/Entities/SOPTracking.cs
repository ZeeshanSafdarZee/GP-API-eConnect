using System;
using System.Collections.Generic;

namespace GP.API.Entities
{
    public partial class SOPTracking
    {
        public string Sopnumbe { get; set; }
        public short Soptype { get; set; }
        public string TrackingNumber { get; set; }
        public int DexRowId { get; set; }
    }
}
