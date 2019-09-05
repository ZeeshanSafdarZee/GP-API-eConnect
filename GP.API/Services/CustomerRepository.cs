using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GP.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GP.API.Services
{
    public class CustomerRepository : ICustomerRepository
    {

        private GPContext _context;

        public CustomerRepository(GPContext context)
        {
            _context = context;
        }

        public bool CustomerExists(string CustomerID)
        {
            return _context.CustomerEntity.Any(c => c.Custnmbr == CustomerID);
        }

        public IEnumerable<CustomerEntity> GetCustomers()
        {
            return _context.CustomerEntity.OrderBy(c => c.Custnmbr).ToList();
        }

        public CustomerEntity GetCustomer(string CustomerID)
        {
            return _context.CustomerEntity.Where(c => c.Custnmbr == CustomerID).FirstOrDefault();
        }

        public CustomerAddressEntity GetCustomerAddress(string CustomerID, string AddressID)
        {
            return _context.CustomerAddressEntity.Where(c => c.Custnmbr == CustomerID && c.Adrscode == AddressID).FirstOrDefault();
        }
        
        public CustomerEntity GetCustomerWithAddresses(string CustomerID)
        {
            return _context.CustomerEntity.Include(c => c.CustomerAddresses)
                    .Where(c => c.Custnmbr == CustomerID).FirstOrDefault();
        }
    }
}
