using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GP.API.Entities
{
    public partial class GPSysContext : DbContext
    {
		public GPSysContext(DbContextOptions<GPSysContext> options) : base(options)
		{
			//Database.Migrate();
		}

		public virtual DbSet<ActivityEntity> Activity { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //    optionsBuilder.UseSqlServer(@"Server=GP2016;Database=DYNAMICS;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityEntity>(entity =>
            {
                entity.HasKey(e => new { e.Cmpnynam, e.Userid, e.ClientUitype })
                    .HasName("PKACTIVITY");

                entity.ToTable("ACTIVITY");

                entity.HasIndex(e => new { e.Userid, e.Cmpnynam, e.ClientUitype })
                    .HasName("AK2ACTIVITY")
                    .IsUnique();

                entity.HasIndex(e => new { e.Logindat, e.Cmpnynam, e.Userid, e.ClientUitype })
                    .HasName("AK3ACTIVITY")
                    .IsUnique();

                entity.Property(e => e.Cmpnynam)
                    .HasColumnName("CMPNYNAM")
                    .HasColumnType("char(65)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.Userid)
                    .HasColumnName("USERID")
                    .HasColumnType("char(15)")
                    .HasDefaultValueSql(" create default dbo.GPS_CHAR AS ''    ");

                entity.Property(e => e.ClientUitype)
                    .HasColumnName("ClientUIType")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.ClientType).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.DexRowId)
                    .HasColumnName("DEX_ROW_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IsOffline).HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.LanguageId)
                    .HasColumnName("Language_ID")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");

                entity.Property(e => e.Logindat)
                    .HasColumnName("LOGINDAT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Logintim)
                    .HasColumnName("LOGINTIM")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql(" create default dbo.GPS_DATE AS '1/1/1900'    ");

                entity.Property(e => e.Sqlsesid)
                    .HasColumnName("SQLSESID")
                    .HasDefaultValueSql(" create default dbo.GPS_INT AS 0    ");
            });
        }
    }
}