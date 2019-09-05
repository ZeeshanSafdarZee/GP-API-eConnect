using System;
using System.Collections.Generic;

namespace GP.API.Entities
{
    public partial class PMOpenEntity
    {
        public string Vchrnmbr { get; set; }
        public string Vendorid { get; set; }
        public short Doctype { get; set; }
        public DateTime Docdate { get; set; }
        public string Docnumbr { get; set; }
        public decimal Docamnt { get; set; }
        public decimal Curtrxam { get; set; }
        public decimal Distknam { get; set; }
        public decimal Discamnt { get; set; }
        public decimal Dscdlram { get; set; }
        public string Bachnumb { get; set; }
        public string Trxsorce { get; set; }
        public string Bchsourc { get; set; }
        public DateTime Discdate { get; set; }
        public DateTime Duedate { get; set; }
        public string Pordnmbr { get; set; }
        public decimal Ten99amnt { get; set; }
        public decimal Wrofamnt { get; set; }
        public decimal Disamtav { get; set; }
        public string Trxdscrn { get; set; }
        public decimal Un1099am { get; set; }
        public decimal Bktpuram { get; set; }
        public decimal Bktfrtam { get; set; }
        public decimal Bktmscam { get; set; }
        public byte Voided { get; set; }
        public byte Hold { get; set; }
        public string Chekbkid { get; set; }
        public DateTime Dinvpdof { get; set; }
        public decimal Ppsamded { get; set; }
        public short Ppstaxrt { get; set; }
        public short Pgramsbj { get; set; }
        public decimal Gstdsamt { get; set; }
        public DateTime Posteddt { get; set; }
        public string Ptdusrid { get; set; }
        public DateTime Modifdt { get; set; }
        public string Mdfusrid { get; set; }
        public short Pyenttyp { get; set; }
        public string Cardname { get; set; }
        public decimal Prchamnt { get; set; }
        public decimal Trdisamt { get; set; }
        public decimal Mscchamt { get; set; }
        public decimal Frtamnt { get; set; }
        public decimal Taxamnt { get; set; }
        public decimal Ttlpymts { get; set; }
        public string Curncyid { get; set; }
        public string Pymtrmid { get; set; }
        public string Shipmthd { get; set; }
        public string Taxschid { get; set; }
        public string Pchschid { get; set; }
        public string Frtschid { get; set; }
        public string Mscschid { get; set; }
        public DateTime Pstgdate { get; set; }
        public decimal Disavtkn { get; set; }
        public short Cntrltyp { get; set; }
        public decimal Noteindx { get; set; }
        public short Prctdisc { get; set; }
        public decimal Retnagam { get; set; }
        public byte Ictrx { get; set; }
        public DateTime TaxDate { get; set; }
        public DateTime Prchdate { get; set; }
        public byte Corrctn { get; set; }
        public byte Simplifd { get; set; }
        public decimal Bnkrcamt { get; set; }
        public byte Aplywith { get; set; }
        public byte Electronic { get; set; }
        public byte Ectrx { get; set; }
        public byte DocPrinted { get; set; }
        public byte TaxInvReqd { get; set; }
        public string Vndchknm { get; set; }
        public decimal BackoutTradeDisc { get; set; }
        public byte Cbvat { get; set; }
        public string Vadcdtro { get; set; }
        public short Ten99type { get; set; }
        public short Ten99boxnumber { get; set; }
        public string Ponumber { get; set; }
        public short WorkflowStatus { get; set; }
        public DateTime DexRowTs { get; set; }
        public int DexRowId { get; set; }
    }
}
