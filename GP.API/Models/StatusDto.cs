using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.API.Models
{
    public class StatusDto
    {
		public bool SQLAvailable { get; set; }
		public bool eConnectAvailable { get; set; }
		public string Message { get; set; }
		public string Elapsed { get; set; }
	}
}
