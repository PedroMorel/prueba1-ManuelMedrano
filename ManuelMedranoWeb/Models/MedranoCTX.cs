using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ManuelMedranoWeb.Models
{
    public partial class MedranoCTX : DbContext
    {
        public MedranoCTX()
        {
        }

        public MedranoCTX(DbContextOptions<MedranoCTX> options)
            : base(options)
        {
        }

        public virtual DbSet<Caso> Caso { get; set; }
        public virtual DbSet<Casoselect> Casoselect { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;database=ManuelMedranoDB;user id=root;password=2914238", x => x.ServerVersion("8.0.17-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caso>(entity =>
            {
                entity.HasIndex(e => e.IdCasoSelect)
                    .HasName("fk_CasoSelect_id");

                entity.Property(e => e.Apellido)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Contacto)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Nombre)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdCasoSelectNavigation)
                    .WithMany(p => p.Caso)
                    .HasForeignKey(d => d.IdCasoSelect)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CasoSelect_id");
            });

            modelBuilder.Entity<Casoselect>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Contacto)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Direccion)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Email)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Nombre)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
