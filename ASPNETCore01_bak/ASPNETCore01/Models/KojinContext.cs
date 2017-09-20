using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASPNETCore01.Models
{
    public partial class KojinContext : DbContext
    {
        public virtual DbSet<TKojin> TKojin { get; set; }
        public virtual DbSet<TSeibetsu> TSeibetsu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\v11.0;Database=Kojin;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TKojin>(entity =>
            {
                entity.ToTable("tKojin");

                entity.Property(e => e.ENamae)
                    .IsRequired()
                    .HasColumnName("eNamae")
                    .HasMaxLength(20);

                entity.Property(e => e.ENenrei).HasColumnName("eNenrei");

                entity.Property(e => e.ESeibetsu).HasColumnName("eSeibetsu");

                entity.HasOne(d => d.ESeibetsuNavigation)
                    .WithMany(p => p.TKojin)
                    .HasForeignKey(d => d.ESeibetsu)
                    .OnDelete(DeleteBehavior.Restrict)
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