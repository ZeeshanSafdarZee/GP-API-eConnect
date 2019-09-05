using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.API.Models
{
    public class SalesOrderResponseDto
    {
        public bool Success { get; set; }
        public string OrderNumber { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string DocumentData { get; set; }
        public string Elapsed { get; set; }
    }
}
