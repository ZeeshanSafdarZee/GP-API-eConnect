using GP.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.API.Services
{
    public interface ISOPOrderRepository
    {
        bool OrderExists(string Sopnumbe);
        IEnumerable<SOPWorkHeader> GetOrders();
        IEnumerable<SOPWorkHeader> GetUpdatedOrders(DateTime updatedSince);
        SOPWorkHeader GetOrder(string Sopnumbe);
        SOPWorkHeader GetOrderWithLines(string Sopnumbe);
        SOPWorkHeader GetOrderWithTracking(string Sopnumbe);
        
        IEnumerable<SOPTracking> GetOrderTracking(string Sopnumbe);
        
    }
}
