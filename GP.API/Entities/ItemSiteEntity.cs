using System;
using System.Collections.Generic;

namespace GP.API.Entities
{
    public partial class ItemSiteEntity
    {
        public string Itemnmbr { get; set; }
        public string Locncode { get; set; }
        public string Binnmbr { get; set; }
        public short Rcrdtype { get; set; }
        public string Primvndr { get; set; }
        public byte Itmfrflg { get; set; }
        public decimal Bgngqty { get; set; }
        public decimal Lsordqty { get; set; }
        public decimal Lrcptqty { get; set; }
        public DateTime Lstorddt { get; set; }
        public string Lsordvnd { get; set; }
        public DateTime Lsrcptdt { get; set; }
        public decimal Qtyrqstn { get; set; }
        public decimal Qtyonord { get; set; }
        public decimal Qtybkord { get; set; }
        public decimal QtyDropShipped { get; set; }
        public decimal Qtyinuse { get; set; }
        public decimal Qtyinsvc { get; set; }
        public decimal Qtyrtrnd { get; set; }
        public decimal Qtydmged { get; set; }
        public decimal Qtyonhnd { get; set; }
        public decimal Atyalloc { get; set; }
        public decimal Qtycomtd { get; set; }
        public decimal Qtysold { get; set; }
        public DateTime Nxtcntdt { get; set; }
        public DateTime Nxtcnttm { get; set; }
        public DateTime Lstcntdt { get; set; }
        public DateTime Lstcnttm { get; set; }
        public short Stckcntintrvl { get; set; }
        public string LandedCostGroupId { get; set; }
        public string Buyerid { get; set; }
        public string Plannerid { get; set; }
        public short Orderpolicy { get; set; }
        public decimal Fxdordrqty { get; set; }
        public decimal Ordrpntqty { get; set; }
        public short Nmbrofdys { get; set; }
        public decimal Mnmmordrqty { get; set; }
        public decimal Mxmmordrqty { get; set; }
        public decimal Ordermultiple { get; set; }
        public short Replenishmentmethod { get; set; }
        public decimal Shrinkagefactor { get; set; }
        public decimal Prchsngldtm { get; set; }
        public decimal Mnfctrngfxdldtm { get; set; }
        public decimal Mnfctrngvrblldtm { get; set; }
        public decimal Stagingldtme { get; set; }
        public short Plnnngtmfncdys { get; set; }
        public short Dmndtmfncprds { get; set; }
        public byte Inclddinplnnng { get; set; }
        public byte Calculateatp { get; set; }
        public byte Autochkatp { get; set; }
        public byte Plnfnlpab { get; set; }
        public short Frcstcnsmptnprd { get; set; }
        public decimal Ordruptolvl { get; set; }
        public decimal Sftystckqty { get; set; }
        public decimal Reordervariance { get; set; }
        public string Poreceiptbin { get; set; }
        public string Poretrnbin { get; set; }
        public string Sofulfillmentbin { get; set; }
        public string Soreturnbin { get; set; }
        public string Bomrcptbin { get; set; }
        public string Materialissuebin { get; set; }
        public string Moreceiptbin { get; set; }
        public string Repairissuesbin { get; set; }
        public short ReplenishmentLevel { get; set; }
        public short PoporderMethod { get; set; }
        public string MasterLocationCode { get; set; }
        public short PopvendorSelection { get; set; }
        public short PoppricingSelection { get; set; }
        public decimal PurchasePrice { get; set; }
        public byte IncludeAllocations { get; set; }
        public byte IncludeBackorders { get; set; }
        public byte IncludeRequisitions { get; set; }
        public short Pickticketitemopt { get; set; }
        public byte Incldmrpmovein { get; set; }
        public byte Incldmrpmoveout { get; set; }
        public byte Incldmrpcancel { get; set; }
        public short MoveOutFence { get; set; }
        public byte Inactive { get; set; }
        public int DexRowId { get; set; }
    }
}
