using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GP.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GP.API.Services
{
	public class VendorAddressRepository : IVendorAddressRepository
	{
		GPContext _context;

		public VendorAddressRepository(GPContext context)
		{
			_context = context;
		}

		public bool VendorAddressExists(string VendorID, string AddressID)
		{
			return _context.VendorAddressEntity.Any(c => c.Vendorid == VendorID && c.Adrscode == AddressID);
		}

		public VendorAddressEntity GetVendorAddress(string VendorID, string AddressID)
		{
			return _context.VendorAddressEntity.Where(c => c.Vendorid == VendorID && c.Adrscode == AddressID).FirstOrDefault();
		}

		public IEnumerable<VendorAddressEntity> GetVendorAddresses(string VendorID)
		{
			return _context.VendorAddressEntity.Where(c => c.Vendorid == VendorID).ToList();
		}

		public VendorAddressEntity GetVendorAddressWithEFT(string VendorID, string AddressID)
		{
			return _context.VendorAddressEntity.Include(c => c.EFTInfo)
				.Where(c => c.Vendorid == VendorID && c.Adrscode == AddressID).FirstOrDefault();
		}

		//public EFTInfoEntity GetVendorEFT(string VendorID, string AddressID)
		//{
		//	return _context.EFTEntity.Where(c => c.Vendorid == VendorID && c.Adrscode == AddressID).FirstOrDefault();
		//}

		//public bool VendorEFTExists(string VendorID, string AddressID)
		//{
		//	return _context.EFTEntity.Any(c => c.Vendorid == VendorID && c.Adrscode == AddressID);
		//}	
	}
}
