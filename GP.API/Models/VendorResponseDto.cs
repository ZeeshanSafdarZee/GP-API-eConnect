using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.API.Models
{
    public class VendorResponseDto
    {
		public bool Success { get; set; }
		public int ErrorCode { get; set; }
		public string Message { get; set; }
		public string Elapsed { get; set; }
	}
}
