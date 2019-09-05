using System;
using System.Collections.Generic;

namespace GP.API.Entities
{
    public partial class VendorEntity
    {
        public string Vendorid { get; set; }
        public string Vendname { get; set; }
        public string Vndchknm { get; set; }
        public string Vendshnm { get; set; }
        public string Vaddcdpr { get; set; }
        public string Vadcdpad { get; set; }
        public string Vadcdsfr { get; set; }
        public string Vadcdtro { get; set; }
        public string Vndclsid { get; set; }
        public string Vndcntct { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public string Phnumbr1 { get; set; }
        public string Phnumbr2 { get; set; }
        public string Phone3 { get; set; }
        public string Faxnumbr { get; set; }
        public string Upszone { get; set; }
        public string Shipmthd { get; set; }
        public string Taxschid { get; set; }
        public string Acnmvndr { get; set; }
        public string Txidnmbr { get; set; }
        public short Vendstts { get; set; }
        public string Curncyid { get; set; }
        public string Txrgnnum { get; set; }
        public string Parvenid { get; set; }
        public short Trddisct { get; set; }
        public short Ten99type { get; set; }
        public short Ten99boxnumber { get; set; }
        public decimal Minorder { get; set; }
        public string Pymtrmid { get; set; }
        public short Minpytyp { get; set; }
        public short Minpypct { get; set; }
        public decimal Minpydlr { get; set; }
        public short Mxiafvnd { get; set; }
        public decimal Maxindlr { get; set; }
        public string Comment1 { get; set; }
        public string Comment2 { get; set; }
        public string Userdef1 { get; set; }
        public string Userdef2 { get; set; }
        public decimal Crlmtdlr { get; set; }
        public string Pymntpri { get; set; }
        public byte Kpcalhst { get; set; }
        public byte Kgldsths { get; set; }
        public byte Kperhist { get; set; }
        public byte Kptrxhst { get; set; }
        public byte Hold { get; set; }
        public short Ptcshacf { get; set; }
        public short Credtlmt { get; set; }
        public short Writeoff { get; set; }
        public decimal Mxwofamt { get; set; }
        public byte Sbppsded { get; set; }
        public short Ppstaxrt { get; set; }
        public string Dxvarnum { get; set; }
        public DateTime Crtcomdt { get; set; }
        public DateTime Crtexpdt { get; set; }
        public byte Rtobutkn { get; set; }
        public byte Xpdtoblg { get; set; }
        public byte Prspayee { get; set; }
        public int Pmapindx { get; set; }
        public int Pmcshidx { get; set; }
        public int Pmdavidx { get; set; }
        public int Pmdtkidx { get; set; }
        public int Pmfinidx { get; set; }
        public int Pmmschix { get; set; }
        public int Pmfrtidx { get; set; }
        public int Pmtaxidx { get; set; }
        public int Pmwrtidx { get; set; }
        public int Pmprchix { get; set; }
        public int Pmrtngix { get; set; }
        public int Pmtdscix { get; set; }
        public int Acpuridx { get; set; }
        public int Purpvidx { get; set; }
        public decimal Noteindx { get; set; }
        public string Chekbkid { get; set; }
        public DateTime Modifdt { get; set; }
        public DateTime Creatddt { get; set; }
        public string Ratetpid { get; set; }
        public byte RevalueVendor { get; set; }
        public short PostResultsTo { get; set; }
        public short Freeonboard { get; set; }
        public string Govcrpid { get; set; }
        public string Govindid { get; set; }
        public short Disgrper { get; set; }
        public short Duegrper { get; set; }
        public string Docfmtid { get; set; }
        public byte TaxInvRecvd { get; set; }
        public short Userlang { get; set; }
        public short WithholdingType { get; set; }
        public short WithholdingFormType { get; set; }
        public short WithholdingEntityType { get; set; }
        public short TaxFileNumMode { get; set; }
        public DateTime Brthdate { get; set; }
        public short LaborPmtType { get; set; }
        public string Ccode { get; set; }
        public string Declid { get; set; }
        public byte Cbvat { get; set; }
        public short WorkflowApprovalStatus { get; set; }
        public short WorkflowPriority { get; set; }
        public short WorkflowStatus { get; set; }
        public string Vadcd1099 { get; set; }
        public DateTime DexRowTs { get; set; }
        public int DexRowId { get; set; }

		public ICollection<VendorAddressEntity> VendorAddresses { get; set; }
			= new List<VendorAddressEntity>();
		
	}
}
