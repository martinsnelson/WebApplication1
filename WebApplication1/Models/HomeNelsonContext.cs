using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class HomeNelsonContext : DbContext
    {
        public HomeNelsonContext()
        {
        }

        public HomeNelsonContext(DbContextOptions<HomeNelsonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Metrica> Metrica { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Regiao> Regiao { get; set; }
        public virtual DbSet<Sensor> Sensor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HomeNelson;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Metrica>(entity =>
            {
                entity.HasKey(e => e.IdMetrica);

                entity.Property(e => e.IdMetrica).ValueGeneratedNever();

                entity.Property(e => e.Processado)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CdSensorNavigation)
                    .WithMany(p => p.Metrica)
                    .HasForeignKey(d => d.CdSensor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SensorMetrica");
            });

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.HasKey(e => e.IdPais);

                entity.Property(e => e.IdPais).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Regiao>(entity =>
            {
                entity.HasKey(e => e.IdRegiao);

                entity.Property(e => e.IdRegiao).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CdPaisNavigation)
                    .WithMany(p => p.Regiao)
                    .HasForeignKey(d => d.CdPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PaisRegiao");
            });

            modelBuilder.Entity<Sensor>(entity =>
            {
                entity.HasKey(e => e.IdSensor);

                entity.Property(e => e.IdSensor).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CdRegiaoNavigation)
                    .WithMany(p => p.Sensor)
                    .HasForeignKey(d => d.CdRegiao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_RegiaoSensor");
            });
        }
    }
}
