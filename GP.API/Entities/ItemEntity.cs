using System;
using System.Collections.Generic;

namespace GP.API.Entities
{
    public partial class ItemEntity
    {
        public string Itemnmbr { get; set; }
        public string Itemdesc { get; set; }
        public decimal Noteindx { get; set; }
        public string Itmshnam { get; set; }
        public short Itemtype { get; set; }
        public string Itmgedsc { get; set; }
        public decimal Stndcost { get; set; }
        public decimal Currcost { get; set; }
        public int Itemshwt { get; set; }
        public short Decplqty { get; set; }
        public short Decplcur { get; set; }
        public string Itmtshid { get; set; }
        public short Taxoptns { get; set; }
        public int Ivivindx { get; set; }
        public int Ivivofix { get; set; }
        public int Ivcogsix { get; set; }
        public int Ivslsidx { get; set; }
        public int Ivsldsix { get; set; }
        public int Ivslrnix { get; set; }
        public int Ivinusix { get; set; }
        public int Ivinsvix { get; set; }
        public int Ivdmgidx { get; set; }
        public int Ivvaridx { get; set; }
        public int Dpshpidx { get; set; }
        public int Purpvidx { get; set; }
        public int Uppvidx { get; set; }
        public int Ivretidx { get; set; }
        public int Asmvridx { get; set; }
        public string Itmclscd { get; set; }
        public short Itmtrkop { get; set; }
        public string Lottype { get; set; }
        public byte Kperhist { get; set; }
        public byte Kptrxhst { get; set; }
        public byte Kpcalhst { get; set; }
        public byte Kpdsthst { get; set; }
        public byte Alwbkord { get; set; }
        public short Vctnmthd { get; set; }
        public string Uomschdl { get; set; }
        public string Altitem1 { get; set; }
        public string Altitem2 { get; set; }
        public string Uscatvls1 { get; set; }
        public string Uscatvls2 { get; set; }
        public string Uscatvls3 { get; set; }
        public string Uscatvls4 { get; set; }
        public string Uscatvls5 { get; set; }
        public string Uscatvls6 { get; set; }
        public short Mstrcdty { get; set; }
        public DateTime Modifdt { get; set; }
        public DateTime Creatddt { get; set; }
        public short Wrntydys { get; set; }
        public string Prclevel { get; set; }
        public string Locncode { get; set; }
        public int Pinflidx { get; set; }
        public int Purmcidx { get; set; }
        public int Ivinfidx { get; set; }
        public int Invmcidx { get; set; }
        public int Cgsinflx { get; set; }
        public int Cgsmcidx { get; set; }
        public string Itemcode { get; set; }
        public string Tcc { get; set; }
        public string PriceGroup { get; set; }
        public short Pricmthd { get; set; }
        public string Prchsuom { get; set; }
        public string Selnguom { get; set; }
        public short Ktacctsr { get; set; }
        public string Lastgensn { get; set; }
        public short Abccode { get; set; }
        public byte RevalueInventory { get; set; }
        public int TolerancePercentage { get; set; }
        public string PurchaseItemTaxSchedu { get; set; }
        public short PurchaseTaxOptions { get; set; }
        public short Itmplnnngtyp { get; set; }
        public short Sttstclvlprcntg { get; set; }
        public string Cntryorgn { get; set; }
        public byte Inactive { get; set; }
        public short Minshelf1 { get; set; }
        public short Minshelf2 { get; set; }
        public byte Includeindp { get; set; }
        public byte Lotexpwarn { get; set; }
        public short Lotexpwarndays { get; set; }
        public string Lastgenlot { get; set; }
        public decimal LotSplitQuantity { get; set; }
        public byte UseQtyOverageTolerance { get; set; }
        public byte UseQtyShortageTolerance { get; set; }
        public int QtyOverTolerancePercent { get; set; }
        public int QtyShortTolerancePercent { get; set; }
        public int Ivscrvix { get; set; }
        public DateTime DexRowTs { get; set; }
        public int DexRowId { get; set; }

        public ICollection<ItemSiteEntity> ItemSites { get; set; }
            = new List<ItemSiteEntity>();

    }
}
