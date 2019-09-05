using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GP.API.Entities;

namespace GP.API.Services
{
    public class SOPOrderRepository : ISOPOrderRepository
    {
        private GPContext _context;

        public SOPOrderRepository(GPContext context)
        {
            _context = context;
        }

        public bool OrderExists(string Sopnumbe)
        {
            return _context.SOPWorkHeader.Any(c => c.Sopnumbe == Sopnumbe);
        }

        public SOPWorkHeader GetOrder(string Sopnumbe)
        {
            return _context.SOPWorkHeader
                .Include(c => c.SOPWorkLines)
                .Where(c => c.Sopnumbe == Sopnumbe).FirstOrDefault();
        }

        public IEnumerable<SOPWorkHeader> GetOrders()
        {
            return _context.SOPWorkHeader
                .Include(c => c.SOPWorkLines)
                .OrderBy(c => c.Sopnumbe).ToList();
        }

        public IEnumerable<SOPWorkHeader> GetUpdatedOrders(DateTime updatedSince)
        {
            //.Include(c => c.ExtOrderInfo).FromSql("SELECT * FROM EXT_ORDER_INFO").Where(e => e.ExtOrderInfo.SOPNumber == e.Sopnumbe)
            return _context.SOPWorkHeader
                .Include(c => c.SOPWorkLines)
                .Where(c => c.DexRowTs >= updatedSince)
                .OrderBy(c => c.Sopnumbe).ToList();
        }

        public SOPWorkHeader GetOrderWithLines(string Sopnumbe)  //int Soptype, 
        {
            return _context.SOPWorkHeader.Include(c => c.SOPWorkLines)
                     .Where(c => c.Sopnumbe == Sopnumbe).FirstOrDefault();  // && c.Soptype == Soptype
        }

        public SOPWorkHeader GetOrderWithTracking(string Sopnumbe)  //int Soptype, 
        {
            return _context.SOPWorkHeader.Include(c => c.SOPTrackingNumbers)
                     .Where(c => c.Sopnumbe == Sopnumbe).FirstOrDefault();  // && c.Soptype == Soptype
        }

        public IEnumerable<SOPTracking> GetOrderTracking(string Sopnumbe)  //int Soptype, 
        {
            //For some reason EF Core isn't able to query from SOP10107, sends incorrect field names
            //return _context.SOPTracking
            //         .Where(c => c.Sopnumbe == Sopnumbe).ToList();  // && c.Soptype == Soptype

            return _context.SOPTracking.FromSql("SELECT * FROM SOP10107").Where(c => c.Sopnumbe == Sopnumbe).ToList();

        }

    
    }
}
