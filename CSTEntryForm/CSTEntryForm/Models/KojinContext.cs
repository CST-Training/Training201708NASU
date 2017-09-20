using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CSTEntryForm.Models
{
    public partial class KojinContext : DbContext
    {
        public virtual DbSet<TKojin> TKojin { get; set; }
        public virtual DbSet<TSeibetsu> TSeibetsu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"server=(localdb)\v11.0;Database=Kojin;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TKojin>(entity =>
            {
                entity.ToTable("tKojin");

                entity.Property(e => e.EDenwa4num).HasColumnName("eDenwa_4Num");

                entity.Property(e => e.EDenwaArea).HasColumnName("eDenwa_Area");

                entity.Property(e => e.EDenwaLocal).HasColumnName("eDenwa_Local");

                entity.Property(e => e.EEmail)
                    .IsRequired()
                    .HasColumnName("eEmail")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.EMendan1Ampm)
                    .HasColumnName("eMendan1_Ampm")
                    .HasColumnType("char(2)");

                entity.Property(e => e.EMendan1Day).HasColumnName("eMendan1_Day");

                entity.Property(e => e.EMendan1Month).HasColumnName("eMendan1_Month");

                entity.Property(e => e.EMendan2Ampm)
                    .HasColumnName("eMendan2_Ampm")
                    .HasColumnType("char(2)");

                entity.Property(e => e.EMendan2Day).HasColumnName("eMendan2_Day");

                entity.Property(e => e.EMendan2Month).HasColumnName("eMendan2_Month");

                entity.Property(e => e.EMendan3Ampm)
                    .HasColumnName("eMendan3_Ampm")
                    .HasColumnType("char(2)");

                entity.Property(e => e.EMendan3Day).HasColumnName("eMendan3_Day");

                entity.Property(e => e.EMendan3Month).HasColumnName("eMendan3_Month");

                entity.Property(e => e.ENamae)
                    .IsRequired()
                    .HasColumnName("eNamae")
                    .HasMaxLength(20);

                entity.Property(e => e.ENamaeNamae)
                    .IsRequired()
                    .HasColumnName("eNamae_Namae")
                    .HasMaxLength(20);

                entity.Property(e => e.ENamaeNamaeKana)
                    .IsRequired()
                    .HasColumnName("eNamae_Namae_Kana")
                    .HasMaxLength(20);

                entity.Property(e => e.ENamaeSeiKana)
                    .IsRequired()
                    .HasColumnName("eNamae_Sei_Kana")
                    .HasMaxLength(20);

                entity.Property(e => e.ENenrei).HasColumnName("eNenrei");

                entity.Property(e => e.EQuestion).HasColumnName("eQuestion");

                entity.Property(e => e.ESeibetsu).HasColumnName("eSeibetsu");

                entity.Property(e => e.EShigotoKibou).HasColumnName("eShigotoKibou");

                entity.HasOne(d => d.ESeibetsuNavigation)
                    .WithMany(p => p.TKojin)
                    .HasForeignKey(d => d.ESeibetsu)
                    .HasConstraintName("FK_tKojin_eSeibetsu");
            });

            modelBuilder.Entity<TSeibetsu>(entity =>
            {
                entity.ToTable("tSeibetsu");

                entity.Property(e => e.ESeibetsu)
                    .IsRequired()
                    .HasColumnName("eSeibetsu")
                    .HasColumnType("nchar(2)");
            });
        }
    }
}