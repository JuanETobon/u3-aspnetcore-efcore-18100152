using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace u3_aspnetcore_efcore_18100152.Models
{
    public partial class ZapateriaContext : DbContext
    {
        public ZapateriaContext()
        {
        }

        public ZapateriaContext(DbContextOptions<ZapateriaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Modelo> Modelos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=----\\LOCALSQL;Database=Zapateria;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marca>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdModelo).HasColumnName("idModelo");

                entity.Property(e => e.NombreDeMarca)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.Marcas)
                    .HasForeignKey(d => d.IdModelo)
                    .HasConstraintName("FK__Marcas__idModelo__267ABA7A");
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.ToTable("Modelo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ModeloDeZapato)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
