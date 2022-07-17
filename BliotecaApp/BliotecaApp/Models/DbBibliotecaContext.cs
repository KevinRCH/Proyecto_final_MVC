using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BliotecaApp.Models
{
    public partial class DbBibliotecaContext : DbContext
    {
        public DbBibliotecaContext()
        {
        }

        public DbBibliotecaContext(DbContextOptions<DbBibliotecaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }
        public virtual DbSet<Prestamo> Prestamos { get; set; }
        public virtual DbSet<PrestamoLibro> PrestamoLibros { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.ClienteId).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.ToTable("Libro");

                entity.Property(e => e.Autor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Edicion)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Editorial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.ToTable("Prestamo");

                entity.Property(e => e.FechaDevolucion).HasColumnType("date");

                entity.Property(e => e.FechaSalida).HasColumnType("date");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prestamo_Cliente");
            });

            modelBuilder.Entity<PrestamoLibro>(entity =>
            {
                entity.ToTable("PrestamoLibro");

                entity.HasOne(d => d.Libro)
                    .WithMany(p => p.PrestamoLibros)
                    .HasForeignKey(d => d.LibroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrestamoLibro_Libro");

                entity.HasOne(d => d.Prestamo)
                    .WithMany(p => p.PrestamoLibros)
                    .HasForeignKey(d => d.PrestamoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrestamoLibro_Prestamo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
