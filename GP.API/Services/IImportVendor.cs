using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GP.API.Models;
using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace GP.API.Services
{
    public interface IImportVendor
    {
		VendorResponseDto ImportGPVendor(taUpdateCreateVendorRcd vendor);


	}
}
