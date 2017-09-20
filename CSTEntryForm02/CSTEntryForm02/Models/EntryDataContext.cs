using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CSTEntryForm02.Models
{
    public partial class EntryDataContext : DbContext
    {
        public virtual DbSet<TEntryData> TEntryData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"server=(localdb)\v11.0;Database=EntryData;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TEntryData>(entity =>
            {
                entity.ToTable("tEntryData");

                entity.Property(e => e.EDenwa)
                    .HasColumnName("E_DENWA")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.EEmail)
                    .IsRequired()
                    .HasColumnName("E_EMAIL")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.EFirstname)
                    .IsRequired()
                    .HasColumnName("E_FIRSTNAME")
                    .HasMaxLength(20);

                entity.Property(e => e.EFirstnameKana)
                    .IsRequired()
                    .HasColumnName("E_FIRSTNAME_KANA")
                    .HasMaxLength(20);

                entity.Property(e => e.ELastname)
                    .IsRequired()
                    .HasColumnName("E_LASTNAME")
                    .HasMaxLength(20);

                entity.Property(e => e.ELastnameKana)
                    .IsRequired()
                    .HasColumnName("E_LASTNAME_KANA")
                    .HasMaxLength(20);

                entity.Property(e => e.EMendan1Ampm)
                    .HasColumnName("E_MENDAN1_AMPM")
                    .HasColumnType("char(2)");

                entity.Property(e => e.EMendan1Day).HasColumnName("E_MENDAN1_DAY");

                entity.Property(e => e.EMendan1Month).HasColumnName("E_MENDAN1_MONTH");

                entity.Property(e => e.EMendan2Ampm)
                    .HasColumnName("E_MENDAN2_AMPM")
                    .HasColumnType("char(2)");

                entity.Property(e => e.EMendan2Day).HasColumnName("E_MENDAN2_DAY");

                entity.Property(e => e.EMendan2Month).HasColumnName("E_MENDAN2_MONTH");

                entity.Property(e => e.EMendan3Ampm)
                    .HasColumnName("E_MENDAN3_AMPM")
                    .HasColumnType("char(2)");

                entity.Property(e => e.EMendan3Day).HasColumnName("E_MENDAN3_DAY");

                entity.Property(e => e.EMendan3Month).HasColumnName("E_MENDAN3_MONTH");

                entity.Property(e => e.EMoyoriekiEki)
                    .HasColumnName("E_MOYORIEKI_EKI")
                    .HasMaxLength(20);

                entity.Property(e => e.EMoyoriekiKyori).HasColumnName("E_MOYORIEKI_KYORI");

                entity.Property(e => e.EMoyoriekiRosen)
                    .HasColumnName("E_MOYORIEKI_ROSEN")
                    .HasMaxLength(20);

                entity.Property(e => e.ENenrei).HasColumnName("E_NENREI");

                entity.Property(e => e.EQuestion).HasColumnName("E_QUESTION");

                entity.Property(e => e.EShigotoKibou).HasColumnName("E_SHIGOTO_KIBOU");
            });
        }
    }
}