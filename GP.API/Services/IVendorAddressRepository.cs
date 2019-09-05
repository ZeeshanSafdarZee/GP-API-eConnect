using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GP.API.Entities;

namespace GP.API.Services
{
    public interface IVendorAddressRepository
    {
		bool VendorAddressExists(string VendorID, string AddressID);
		IEnumerable<VendorAddressEntity> GetVendorAddresses(string VendorID);
		VendorAddressEntity GetVendorAddress(string VendorID, string AddressID);
		VendorAddressEntity GetVendorAddressWithEFT(string VendorID, string AddressID);

		//bool VendorEFTExists(string VendorID, string AddressID);
		//EFTInfoEntity GetVendorEFT(string VendorID, string AddressID);
	}
}
