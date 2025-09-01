using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data
{
    internal class TPIContext:DbContext
    {
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Persona> Personas { get; set; }

        internal TPIContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasKey(e => e.Id_plan);

                entity.Property(e => e.Id_plan)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Desc_plan)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Id_especialidad)
                    .IsRequired();
            });

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.HasKey(e => e.Id_especialidad);

                entity.Property(e => e.Id_especialidad)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Desc_esp)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Id_persona);

                entity.Property(e => e.Id_persona)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Legajo)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Tipo_persona)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Id_plan)
                    .IsRequired();

                entity.Property(e => e.Fecha_nac)
                    .IsRequired();
            });
        }
    }
}
