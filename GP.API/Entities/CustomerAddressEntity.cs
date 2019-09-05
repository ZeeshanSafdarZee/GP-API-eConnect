using System;
using System.Collections.Generic;

namespace GP.API.Entities
{
    public partial class CustomerAddressEntity
    {
        public string Custnmbr { get; set; }
        public string Adrscode { get; set; }
        public string Slprsnid { get; set; }
        public string Upszone { get; set; }
        public string Shipmthd { get; set; }
        public string Taxschid { get; set; }
        public string Cntcprsn { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Fax { get; set; }
        public DateTime Modifdt { get; set; }
        public DateTime Creatddt { get; set; }
        public string Gpsfointegrationid { get; set; }
        public short Integrationsource { get; set; }
        public string Integrationid { get; set; }
        public string Ccode { get; set; }
        public string Declid { get; set; }
        public string Locncode { get; set; }
        public string Salsterr { get; set; }
        public string Userdef1 { get; set; }
        public string Userdef2 { get; set; }
        public string ShipToName { get; set; }
        public short PrintPhoneNumberGb { get; set; }
        public DateTime DexRowTs { get; set; }
        public int DexRowId { get; set; }
    }
}
