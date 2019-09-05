using GP.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.API.Services
{
    public interface ICustomerRepository
    {
        bool CustomerExists(string CustomerID);
        IEnumerable<CustomerEntity> GetCustomers();
        CustomerEntity GetCustomer(string CustomerID);
        CustomerEntity GetCustomerWithAddresses(string CustomerID);
        CustomerAddressEntity GetCustomerAddress(string CustomerID, string AddressID);
    }
}
