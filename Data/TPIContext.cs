using System;
using System.IO;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class TPIContext : DbContext
    {
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<AlumnoInscripcion> AlumnosInscripciones { get; set; }
        public DbSet<DocenteCurso> DocentesCursos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Comision> Comisiones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public TPIContext()
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

            // -----------------------------
            // ESPECIALIDAD
            // -----------------------------
            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.HasKey(e => e.Id_especialidad);
                entity.Property(e => e.Id_especialidad).ValueGeneratedOnAdd();
                entity.Property(e => e.Desc_esp).IsRequired().HasMaxLength(100);

                entity.HasData(
                    new { Id_especialidad = 1, Desc_esp = "Sistemas" },
                    new { Id_especialidad = 2, Desc_esp = "Electrónica" }
                );
            });

            // -----------------------------
            // PLAN
            // -----------------------------
            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasKey(e => e.Id_plan);
                entity.Property(e => e.Id_plan).ValueGeneratedOnAdd();
                entity.Property(e => e.Desc_plan).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Id_especialidad).IsRequired();

                entity.HasOne<Especialidad>()
                    .WithMany()
                    .HasForeignKey(p => p.Id_especialidad);

                entity.HasData(
                    new { Id_plan = 1, Desc_plan = "Plan 2008", Id_especialidad = 1 },
                    new { Id_plan = 2, Desc_plan = "Plan 2015", Id_especialidad = 2 }
                );
            });

            // -----------------------------
            // MATERIA
            // -----------------------------
            modelBuilder.Entity<Materia>(entity =>
            {
                entity.HasKey(m => m.Id_materia);
                entity.Property(m => m.Id_materia).ValueGeneratedOnAdd();
                entity.Property(m => m.Desc_materia).IsRequired().HasMaxLength(100);
                entity.Property(m => m.Hs_semanales).IsRequired();
                entity.Property(m => m.Hs_totales).IsRequired();
                entity.Property(m => m.Id_plan).IsRequired();

                entity.HasOne<Plan>()
                    .WithMany()
                    .HasForeignKey(m => m.Id_plan)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasData(
                    new { Id_materia = 1, Desc_materia = "Programación I", Hs_semanales = 6, Hs_totales = 90, Id_plan = 1 },
                    new { Id_materia = 2, Desc_materia = "Bases de Datos", Hs_semanales = 4, Hs_totales = 64, Id_plan = 1 },
                    new { Id_materia = 3, Desc_materia = "Electrónica Básica", Hs_semanales = 5, Hs_totales = 80, Id_plan = 2 }
                );
            });

            // -----------------------------
            // COMISION
            // -----------------------------
            modelBuilder.Entity<Comision>(entity =>
            {
                entity.HasKey(c => c.Id_comision);
                entity.Property(c => c.Id_comision).ValueGeneratedOnAdd();
                entity.Property(c => c.Desc_comision).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Anio_especialidad).IsRequired();
                entity.Property(c => c.Id_plan).IsRequired();

                entity.HasOne<Plan>()
                    .WithMany()
                    .HasForeignKey(c => c.Id_plan)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasData(
                    new { Id_comision = 1, Desc_comision = "Comisión A", Anio_especialidad = 1, Id_plan = 1 },
                    new { Id_comision = 2, Desc_comision = "Comisión B", Anio_especialidad = 2, Id_plan = 2 }
                );
            });

          
            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.Id_curso);
                entity.Property(e => e.Id_curso).ValueGeneratedOnAdd();
                entity.Property(e => e.Anio_calendario).IsRequired();
                entity.Property(e => e.Cupo).IsRequired();
                entity.Property(e => e.Id_materia).IsRequired();
                entity.Property(e => e.Id_comision).IsRequired();

                entity.HasData(
                    new { Id_curso = 1, Anio_calendario = 2025, Cupo = 30, Id_materia = 1, Id_comision = 1 },
                    new { Id_curso = 2, Anio_calendario = 2025, Cupo = 25, Id_materia = 2, Id_comision = 1 },
                    new { Id_curso = 3, Anio_calendario = 2025, Cupo = 20, Id_materia = 3, Id_comision = 2 }
                );
            });

            
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Id_persona);
                entity.Property(e => e.Id_persona).ValueGeneratedOnAdd();

                entity.HasData(
                    new
                    {
                        Id_persona = 1,
                        Nombre = "Admin",
                        Apellido = "Sistema",
                        Direccion = "UTN",
                        Email = "admin@utn.edu.ar",
                        Telefono = "12345678",
                        Fecha_nac = DateOnly.FromDateTime(DateTime.Now.AddYears(-30)),
                        Legajo = "ADMIN001",
                        Tipo_persona = "Admin",
                        Id_plan = 1
                    },
                    new
                    {
                        Id_persona = 2,
                        Nombre = "Juan",
                        Apellido = "Pérez",
                        Direccion = "Av. Siempre Viva 123",
                        Email = "juan.perez@utn.edu.ar",
                        Telefono = "987654321",
                        Fecha_nac = DateOnly.FromDateTime(DateTime.Now.AddYears(-22)),
                        Legajo = "A001",
                        Tipo_persona = "Alumno",
                        Id_plan = 1
                    },
                    new
                    {
                        Id_persona = 3,
                        Nombre = "María",
                        Apellido = "López",
                        Direccion = "Calle Falsa 456",
                        Email = "maria.lopez@utn.edu.ar",
                        Telefono = "654987321",
                        Fecha_nac = DateOnly.FromDateTime(DateTime.Now.AddYears(-35)),
                        Legajo = "D001",
                        Tipo_persona = "Docente",
                        Id_plan = 1
                    }
                );
            });

          
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasData(
                    new
                    {
                        Id = 1,
                        Username = "admin",
                        Email = "admin@utn.edu.ar",
                        PasswordHash = "e9zBfoqwzxHKQgWkj3qt82gOACblMENzV3rGFvpz/kk=",//123123
                        Salt = "1oxOIZOEdxvAgTlYnMfnnMVG1BoZj7sHIbjxZW8aZSQ=",
                        FechaCreacion = DateTime.Now,
                        Activo = true,
                        Id_persona = 1
                    },
                    new
                    {
                        Id = 2,
                        Username = "juan",
                        Email = "juan.perez@utn.edu.ar",
                        PasswordHash = "e9zBfoqwzxHKQgWkj3qt82gOACblMENzV3rGFvpz/kk=",//123123
                        Salt = "1oxOIZOEdxvAgTlYnMfnnMVG1BoZj7sHIbjxZW8aZSQ=",
                        FechaCreacion = DateTime.Now,
                        Activo = true,
                        Id_persona = 2
                    },

                    new
                    {
                        Id = 3,
                        Username = "maria",
                        Email = "maria.lopez@utn.edu.ar",
                        PasswordHash = "e9zBfoqwzxHKQgWkj3qt82gOACblMENzV3rGFvpz/kk=",//123123
                        Salt = "1oxOIZOEdxvAgTlYnMfnnMVG1BoZj7sHIbjxZW8aZSQ=",
                        FechaCreacion = DateTime.Now,
                        Activo = true,
                        Id_persona = 3
                    }
                );
            });

         
            modelBuilder.Entity<DocenteCurso>(entity =>
            {
                entity.HasKey(e => e.Id_dictado);
                entity.Property(e => e.Id_dictado).ValueGeneratedOnAdd();

                entity.HasData(
                    new { Id_dictado = 1, Id_docente = 3, Id_curso = 1, Cargo = 1 },
                    new { Id_dictado = 2, Id_docente = 3, Id_curso = 2, Cargo = 1 }
                );
            });

            
            modelBuilder.Entity<AlumnoInscripcion>(entity =>
            {
                entity.HasKey(e => e.Id_inscripcion);
                entity.Property(e => e.Id_inscripcion).ValueGeneratedOnAdd();

                entity.HasData(
                    new { Id_inscripcion = 1, Id_alumno = 2, Id_curso = 1, Condicion = "Activo", Nota = (int?)null },
                    new { Id_inscripcion = 2, Id_alumno = 2, Id_curso = 2, Condicion = "Activo", Nota = (int?)null }
                );
            });
        }
    }
}
