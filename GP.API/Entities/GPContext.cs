using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GP.API.Entities
{
    public partial class GPContext : DbContext
    {
        public GPContext(DbContextOptions<GPContext> options) : base(options)
        {
        }

        public virtual DbSet<ItemEntity> ItemEntity { get; set; }
        public virtual DbSet<ItemSiteEntity> ItemSiteEntity { get; set; }
        public virtual DbSet<CustomerEntity> CustomerEntity { get; set; }
        public virtual DbSet<CustomerAddressEntity> CustomerAddressEntity { get; set; }

        public virtual DbSet<VendorEntity> VendorEntity { get; set; }
        public virtual DbSet<VendorAddressEntity> VendorAddressEntity { get; set; }
        public virtual DbSet<EFTInfoEntity> EFTEntity { get; set; }

        public virtual DbSet<SOPWorkHeader> SOPWorkHeader { get; set; }
        public virtual DbSet<SOPWorkLine> SOPWorkLine { get; set; }
        public virtual DbSet<SOPTracking> SOPTracking { get; set; }

        public virtual DbSet<PMOpenEntity> PMOpenEntity { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //    //optionsBuilder.UseSqlServer(@"Server=GP2016;Database=TWO;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemEntity>(entity =>
            {
                entity.HasKey(e => e.Itemnmbr)
                    .HasName("PKIV00101");

                entity.ToTable("IV00101");

                entity.HasIndex(e => new { e.Itemcode, e.DexRowId })
                    .HasName("AK7IV00101")
                    .IsUnique();

                entity.HasIndex(e => new { e.Itemdesc, e.Itemnmbr })
                    .HasName("AK2IV00101")
                    .IsUnique();

                entity.HasIndex(e => new { e.Itmclscd, e.Itemnmbr })
                    .HasName("AK3IV00101")
                    .IsUnique();

                entity.HasIndex(e => new { e.Itmgedsc, e.Itemnmbr })
                    .HasName("AK5IV00101")
                    .IsUnique();

                entity.HasIndex(e => new { e.Itmshnam, e.Itemnmbr })
                    .HasName("AK4IV00101")
                    .IsUnique();

                entity.HasIndex(e => new { e.Uomschdl, e.DexRowId })
                    .HasName("AK6IV00101")
                    .IsUnique();

                entity.Property(e => e.Itemnmbr)
                    .HasColumnName("ITEMNMBR")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Abccode)
                    .HasColumnName("ABCCODE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Altitem1)
                    .IsRequired()
                    .HasColumnName("ALTITEM1")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Altitem2)
                    .IsRequired()
                    .HasColumnName("ALTITEM2")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Alwbkord)
                    .HasColumnName("ALWBKORD")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Asmvridx)
                    .HasColumnName("ASMVRIDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Cgsinflx)
                    .HasColumnName("CGSINFLX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Cgsmcidx)
                    .HasColumnName("CGSMCIDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Cntryorgn)
                    .IsRequired()
                    .HasColumnName("CNTRYORGN")
                    .HasColumnType("char(7)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Creatddt)
                    .HasColumnName("CREATDDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Currcost)
                    .HasColumnName("CURRCOST")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Decplcur)
                    .HasColumnName("DECPLCUR")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Decplqty)
                    .HasColumnName("DECPLQTY")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.DexRowId)
                    .HasColumnName("DEX_ROW_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DexRowTs)
                    .HasColumnName("DEX_ROW_TS")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.Dpshpidx)
                    .HasColumnName("DPSHPIDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Inactive)
                    .HasColumnName("INACTIVE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Includeindp)
                    .HasColumnName("INCLUDEINDP")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Invmcidx)
                    .HasColumnName("INVMCIDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Itemcode)
                    .IsRequired()
                    .HasColumnName("ITEMCODE")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Itemdesc)
                    .IsRequired()
                    .HasColumnName("ITEMDESC")
                    .HasColumnType("char(101)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Itemshwt)
                    .HasColumnName("ITEMSHWT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Itemtype)
                    .HasColumnName("ITEMTYPE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Itmclscd)
                    .IsRequired()
                    .HasColumnName("ITMCLSCD")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Itmgedsc)
                    .IsRequired()
                    .HasColumnName("ITMGEDSC")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Itmplnnngtyp)
                    .HasColumnName("ITMPLNNNGTYP")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Itmshnam)
                    .IsRequired()
                    .HasColumnName("ITMSHNAM")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Itmtrkop)
                    .HasColumnName("ITMTRKOP")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Itmtshid)
                    .IsRequired()
                    .HasColumnName("ITMTSHID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Ivcogsix)
                    .HasColumnName("IVCOGSIX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ivdmgidx)
                    .HasColumnName("IVDMGIDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ivinfidx)
                    .HasColumnName("IVINFIDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ivinsvix)
                    .HasColumnName("IVINSVIX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ivinusix)
                    .HasColumnName("IVINUSIX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ivivindx)
                    .HasColumnName("IVIVINDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ivivofix)
                    .HasColumnName("IVIVOFIX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ivretidx)
                    .HasColumnName("IVRETIDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ivscrvix)
                    .HasColumnName("IVSCRVIX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ivsldsix)
                    .HasColumnName("IVSLDSIX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ivslrnix)
                    .HasColumnName("IVSLRNIX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ivslsidx)
                    .HasColumnName("IVSLSIDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ivvaridx)
                    .HasColumnName("IVVARIDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Kpcalhst)
                    .HasColumnName("KPCALHST")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Kpdsthst)
                    .HasColumnName("KPDSTHST")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Kperhist)
                    .HasColumnName("KPERHIST")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Kptrxhst)
                    .HasColumnName("KPTRXHST")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ktacctsr)
                    .HasColumnName("KTACCTSR")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Lastgenlot)
                    .IsRequired()
                    .HasColumnName("LASTGENLOT")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Lastgensn)
                    .IsRequired()
                    .HasColumnName("LASTGENSN")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Locncode)
                    .IsRequired()
                    .HasColumnName("LOCNCODE")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.LotSplitQuantity)
                    .HasColumnName("Lot_Split_Quantity")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Lotexpwarn)
                    .HasColumnName("LOTEXPWARN")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Lotexpwarndays)
                    .HasColumnName("LOTEXPWARNDAYS")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Lottype)
                    .IsRequired()
                    .HasColumnName("LOTTYPE")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Minshelf1)
                    .HasColumnName("MINSHELF1")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Minshelf2)
                    .HasColumnName("MINSHELF2")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Modifdt)
                    .HasColumnName("MODIFDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Mstrcdty)
                    .HasColumnName("MSTRCDTY")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Noteindx)
                    .HasColumnName("NOTEINDX")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Pinflidx)
                    .HasColumnName("PINFLIDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Prchsuom)
                    .IsRequired()
                    .HasColumnName("PRCHSUOM")
                    .HasColumnType("char(9)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Prclevel)
                    .IsRequired()
                    .HasColumnName("PRCLEVEL")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.PriceGroup)
                    .IsRequired()
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Pricmthd)
                    .HasColumnName("PRICMTHD")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.PurchaseItemTaxSchedu)
                    .IsRequired()
                    .HasColumnName("Purchase_Item_Tax_Schedu")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.PurchaseTaxOptions)
                    .HasColumnName("Purchase_Tax_Options")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Purmcidx)
                    .HasColumnName("PURMCIDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Purpvidx)
                    .HasColumnName("PURPVIDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.QtyOverTolerancePercent).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.QtyShortTolerancePercent).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.RevalueInventory)
                    .HasColumnName("Revalue_Inventory")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Selnguom)
                    .IsRequired()
                    .HasColumnName("SELNGUOM")
                    .HasColumnType("char(9)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Stndcost)
                    .HasColumnName("STNDCOST")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Sttstclvlprcntg)
                    .HasColumnName("STTSTCLVLPRCNTG")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Taxoptns)
                    .HasColumnName("TAXOPTNS")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Tcc)
                    .IsRequired()
                    .HasColumnName("TCC")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.TolerancePercentage)
                    .HasColumnName("Tolerance_Percentage")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Uomschdl)
                    .IsRequired()
                    .HasColumnName("UOMSCHDL")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Uppvidx)
                    .HasColumnName("UPPVIDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Uscatvls1)
                    .IsRequired()
                    .HasColumnName("USCATVLS_1")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Uscatvls2)
                    .IsRequired()
                    .HasColumnName("USCATVLS_2")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Uscatvls3)
                    .IsRequired()
                    .HasColumnName("USCATVLS_3")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Uscatvls4)
                    .IsRequired()
                    .HasColumnName("USCATVLS_4")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Uscatvls5)
                    .IsRequired()
                    .HasColumnName("USCATVLS_5")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Uscatvls6)
                    .IsRequired()
                    .HasColumnName("USCATVLS_6")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.UseQtyOverageTolerance).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.UseQtyShortageTolerance).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Vctnmthd)
                    .HasColumnName("VCTNMTHD")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Wrntydys)
                    .HasColumnName("WRNTYDYS")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");
            });

            modelBuilder.Entity<ItemSiteEntity>(entity =>
            {
                entity.HasKey(e => new { e.Itemnmbr, e.Rcrdtype, e.Locncode })
                    .HasName("PKIV00102");

                entity.ToTable("IV00102");

                entity.HasIndex(e => new { e.Locncode, e.Itemnmbr })
                    .HasName("AK2IV00102")
                    .IsUnique();

                entity.HasIndex(e => new { e.Itemnmbr, e.Rcrdtype, e.DexRowId })
                    .HasName("AK4IV00102")
                    .IsUnique();

                entity.HasIndex(e => new { e.Primvndr, e.Itemnmbr, e.Locncode })
                    .HasName("AK3IV00102")
                    .IsUnique();

                entity.Property(e => e.Itemnmbr)
                    .HasColumnName("ITEMNMBR")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Rcrdtype)
                    .HasColumnName("RCRDTYPE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Locncode)
                    .HasColumnName("LOCNCODE")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Atyalloc)
                    .HasColumnName("ATYALLOC")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Autochkatp)
                    .HasColumnName("AUTOCHKATP")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Bgngqty)
                    .HasColumnName("BGNGQTY")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Binnmbr)
                    .IsRequired()
                    .HasColumnName("BINNMBR")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Bomrcptbin)
                    .IsRequired()
                    .HasColumnName("BOMRCPTBIN")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Buyerid)
                    .IsRequired()
                    .HasColumnName("BUYERID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Calculateatp)
                    .HasColumnName("CALCULATEATP")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.DexRowId)
                    .HasColumnName("DEX_ROW_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Dmndtmfncprds)
                    .HasColumnName("DMNDTMFNCPRDS")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Frcstcnsmptnprd)
                    .HasColumnName("FRCSTCNSMPTNPRD")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Fxdordrqty)
                    .HasColumnName("FXDORDRQTY")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Inactive)
                    .HasColumnName("INACTIVE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Inclddinplnnng)
                    .HasColumnName("INCLDDINPLNNNG")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Incldmrpcancel)
                    .HasColumnName("INCLDMRPCANCEL")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Incldmrpmovein)
                    .HasColumnName("INCLDMRPMOVEIN")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Incldmrpmoveout)
                    .HasColumnName("INCLDMRPMOVEOUT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.IncludeAllocations).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.IncludeBackorders).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.IncludeRequisitions).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Itmfrflg)
                    .HasColumnName("ITMFRFLG")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.LandedCostGroupId)
                    .IsRequired()
                    .HasColumnName("Landed_Cost_Group_ID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Lrcptqty)
                    .HasColumnName("LRCPTQTY")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Lsordqty)
                    .HasColumnName("LSORDQTY")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Lsordvnd)
                    .IsRequired()
                    .HasColumnName("LSORDVND")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Lsrcptdt)
                    .HasColumnName("LSRCPTDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Lstcntdt)
                    .HasColumnName("LSTCNTDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Lstcnttm)
                    .HasColumnName("LSTCNTTM")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Lstorddt)
                    .HasColumnName("LSTORDDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.MasterLocationCode)
                    .IsRequired()
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Materialissuebin)
                    .IsRequired()
                    .HasColumnName("MATERIALISSUEBIN")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Mnfctrngfxdldtm)
                    .HasColumnName("MNFCTRNGFXDLDTM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Mnfctrngvrblldtm)
                    .HasColumnName("MNFCTRNGVRBLLDTM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Mnmmordrqty)
                    .HasColumnName("MNMMORDRQTY")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Moreceiptbin)
                    .IsRequired()
                    .HasColumnName("MORECEIPTBIN")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.MoveOutFence)
                    .HasColumnName("Move_Out_Fence")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Mxmmordrqty)
                    .HasColumnName("MXMMORDRQTY")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Nmbrofdys)
                    .HasColumnName("NMBROFDYS")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Nxtcntdt)
                    .HasColumnName("NXTCNTDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Nxtcnttm)
                    .HasColumnName("NXTCNTTM")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Ordermultiple)
                    .HasColumnName("ORDERMULTIPLE")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Orderpolicy)
                    .HasColumnName("ORDERPOLICY")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ordrpntqty)
                    .HasColumnName("ORDRPNTQTY")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ordruptolvl)
                    .HasColumnName("ORDRUPTOLVL")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Pickticketitemopt)
                    .HasColumnName("PICKTICKETITEMOPT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Plannerid)
                    .IsRequired()
                    .HasColumnName("PLANNERID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Plnfnlpab)
                    .HasColumnName("PLNFNLPAB")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Plnnngtmfncdys)
                    .HasColumnName("PLNNNGTMFNCDYS")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.PoporderMethod)
                    .HasColumnName("POPOrderMethod")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.PoppricingSelection)
                    .HasColumnName("POPPricingSelection")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.PopvendorSelection)
                    .HasColumnName("POPVendorSelection")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Poreceiptbin)
                    .IsRequired()
                    .HasColumnName("PORECEIPTBIN")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Poretrnbin)
                    .IsRequired()
                    .HasColumnName("PORETRNBIN")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Prchsngldtm)
                    .HasColumnName("PRCHSNGLDTM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Primvndr)
                    .IsRequired()
                    .HasColumnName("PRIMVNDR")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.PurchasePrice)
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.QtyDropShipped)
                    .HasColumnName("QTY_Drop_Shipped")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtybkord)
                    .HasColumnName("QTYBKORD")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtycomtd)
                    .HasColumnName("QTYCOMTD")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtydmged)
                    .HasColumnName("QTYDMGED")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyinsvc)
                    .HasColumnName("QTYINSVC")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyinuse)
                    .HasColumnName("QTYINUSE")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyonhnd)
                    .HasColumnName("QTYONHND")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyonord)
                    .HasColumnName("QTYONORD")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyrqstn)
                    .HasColumnName("QTYRQSTN")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyrtrnd)
                    .HasColumnName("QTYRTRND")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtysold)
                    .HasColumnName("QTYSOLD")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Reordervariance)
                    .HasColumnName("REORDERVARIANCE")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Repairissuesbin)
                    .IsRequired()
                    .HasColumnName("REPAIRISSUESBIN")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.ReplenishmentLevel).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Replenishmentmethod)
                    .HasColumnName("REPLENISHMENTMETHOD")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Sftystckqty)
                    .HasColumnName("SFTYSTCKQTY")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Shrinkagefactor)
                    .HasColumnName("SHRINKAGEFACTOR")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Sofulfillmentbin)
                    .IsRequired()
                    .HasColumnName("SOFULFILLMENTBIN")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Soreturnbin)
                    .IsRequired()
                    .HasColumnName("SORETURNBIN")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Stagingldtme)
                    .HasColumnName("STAGINGLDTME")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Stckcntintrvl)
                    .HasColumnName("STCKCNTINTRVL")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");
            });

            modelBuilder.Entity<CustomerEntity>(entity =>
            {
                entity.HasKey(e => e.Custnmbr)
                    .HasName("PKRM00101");

                entity.ToTable("RM00101");

                entity.HasIndex(e => new { e.Cprcstnm, e.Custnmbr })
                    .HasName("AK7RM00101")
                    .IsUnique();

                entity.HasIndex(e => new { e.Custclas, e.Custnmbr })
                    .HasName("AK3RM00101")
                    .IsUnique();

                entity.HasIndex(e => new { e.Custname, e.DexRowId })
                    .HasName("AK2RM00101")
                    .IsUnique();

                entity.HasIndex(e => new { e.Salsterr, e.Custnmbr })
                    .HasName("AK6RM00101")
                    .IsUnique();

                entity.HasIndex(e => new { e.Slprsnid, e.Custnmbr })
                    .HasName("AK5RM00101")
                    .IsUnique();

                entity.HasIndex(e => new { e.Txrgnnum, e.Custnmbr })
                    .HasName("AK8RM00101")
                    .IsUnique();

                entity.HasIndex(e => new { e.Userdef1, e.Custnmbr })
                    .HasName("AK4RM00101")
                    .IsUnique();

                entity.Property(e => e.Custnmbr)
                    .HasColumnName("CUSTNMBR")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasColumnName("ADDRESS1")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasColumnName("ADDRESS2")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Address3)
                    .IsRequired()
                    .HasColumnName("ADDRESS3")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Adrscode)
                    .IsRequired()
                    .HasColumnName("ADRSCODE")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Balnctyp)
                    .HasColumnName("BALNCTYP")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Bankname)
                    .IsRequired()
                    .HasColumnName("BANKNAME")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Bnkbrnch)
                    .IsRequired()
                    .HasColumnName("BNKBRNCH")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Cbvat)
                    .HasColumnName("CBVAT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ccode)
                    .IsRequired()
                    .HasColumnName("CCode")
                    .HasColumnType("char(7)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Ccrdxpdt)
                    .HasColumnName("CCRDXPDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Chekbkid)
                    .IsRequired()
                    .HasColumnName("CHEKBKID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("CITY")
                    .HasColumnType("char(35)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Cntcprsn)
                    .IsRequired()
                    .HasColumnName("CNTCPRSN")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Comment1)
                    .IsRequired()
                    .HasColumnName("COMMENT1")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Comment2)
                    .IsRequired()
                    .HasColumnName("COMMENT2")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("COUNTRY")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Cprcstnm)
                    .IsRequired()
                    .HasColumnName("CPRCSTNM")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Crcardid)
                    .IsRequired()
                    .HasColumnName("CRCARDID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Crcrdnum)
                    .IsRequired()
                    .HasColumnName("CRCRDNUM")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Creatddt)
                    .HasColumnName("CREATDDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Crlmtamt)
                    .HasColumnName("CRLMTAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Crlmtpam)
                    .HasColumnName("CRLMTPAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Crlmtper)
                    .HasColumnName("CRLMTPER")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Crlmttyp)
                    .HasColumnName("CRLMTTYP")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Curncyid)
                    .IsRequired()
                    .HasColumnName("CURNCYID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Custclas)
                    .IsRequired()
                    .HasColumnName("CUSTCLAS")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Custdisc)
                    .HasColumnName("CUSTDISC")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Custname)
                    .IsRequired()
                    .HasColumnName("CUSTNAME")
                    .HasColumnType("char(65)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Custpriority)
                    .HasColumnName("CUSTPRIORITY")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Declid)
                    .IsRequired()
                    .HasColumnName("DECLID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Defcacty)
                    .HasColumnName("DEFCACTY")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.DexRowId)
                    .HasColumnName("DEX_ROW_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DexRowTs)
                    .HasColumnName("DEX_ROW_TS")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.Disgrper)
                    .HasColumnName("DISGRPER")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Docfmtid)
                    .IsRequired()
                    .HasColumnName("DOCFMTID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Duegrper)
                    .HasColumnName("DUEGRPER")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Fax)
                    .IsRequired()
                    .HasColumnName("FAX")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Finchdlr)
                    .HasColumnName("FINCHDLR")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Finchid)
                    .IsRequired()
                    .HasColumnName("FINCHID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Fnchatyp)
                    .HasColumnName("FNCHATYP")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Fnchpcnt)
                    .HasColumnName("FNCHPCNT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Frstindt)
                    .HasColumnName("FRSTINDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Govcrpid)
                    .IsRequired()
                    .HasColumnName("GOVCRPID")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Govindid)
                    .IsRequired()
                    .HasColumnName("GOVINDID")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Gpsfointegrationid)
                    .IsRequired()
                    .HasColumnName("GPSFOINTEGRATIONID")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Hold)
                    .HasColumnName("HOLD")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Inactive)
                    .HasColumnName("INACTIVE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Includeindp)
                    .HasColumnName("INCLUDEINDP")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Integrationid)
                    .IsRequired()
                    .HasColumnName("INTEGRATIONID")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Integrationsource)
                    .HasColumnName("INTEGRATIONSOURCE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Kpcalhst)
                    .HasColumnName("KPCALHST")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Kpdsthst)
                    .HasColumnName("KPDSTHST")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Kperhist)
                    .HasColumnName("KPERHIST")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Kptrxhst)
                    .HasColumnName("KPTRXHST")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Minpydlr)
                    .HasColumnName("MINPYDLR")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Minpypct)
                    .HasColumnName("MINPYPCT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Minpytyp)
                    .HasColumnName("MINPYTYP")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Modifdt)
                    .HasColumnName("MODIFDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Mxwoftyp)
                    .HasColumnName("MXWOFTYP")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Mxwrofam)
                    .HasColumnName("MXWROFAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Noteindx)
                    .HasColumnName("NOTEINDX")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Orderfulfilldefault)
                    .HasColumnName("ORDERFULFILLDEFAULT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Phone1)
                    .IsRequired()
                    .HasColumnName("PHONE1")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Phone2)
                    .IsRequired()
                    .HasColumnName("PHONE2")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Phone3)
                    .IsRequired()
                    .HasColumnName("PHONE3")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.PostResultsTo)
                    .HasColumnName("Post_Results_To")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Prbtadcd)
                    .IsRequired()
                    .HasColumnName("PRBTADCD")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Prclevel)
                    .IsRequired()
                    .HasColumnName("PRCLEVEL")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Prstadcd)
                    .IsRequired()
                    .HasColumnName("PRSTADCD")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Pymtrmid)
                    .IsRequired()
                    .HasColumnName("PYMTRMID")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Ratetpid)
                    .IsRequired()
                    .HasColumnName("RATETPID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.RevalueCustomer)
                    .HasColumnName("Revalue_Customer")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Rmaracc)
                    .HasColumnName("RMARACC")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Rmavacc)
                    .HasColumnName("RMAVACC")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Rmcosacc)
                    .HasColumnName("RMCOSACC")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Rmcshacc)
                    .HasColumnName("RMCSHACC")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Rmfcgacc)
                    .HasColumnName("RMFCGACC")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Rmivacc)
                    .HasColumnName("RMIVACC")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.RmovrpymtWrtoffAcctIdx)
                    .HasColumnName("RMOvrpymtWrtoffAcctIdx")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Rmslsacc)
                    .HasColumnName("RMSLSACC")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Rmsoracc)
                    .HasColumnName("RMSORACC")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Rmtakacc)
                    .HasColumnName("RMTAKACC")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Rmwracc)
                    .HasColumnName("RMWRACC")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Salsterr)
                    .IsRequired()
                    .HasColumnName("SALSTERR")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.SendEmailStatements)
                    .HasColumnName("Send_Email_Statements")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Shipcomplete)
                    .HasColumnName("SHIPCOMPLETE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Shipmthd)
                    .IsRequired()
                    .HasColumnName("SHIPMTHD")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Shrtname)
                    .IsRequired()
                    .HasColumnName("SHRTNAME")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Slprsnid)
                    .IsRequired()
                    .HasColumnName("SLPRSNID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Staddrcd)
                    .IsRequired()
                    .HasColumnName("STADDRCD")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("STATE")
                    .HasColumnType("char(29)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Stmtcycl)
                    .HasColumnName("STMTCYCL")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Stmtname)
                    .IsRequired()
                    .HasColumnName("STMTNAME")
                    .HasColumnType("char(65)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Taxexmt1)
                    .IsRequired()
                    .HasColumnName("TAXEXMT1")
                    .HasColumnType("char(25)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Taxexmt2)
                    .IsRequired()
                    .HasColumnName("TAXEXMT2")
                    .HasColumnType("char(25)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Taxschid)
                    .IsRequired()
                    .HasColumnName("TAXSCHID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Txrgnnum)
                    .IsRequired()
                    .HasColumnName("TXRGNNUM")
                    .HasColumnType("char(25)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Upszone)
                    .IsRequired()
                    .HasColumnName("UPSZONE")
                    .HasColumnType("char(3)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Userdef1)
                    .IsRequired()
                    .HasColumnName("USERDEF1")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Userdef2)
                    .IsRequired()
                    .HasColumnName("USERDEF2")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Userlang)
                    .HasColumnName("USERLANG")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasColumnName("ZIP")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");
            });

            modelBuilder.Entity<CustomerAddressEntity>(entity =>
            {
                entity.HasKey(e => new { e.Custnmbr, e.Adrscode })
                    .HasName("PKRM00102");

                entity.ToTable("RM00102");

                entity.HasIndex(e => new { e.Custnmbr, e.City, e.DexRowId })
                    .HasName("AK2RM00102")
                    .IsUnique();

                entity.HasIndex(e => new { e.Custnmbr, e.Salsterr, e.DexRowId })
                    .HasName("AK6RM00102")
                    .IsUnique();

                entity.HasIndex(e => new { e.Custnmbr, e.Slprsnid, e.DexRowId })
                    .HasName("AK5RM00102")
                    .IsUnique();

                entity.HasIndex(e => new { e.Custnmbr, e.State, e.DexRowId })
                    .HasName("AK3RM00102")
                    .IsUnique();

                entity.HasIndex(e => new { e.Custnmbr, e.Zip, e.DexRowId })
                    .HasName("AK4RM00102")
                    .IsUnique();

                entity.Property(e => e.Custnmbr)
                    .HasColumnName("CUSTNMBR")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Adrscode)
                    .HasColumnName("ADRSCODE")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasColumnName("ADDRESS1")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasColumnName("ADDRESS2")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Address3)
                    .IsRequired()
                    .HasColumnName("ADDRESS3")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Ccode)
                    .IsRequired()
                    .HasColumnName("CCode")
                    .HasColumnType("char(7)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("CITY")
                    .HasColumnType("char(35)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Cntcprsn)
                    .IsRequired()
                    .HasColumnName("CNTCPRSN")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("COUNTRY")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Creatddt)
                    .HasColumnName("CREATDDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Declid)
                    .IsRequired()
                    .HasColumnName("DECLID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.DexRowId)
                    .HasColumnName("DEX_ROW_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DexRowTs)
                    .HasColumnName("DEX_ROW_TS")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.Fax)
                    .IsRequired()
                    .HasColumnName("FAX")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Gpsfointegrationid)
                    .IsRequired()
                    .HasColumnName("GPSFOINTEGRATIONID")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Integrationid)
                    .IsRequired()
                    .HasColumnName("INTEGRATIONID")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Integrationsource)
                    .HasColumnName("INTEGRATIONSOURCE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Locncode)
                    .IsRequired()
                    .HasColumnName("LOCNCODE")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Modifdt)
                    .HasColumnName("MODIFDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Phone1)
                    .IsRequired()
                    .HasColumnName("PHONE1")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Phone2)
                    .IsRequired()
                    .HasColumnName("PHONE2")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Phone3)
                    .IsRequired()
                    .HasColumnName("PHONE3")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.PrintPhoneNumberGb)
                    .HasColumnName("Print_Phone_NumberGB")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Salsterr)
                    .IsRequired()
                    .HasColumnName("SALSTERR")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.ShipToName)
                    .IsRequired()
                    .HasColumnType("char(65)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Shipmthd)
                    .IsRequired()
                    .HasColumnName("SHIPMTHD")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Slprsnid)
                    .IsRequired()
                    .HasColumnName("SLPRSNID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("STATE")
                    .HasColumnType("char(29)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Taxschid)
                    .IsRequired()
                    .HasColumnName("TAXSCHID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Upszone)
                    .IsRequired()
                    .HasColumnName("UPSZONE")
                    .HasColumnType("char(3)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Userdef1)
                    .IsRequired()
                    .HasColumnName("USERDEF1")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Userdef2)
                    .IsRequired()
                    .HasColumnName("USERDEF2")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasColumnName("ZIP")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");
            });

            modelBuilder.Entity<SOPWorkHeader>(entity =>
            {
                entity.HasKey(e => new { e.Sopnumbe, e.Soptype })
                    .HasName("PKSOP10100");

                entity.ToTable("SOP10100");

                entity.HasIndex(e => new { e.Docdate, e.DexRowId })
                    .HasName("AK3SOP10100")
                    .IsUnique();

                entity.HasIndex(e => new { e.Mstrnumb, e.DexRowId })
                    .HasName("AK6SOP10100")
                    .IsUnique();

                entity.HasIndex(e => new { e.Soptype, e.Docid, e.DexRowId })
                    .HasName("AK5SOP10100")
                    .IsUnique();

                entity.HasIndex(e => new { e.Bchsourc, e.Bachnumb, e.Soptype, e.Sopnumbe })
                    .HasName("AK4SOP10100")
                    .IsUnique();

                entity.HasIndex(e => new { e.Custnmbr, e.Cstponbr, e.Docdate, e.DexRowId })
                    .HasName("AK2SOP10100")
                    .IsUnique();

                entity.Property(e => e.Sopnumbe)
                    .HasColumnName("SOPNUMBE")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Soptype)
                    .HasColumnName("SOPTYPE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Acctamnt)
                //    .HasColumnName("ACCTAMNT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Actlship)
                    .HasColumnName("ACTLSHIP")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasColumnName("ADDRESS1")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasColumnName("ADDRESS2")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Address3)
                    .IsRequired()
                    .HasColumnName("ADDRESS3")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Allocaby)
                //    .HasColumnName("ALLOCABY")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Aplywith)
                //    .HasColumnName("APLYWITH")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Bachnumb)
                    .IsRequired()
                    .HasColumnName("BACHNUMB")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Backdate)
                    .HasColumnName("BACKDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                //entity.Property(e => e.BackoutTradeDisc)
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Bchsourc)
                    .IsRequired()
                    .HasColumnName("BCHSOURC")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Bcktxamt)
                //    .HasColumnName("BCKTXAMT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Bktfrtam)
                //    .HasColumnName("BKTFRTAM")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Bktmscam)
                //    .HasColumnName("BKTMSCAM")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Bsivcttl)
                //    .HasColumnName("BSIVCTTL")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ccode)
                    .IsRequired()
                    .HasColumnName("CCode")
                    .HasColumnType("char(7)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("CITY")
                    .HasColumnType("char(35)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Cmmslamt)
                //    .HasColumnName("CMMSLAMT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Cntcprsn)
                    .IsRequired()
                    .HasColumnName("CNTCPRSN")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Codamnt)
                //    .HasColumnName("CODAMNT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Comappto)
                //    .HasColumnName("COMAPPTO")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Commamnt)
                //    .HasColumnName("COMMAMNT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Commntid)
                //    .IsRequired()
                //    .HasColumnName("COMMNTID")
                //    .HasColumnType("char(15)")
                //    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.ContractExchangeRateStat).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Corrctn)
                //    .HasColumnName("CORRCTN")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Corrnxst)
                //    .HasColumnName("CORRNXST")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("COUNTRY")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Creatddt)
                    .HasColumnName("CREATDDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Cstponbr)
                    .IsRequired()
                    .HasColumnName("CSTPONBR")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Curncyid)
                    .IsRequired()
                    .HasColumnName("CURNCYID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Currnidx)
                //    .HasColumnName("CURRNIDX")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Custname)
                    .IsRequired()
                    .HasColumnName("CUSTNAME")
                    .HasColumnType("char(65)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Custnmbr)
                    .IsRequired()
                    .HasColumnName("CUSTNMBR")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Denxrate)
                //    .HasColumnName("DENXRATE")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Deprecvd)
                //    .HasColumnName("DEPRECVD")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.DexRowId)
                    .HasColumnName("DEX_ROW_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DexRowTs)
                    .HasColumnName("DEX_ROW_TS")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                //entity.Property(e => e.Directdebit)
                //    .HasColumnName("DIRECTDEBIT")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Disavamt)
                //    .HasColumnName("DISAVAMT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Disavtkn)
                //    .HasColumnName("DISAVTKN")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Discdate)
                //    .HasColumnName("DISCDATE")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                //entity.Property(e => e.Discfrgt)
                //    .HasColumnName("DISCFRGT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Discmisc)
                //    .HasColumnName("DISCMISC")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Discrtnd)
                //    .HasColumnName("DISCRTND")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Distknam)
                //    .HasColumnName("DISTKNAM")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Docamnt)
                    .HasColumnName("DOCAMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Docdate)
                    .HasColumnName("DOCDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Docid)
                    .IsRequired()
                    .HasColumnName("DOCID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Docncorr)
                //    .IsRequired()
                //    .HasColumnName("DOCNCORR")
                //    .HasColumnType("char(21)")
                //    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Dscdlram)
                //    .HasColumnName("DSCDLRAM")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Dscpctam)
                //    .HasColumnName("DSCPCTAM")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Dstbtch1)
                //    .IsRequired()
                //    .HasColumnName("DSTBTCH1")
                //    .HasColumnType("char(15)")
                //    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Dstbtch2)
                //    .IsRequired()
                //    .HasColumnName("DSTBTCH2")
                //    .HasColumnType("char(15)")
                //    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Dtlstrep)
                //    .HasColumnName("DTLSTREP")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Duedate)
                    .HasColumnName("DUEDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                //entity.Property(e => e.Dystincr)
                //    .HasColumnName("DYSTINCR")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Ectrx)
                //    .HasColumnName("ECTRX")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Exceptionaldemand)
                //    .HasColumnName("EXCEPTIONALDEMAND")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Exchdate)
                //    .HasColumnName("EXCHDATE")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                //entity.Property(e => e.Exgtblid)
                //    .IsRequired()
                //    .HasColumnName("EXGTBLID")
                //    .HasColumnType("char(15)")
                //    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Extdcost)
                    .HasColumnName("EXTDCOST")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Faxnumbr)
                    .IsRequired()
                    .HasColumnName("FAXNUMBR")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Flags).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Frgttxbl)
                //    .HasColumnName("FRGTTXBL")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Frtamnt)
                    .HasColumnName("FRTAMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Frtschid)
                //    .IsRequired()
                //    .HasColumnName("FRTSCHID")
                //    .HasColumnType("char(15)")
                //    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Frttxamt)
                //    .HasColumnName("FRTTXAMT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Fufildat)
                    .HasColumnName("FUFILDAT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Glpostdt)
                    .HasColumnName("GLPOSTDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                //entity.Property(e => e.Gpsfointegrationid)
                //    .IsRequired()
                //    .HasColumnName("GPSFOINTEGRATIONID")
                //    .HasColumnType("char(31)")
                //    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Integrationid)
                //    .IsRequired()
                //    .HasColumnName("INTEGRATIONID")
                //    .HasColumnType("char(31)")
                //    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Integrationsource)
                //    .HasColumnName("INTEGRATIONSOURCE")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Invodate)
                    .HasColumnName("INVODATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Locncode)
                    .IsRequired()
                    .HasColumnName("LOCNCODE")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Mctrxstt)
                //    .HasColumnName("MCTRXSTT")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Miscamnt)
                    .HasColumnName("MISCAMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Misctxbl)
                //    .HasColumnName("MISCTXBL")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Modifdt)
                    .HasColumnName("MODIFDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                //entity.Property(e => e.Mrkdnamt)
                //    .HasColumnName("MRKDNAMT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Mscschid)
                //    .IsRequired()
                //    .HasColumnName("MSCSCHID")
                //    .HasColumnType("char(15)")
                //    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Msctxamt)
                //    .HasColumnName("MSCTXAMT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Mstrnumb)
                    .HasColumnName("MSTRNUMB")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Ncomamnt)
                //    .HasColumnName("NCOMAMNT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Noteindx)
                //    .HasColumnName("NOTEINDX")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Obtaxamt)
                //    .HasColumnName("OBTAXAMT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Ocommamt)
                //    .HasColumnName("OCOMMAMT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Oractamt)
                //    .HasColumnName("ORACTAMT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Orbktfrt)
                //    .HasColumnName("ORBKTFRT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Orbktmsc)
                //    .HasColumnName("ORBKTMSC")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Orcodamt)
                //    .HasColumnName("ORCODAMT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Orcosamt)
                //    .HasColumnName("ORCOSAMT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Ordatkn)
                //    .HasColumnName("ORDATKN")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Ordavamt)
                //    .HasColumnName("ORDAVAMT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Ordavfrt)
                //    .HasColumnName("ORDAVFRT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Ordavmsc)
                //    .HasColumnName("ORDAVMSC")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Orddlrat)
                //    .HasColumnName("ORDDLRAT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Ordeprvd)
                //    .HasColumnName("ORDEPRVD")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Ordisrtd)
                //    .HasColumnName("ORDISRTD")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Ordistkn)
                //    .HasColumnName("ORDISTKN")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Ordocamt)
                //    .HasColumnName("ORDOCAMT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ordrdate)
                    .HasColumnName("ORDRDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                //entity.Property(e => e.Oremsubt)
                //    .HasColumnName("OREMSUBT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Orextcst)
                //    .HasColumnName("OREXTCST")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Orfrtamt)
                //    .HasColumnName("ORFRTAMT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Orfrttax)
                //    .HasColumnName("ORFRTTAX")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.OrigBackoutTradeDisc)
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Orignumb)
                    .IsRequired()
                    .HasColumnName("ORIGNUMB")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Origtype)
                    .HasColumnName("ORIGTYPE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Ormiscamt)
                //    .HasColumnName("ORMISCAMT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Ormrkdam)
                //    .HasColumnName("ORMRKDAM")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Ormsctax)
                //    .HasColumnName("ORMSCTAX")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Orncmamt)
                //    .HasColumnName("ORNCMAMT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Orpmtrvd)
                //    .HasColumnName("ORPMTRVD")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Orsubtot)
                //    .HasColumnName("ORSUBTOT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Ortaxamt)
                //    .HasColumnName("ORTAXAMT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Ortdisam)
                //    .HasColumnName("ORTDISAM")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Otaxtamt)
                //    .HasColumnName("OTAXTAMT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Pckslpno)
                    .IsRequired()
                    .HasColumnName("PCKSLPNO")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Phnumbr1)
                    .IsRequired()
                    .HasColumnName("PHNUMBR1")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Phnumbr2)
                    .IsRequired()
                    .HasColumnName("PHNUMBR2")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Phone3)
                    .IsRequired()
                    .HasColumnName("PHONE3")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Picticnu)
                    .IsRequired()
                    .HasColumnName("PICTICNU")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Posteddt)
                    .HasColumnName("POSTEDDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Prbtadcd)
                    .IsRequired()
                    .HasColumnName("PRBTADCD")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Prclevel)
                    .IsRequired()
                    .HasColumnName("PRCLEVEL")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.PrintPhoneNumberGb)
                //    .HasColumnName("Print_Phone_NumberGB")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Prospect)
                //    .HasColumnName("PROSPECT")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Prstadcd)
                    .IsRequired()
                    .HasColumnName("PRSTADCD")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Pstgstus)
                    .HasColumnName("PSTGSTUS")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Ptdusrid)
                //    .IsRequired()
                //    .HasColumnName("PTDUSRID")
                //    .HasColumnType("char(15)")
                //    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Pymtrcvd)
                    .HasColumnName("PYMTRCVD")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Pymtrmid)
                    .IsRequired()
                    .HasColumnName("PYMTRMID")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Quoexpda)
                //    .HasColumnName("QUOEXPDA")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                //entity.Property(e => e.Quotedat)
                //    .HasColumnName("QUOTEDAT")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                //entity.Property(e => e.Ratetpid)
                //    .IsRequired()
                //    .HasColumnName("RATETPID")
                //    .HasColumnType("char(15)")
                //    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Refrence)
                //    .IsRequired()
                //    .HasColumnName("REFRENCE")
                //    .HasColumnType("char(31)")
                //    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Remsubto)
                    .HasColumnName("REMSUBTO")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Repting)
                //    .HasColumnName("REPTING")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.ReqShipDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Retudate)
                    .HasColumnName("RETUDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                //entity.Property(e => e.Rtclcmtd)
                //    .HasColumnName("RTCLCMTD")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Saledate)
                //    .HasColumnName("SALEDATE")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Salsterr)
                    .IsRequired()
                    .HasColumnName("SALSTERR")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Seqncorr)
                //    .HasColumnName("SEQNCORR")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.ShipToName)
                    .IsRequired()
                    .HasColumnType("char(65)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Shipcomplete)
                //    .HasColumnName("SHIPCOMPLETE")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Shipmthd)
                    .IsRequired()
                    .HasColumnName("SHIPMTHD")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Shppgdoc)
                //    .HasColumnName("SHPPGDOC")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Simplifd)
                //    .HasColumnName("SIMPLIFD")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Slprsnid)
                    .IsRequired()
                    .HasColumnName("SLPRSNID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Sophdre1)
                //    .IsRequired()
                //    .HasColumnName("SOPHDRE1")
                //    .HasColumnType("binary(4)")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Sophdre2)
                //    .IsRequired()
                //    .HasColumnName("SOPHDRE2")
                //    .HasColumnType("binary(4)")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Sophdre3)
                //    .IsRequired()
                //    .HasColumnName("SOPHDRE3")
                //    .HasColumnType("binary(4)")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Sophdrfl)
                //    .IsRequired()
                //    .HasColumnName("SOPHDRFL")
                //    .HasColumnType("binary(4)")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Soplnerr)
                //    .IsRequired()
                //    .HasColumnName("SOPLNERR")
                //    .HasColumnType("binary(4)")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Sopmcerr)
                //    .IsRequired()
                //    .HasColumnName("SOPMCERR")
                //    .HasColumnType("binary(4)")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Sopstatus)
                    .HasColumnName("SOPSTATUS")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("STATE")
                    .HasColumnType("char(29)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Subtotal)
                    .HasColumnName("SUBTOTAL")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.TaxDate)
                //    .HasColumnName("Tax_Date")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                //entity.Property(e => e.Taxamnt)
                //    .HasColumnName("TAXAMNT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Taxexmt1)
                    .IsRequired()
                    .HasColumnName("TAXEXMT1")
                    .HasColumnType("char(25)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Taxexmt2)
                    .IsRequired()
                    .HasColumnName("TAXEXMT2")
                    .HasColumnType("char(25)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Taxschid)
                    .IsRequired()
                    .HasColumnName("TAXSCHID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Time1)
                //    .HasColumnName("TIME1")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                //entity.Property(e => e.Timerepd)
                //    .HasColumnName("TIMEREPD")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Timesprt)
                //    .HasColumnName("TIMESPRT")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Timetrep)
                //    .HasColumnName("TIMETREP")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Trdisamt)
                //    .HasColumnName("TRDISAMT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Trdispct)
                //    .HasColumnName("TRDISPCT")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Trxfrequ)
                //    .HasColumnName("TRXFREQU")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Trxsorce)
                //    .IsRequired()
                //    .HasColumnName("TRXSORCE")
                //    .HasColumnType("char(13)")
                //    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Txbtxamt)
                //    .HasColumnName("TXBTXAMT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Txengcld)
                    .HasColumnName("TXENGCLD")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Txrgnnum)
                    .IsRequired()
                    .HasColumnName("TXRGNNUM")
                    .HasColumnType("char(25)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Txschsrc)
                //    .HasColumnName("TXSCHSRC")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Upszone)
                    .IsRequired()
                    .HasColumnName("UPSZONE")
                    .HasColumnType("char(3)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Usdocid1)
                //    .IsRequired()
                //    .HasColumnName("USDOCID1")
                //    .HasColumnType("char(15)")
                //    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Usdocid2)
                //    .IsRequired()
                //    .HasColumnName("USDOCID2")
                //    .HasColumnType("char(15)")
                //    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.User2ent)
                    .IsRequired()
                    .HasColumnName("USER2ENT")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Voidstts)
                    .HasColumnName("VOIDSTTS")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Withhamt)
                //    .HasColumnName("WITHHAMT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.WorkflowApprStatCreditLm).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.WorkflowApprStatusQuote).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.WorkflowPriorityCreditLm).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.WorkflowPriorityQuote).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.WorkflowStatus)
                //    .HasColumnName("Workflow_Status")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Xchgrate)
                //    .HasColumnName("XCHGRATE")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Zipcode)
                    .IsRequired()
                    .HasColumnName("ZIPCODE")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");
            });

            modelBuilder.Entity<SOPWorkLine>(entity =>
            {
                entity.HasKey(e => new { e.Sopnumbe, e.Soptype, e.Cmpntseq, e.Lnitmseq })
                    .HasName("PKSOP10200");

                entity.ToTable("SOP10200");

                entity.HasIndex(e => new { e.Locncode, e.DexRowId })
                    .HasName("AK3SOP10200")
                    .IsUnique();

                entity.HasIndex(e => new { e.ReqShipDate, e.Actlship, e.Soptype, e.DexRowId })
                    .HasName("AK7SOP10200")
                    .IsUnique();

                entity.HasIndex(e => new { e.Sopnumbe, e.Soptype, e.Lnitmseq, e.Cmpntseq })
                    .HasName("AK6SOP10200")
                    .IsUnique();

                //entity.HasIndex(e => new { e.Trxsorce, e.Itemnmbr, e.Locncode, e.DexRowId })
                //    .HasName("AK4SOP10200")
                //    .IsUnique();

                //entity.HasIndex(e => new { e.Purchstat, e.Itemnmbr, e.Soptype, e.Sopnumbe, e.DexRowId })
                //    .HasName("AK5SOP10200")
                //    .IsUnique();

                //entity.HasIndex(e => new { e.Soptype, e.Sopnumbe, e.Lnitmseq, e.Cmpntseq, e.Brkfld1, e.Brkfld2, e.Brkfld3 })
                //    .HasName("AK2SOP10200")
                //    .IsUnique();

                entity.Property(e => e.Sopnumbe)
                    .HasColumnName("SOPNUMBE")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Soptype)
                    .HasColumnName("SOPTYPE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Cmpntseq)
                    .HasColumnName("CMPNTSEQ")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Lnitmseq)
                    .HasColumnName("LNITMSEQ")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Actlship)
                    .HasColumnName("ACTLSHIP")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasColumnName("ADDRESS1")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasColumnName("ADDRESS2")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Address3)
                    .IsRequired()
                    .HasColumnName("ADDRESS3")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Atyalloc)
                    .HasColumnName("ATYALLOC")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.BackoutTradeDisc)
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Bktslsam)
                //    .HasColumnName("BKTSLSAM")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Brkfld1)
                //    .HasColumnName("BRKFLD1")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Brkfld2)
                //    .HasColumnName("BRKFLD2")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Brkfld3)
                //    .HasColumnName("BRKFLD3")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Bsivcttl)
                //    .HasColumnName("BSIVCTTL")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Bulkpickprnt)
                    .HasColumnName("BULKPICKPRNT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ccode)
                    .IsRequired()
                    .HasColumnName("CCode")
                    .HasColumnType("char(7)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("CITY")
                    .HasColumnType("char(35)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Cntcprsn)
                    .IsRequired()
                    .HasColumnName("CNTCPRSN")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Commntid)
                //    .IsRequired()
                //    .HasColumnName("COMMNTID")
                //    .HasColumnType("char(15)")
                //    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Contenddte)
                //    .HasColumnName("CONTENDDTE")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                //entity.Property(e => e.Contitemnbr)
                //    .IsRequired()
                //    .HasColumnName("CONTITEMNBR")
                //    .HasColumnType("char(31)")
                //    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Contlnseqnbr)
                //    .HasColumnName("CONTLNSEQNBR")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Contnbr)
                //    .IsRequired()
                //    .HasColumnName("CONTNBR")
                //    .HasColumnType("char(11)")
                //    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Contserialnbr)
                //    .IsRequired()
                //    .HasColumnName("CONTSERIALNBR")
                //    .HasColumnType("char(21)")
                //    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Contstartdte)
                //    .HasColumnName("CONTSTARTDTE")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("COUNTRY")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Cslsindx)
                //    .HasColumnName("CSLSINDX")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Currnidx)
                //    .HasColumnName("CURRNIDX")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Decplcur)
                //    .HasColumnName("DECPLCUR")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Decplqty)
                //    .HasColumnName("DECPLQTY")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.DexRowId)
                    .HasColumnName("DEX_ROW_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DexRowTs)
                    .HasColumnName("DEX_ROW_TS")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                //entity.Property(e => e.Discsale)
                //.HasColumnName("DISCSALE")
                //.HasColumnType("numeric")
                //.HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Dmgdindx)
                //.HasColumnName("DMGDINDX")
                //.HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Dropship)
                    .HasColumnName("DROPSHIP")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Exceptionaldemand)
                //    .HasColumnName("EXCEPTIONALDEMAND")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Extdcost)
                //    .HasColumnName("EXTDCOST")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Extqtyal)
                //    .HasColumnName("EXTQTYAL")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Extqtysel)
                //    .HasColumnName("EXTQTYSEL")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Faxnumbr)
                    .IsRequired()
                    .HasColumnName("FAXNUMBR")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Flags).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Fufildat)
                    .HasColumnName("FUFILDAT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                //entity.Property(e => e.Gpsfointegrationid)
                //    .IsRequired()
                //    .HasColumnName("GPSFOINTEGRATIONID")
                //    .HasColumnType("char(31)")
                //    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Indpickprnt)
                    .HasColumnName("INDPICKPRNT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Insrindx)
                //    .HasColumnName("INSRINDX")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Integrationid)
                //    .IsRequired()
                //    .HasColumnName("INTEGRATIONID")
                //    .HasColumnType("char(31)")
                //    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Integrationsource)
                //    .HasColumnName("INTEGRATIONSOURCE")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Inusindx)
                //    .HasColumnName("INUSINDX")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Invindx)
                //    .HasColumnName("INVINDX")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Islineintra)
                //    .HasColumnName("ISLINEINTRA")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Itemcode)
                //    .IsRequired()
                //    .HasColumnName("ITEMCODE")
                //    .HasColumnType("char(15)")
                //    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Itemdesc)
                    .IsRequired()
                    .HasColumnName("ITEMDESC")
                    .HasColumnType("char(101)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Itemnmbr)
                    .IsRequired()
                    .HasColumnName("ITEMNMBR")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Itmtshid)
                //    .IsRequired()
                //    .HasColumnName("ITMTSHID")
                //    .HasColumnType("char(15)")
                //    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Ivitmtxb)
                //    .HasColumnName("IVITMTXB")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Locncode)
                    .IsRequired()
                    .HasColumnName("LOCNCODE")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Mkdnindx)
                //.HasColumnName("MKDNINDX")
                //.HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Mrkdnamt)
                //.HasColumnName("MRKDNAMT")
                //.HasColumnType("numeric")
                //.HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Mrkdnpct)
                //.HasColumnName("MRKDNPCT")
                //.HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Mrkdntyp)
                //.HasColumnName("MRKDNTYP")
                //.HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Multiplebins)
                //.HasColumnName("MULTIPLEBINS")
                //.HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Noninven)
                    .HasColumnName("NONINVEN")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Odecplcu)
                //    .HasColumnName("ODECPLCU")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Orbktsls)
                //    .HasColumnName("ORBKTSLS")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Ordavsls)
                //    .HasColumnName("ORDAVSLS")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Oreprice)
                //    .HasColumnName("OREPRICE")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Orextcst)
                //    .HasColumnName("OREXTCST")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Orgseqnm)
                //    .HasColumnName("ORGSEQNM")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.OrigBackoutTradeDisc)
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Ormrkdam)
                //    .HasColumnName("ORMRKDAM")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Ortaxamt)
                //    .HasColumnName("ORTAXAMT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Ortdisam)
                //    .HasColumnName("ORTDISAM")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Oruntcst)
                //    .HasColumnName("ORUNTCST")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Oruntprc)
                //    .HasColumnName("ORUNTPRC")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Otaxtamt)
                //    .HasColumnName("OTAXTAMT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Oxtndprc)
                //    .HasColumnName("OXTNDPRC")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Phone1)
                    .IsRequired()
                    .HasColumnName("PHONE1")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Phone2)
                    .IsRequired()
                    .HasColumnName("PHONE2")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Phone3)
                    .IsRequired()
                    .HasColumnName("PHONE3")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Prclevel)
                    .IsRequired()
                    .HasColumnName("PRCLEVEL")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.PrintPhoneNumberGb)
                //    .HasColumnName("Print_Phone_NumberGB")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Prstadcd)
                    .IsRequired()
                    .HasColumnName("PRSTADCD")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Purchstat)
                //    .HasColumnName("PURCHSTAT")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Qtybsuom)
                //    .HasColumnName("QTYBSUOM")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtycance)
                    .HasColumnName("QTYCANCE")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtycanot)
                    .HasColumnName("QTYCANOT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtydmged)
                    .HasColumnName("QTYDMGED")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyfulfi)
                    .HasColumnName("QTYFULFI")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyinsvc)
                    .HasColumnName("QTYINSVC")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyinuse)
                    .HasColumnName("QTYINUSE")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyonhnd)
                    .HasColumnName("QTYONHND")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyonpo)
                    .HasColumnName("QTYONPO")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyorder)
                    .HasColumnName("QTYORDER")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Qtyprbac)
                //    .HasColumnName("QTYPRBAC")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Qtyprboo)
                //    .HasColumnName("QTYPRBOO")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Qtyprinv)
                //    .HasColumnName("QTYPRINV")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Qtyprord)
                //    .HasColumnName("QTYPRORD")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Qtyprvrecvd)
                //    .HasColumnName("QTYPRVRECVD")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyrecvd)
                    .HasColumnName("QTYRECVD")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyremai)
                    .HasColumnName("QTYREMAI")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyrembo)
                    .HasColumnName("QTYREMBO")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyrtrnd)
                    .HasColumnName("QTYRTRND")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Qtyslctd)
                //    .HasColumnName("QTYSLCTD")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtytbaor)
                    .HasColumnName("QTYTBAOR")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtytoinv)
                    .HasColumnName("QTYTOINV")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtytordr)
                    .HasColumnName("QTYTORDR")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtytoshp)
                    .HasColumnName("QTYTOSHP")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Quantity)
                    .HasColumnName("QUANTITY")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Remprice)
                    .HasColumnName("REMPRICE")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.ReqShipDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                //entity.Property(e => e.Rtnsindx)
                //    .HasColumnName("RTNSINDX")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Salsterr)
                    .IsRequired()
                    .HasColumnName("SALSTERR")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.ShipToName)
                    .IsRequired()
                    .HasColumnType("char(65)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Shipmthd)
                    .IsRequired()
                    .HasColumnName("SHIPMTHD")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Slprsnid)
                    .IsRequired()
                    .HasColumnName("SLPRSNID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Slsindx)
                //    .HasColumnName("SLSINDX")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Sofulfillmentbin)
                //    .IsRequired()
                //    .HasColumnName("SOFULFILLMENTBIN")
                //    .HasColumnType("char(15)")
                //    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Soplnerr)
                //    .IsRequired()
                //    .HasColumnName("SOPLNERR")
                //    .HasColumnType("binary(4)")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("STATE")
                    .HasColumnType("char(29)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Taxamnt)
                    .HasColumnName("TAXAMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Taxschid)
                    .IsRequired()
                    .HasColumnName("TAXSCHID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Trdisamt)
                    .HasColumnName("TRDISAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Trxsorce)
                //    .IsRequired()
                //    .HasColumnName("TRXSORCE")
                //    .HasColumnType("char(13)")
                //    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                //entity.Property(e => e.Txbtxamt)
                //    .HasColumnName("TXBTXAMT")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                //entity.Property(e => e.Txschsrc)
                //    .HasColumnName("TXSCHSRC")
                //    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.Unitcost)
                //    .HasColumnName("UNITCOST")
                //    .HasColumnType("numeric")
                //    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Unitprce)
                    .HasColumnName("UNITPRCE")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Uofm)
                    .IsRequired()
                    .HasColumnName("UOFM")
                    .HasColumnType("char(9)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Xfrshdoc)
                    .HasColumnName("XFRSHDOC")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Xtndprce)
                    .HasColumnName("XTNDPRCE")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Zipcode)
                    .IsRequired()
                    .HasColumnName("ZIPCODE")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");
            });

            modelBuilder.Entity<SOPHistHeader>(entity =>
            {
                entity.HasKey(e => new { e.Sopnumbe, e.Soptype })
                    .HasName("PKSOP30200");

                entity.ToTable("SOP30200");

                entity.HasIndex(e => new { e.Docdate, e.DexRowId })
                    .HasName("AK3SOP30200")
                    .IsUnique();

                entity.HasIndex(e => new { e.Mstrnumb, e.DexRowId })
                    .HasName("AK6SOP30200")
                    .IsUnique();

                entity.HasIndex(e => new { e.Trxsorce, e.DexRowId })
                    .HasName("AK4SOP30200")
                    .IsUnique();

                entity.HasIndex(e => new { e.Soptype, e.Docid, e.DexRowId })
                    .HasName("AK5SOP30200")
                    .IsUnique();

                entity.HasIndex(e => new { e.Soptype, e.Voidstts, e.Sopnumbe })
                    .HasName("AK7SOP30200")
                    .IsUnique();

                entity.HasIndex(e => new { e.Custnmbr, e.Cstponbr, e.Docdate, e.DexRowId })
                    .HasName("AK2SOP30200")
                    .IsUnique();

                entity.Property(e => e.Sopnumbe)
                    .HasColumnName("SOPNUMBE")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Soptype)
                    .HasColumnName("SOPTYPE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Acctamnt)
                    .HasColumnName("ACCTAMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Actlship)
                    .HasColumnName("ACTLSHIP")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasColumnName("ADDRESS1")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasColumnName("ADDRESS2")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Address3)
                    .IsRequired()
                    .HasColumnName("ADDRESS3")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Allocaby)
                    .HasColumnName("ALLOCABY")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Aplywith)
                    .HasColumnName("APLYWITH")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Bachnumb)
                    .IsRequired()
                    .HasColumnName("BACHNUMB")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Backdate)
                    .HasColumnName("BACKDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Bchsourc)
                    .IsRequired()
                    .HasColumnName("BCHSOURC")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Bcktxamt)
                    .HasColumnName("BCKTXAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Bktfrtam)
                    .HasColumnName("BKTFRTAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Bktmscam)
                    .HasColumnName("BKTMSCAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Bsivcttl)
                    .HasColumnName("BSIVCTTL")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ccode)
                    .IsRequired()
                    .HasColumnName("CCode")
                    .HasColumnType("char(7)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("CITY")
                    .HasColumnType("char(35)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Cmmslamt)
                    .HasColumnName("CMMSLAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Cntcprsn)
                    .IsRequired()
                    .HasColumnName("CNTCPRSN")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Codamnt)
                    .HasColumnName("CODAMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Comappto)
                    .HasColumnName("COMAPPTO")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Commamnt)
                    .HasColumnName("COMMAMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Commntid)
                    .IsRequired()
                    .HasColumnName("COMMNTID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.ContractExchangeRateStat).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Corrctn)
                    .HasColumnName("CORRCTN")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("COUNTRY")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Creatddt)
                    .HasColumnName("CREATDDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Cstponbr)
                    .IsRequired()
                    .HasColumnName("CSTPONBR")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Curncyid)
                    .IsRequired()
                    .HasColumnName("CURNCYID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Currnidx)
                    .HasColumnName("CURRNIDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Custname)
                    .IsRequired()
                    .HasColumnName("CUSTNAME")
                    .HasColumnType("char(65)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Custnmbr)
                    .IsRequired()
                    .HasColumnName("CUSTNMBR")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Denxrate)
                    .HasColumnName("DENXRATE")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Deprecvd)
                    .HasColumnName("DEPRECVD")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.DexRowId)
                    .HasColumnName("DEX_ROW_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DexRowTs)
                    .HasColumnName("DEX_ROW_TS")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.Directdebit)
                    .HasColumnName("DIRECTDEBIT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Disavamt)
                    .HasColumnName("DISAVAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Disavtkn)
                    .HasColumnName("DISAVTKN")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Discdate)
                    .HasColumnName("DISCDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Discfrgt)
                    .HasColumnName("DISCFRGT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Discmisc)
                    .HasColumnName("DISCMISC")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Discrtnd)
                    .HasColumnName("DISCRTND")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Distknam)
                    .HasColumnName("DISTKNAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Docamnt)
                    .HasColumnName("DOCAMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Docdate)
                    .HasColumnName("DOCDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Docid)
                    .IsRequired()
                    .HasColumnName("DOCID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Docncorr)
                    .IsRequired()
                    .HasColumnName("DOCNCORR")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Dscdlram)
                    .HasColumnName("DSCDLRAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Dscpctam)
                    .HasColumnName("DSCPCTAM")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Dstbtch1)
                    .IsRequired()
                    .HasColumnName("DSTBTCH1")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Dstbtch2)
                    .IsRequired()
                    .HasColumnName("DSTBTCH2")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Dtlstrep)
                    .HasColumnName("DTLSTREP")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Duedate)
                    .HasColumnName("DUEDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Dystincr)
                    .HasColumnName("DYSTINCR")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ectrx)
                    .HasColumnName("ECTRX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Exceptionaldemand)
                    .HasColumnName("EXCEPTIONALDEMAND")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Exchdate)
                    .HasColumnName("EXCHDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Exgtblid)
                    .IsRequired()
                    .HasColumnName("EXGTBLID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Extdcost)
                    .HasColumnName("EXTDCOST")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Faxnumbr)
                    .IsRequired()
                    .HasColumnName("FAXNUMBR")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Flags).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Frgttxbl)
                    .HasColumnName("FRGTTXBL")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Frtamnt)
                    .HasColumnName("FRTAMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Frtschid)
                    .IsRequired()
                    .HasColumnName("FRTSCHID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Frttxamt)
                    .HasColumnName("FRTTXAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Fufildat)
                    .HasColumnName("FUFILDAT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Glpostdt)
                    .HasColumnName("GLPOSTDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Invodate)
                    .HasColumnName("INVODATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Locncode)
                    .IsRequired()
                    .HasColumnName("LOCNCODE")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Mctrxstt)
                    .HasColumnName("MCTRXSTT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Miscamnt)
                    .HasColumnName("MISCAMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Misctxbl)
                    .HasColumnName("MISCTXBL")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Modifdt)
                    .HasColumnName("MODIFDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Mrkdnamt)
                    .HasColumnName("MRKDNAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Mscschid)
                    .IsRequired()
                    .HasColumnName("MSCSCHID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Msctxamt)
                    .HasColumnName("MSCTXAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Mstrnumb)
                    .HasColumnName("MSTRNUMB")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ncomamnt)
                    .HasColumnName("NCOMAMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Noteindx)
                    .HasColumnName("NOTEINDX")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Obtaxamt)
                    .HasColumnName("OBTAXAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ocommamt)
                    .HasColumnName("OCOMMAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Oractamt)
                    .HasColumnName("ORACTAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Orbktfrt)
                    .HasColumnName("ORBKTFRT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Orbktmsc)
                    .HasColumnName("ORBKTMSC")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Orcodamt)
                    .HasColumnName("ORCODAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Orcosamt)
                    .HasColumnName("ORCOSAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ordatkn)
                    .HasColumnName("ORDATKN")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ordavamt)
                    .HasColumnName("ORDAVAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ordavfrt)
                    .HasColumnName("ORDAVFRT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ordavmsc)
                    .HasColumnName("ORDAVMSC")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Orddlrat)
                    .HasColumnName("ORDDLRAT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ordeprvd)
                    .HasColumnName("ORDEPRVD")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ordisrtd)
                    .HasColumnName("ORDISRTD")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ordistkn)
                    .HasColumnName("ORDISTKN")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ordocamt)
                    .HasColumnName("ORDOCAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ordrdate)
                    .HasColumnName("ORDRDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Oremsubt)
                    .HasColumnName("OREMSUBT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Orextcst)
                    .HasColumnName("OREXTCST")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Orfrtamt)
                    .HasColumnName("ORFRTAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Orfrttax)
                    .HasColumnName("ORFRTTAX")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Orignumb)
                    .IsRequired()
                    .HasColumnName("ORIGNUMB")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Origtype)
                    .HasColumnName("ORIGTYPE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ormiscamt)
                    .HasColumnName("ORMISCAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ormrkdam)
                    .HasColumnName("ORMRKDAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ormsctax)
                    .HasColumnName("ORMSCTAX")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Orncmamt)
                    .HasColumnName("ORNCMAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Orpmtrvd)
                    .HasColumnName("ORPMTRVD")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Orsubtot)
                    .HasColumnName("ORSUBTOT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ortaxamt)
                    .HasColumnName("ORTAXAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ortdisam)
                    .HasColumnName("ORTDISAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Otaxtamt)
                    .HasColumnName("OTAXTAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Pckslpno)
                    .IsRequired()
                    .HasColumnName("PCKSLPNO")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Phnumbr1)
                    .IsRequired()
                    .HasColumnName("PHNUMBR1")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Phnumbr2)
                    .IsRequired()
                    .HasColumnName("PHNUMBR2")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Phone3)
                    .IsRequired()
                    .HasColumnName("PHONE3")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Picticnu)
                    .IsRequired()
                    .HasColumnName("PICTICNU")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Posteddt)
                    .HasColumnName("POSTEDDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Prbtadcd)
                    .IsRequired()
                    .HasColumnName("PRBTADCD")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Prclevel)
                    .IsRequired()
                    .HasColumnName("PRCLEVEL")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.PrintPhoneNumberGb)
                    .HasColumnName("Print_Phone_NumberGB")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Prospect)
                    .HasColumnName("PROSPECT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Prstadcd)
                    .IsRequired()
                    .HasColumnName("PRSTADCD")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Pstgstus)
                    .HasColumnName("PSTGSTUS")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ptdusrid)
                    .IsRequired()
                    .HasColumnName("PTDUSRID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Pymtrcvd)
                    .HasColumnName("PYMTRCVD")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Pymtrmid)
                    .IsRequired()
                    .HasColumnName("PYMTRMID")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Quoexpda)
                    .HasColumnName("QUOEXPDA")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Quotedat)
                    .HasColumnName("QUOTEDAT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Ratetpid)
                    .IsRequired()
                    .HasColumnName("RATETPID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Refrence)
                    .IsRequired()
                    .HasColumnName("REFRENCE")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Remsubto)
                    .HasColumnName("REMSUBTO")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Repting)
                    .HasColumnName("REPTING")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.ReqShipDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Retudate)
                    .HasColumnName("RETUDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Rtclcmtd)
                    .HasColumnName("RTCLCMTD")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Saledate)
                    .HasColumnName("SALEDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Salsterr)
                    .IsRequired()
                    .HasColumnName("SALSTERR")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Seqncorr)
                    .HasColumnName("SEQNCORR")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.ShipToName)
                    .IsRequired()
                    .HasColumnType("char(65)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Shipcomplete)
                    .HasColumnName("SHIPCOMPLETE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Shipmthd)
                    .IsRequired()
                    .HasColumnName("SHIPMTHD")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Shppgdoc)
                    .HasColumnName("SHPPGDOC")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Simplifd)
                    .HasColumnName("SIMPLIFD")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Slprsnid)
                    .IsRequired()
                    .HasColumnName("SLPRSNID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Sophdre1)
                    .IsRequired()
                    .HasColumnName("SOPHDRE1")
                    .HasColumnType("binary(4)")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Sophdre2)
                    .IsRequired()
                    .HasColumnName("SOPHDRE2")
                    .HasColumnType("binary(4)")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Sophdrfl)
                    .IsRequired()
                    .HasColumnName("SOPHDRFL")
                    .HasColumnType("binary(4)")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Soplnerr)
                    .IsRequired()
                    .HasColumnName("SOPLNERR")
                    .HasColumnType("binary(4)")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Sopstatus)
                    .HasColumnName("SOPSTATUS")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("STATE")
                    .HasColumnType("char(29)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Subtotal)
                    .HasColumnName("SUBTOTAL")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.TaxDate)
                    .HasColumnName("Tax_Date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Taxamnt)
                    .HasColumnName("TAXAMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Taxexmt1)
                    .IsRequired()
                    .HasColumnName("TAXEXMT1")
                    .HasColumnType("char(25)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Taxexmt2)
                    .IsRequired()
                    .HasColumnName("TAXEXMT2")
                    .HasColumnType("char(25)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Taxschid)
                    .IsRequired()
                    .HasColumnName("TAXSCHID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Time1)
                    .HasColumnName("TIME1")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Timerepd)
                    .HasColumnName("TIMEREPD")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Timesprt)
                    .HasColumnName("TIMESPRT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Timetrep)
                    .HasColumnName("TIMETREP")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Trdisamt)
                    .HasColumnName("TRDISAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Trdispct)
                    .HasColumnName("TRDISPCT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Trxfrequ)
                    .HasColumnName("TRXFREQU")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Trxsorce)
                    .IsRequired()
                    .HasColumnName("TRXSORCE")
                    .HasColumnType("char(13)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Txbtxamt)
                    .HasColumnName("TXBTXAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Txengcld)
                    .HasColumnName("TXENGCLD")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Txrgnnum)
                    .IsRequired()
                    .HasColumnName("TXRGNNUM")
                    .HasColumnType("char(25)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Txschsrc)
                    .HasColumnName("TXSCHSRC")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Upszone)
                    .IsRequired()
                    .HasColumnName("UPSZONE")
                    .HasColumnType("char(3)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Usdocid1)
                    .IsRequired()
                    .HasColumnName("USDOCID1")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Usdocid2)
                    .IsRequired()
                    .HasColumnName("USDOCID2")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.User2ent)
                    .IsRequired()
                    .HasColumnName("USER2ENT")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Voidstts)
                    .HasColumnName("VOIDSTTS")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Withhamt)
                    .HasColumnName("WITHHAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.WorkflowApprStatCreditLm).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.WorkflowApprStatusQuote).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.WorkflowPriorityCreditLm).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.WorkflowPriorityQuote).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.WorkflowStatus)
                    .HasColumnName("Workflow_Status")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Xchgrate)
                    .HasColumnName("XCHGRATE")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Zipcode)
                    .IsRequired()
                    .HasColumnName("ZIPCODE")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");
            });

            modelBuilder.Entity<SOPHistLine>(entity =>
            {
                entity.HasKey(e => new { e.Sopnumbe, e.Soptype, e.Cmpntseq, e.Lnitmseq })
                    .HasName("PKSOP30300");

                entity.ToTable("SOP30300");

                entity.HasIndex(e => new { e.Itemnmbr, e.DexRowId })
                    .HasName("AK3SOP30300")
                    .IsUnique();

                entity.HasIndex(e => new { e.Trxsorce, e.Itemnmbr, e.DexRowId })
                    .HasName("AK4SOP30300")
                    .IsUnique();

                entity.HasIndex(e => new { e.Docncorr, e.Orgseqnm, e.Soptype, e.Sopnumbe, e.DexRowId })
                    .HasName("AK5SOP30300")
                    .IsUnique();

                entity.HasIndex(e => new { e.Soptype, e.Remprice, e.Sopnumbe, e.Itemnmbr, e.DexRowId })
                    .HasName("AK7SOP30300")
                    .IsUnique();

                entity.HasIndex(e => new { e.Soptype, e.ReqShipDate, e.Actlship, e.Sopnumbe, e.DexRowId })
                    .HasName("AK6SOP30300")
                    .IsUnique();

                entity.HasIndex(e => new { e.Soptype, e.Qtytoinv, e.Sopnumbe, e.Itemnmbr, e.Qtybsuom, e.Decplqty, e.DexRowId })
                    .HasName("AK8SOP30300")
                    .IsUnique();

                entity.HasIndex(e => new { e.Soptype, e.Sopnumbe, e.Lnitmseq, e.Cmpntseq, e.Brkfld1, e.Brkfld2, e.Brkfld3 })
                    .HasName("AK2SOP30300")
                    .IsUnique();

                entity.Property(e => e.Sopnumbe)
                    .HasColumnName("SOPNUMBE")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Soptype)
                    .HasColumnName("SOPTYPE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Cmpntseq)
                    .HasColumnName("CMPNTSEQ")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Lnitmseq)
                    .HasColumnName("LNITMSEQ")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Actlship)
                    .HasColumnName("ACTLSHIP")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasColumnName("ADDRESS1")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasColumnName("ADDRESS2")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Address3)
                    .IsRequired()
                    .HasColumnName("ADDRESS3")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Atyalloc)
                    .HasColumnName("ATYALLOC")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Bktslsam)
                    .HasColumnName("BKTSLSAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Brkfld1)
                    .HasColumnName("BRKFLD1")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Brkfld2)
                    .HasColumnName("BRKFLD2")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Brkfld3)
                    .HasColumnName("BRKFLD3")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Bsivcttl)
                    .HasColumnName("BSIVCTTL")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ccode)
                    .IsRequired()
                    .HasColumnName("CCode")
                    .HasColumnType("char(7)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("CITY")
                    .HasColumnType("char(35)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Cntcprsn)
                    .IsRequired()
                    .HasColumnName("CNTCPRSN")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Commntid)
                    .IsRequired()
                    .HasColumnName("COMMNTID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Contenddte)
                    .HasColumnName("CONTENDDTE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Contitemnbr)
                    .IsRequired()
                    .HasColumnName("CONTITEMNBR")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Contlnseqnbr)
                    .HasColumnName("CONTLNSEQNBR")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Contnbr)
                    .IsRequired()
                    .HasColumnName("CONTNBR")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Contserialnbr)
                    .IsRequired()
                    .HasColumnName("CONTSERIALNBR")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Contstartdte)
                    .HasColumnName("CONTSTARTDTE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("COUNTRY")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Cslsindx)
                    .HasColumnName("CSLSINDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Currnidx)
                    .HasColumnName("CURRNIDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Decplcur)
                    .HasColumnName("DECPLCUR")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Decplqty)
                    .HasColumnName("DECPLQTY")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.DexRowId)
                    .HasColumnName("DEX_ROW_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DexRowTs)
                    .HasColumnName("DEX_ROW_TS")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.Discsale)
                    .HasColumnName("DISCSALE")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Dmgdindx)
                    .HasColumnName("DMGDINDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Docncorr)
                    .IsRequired()
                    .HasColumnName("DOCNCORR")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Dropship)
                    .HasColumnName("DROPSHIP")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Exceptionaldemand)
                    .HasColumnName("EXCEPTIONALDEMAND")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Extdcost)
                    .HasColumnName("EXTDCOST")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Extqtyal)
                    .HasColumnName("EXTQTYAL")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Extqtysel)
                    .HasColumnName("EXTQTYSEL")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Faxnumbr)
                    .IsRequired()
                    .HasColumnName("FAXNUMBR")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Flags).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Fufildat)
                    .HasColumnName("FUFILDAT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Insrindx)
                    .HasColumnName("INSRINDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Inusindx)
                    .HasColumnName("INUSINDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Invindx)
                    .HasColumnName("INVINDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Islineintra)
                    .HasColumnName("ISLINEINTRA")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Itemcode)
                    .IsRequired()
                    .HasColumnName("ITEMCODE")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Itemdesc)
                    .IsRequired()
                    .HasColumnName("ITEMDESC")
                    .HasColumnType("char(101)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Itemnmbr)
                    .IsRequired()
                    .HasColumnName("ITEMNMBR")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Itmtshid)
                    .IsRequired()
                    .HasColumnName("ITMTSHID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Ivitmtxb)
                    .HasColumnName("IVITMTXB")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Locncode)
                    .IsRequired()
                    .HasColumnName("LOCNCODE")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Mkdnindx)
                    .HasColumnName("MKDNINDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Mrkdnamt)
                    .HasColumnName("MRKDNAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Mrkdnpct)
                    .HasColumnName("MRKDNPCT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Mrkdntyp)
                    .HasColumnName("MRKDNTYP")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Noninven)
                    .HasColumnName("NONINVEN")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Odecplcu)
                    .HasColumnName("ODECPLCU")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Orbktsls)
                    .HasColumnName("ORBKTSLS")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ordavsls)
                    .HasColumnName("ORDAVSLS")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Oreprice)
                    .HasColumnName("OREPRICE")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Orextcst)
                    .HasColumnName("OREXTCST")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Orgseqnm)
                    .HasColumnName("ORGSEQNM")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ormrkdam)
                    .HasColumnName("ORMRKDAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ortaxamt)
                    .HasColumnName("ORTAXAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ortdisam)
                    .HasColumnName("ORTDISAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Oruntcst)
                    .HasColumnName("ORUNTCST")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Oruntprc)
                    .HasColumnName("ORUNTPRC")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Otaxtamt)
                    .HasColumnName("OTAXTAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Oxtndprc)
                    .HasColumnName("OXTNDPRC")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Phone1)
                    .IsRequired()
                    .HasColumnName("PHONE1")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Phone2)
                    .IsRequired()
                    .HasColumnName("PHONE2")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Phone3)
                    .IsRequired()
                    .HasColumnName("PHONE3")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Prclevel)
                    .IsRequired()
                    .HasColumnName("PRCLEVEL")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.PrintPhoneNumberGb)
                    .HasColumnName("Print_Phone_NumberGB")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Prstadcd)
                    .IsRequired()
                    .HasColumnName("PRSTADCD")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Purchstat)
                    .HasColumnName("PURCHSTAT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Qtybsuom)
                    .HasColumnName("QTYBSUOM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtycance)
                    .HasColumnName("QTYCANCE")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtycanot)
                    .HasColumnName("QTYCANOT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtydmged)
                    .HasColumnName("QTYDMGED")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyfulfi)
                    .HasColumnName("QTYFULFI")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyinsvc)
                    .HasColumnName("QTYINSVC")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyinuse)
                    .HasColumnName("QTYINUSE")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyonhnd)
                    .HasColumnName("QTYONHND")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyorder)
                    .HasColumnName("QTYORDER")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyprbac)
                    .HasColumnName("QTYPRBAC")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyprboo)
                    .HasColumnName("QTYPRBOO")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyprinv)
                    .HasColumnName("QTYPRINV")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyprord)
                    .HasColumnName("QTYPRORD")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyprvrecvd)
                    .HasColumnName("QTYPRVRECVD")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyrecvd)
                    .HasColumnName("QTYRECVD")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyremai)
                    .HasColumnName("QTYREMAI")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyrembo)
                    .HasColumnName("QTYREMBO")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyrtrnd)
                    .HasColumnName("QTYRTRND")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtyslctd)
                    .HasColumnName("QTYSLCTD")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtytbaor)
                    .HasColumnName("QTYTBAOR")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtytoinv)
                    .HasColumnName("QTYTOINV")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Qtytordr)
                    .HasColumnName("QTYTORDR")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Quantity)
                    .HasColumnName("QUANTITY")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Remprice)
                    .HasColumnName("REMPRICE")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.ReqShipDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Rtnsindx)
                    .HasColumnName("RTNSINDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Salsterr)
                    .IsRequired()
                    .HasColumnName("SALSTERR")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.ShipToName)
                    .IsRequired()
                    .HasColumnType("char(65)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Shipmthd)
                    .IsRequired()
                    .HasColumnName("SHIPMTHD")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Slprsnid)
                    .IsRequired()
                    .HasColumnName("SLPRSNID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Slsindx)
                    .HasColumnName("SLSINDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Soplnerr)
                    .IsRequired()
                    .HasColumnName("SOPLNERR")
                    .HasColumnType("binary(4)")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("STATE")
                    .HasColumnType("char(29)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Taxamnt)
                    .HasColumnName("TAXAMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Taxschid)
                    .IsRequired()
                    .HasColumnName("TAXSCHID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Trdisamt)
                    .HasColumnName("TRDISAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Trxsorce)
                    .IsRequired()
                    .HasColumnName("TRXSORCE")
                    .HasColumnType("char(13)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Txbtxamt)
                    .HasColumnName("TXBTXAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Txschsrc)
                    .HasColumnName("TXSCHSRC")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Unitcost)
                    .HasColumnName("UNITCOST")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Unitprce)
                    .HasColumnName("UNITPRCE")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Uofm)
                    .IsRequired()
                    .HasColumnName("UOFM")
                    .HasColumnType("char(9)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Xtndprce)
                    .HasColumnName("XTNDPRCE")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Zipcode)
                    .IsRequired()
                    .HasColumnName("ZIPCODE")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");
            });

            modelBuilder.Entity<SOPTracking>(entity =>
            {
                entity.HasKey(e => new { e.Sopnumbe, e.Soptype, e.TrackingNumber })
                    .HasName("PKSOP10107");

                //entity.ToTable("SOP10107");

                entity.Property(e => e.Sopnumbe)
                    .HasColumnName("SOPNUMBE")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Soptype)
                    .HasColumnName("SOPTYPE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.TrackingNumber)
                    .HasColumnName("Tracking_Number")
                    .HasColumnType("char(41)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.DexRowId)
                    .HasColumnName("DEX_ROW_ID")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VendorEntity>(entity =>
            {
                entity.HasKey(e => e.Vendorid)
                    .HasName("PKPM00200");

                entity.ToTable("PM00200");

                entity.HasIndex(e => new { e.Pymntpri, e.Vendorid })
                    .HasName("AK5PM00200")
                    .IsUnique();

                entity.HasIndex(e => new { e.Txrgnnum, e.Vendorid })
                    .HasName("AK6PM00200")
                    .IsUnique();

                entity.HasIndex(e => new { e.Userdef1, e.Vendorid })
                    .HasName("AK4PM00200")
                    .IsUnique();

                entity.HasIndex(e => new { e.Vendname, e.Vendorid })
                    .HasName("AK2PM00200")
                    .IsUnique();

                entity.HasIndex(e => new { e.Vndclsid, e.Vendorid })
                    .HasName("AK3PM00200")
                    .IsUnique();

                entity.Property(e => e.Vendorid)
                    .HasColumnName("VENDORID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Acnmvndr)
                    .IsRequired()
                    .HasColumnName("ACNMVNDR")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Acpuridx)
                    .HasColumnName("ACPURIDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasColumnName("ADDRESS1")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasColumnName("ADDRESS2")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Address3)
                    .IsRequired()
                    .HasColumnName("ADDRESS3")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Brthdate)
                    .HasColumnName("BRTHDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Cbvat)
                    .HasColumnName("CBVAT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ccode)
                    .IsRequired()
                    .HasColumnName("CCode")
                    .HasColumnType("char(7)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Chekbkid)
                    .IsRequired()
                    .HasColumnName("CHEKBKID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("CITY")
                    .HasColumnType("char(35)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Comment1)
                    .IsRequired()
                    .HasColumnName("COMMENT1")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Comment2)
                    .IsRequired()
                    .HasColumnName("COMMENT2")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("COUNTRY")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Creatddt)
                    .HasColumnName("CREATDDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Credtlmt)
                    .HasColumnName("CREDTLMT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Crlmtdlr)
                    .HasColumnName("CRLMTDLR")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Crtcomdt)
                    .HasColumnName("CRTCOMDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Crtexpdt)
                    .HasColumnName("CRTEXPDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Curncyid)
                    .IsRequired()
                    .HasColumnName("CURNCYID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Declid)
                    .IsRequired()
                    .HasColumnName("DECLID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.DexRowId)
                    .HasColumnName("DEX_ROW_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DexRowTs)
                    .HasColumnName("DEX_ROW_TS")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.Disgrper)
                    .HasColumnName("DISGRPER")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Docfmtid)
                    .IsRequired()
                    .HasColumnName("DOCFMTID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Duegrper)
                    .HasColumnName("DUEGRPER")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Dxvarnum)
                    .IsRequired()
                    .HasColumnName("DXVARNUM")
                    .HasColumnType("char(25)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Faxnumbr)
                    .IsRequired()
                    .HasColumnName("FAXNUMBR")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Freeonboard)
                    .HasColumnName("FREEONBOARD")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Govcrpid)
                    .IsRequired()
                    .HasColumnName("GOVCRPID")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Govindid)
                    .IsRequired()
                    .HasColumnName("GOVINDID")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Hold)
                    .HasColumnName("HOLD")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Kgldsths)
                    .HasColumnName("KGLDSTHS")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Kpcalhst)
                    .HasColumnName("KPCALHST")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Kperhist)
                    .HasColumnName("KPERHIST")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Kptrxhst)
                    .HasColumnName("KPTRXHST")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.LaborPmtType).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Maxindlr)
                    .HasColumnName("MAXINDLR")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Minorder)
                    .HasColumnName("MINORDER")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Minpydlr)
                    .HasColumnName("MINPYDLR")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Minpypct)
                    .HasColumnName("MINPYPCT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Minpytyp)
                    .HasColumnName("MINPYTYP")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Modifdt)
                    .HasColumnName("MODIFDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Mxiafvnd)
                    .HasColumnName("MXIAFVND")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Mxwofamt)
                    .HasColumnName("MXWOFAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Noteindx)
                    .HasColumnName("NOTEINDX")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Parvenid)
                    .IsRequired()
                    .HasColumnName("PARVENID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Phnumbr1)
                    .IsRequired()
                    .HasColumnName("PHNUMBR1")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Phnumbr2)
                    .IsRequired()
                    .HasColumnName("PHNUMBR2")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Phone3)
                    .IsRequired()
                    .HasColumnName("PHONE3")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Pmapindx)
                    .HasColumnName("PMAPINDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Pmcshidx)
                    .HasColumnName("PMCSHIDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Pmdavidx)
                    .HasColumnName("PMDAVIDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Pmdtkidx)
                    .HasColumnName("PMDTKIDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Pmfinidx)
                    .HasColumnName("PMFINIDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Pmfrtidx)
                    .HasColumnName("PMFRTIDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Pmmschix)
                    .HasColumnName("PMMSCHIX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Pmprchix)
                    .HasColumnName("PMPRCHIX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Pmrtngix)
                    .HasColumnName("PMRTNGIX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Pmtaxidx)
                    .HasColumnName("PMTAXIDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Pmtdscix)
                    .HasColumnName("PMTDSCIX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Pmwrtidx)
                    .HasColumnName("PMWRTIDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.PostResultsTo)
                    .HasColumnName("Post_Results_To")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ppstaxrt)
                    .HasColumnName("PPSTAXRT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Prspayee)
                    .HasColumnName("PRSPAYEE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ptcshacf)
                    .HasColumnName("PTCSHACF")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Purpvidx)
                    .HasColumnName("PURPVIDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Pymntpri)
                    .IsRequired()
                    .HasColumnName("PYMNTPRI")
                    .HasColumnType("char(3)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Pymtrmid)
                    .IsRequired()
                    .HasColumnName("PYMTRMID")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Ratetpid)
                    .IsRequired()
                    .HasColumnName("RATETPID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.RevalueVendor)
                    .HasColumnName("Revalue_Vendor")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Rtobutkn)
                    .HasColumnName("RTOBUTKN")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Sbppsded)
                    .HasColumnName("SBPPSDED")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Shipmthd)
                    .IsRequired()
                    .HasColumnName("SHIPMTHD")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("STATE")
                    .HasColumnType("char(29)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.TaxFileNumMode).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.TaxInvRecvd).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Taxschid)
                    .IsRequired()
                    .HasColumnName("TAXSCHID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Ten99boxnumber)
                    .HasColumnName("TEN99BOXNUMBER")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ten99type)
                    .HasColumnName("TEN99TYPE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Trddisct)
                    .HasColumnName("TRDDISCT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Txidnmbr)
                    .IsRequired()
                    .HasColumnName("TXIDNMBR")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Txrgnnum)
                    .IsRequired()
                    .HasColumnName("TXRGNNUM")
                    .HasColumnType("char(25)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Upszone)
                    .IsRequired()
                    .HasColumnName("UPSZONE")
                    .HasColumnType("char(3)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Userdef1)
                    .IsRequired()
                    .HasColumnName("USERDEF1")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Userdef2)
                    .IsRequired()
                    .HasColumnName("USERDEF2")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Userlang)
                    .HasColumnName("USERLANG")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Vadcd1099)
                    .IsRequired()
                    .HasColumnName("VADCD1099")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Vadcdpad)
                    .IsRequired()
                    .HasColumnName("VADCDPAD")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Vadcdsfr)
                    .IsRequired()
                    .HasColumnName("VADCDSFR")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Vadcdtro)
                    .IsRequired()
                    .HasColumnName("VADCDTRO")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Vaddcdpr)
                    .IsRequired()
                    .HasColumnName("VADDCDPR")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Vendname)
                    .IsRequired()
                    .HasColumnName("VENDNAME")
                    .HasColumnType("char(65)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Vendshnm)
                    .IsRequired()
                    .HasColumnName("VENDSHNM")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Vendstts)
                    .HasColumnName("VENDSTTS")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Vndchknm)
                    .IsRequired()
                    .HasColumnName("VNDCHKNM")
                    .HasColumnType("char(65)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Vndclsid)
                    .IsRequired()
                    .HasColumnName("VNDCLSID")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Vndcntct)
                    .IsRequired()
                    .HasColumnName("VNDCNTCT")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.WithholdingEntityType).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.WithholdingFormType).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.WithholdingType).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.WorkflowApprovalStatus)
                    .HasColumnName("Workflow_Approval_Status")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.WorkflowPriority)
                    .HasColumnName("Workflow_Priority")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.WorkflowStatus)
                    .HasColumnName("Workflow_Status")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Writeoff)
                    .HasColumnName("WRITEOFF")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Xpdtoblg)
                    .HasColumnName("XPDTOBLG")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Zipcode)
                    .IsRequired()
                    .HasColumnName("ZIPCODE")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");
            });

            modelBuilder.Entity<VendorAddressEntity>(entity =>
            {
                entity.HasKey(e => new { e.Vendorid, e.Adrscode })
                    .HasName("PKPM00300");

                entity.ToTable("PM00300");

                entity.HasIndex(e => new { e.Vendorid, e.DexRowId })
                    .HasName("AK5PM00300")
                    .IsUnique();

                entity.HasIndex(e => new { e.Vendorid, e.City, e.DexRowId })
                    .HasName("AK2PM00300")
                    .IsUnique();

                entity.HasIndex(e => new { e.Vendorid, e.State, e.DexRowId })
                    .HasName("AK3PM00300")
                    .IsUnique();

                entity.HasIndex(e => new { e.Vendorid, e.Zipcode, e.DexRowId })
                    .HasName("AK4PM00300")
                    .IsUnique();

                entity.Property(e => e.Vendorid)
                    .HasColumnName("VENDORID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Adrscode)
                    .HasColumnName("ADRSCODE")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasColumnName("ADDRESS1")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasColumnName("ADDRESS2")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Address3)
                    .IsRequired()
                    .HasColumnName("ADDRESS3")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Ccode)
                    .IsRequired()
                    .HasColumnName("CCode")
                    .HasColumnType("char(7)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("CITY")
                    .HasColumnType("char(35)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("COUNTRY")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Declid)
                    .IsRequired()
                    .HasColumnName("DECLID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.DexRowId)
                    .HasColumnName("DEX_ROW_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DexRowTs)
                    .HasColumnName("DEX_ROW_TS")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.EmailPoformat)
                    .HasColumnName("EmailPOFormat")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.EmailPos)
                    .HasColumnName("EmailPOs")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.FaxPoformat)
                    .HasColumnName("FaxPOFormat")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.FaxPos)
                    .HasColumnName("FaxPOs")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Faxnumbr)
                    .IsRequired()
                    .HasColumnName("FAXNUMBR")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Phnumbr1)
                    .IsRequired()
                    .HasColumnName("PHNUMBR1")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Phnumbr2)
                    .IsRequired()
                    .HasColumnName("PHNUMBR2")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Phone3)
                    .IsRequired()
                    .HasColumnName("PHONE3")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.PoemailRecipient)
                    .IsRequired()
                    .HasColumnName("POEmailRecipient")
                    .HasColumnType("char(81)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.PofaxNumber)
                    .IsRequired()
                    .HasColumnName("POFaxNumber")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Shipmthd)
                    .IsRequired()
                    .HasColumnName("SHIPMTHD")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("STATE")
                    .HasColumnType("char(29)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Taxschid)
                    .IsRequired()
                    .HasColumnName("TAXSCHID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Upszone)
                    .IsRequired()
                    .HasColumnName("UPSZONE")
                    .HasColumnType("char(3)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Vndcntct)
                    .IsRequired()
                    .HasColumnName("VNDCNTCT")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Zipcode)
                    .IsRequired()
                    .HasColumnName("ZIPCODE")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");
            });

            modelBuilder.Entity<EFTInfoEntity>(entity =>
            {
                entity.HasKey(e => new { e.CustomerVendorId, e.Adrscode, e.Series })
                    .HasName("PKSY06000");

                entity.ToTable("SY06000");

                //entity.HasIndex(e => new { e.Custnmbr, e.DexRowId })
                //    .HasName("AK2SY06000")
                //    .IsUnique();

                //entity.HasIndex(e => new { e.Vendorid, e.DexRowId })
                //    .HasName("AK3SY06000")
                //    .IsUnique();

                entity.Property(e => e.CustomerVendorId)
                    .HasColumnName("CustomerVendor_ID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Adrscode)
                    .HasColumnName("ADRSCODE")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Series)
                    .HasColumnName("SERIES")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasColumnName("ADDRESS1")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ")
                    .HasDefaultValue(string.Empty);

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasColumnName("ADDRESS2")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Address3)
                    .IsRequired()
                    .HasColumnName("ADDRESS3")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Address4)
                    .IsRequired()
                    .HasColumnName("ADDRESS4")
                    .HasColumnType("char(61)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.BankInfo7).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Bankname)
                    .IsRequired()
                    .HasColumnName("BANKNAME")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Bnkctrcd)
                    .IsRequired()
                    .HasColumnName("BNKCTRCD")
                    .HasColumnType("char(3)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Bsrollno)
                    .IsRequired()
                    .HasColumnName("BSROLLNO")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Cbankcd)
                    .IsRequired()
                    .HasColumnName("CBANKCD")
                    .HasColumnType("char(9)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Curncyid)
                    .IsRequired()
                    .HasColumnName("CURNCYID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.CustVendCountryCode)
                    .IsRequired()
                    .HasColumnType("char(3)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Custnmbr)
                    .IsRequired()
                    .HasColumnName("CUSTNMBR")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.DeliveryCountryCode)
                    .IsRequired()
                    .HasColumnType("char(3)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.DexRowId)
                    .HasColumnName("DEX_ROW_ID")
                    .ValueGeneratedOnAdd()
                    .Metadata.IsReadOnlyAfterSave = true;

                entity.Property(e => e.EftaccountType)
                    .HasColumnName("EFTAccountType")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.EftbankAcct)
                    .IsRequired()
                    .HasColumnName("EFTBankAcct")
                    .HasColumnType("char(35)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.EftbankBranch)
                    .IsRequired()
                    .HasColumnName("EFTBankBranch")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.EftbankBranchCode)
                    .IsRequired()
                    .HasColumnName("EFTBankBranchCode")
                    .HasColumnType("char(5)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.EftbankCheckDigit)
                    .IsRequired()
                    .HasColumnName("EFTBankCheckDigit")
                    .HasColumnType("char(3)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.EftbankCode)
                    .IsRequired()
                    .HasColumnName("EFTBankCode")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.EftbankType)
                    .HasColumnName("EFTBankType")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                //entity.Property(e => e.EftprenoteDate)
                //    .HasColumnName("EFTPrenoteDate")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                //entity.Property(e => e.EftterminationDate)
                //    .HasColumnName("EFTTerminationDate")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.EfttransferMethod)
                    .HasColumnName("EFTTransferMethod")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.EfttransitRoutingNo)
                    .IsRequired()
                    .HasColumnName("EFTTransitRoutingNo")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.EftuseMasterId)
                    .HasColumnName("EFTUseMasterID")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Frgnbank)
                    .HasColumnName("FRGNBANK")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.GiropostType)
                    .HasColumnName("GIROPostType")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Inactive)
                    .HasColumnName("INACTIVE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.IntlBankAcctNum)
                    .IsRequired()
                    .HasColumnType("char(35)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.RegCode1)
                    .IsRequired()
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.RegCode2)
                    .IsRequired()
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Swiftaddr)
                    .IsRequired()
                    .HasColumnName("SWIFTADDR")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Vendorid)
                    .IsRequired()
                    .HasColumnName("VENDORID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");
            });

            modelBuilder.Entity<PMOpenEntity>(entity =>
            {
                entity.HasKey(e => new { e.Doctype, e.Vchrnmbr })
                    .HasName("PKPM20000");

                entity.ToTable("PM20000");

                entity.HasIndex(e => new { e.Docnumbr, e.DexRowId })
                    .HasName("AK7PM20000")
                    .IsUnique();

                entity.HasIndex(e => new { e.Trxsorce, e.DexRowId })
                    .HasName("AK8PM20000")
                    .IsUnique();

                entity.HasIndex(e => new { e.Vchrnmbr, e.DexRowId })
                    .HasName("AK6PM20000")
                    .IsUnique();

                entity.HasIndex(e => new { e.Vendorid, e.Doctype, e.Vchrnmbr })
                    .HasName("AK3PM20000")
                    .IsUnique();

                entity.HasIndex(e => new { e.Vendorid, e.Docdate, e.Vchrnmbr, e.Doctype })
                    .HasName("AK5PM20000")
                    .IsUnique();

                entity.HasIndex(e => new { e.Vendorid, e.Doctype, e.Docnumbr, e.DexRowId })
                    .HasName("AK1PM20000")
                    .IsUnique();

                entity.HasIndex(e => new { e.Vendorid, e.Duedate, e.Vchrnmbr, e.Doctype })
                    .HasName("AK4PM20000")
                    .IsUnique();

                entity.HasIndex(e => new { e.Vendorid, e.Doctype, e.Docnumbr, e.Docdate, e.DexRowId })
                    .HasName("AK9PM20000")
                    .IsUnique();

                entity.Property(e => e.Doctype)
                    .HasColumnName("DOCTYPE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Vchrnmbr)
                    .HasColumnName("VCHRNMBR")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Aplywith)
                    .HasColumnName("APLYWITH")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Bachnumb)
                    .IsRequired()
                    .HasColumnName("BACHNUMB")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.BackoutTradeDisc)
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Bchsourc)
                    .IsRequired()
                    .HasColumnName("BCHSOURC")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Bktfrtam)
                    .HasColumnName("BKTFRTAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Bktmscam)
                    .HasColumnName("BKTMSCAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Bktpuram)
                    .HasColumnName("BKTPURAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Bnkrcamt)
                    .HasColumnName("BNKRCAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Cardname)
                    .IsRequired()
                    .HasColumnName("CARDNAME")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Cbvat)
                    .HasColumnName("CBVAT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Chekbkid)
                    .IsRequired()
                    .HasColumnName("CHEKBKID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Cntrltyp)
                    .HasColumnName("CNTRLTYP")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Corrctn)
                    .HasColumnName("CORRCTN")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Curncyid)
                    .IsRequired()
                    .HasColumnName("CURNCYID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Curtrxam)
                    .HasColumnName("CURTRXAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.DexRowId)
                    .HasColumnName("DEX_ROW_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DexRowTs)
                    .HasColumnName("DEX_ROW_TS")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.Dinvpdof)
                    .HasColumnName("DINVPDOF")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Disamtav)
                    .HasColumnName("DISAMTAV")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Disavtkn)
                    .HasColumnName("DISAVTKN")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Discamnt)
                    .HasColumnName("DISCAMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Discdate)
                    .HasColumnName("DISCDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Distknam)
                    .HasColumnName("DISTKNAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.DocPrinted).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Docamnt)
                    .HasColumnName("DOCAMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Docdate)
                    .HasColumnName("DOCDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Docnumbr)
                    .IsRequired()
                    .HasColumnName("DOCNUMBR")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Dscdlram)
                    .HasColumnName("DSCDLRAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Duedate)
                    .HasColumnName("DUEDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Ectrx)
                    .HasColumnName("ECTRX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Electronic).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Frtamnt)
                    .HasColumnName("FRTAMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Frtschid)
                    .IsRequired()
                    .HasColumnName("FRTSCHID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Gstdsamt)
                    .HasColumnName("GSTDSAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Hold)
                    .HasColumnName("HOLD")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ictrx)
                    .HasColumnName("ICTRX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Mdfusrid)
                    .IsRequired()
                    .HasColumnName("MDFUSRID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Modifdt)
                    .HasColumnName("MODIFDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Mscchamt)
                    .HasColumnName("MSCCHAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Mscschid)
                    .IsRequired()
                    .HasColumnName("MSCSCHID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Noteindx)
                    .HasColumnName("NOTEINDX")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Pchschid)
                    .IsRequired()
                    .HasColumnName("PCHSCHID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Pgramsbj)
                    .HasColumnName("PGRAMSBJ")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ponumber)
                    .IsRequired()
                    .HasColumnName("PONUMBER")
                    .HasColumnType("char(17)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Pordnmbr)
                    .IsRequired()
                    .HasColumnName("PORDNMBR")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Posteddt)
                    .HasColumnName("POSTEDDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Ppsamded)
                    .HasColumnName("PPSAMDED")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ppstaxrt)
                    .HasColumnName("PPSTAXRT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Prchamnt)
                    .HasColumnName("PRCHAMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Prchdate)
                    .HasColumnName("PRCHDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Prctdisc)
                    .HasColumnName("PRCTDISC")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Pstgdate)
                    .HasColumnName("PSTGDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Ptdusrid)
                    .IsRequired()
                    .HasColumnName("PTDUSRID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Pyenttyp)
                    .HasColumnName("PYENTTYP")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Pymtrmid)
                    .IsRequired()
                    .HasColumnName("PYMTRMID")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Retnagam)
                    .HasColumnName("RETNAGAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Shipmthd)
                    .IsRequired()
                    .HasColumnName("SHIPMTHD")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Simplifd)
                    .HasColumnName("SIMPLIFD")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.TaxDate)
                    .HasColumnName("Tax_Date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.TaxInvReqd).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Taxamnt)
                    .HasColumnName("TAXAMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Taxschid)
                    .IsRequired()
                    .HasColumnName("TAXSCHID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Ten99amnt)
                    .HasColumnName("TEN99AMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ten99boxnumber)
                    .HasColumnName("TEN99BOXNUMBER")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ten99type)
                    .HasColumnName("TEN99TYPE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Trdisamt)
                    .HasColumnName("TRDISAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Trxdscrn)
                    .IsRequired()
                    .HasColumnName("TRXDSCRN")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Trxsorce)
                    .IsRequired()
                    .HasColumnName("TRXSORCE")
                    .HasColumnType("char(13)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Ttlpymts)
                    .HasColumnName("TTLPYMTS")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Un1099am)
                    .HasColumnName("UN1099AM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Vadcdtro)
                    .IsRequired()
                    .HasColumnName("VADCDTRO")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Vendorid)
                    .IsRequired()
                    .HasColumnName("VENDORID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Vndchknm)
                    .IsRequired()
                    .HasColumnName("VNDCHKNM")
                    .HasColumnType("char(65)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Voided)
                    .HasColumnName("VOIDED")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.WorkflowStatus)
                    .HasColumnName("Workflow_Status")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Wrofamnt)
                    .HasColumnName("WROFAMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");
            });

            modelBuilder.Entity<PMHistoryEntity>(entity =>
            {
                entity.HasKey(e => new { e.Doctype, e.Vchrnmbr })
                    .HasName("PKPM30200");

                entity.ToTable("PM30200");

                entity.HasIndex(e => new { e.Docdate, e.DexRowId })
                    .HasName("AK4PM30200")
                    .IsUnique();

                entity.HasIndex(e => new { e.Docnumbr, e.DexRowId })
                    .HasName("AK3PM30200")
                    .IsUnique();

                entity.HasIndex(e => new { e.Vchrnmbr, e.DexRowId })
                    .HasName("AK6PM30200")
                    .IsUnique();

                entity.HasIndex(e => new { e.Vendorid, e.DexRowId })
                    .HasName("AK1PM30200")
                    .IsUnique();

                entity.HasIndex(e => new { e.Doctype, e.Docnumbr, e.DexRowId })
                    .HasName("AK7PM30200")
                    .IsUnique();

                entity.HasIndex(e => new { e.Trxsorce, e.Vchrnmbr, e.DexRowId })
                    .HasName("AK5PM30200")
                    .IsUnique();

                entity.HasIndex(e => new { e.Vendorid, e.Docdate, e.DexRowId })
                    .HasName("AK8PM30200")
                    .IsUnique();

                entity.HasIndex(e => new { e.Doctype, e.Voided, e.Docdate, e.Prchamnt, e.DexRowId })
                    .HasName("AK9PM30200")
                    .IsUnique();

                entity.HasIndex(e => new { e.Vendorid, e.Doctype, e.Docnumbr, e.Docdate, e.DexRowId })
                    .HasName("AK10PM30200")
                    .IsUnique();

                entity.Property(e => e.Doctype)
                    .HasColumnName("DOCTYPE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Vchrnmbr)
                    .HasColumnName("VCHRNMBR")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Aplywith)
                    .HasColumnName("APLYWITH")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Bachnumb)
                    .IsRequired()
                    .HasColumnName("BACHNUMB")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.BackoutTradeDisc)
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Bchsourc)
                    .IsRequired()
                    .HasColumnName("BCHSOURC")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Bktfrtam)
                    .HasColumnName("BKTFRTAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Bktmscam)
                    .HasColumnName("BKTMSCAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Bktpuram)
                    .HasColumnName("BKTPURAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Cardname)
                    .IsRequired()
                    .HasColumnName("CARDNAME")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Cbvat)
                    .HasColumnName("CBVAT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Chekbkid)
                    .IsRequired()
                    .HasColumnName("CHEKBKID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Cntrltyp)
                    .HasColumnName("CNTRLTYP")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Corrctn)
                    .HasColumnName("CORRCTN")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Curncyid)
                    .IsRequired()
                    .HasColumnName("CURNCYID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Curtrxam)
                    .HasColumnName("CURTRXAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.DexRowId)
                    .HasColumnName("DEX_ROW_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DexRowTs)
                    .HasColumnName("DEX_ROW_TS")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.Dinvpdof)
                    .HasColumnName("DINVPDOF")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Disamtav)
                    .HasColumnName("DISAMTAV")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Disavtkn)
                    .HasColumnName("DISAVTKN")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Discamnt)
                    .HasColumnName("DISCAMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Discdate)
                    .HasColumnName("DISCDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Distknam)
                    .HasColumnName("DISTKNAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.DocPrinted).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Docamnt)
                    .HasColumnName("DOCAMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Docdate)
                    .HasColumnName("DOCDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Docnumbr)
                    .IsRequired()
                    .HasColumnName("DOCNUMBR")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Dscdlram)
                    .HasColumnName("DSCDLRAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Duedate)
                    .HasColumnName("DUEDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Ectrx)
                    .HasColumnName("ECTRX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Electronic).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Frtamnt)
                    .HasColumnName("FRTAMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Frtschid)
                    .IsRequired()
                    .HasColumnName("FRTSCHID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Gstdsamt)
                    .HasColumnName("GSTDSAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Hold)
                    .HasColumnName("HOLD")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ictrx)
                    .HasColumnName("ICTRX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Mdfusrid)
                    .IsRequired()
                    .HasColumnName("MDFUSRID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Modifdt)
                    .HasColumnName("MODIFDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Mscchamt)
                    .HasColumnName("MSCCHAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Mscschid)
                    .IsRequired()
                    .HasColumnName("MSCSCHID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Noteindx)
                    .HasColumnName("NOTEINDX")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Pchschid)
                    .IsRequired()
                    .HasColumnName("PCHSCHID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Pgramsbj)
                    .HasColumnName("PGRAMSBJ")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ponumber)
                    .IsRequired()
                    .HasColumnName("PONUMBER")
                    .HasColumnType("char(17)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Pordnmbr)
                    .IsRequired()
                    .HasColumnName("PORDNMBR")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Posteddt)
                    .HasColumnName("POSTEDDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Ppsamded)
                    .HasColumnName("PPSAMDED")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ppstaxrt)
                    .HasColumnName("PPSTAXRT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Prchamnt)
                    .HasColumnName("PRCHAMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Prchdate)
                    .HasColumnName("PRCHDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Prctdisc)
                    .HasColumnName("PRCTDISC")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Pstgdate)
                    .HasColumnName("PSTGDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Ptdusrid)
                    .IsRequired()
                    .HasColumnName("PTDUSRID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Pyenttyp)
                    .HasColumnName("PYENTTYP")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Pymtrmid)
                    .IsRequired()
                    .HasColumnName("PYMTRMID")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Retnagam)
                    .HasColumnName("RETNAGAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Shipmthd)
                    .IsRequired()
                    .HasColumnName("SHIPMTHD")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Simplifd)
                    .HasColumnName("SIMPLIFD")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.TaxDate)
                    .HasColumnName("Tax_Date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.TaxInvReqd).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Taxamnt)
                    .HasColumnName("TAXAMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Taxschid)
                    .IsRequired()
                    .HasColumnName("TAXSCHID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Ten99amnt)
                    .HasColumnName("TEN99AMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ten99boxnumber)
                    .HasColumnName("TEN99BOXNUMBER")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ten99type)
                    .HasColumnName("TEN99TYPE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Trdisamt)
                    .HasColumnName("TRDISAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Trxdscrn)
                    .IsRequired()
                    .HasColumnName("TRXDSCRN")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Trxsorce)
                    .IsRequired()
                    .HasColumnName("TRXSORCE")
                    .HasColumnType("char(13)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Ttlpymts)
                    .HasColumnName("TTLPYMTS")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Un1099am)
                    .HasColumnName("UN1099AM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Vadcdtro)
                    .IsRequired()
                    .HasColumnName("VADCDTRO")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Vendorid)
                    .IsRequired()
                    .HasColumnName("VENDORID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Vndchknm)
                    .IsRequired()
                    .HasColumnName("VNDCHKNM")
                    .HasColumnType("char(65)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Voided)
                    .HasColumnName("VOIDED")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Voidpdate)
                    .HasColumnName("VOIDPDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.WorkflowStatus)
                    .HasColumnName("Workflow_Status")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Wrofamnt)
                    .HasColumnName("WROFAMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");
            });

            modelBuilder.Entity<PMApplyEntity>(entity =>
            {
                entity.HasKey(e => new { e.Aptvchnm, e.Aptodcty, e.Vchrnmbr, e.Doctype })
                    .HasName("PKPM30300");

                entity.ToTable("PM30300");

                entity.HasIndex(e => new { e.Vchrnmbr, e.Doctype, e.Aptvchnm, e.Aptodcty })
                    .HasName("AK2PM30300")
                    .IsUnique();

                entity.Property(e => e.Aptvchnm)
                    .HasColumnName("APTVCHNM")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Aptodcty)
                    .HasColumnName("APTODCTY")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Vchrnmbr)
                    .HasColumnName("VCHRNMBR")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Doctype)
                    .HasColumnName("DOCTYPE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.ActualApplyToAmount)
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.ActualDiscAvailTaken)
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.ActualDiscTakenAmount)
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.ActualWriteOffAmount)
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Apfrdcnm)
                    .IsRequired()
                    .HasColumnName("APFRDCNM")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Apfrmaplyamt)
                    .HasColumnName("APFRMAPLYAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Apfrmdenrate)
                    .HasColumnName("APFRMDENRATE")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Apfrmdiscavail)
                    .HasColumnName("APFRMDISCAVAIL")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Apfrmdisctaken)
                    .HasColumnName("APFRMDISCTAKEN")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Apfrmexrate)
                    .HasColumnName("APFRMEXRATE")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Apfrmmctrxstt)
                    .HasColumnName("APFRMMCTRXSTT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Apfrmrtclcmeth)
                    .HasColumnName("APFRMRTCLCMETH")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Apfrmwrofamt)
                    .HasColumnName("APFRMWROFAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Appldamt)
                    .HasColumnName("APPLDAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.ApplyFromGlpostDate)
                    .HasColumnName("ApplyFromGLPostDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.ApplyToGlpostDate)
                    .HasColumnName("ApplyToGLPostDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Aptodcdt)
                    .HasColumnName("APTODCDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Aptodcnm)
                    .IsRequired()
                    .HasColumnName("APTODCNM")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Aptodenrate)
                    .HasColumnName("APTODENRATE")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Aptoexrate)
                    .HasColumnName("APTOEXRATE")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Aptomctrxstt)
                    .HasColumnName("APTOMCTRXSTT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Aptortclcmeth)
                    .HasColumnName("APTORTCLCMETH")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Apyfrmrndamt)
                    .HasColumnName("APYFRMRNDAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Apytorndamt)
                    .HasColumnName("APYTORNDAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Apytornddisc)
                    .HasColumnName("APYTORNDDISC")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Credit1099Amount)
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Curncyid)
                    .IsRequired()
                    .HasColumnName("CURNCYID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Currnidx)
                    .HasColumnName("CURRNIDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Date1)
                    .HasColumnName("DATE1")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Deften99boxnumber)
                    .HasColumnName("DEFTEN99BOXNUMBER")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Deften99type)
                    .HasColumnName("DEFTEN99TYPE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.DexRowId)
                    .HasColumnName("DEX_ROW_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Disavtkn)
                    .HasColumnName("DISAVTKN")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Distknam)
                    .HasColumnName("DISTKNAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Docdate)
                    .HasColumnName("DOCDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Fromcurr)
                    .IsRequired()
                    .HasColumnName("FROMCURR")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Glpostdt)
                    .HasColumnName("GLPOSTDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Gstdsamt)
                    .HasColumnName("GSTDSAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Oapyfrmrndamt)
                    .HasColumnName("OAPYFRMRNDAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Oapytorndamt)
                    .HasColumnName("OAPYTORNDAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Oapytornddisc)
                    .HasColumnName("OAPYTORNDDISC")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Orappamt)
                    .HasColumnName("ORAPPAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ordatkn)
                    .HasColumnName("ORDATKN")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ordistkn)
                    .HasColumnName("ORDISTKN")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Orwrofam)
                    .HasColumnName("ORWROFAM")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Posted)
                    .HasColumnName("POSTED")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ppsamded)
                    .HasColumnName("PPSAMDED")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.RevaluationStatus)
                    .HasColumnName("Revaluation_Status")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Rlganlos)
                    .HasColumnName("RLGANLOS")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.SettledGainCreditCurrT)
                    .HasColumnName("Settled_Gain_CreditCurrT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.SettledGainDebitCurrTr)
                    .HasColumnName("Settled_Gain_DebitCurrTr")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.SettledGainDebitDiscAv)
                    .HasColumnName("Settled_Gain_DebitDiscAv")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.SettledLossCreditCurrT)
                    .HasColumnName("Settled_Loss_CreditCurrT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.SettledLossDebitCurrTr)
                    .HasColumnName("Settled_Loss_DebitCurrTr")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.SettledLossDebitDiscAv)
                    .HasColumnName("Settled_Loss_DebitDiscAv")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Taxdtlid)
                    .IsRequired()
                    .HasColumnName("TAXDTLID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Ten99amnt)
                    .HasColumnName("TEN99AMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Time1)
                    .HasColumnName("TIME1")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Vendorid)
                    .IsRequired()
                    .HasColumnName("VENDORID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Wrofamnt)
                    .HasColumnName("WROFAMNT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");
            });

        }
    }
}