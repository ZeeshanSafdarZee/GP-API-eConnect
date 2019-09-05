using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GP.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GP.API.Services
{
	public class VendorRepository : IVendorRepository
	{
		private GPContext _context;

		public VendorRepository(GPContext context)
		{
			_context = context;
		}

		public bool VendorExists(string VendorID)
		{
			return _context.VendorEntity.Any(c => c.Vendorid == VendorID);
		}

		public VendorEntity GetVendor(string VendorID)
		{
			return _context.VendorEntity.Where(c => c.Vendorid == VendorID).FirstOrDefault();
		}

		public VendorAddressEntity GetVendorEFT(string VendorID, string AddressID)
		{
			return _context.VendorAddressEntity.Where(c => c.EFTInfo.Series == 4 && c.Vendorid == VendorID && c.Adrscode == AddressID).FirstOrDefault();
		}

		public IEnumerable<VendorEntity> GetVendors()
		{
			return _context.VendorEntity.OrderBy(c => c.Vendorid).ToList();
		}

		public VendorEntity GetVendorWithAddresses(string VendorID)
		{
			return _context.VendorEntity
				.Include(c => c.VendorAddresses)
				.Where(c => c.Vendorid == VendorID).FirstOrDefault();
		}

		
	}
}
