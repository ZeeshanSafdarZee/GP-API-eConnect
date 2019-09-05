using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.API.Models
{
    public class SOPTrackingDto
    {
        public string Sopnumbe { get; set; }
        public short Soptype { get; set; }
        public string TrackingNumber { get; set; }
        public int DexRowId { get; set; }
    }
}
