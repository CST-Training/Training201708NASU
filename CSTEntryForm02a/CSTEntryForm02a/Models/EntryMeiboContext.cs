using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CSTEntryForm02a.Models
{
   

    public partial class EntryMeiboContext : DbContext
    {
        public virtual DbSet<TEntryMeibo> TEntryMeibo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\v11.0;Database=EntryMeibo;Trusted_Connection=True");
            optionsBuilder.UseSqlServer(@"Server=CST228\SQLEXPRESS;Database=EntryMeibo;User ID=sa;Password=sql#228;Trusted_Connection=False");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TEntryMeibo>(entity =>
            {
                entity.ToTable("tEntryMeibo");

                entity.Property(e => e.EEmail)
                    .IsRequired()
                    .HasColumnName("eEmail")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.EJitakuMoyorieki)
                    .HasColumnName("eJitakuMoyorieki")
                    .HasMaxLength(50);

                entity.Property(e => e.EJitakuRosen)
                    .HasColumnName("eJitakuRosen")
                    .HasMaxLength(50);

                entity.Property(e => e.EJitakuToEki).HasColumnName("eJitakuToEki");

                entity.Property(e => e.EMendan1Ampm)
                    .HasColumnName("eMendan1Ampm")
                    .HasColumnType("char(4)");

                entity.Property(e => e.EMendan1Date)
                    .HasColumnName("eMendan1Date")
                    .HasColumnType("date");

                entity.Property(e => e.EMendan2Ampm)
                    .HasColumnName("eMendan2Ampm")
                    .HasColumnType("char(4)");

                entity.Property(e => e.EMendan2Date)
                    .HasColumnName("eMendan2Date")
                    .HasColumnType("date");

                entity.Property(e => e.EMendan3Ampm)
                    .HasColumnName("eMendan3Ampm")
                    .HasColumnType("char(4)");

                entity.Property(e => e.EMendan3Date)
                    .HasColumnName("eMendan3Date")
                    .HasColumnType("date");

                entity.Property(e => e.ENameNamae)
                    .IsRequired()
                    .HasColumnName("eNameNamae")
                    .HasMaxLength(20);

                entity.Property(e => e.ENameNamaeKana)
                    .IsRequired()
                    .HasColumnName("eNameNamaeKana")
                    .HasMaxLength(20);

                entity.Property(e => e.ENameSei)
                    .IsRequired()
                    .HasColumnName("eNameSei")
                    .HasMaxLength(20);

                entity.Property(e => e.ENameSeiKana)
                    .IsRequired()
                    .HasColumnName("eNameSeiKana")
                    .HasMaxLength(20);

                entity.Property(e => e.ENenrei).HasColumnName("eNenrei");

                entity.Property(e => e.EPhone)
                    .HasColumnName("ePhone")
                    .HasMaxLength(50);

                entity.Property(e => e.EQuestion)
                    .HasColumnName("eQuestion")
                    .HasMaxLength(800);

                entity.Property(e => e.EShigotoKibou)
                    .HasColumnName("eShigotoKibou")
                    .HasMaxLength(800);

                entity.Property(e => e.ETimeStamp)
                    .HasColumnName("eTimeStamp")
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();
            });
        }
    }
}