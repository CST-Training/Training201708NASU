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
            optionsBuilder.UseSqlServer(@"Server=(localdb)\v11.0;Database=EntryMeibo;Trusted_Connection=True");
            //optionsBuilder.UseSqlServer(@"Server=CST228\SQLEXPRESS;Database=EntryMeibo;User ID=sa;Password=sql#228;Trusted_Connection=False");
            //optionsBuilder.UseSqlServer(@"Server=PayCSTSrv2016A\SQLEXPRESS;Database=EntryMeibo;User ID=sa;Password=sql#CST;Trusted_Connection=False");

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

                entity.Property(e => e.EJitakuToEki_Koutsu)
                    .HasColumnName("eJitakuToEki_Koutsu")
                    .HasMaxLength(20);

                entity.Property(e => e.EJitakuToEki_Jikan)
                   .HasColumnName("eJitakuToEki_Jikan")
                   .HasMaxLength(20);

                entity.Property(e => e.EMendan1Ampm)
                    .HasColumnName("eMendan1Ampm")
                    .HasColumnType("char(4)");

                entity.Property(e => e.EMendan1Tsuki)
                    .HasColumnName("eMendan1Tsuki")
                    .HasMaxLength(10);

                entity.Property(e => e.EMendan1Hi)
                   .HasColumnName("eMendan1Hi")
                   .HasMaxLength(10);

                entity.Property(e => e.EMendan1Youbi)
                  .HasColumnName("eMendan1Youbi")
                  .HasMaxLength(10);

                entity.Property(e => e.EMendan2Ampm)
                    .HasColumnName("eMendan2Ampm")
                    .HasColumnType("char(4)");

                entity.Property(e => e.EMendan2Tsuki)
                   .HasColumnName("eMendan2Tsuki")
                   .HasMaxLength(10);

                entity.Property(e => e.EMendan2Hi)
                   .HasColumnName("eMendan2Hi")
                   .HasMaxLength(10);

                entity.Property(e => e.EMendan2Youbi)
                  .HasColumnName("eMendan2Youbi")
                  .HasMaxLength(10);

                entity.Property(e => e.EMendan3Ampm)
                    .HasColumnName("eMendan3Ampm")
                    .HasColumnType("char(4)");

                entity.Property(e => e.EMendan3Tsuki)
                   .HasColumnName("eMendan3Tsuki")
                   .HasMaxLength(10);

                entity.Property(e => e.EMendan3Hi)
                   .HasColumnName("eMendan3Hi")
                   .HasMaxLength(10);

                entity.Property(e => e.EMendan3Youbi)
                  .HasColumnName("eMendan3Youbi")
                  .HasMaxLength(10);

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

                entity.Property(e => e.ENenrei)
                    .HasColumnName("eNenrei")
                    .HasMaxLength(20); 

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
                    .HasColumnType("date");

                //entity.Property(e => e.ETimeStamp)
                //    .HasColumnName("eTimeStamp")
                //    .HasColumnType("timestamp")
                //    .ValueGeneratedOnAddOrUpdate();
            });
        }
    }
}