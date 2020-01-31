using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Clientes.models.Models
{
    public partial class Bd_TestContext : DbContext
    {
        public Bd_TestContext()
        {
        }

        public Bd_TestContext(DbContextOptions<Bd_TestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblClientes> TblClientes { get; set; }
        public virtual DbSet<TblProductos> TblProductos { get; set; }
        public virtual DbSet<TblVentas> TblVentas { get; set; }

        public partial class BloggingContext : DbContext
        {
            public BloggingContext(DbContextOptions<BloggingContext> options)
                : base(options)
            { }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblClientes>(entity =>
            {
                entity.HasKey(e => e.IdCli)
                    .HasName("PK__Tbl_Clie__710C9B091C47EF62");

                entity.ToTable("Tbl_Clientes");

                entity.Property(e => e.IdCli)
                    .HasColumnName("id_Cli")
                    .ValueGeneratedNever();

                entity.Property(e => e.Ciudad)
                    .IsRequired()
                    .HasColumnName("ciudad")
                    .HasMaxLength(200);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(200);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(200);

                entity.Property(e => e.NumeroDocumento)
                    .IsRequired()
                    .HasColumnName("numero_Documento")
                    .HasMaxLength(200);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TblProductos>(entity =>
            {
                entity.HasKey(e => e.IdProd)
                    .HasName("PK__Tbl_Prod__2E46E6998A1EF80D");

                entity.ToTable("Tbl_Productos");

                entity.Property(e => e.IdProd)
                    .HasColumnName("id_Prod")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(200);

                entity.Property(e => e.Precio)
                    .IsRequired()
                    .HasColumnName("precio")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TblVentas>(entity =>
            {
                entity.ToTable("Tbl_Ventas");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cantidad)
                    .IsRequired()
                    .HasColumnName("cantidad")
                    .HasMaxLength(200);

                entity.Property(e => e.IdCli).HasColumnName("id_Cli");

                entity.Property(e => e.IdProd).HasColumnName("id_Prod");

                entity.HasOne(d => d.IdCliNavigation)
                    .WithMany(p => p.TblVentas)
                    .HasForeignKey(d => d.IdCli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tbl_Venta__id_Cl__5DCAEF64");

                entity.HasOne(d => d.IdProdNavigation)
                    .WithMany(p => p.TblVentas)
                    .HasForeignKey(d => d.IdProd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tbl_Venta__id_Pr__5EBF139D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
