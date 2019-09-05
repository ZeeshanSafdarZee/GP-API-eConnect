using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GP.API.Entities;

namespace GP.API.Services
{
    public interface IVendorRepository
    {
		bool VendorExists(string VendorID);
		IEnumerable<VendorEntity> GetVendors();
		VendorEntity GetVendor(string VendorID);
		VendorEntity GetVendorWithAddresses(string VendorID);
		VendorAddressEntity GetVendorEFT(string VendorID, string AddressID);
    }
}
