using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GP.API.Entities
{
    public partial class GPContextGL : DbContext
    {
        public virtual DbSet<Gl20000> Gl20000 { get; set; }
        public virtual DbSet<Gl30000> Gl30000 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=S4;Database=TWO;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gl20000>(entity =>
            {
                entity.HasKey(e => e.DexRowId)
                    .HasName("PKGL20000");

                entity.ToTable("GL20000");

                entity.HasIndex(e => e.Jrnentry)
                    .HasName("CL8GL20000");

                entity.HasIndex(e => new { e.Jrnentry, e.DexRowId })
                    .HasName("AK8GL20000")
                    .IsUnique();

                entity.HasIndex(e => new { e.BackOutJe, e.Openyear, e.DexRowId })
                    .HasName("AK9GL20000")
                    .IsUnique();

                entity.HasIndex(e => new { e.Actindx, e.Openyear, e.Sourcdoc, e.DexRowId })
                    .HasName("AK2GL20000")
                    .IsUnique();

                entity.HasIndex(e => new { e.Jrnentry, e.Qkofset, e.Actindx, e.DexRowId })
                    .HasName("AK4GL20000")
                    .IsUnique();

                entity.HasIndex(e => new { e.Openyear, e.Trxdate, e.Actindx, e.DexRowId })
                    .HasName("AK3GL20000")
                    .IsUnique();

                entity.HasIndex(e => new { e.Jrnentry, e.Openyear, e.Trxdate, e.Rctrxseq, e.DexRowId })
                    .HasName("AK10GL20000")
                    .IsUnique();

                entity.HasIndex(e => new { e.Openyear, e.Actindx, e.Curncyid, e.Trxdate, e.DexRowId })
                    .HasName("AK6GL20000")
                    .IsUnique();

                entity.HasIndex(e => new { e.Openyear, e.Actindx, e.Trxdate, e.Periodid, e.DexRowId })
                    .HasName("AK5GL20000")
                    .IsUnique();

                entity.HasIndex(e => new { e.Jrnentry, e.Rctrxseq, e.Actindx, e.Trxdate, e.Periodid, e.DexRowId })
                    .HasName("AK1GL20000")
                    .IsUnique();

                entity.HasIndex(e => new { e.Actindx, e.Trxdate, e.Openyear, e.LedgerId, e.Debitamt, e.Crdtamnt, e.DexRowId })
                    .HasName("AK7GL20000")
                    .IsUnique();

                entity.Property(e => e.DexRowId).HasColumnName("DEX_ROW_ID");

                entity.Property(e => e.Actindx)
                    .HasColumnName("ACTINDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.AdjustmentTransaction)
                    .HasColumnName("Adjustment_Transaction")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Apprvldt)
                    .HasColumnName("APPRVLDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Aprvluserid)
                    .IsRequired()
                    .HasColumnName("APRVLUSERID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.BackOutJe)
                    .HasColumnName("Back_Out_JE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.BackOutJeYear)
                    .HasColumnName("Back_Out_JE_Year")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.CorrectingJe)
                    .HasColumnName("Correcting_JE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.CorrectingJeYear)
                    .HasColumnName("Correcting_JE_Year")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.CorrespondingUnit)
                    .IsRequired()
                    .HasColumnType("char(5)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Crdtamnt)
                    .HasColumnName("CRDTAMNT")
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

                entity.Property(e => e.Debitamt)
                    .HasColumnName("DEBITAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Denxrate)
                    .HasColumnName("DENXRATE")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.DexRowTs)
                    .HasColumnName("DEX_ROW_TS")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.Docdate)
                    .HasColumnName("DOCDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Dscriptn)
                    .IsRequired()
                    .HasColumnName("DSCRIPTN")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.DtaGlStatus)
                    .HasColumnName("DTA_GL_Status")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.DtaIndex)
                    .HasColumnName("DTA_Index")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Exchdate)
                    .HasColumnName("EXCHDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Exgtblid)
                    .IsRequired()
                    .HasColumnName("EXGTBLID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Ictrx)
                    .HasColumnName("ICTRX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Jrnentry)
                    .HasColumnName("JRNENTRY")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Lastuser)
                    .IsRequired()
                    .HasColumnName("LASTUSER")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.LedgerId)
                    .HasColumnName("Ledger_ID")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Lstdtedt)
                    .HasColumnName("LSTDTEDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Mctrxstt)
                    .HasColumnName("MCTRXSTT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Noteindx)
                    .HasColumnName("NOTEINDX")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Openyear)
                    .HasColumnName("OPENYEAR")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Orcomid)
                    .IsRequired()
                    .HasColumnName("ORCOMID")
                    .HasColumnType("char(5)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Orcrdamt)
                    .HasColumnName("ORCRDAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Orctrnum)
                    .IsRequired()
                    .HasColumnName("ORCTRNUM")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Ordbtamt)
                    .HasColumnName("ORDBTAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ordocnum)
                    .IsRequired()
                    .HasColumnName("ORDOCNUM")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Orgnatyp)
                    .HasColumnName("ORGNATYP")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Orgntsrc)
                    .IsRequired()
                    .HasColumnName("ORGNTSRC")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.OrigDtaseries)
                    .HasColumnName("OrigDTASeries")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.OrigSeqNum).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.OriginalJe)
                    .HasColumnName("Original_JE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.OriginalJeSeqNum)
                    .HasColumnName("Original_JE_Seq_Num")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.OriginalJeYear)
                    .HasColumnName("Original_JE_Year")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Originje)
                    .HasColumnName("ORIGINJE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ormstrid)
                    .IsRequired()
                    .HasColumnName("ORMSTRID")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Ormstrnm)
                    .IsRequired()
                    .HasColumnName("ORMSTRNM")
                    .HasColumnType("char(65)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Orpstddt)
                    .HasColumnName("ORPSTDDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Ortrxsrc)
                    .IsRequired()
                    .HasColumnName("ORTRXSRC")
                    .HasColumnType("char(13)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Ortrxtyp)
                    .HasColumnName("ORTRXTYP")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Periodid)
                    .HasColumnName("PERIODID")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Polldtrx)
                    .HasColumnName("POLLDTRX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ppsgnmbr)
                    .HasColumnName("PPSGNMBR")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Pstgnmbr)
                    .HasColumnName("PSTGNMBR")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Qkofset)
                    .HasColumnName("QKOFSET")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ratetpid)
                    .IsRequired()
                    .HasColumnName("RATETPID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Rctrxseq)
                    .HasColumnName("RCTRXSEQ")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Refrence)
                    .IsRequired()
                    .HasColumnName("REFRENCE")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Rtclcmtd)
                    .HasColumnName("RTCLCMTD")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Seqnumbr)
                    .HasColumnName("SEQNUMBR")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Series)
                    .HasColumnName("SERIES")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Sourcdoc)
                    .IsRequired()
                    .HasColumnName("SOURCDOC")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Time1)
                    .HasColumnName("TIME1")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Trxdate)
                    .HasColumnName("TRXDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Trxsorce)
                    .IsRequired()
                    .HasColumnName("TRXSORCE")
                    .HasColumnType("char(13)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Uswhpstd)
                    .IsRequired()
                    .HasColumnName("USWHPSTD")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Voided)
                    .HasColumnName("VOIDED")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Xchgrate)
                    .HasColumnName("XCHGRATE")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");
            });

            modelBuilder.Entity<Gl30000>(entity =>
            {
                entity.HasKey(e => e.DexRowId)
                    .HasName("PKGL30000");

                entity.ToTable("GL30000");

                entity.HasIndex(e => new { e.Curncyid, e.DexRowId })
                    .HasName("AK7GL30000")
                    .IsUnique();

                entity.HasIndex(e => new { e.Actindx, e.Hstyear, e.DexRowId })
                    .HasName("AK3GL30000")
                    .IsUnique();

                entity.HasIndex(e => new { e.BackOutJe, e.Hstyear, e.DexRowId })
                    .HasName("AK9GL30000")
                    .IsUnique();

                entity.HasIndex(e => new { e.Hstyear, e.Trxdate, e.Actindx, e.DexRowId })
                    .HasName("AK2GL30000")
                    .IsUnique();

                entity.HasIndex(e => new { e.Jrnentry, e.Qkofset, e.Actindx, e.DexRowId })
                    .HasName("AK4GL30000")
                    .IsUnique();

                entity.HasIndex(e => new { e.Hstyear, e.Actindx, e.Curncyid, e.Trxdate, e.DexRowId })
                    .HasName("AK6GL30000")
                    .IsUnique();

                entity.HasIndex(e => new { e.Hstyear, e.Actindx, e.Trxdate, e.Periodid, e.DexRowId })
                    .HasName("AK5GL30000")
                    .IsUnique();

                entity.HasIndex(e => new { e.Hstyear, e.Jrnentry, e.Rctrxseq, e.Periodid, e.DexRowId })
                    .HasName("AK1GL30000")
                    .IsUnique();

                entity.HasIndex(e => new { e.Jrnentry, e.Hstyear, e.Trxdate, e.Rctrxseq, e.DexRowId })
                    .HasName("AK10GL30000")
                    .IsUnique();

                entity.HasIndex(e => new { e.Actindx, e.Trxdate, e.Hstyear, e.LedgerId, e.Debitamt, e.Crdtamnt, e.DexRowId })
                    .HasName("AK8GL30000")
                    .IsUnique();

                entity.Property(e => e.DexRowId).HasColumnName("DEX_ROW_ID");

                entity.Property(e => e.Actindx)
                    .HasColumnName("ACTINDX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.AdjustmentTransaction)
                    .HasColumnName("Adjustment_Transaction")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Apprvldt)
                    .HasColumnName("APPRVLDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Aprvluserid)
                    .IsRequired()
                    .HasColumnName("APRVLUSERID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.BackOutJe)
                    .HasColumnName("Back_Out_JE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.BackOutJeYear)
                    .HasColumnName("Back_Out_JE_Year")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.CorrectingJe)
                    .HasColumnName("Correcting_JE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.CorrectingJeYear)
                    .HasColumnName("Correcting_JE_Year")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.CorrespondingUnit)
                    .IsRequired()
                    .HasColumnType("char(5)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Crdtamnt)
                    .HasColumnName("CRDTAMNT")
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

                entity.Property(e => e.Debitamt)
                    .HasColumnName("DEBITAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Denxrate)
                    .HasColumnName("DENXRATE")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.DexRowTs)
                    .HasColumnName("DEX_ROW_TS")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.Docdate)
                    .HasColumnName("DOCDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Dscriptn)
                    .IsRequired()
                    .HasColumnName("DSCRIPTN")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.DtaGlStatus)
                    .HasColumnName("DTA_GL_Status")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.DtaIndex)
                    .HasColumnName("DTA_Index")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Exchdate)
                    .HasColumnName("EXCHDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Exgtblid)
                    .IsRequired()
                    .HasColumnName("EXGTBLID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Hstyear)
                    .HasColumnName("HSTYEAR")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ictrx)
                    .HasColumnName("ICTRX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Jrnentry)
                    .HasColumnName("JRNENTRY")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Lastuser)
                    .IsRequired()
                    .HasColumnName("LASTUSER")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.LedgerId)
                    .HasColumnName("Ledger_ID")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Lstdtedt)
                    .HasColumnName("LSTDTEDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Mctrxstt)
                    .HasColumnName("MCTRXSTT")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Noteindx)
                    .HasColumnName("NOTEINDX")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Orcomid)
                    .IsRequired()
                    .HasColumnName("ORCOMID")
                    .HasColumnType("char(5)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Orcrdamt)
                    .HasColumnName("ORCRDAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Orctrnum)
                    .IsRequired()
                    .HasColumnName("ORCTRNUM")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Ordbtamt)
                    .HasColumnName("ORDBTAMT")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Ordocnum)
                    .IsRequired()
                    .HasColumnName("ORDOCNUM")
                    .HasColumnType("char(21)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Orgnatyp)
                    .HasColumnName("ORGNATYP")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Orgntsrc)
                    .IsRequired()
                    .HasColumnName("ORGNTSRC")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.OrigDtaseries)
                    .HasColumnName("OrigDTASeries")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.OrigSeqNum).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.OriginalJe)
                    .HasColumnName("Original_JE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.OriginalJeSeqNum)
                    .HasColumnName("Original_JE_Seq_Num")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.OriginalJeYear)
                    .HasColumnName("Original_JE_Year")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Originje)
                    .HasColumnName("ORIGINJE")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ormstrid)
                    .IsRequired()
                    .HasColumnName("ORMSTRID")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Ormstrnm)
                    .IsRequired()
                    .HasColumnName("ORMSTRNM")
                    .HasColumnType("char(65)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Orpstddt)
                    .HasColumnName("ORPSTDDT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Ortrxsrc)
                    .IsRequired()
                    .HasColumnName("ORTRXSRC")
                    .HasColumnType("char(13)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Ortrxtyp)
                    .HasColumnName("ORTRXTYP")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Periodid)
                    .HasColumnName("PERIODID")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Polldtrx)
                    .HasColumnName("POLLDTRX")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ppsgnmbr)
                    .HasColumnName("PPSGNMBR")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Pstgnmbr)
                    .HasColumnName("PSTGNMBR")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Qkofset)
                    .HasColumnName("QKOFSET")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Ratetpid)
                    .IsRequired()
                    .HasColumnName("RATETPID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Rctrxseq)
                    .HasColumnName("RCTRXSEQ")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");

                entity.Property(e => e.Refrence)
                    .IsRequired()
                    .HasColumnName("REFRENCE")
                    .HasColumnType("char(31)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Rtclcmtd)
                    .HasColumnName("RTCLCMTD")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Seqnumbr)
                    .HasColumnName("SEQNUMBR")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Series)
                    .HasColumnName("SERIES")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Sourcdoc)
                    .IsRequired()
                    .HasColumnName("SOURCDOC")
                    .HasColumnType("char(11)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Time1)
                    .HasColumnName("TIME1")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Trxdate)
                    .HasColumnName("TRXDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Trxsorce)
                    .IsRequired()
                    .HasColumnName("TRXSORCE")
                    .HasColumnType("char(13)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Uswhpstd)
                    .IsRequired()
                    .HasColumnName("USWHPSTD")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Voided)
                    .HasColumnName("VOIDED")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Xchgrate)
                    .HasColumnName("XCHGRATE")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql(" create default dbo.GPS_MONEY AS 0.00    ");
            });
        }
    }
}