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

        public TPIContext() {
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

           
            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.HasKey(e => e.Id_especialidad);
                entity.Property(e => e.Id_especialidad).ValueGeneratedOnAdd();
                entity.Property(e => e.Desc_esp).IsRequired().HasMaxLength(100);
                
                // Seed data for Especialidad
                entity.HasData(new
                {
                    Id_especialidad = 1,
                    Desc_esp = "Sistemas"
                });
            });

            
            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasKey(e => e.Id_plan);
                entity.Property(e => e.Id_plan).ValueGeneratedOnAdd();
                entity.Property(e => e.Desc_plan).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Id_especialidad).IsRequired();

                entity.HasOne<Especialidad>()
                    .WithMany()
                    .HasForeignKey(p => p.Id_especialidad)
                    ;
                    
                // Seed data for Plan
                entity.HasData(new
                {
                    Id_plan = 1,
                    Desc_plan = "Plan 2008",
                    Id_especialidad = 1
                });
            });

           
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Id_persona);
                entity.Property(e => e.Id_persona).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Apellido).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Direccion).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Telefono).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Legajo).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Tipo_persona).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Id_plan).IsRequired();
                entity.Property(e => e.Fecha_nac).IsRequired();

                entity.HasIndex(e => e.Email).IsUnique();

                entity.HasOne<Plan>()
                    .WithMany()
                    .HasForeignKey(p => p.Id_plan)
                    .OnDelete(DeleteBehavior.Restrict);
                    
                // Seed data for Persona
                entity.HasData(new
                {
                    Id_persona = 1,
                    Nombre = "Admin",
                    Apellido = "Sistema",
                    Direccion = "Universidad Tecnológica Nacional",
                    Email = "admin@utn.edu.ar",
                    Telefono = "12345678",
                    Fecha_nac = DateOnly.FromDateTime(DateTime.Now),
                    Legajo = "ADMIN001",
                    Tipo_persona = "Administrador",
                    Id_plan = 1
                });
            });

            
            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.Id_curso);
                entity.Property(e => e.Id_curso).ValueGeneratedOnAdd();
                entity.Property(e => e.Anio_calendario).IsRequired();
                entity.Property(e => e.Cupo).IsRequired();
                entity.Property(e => e.Id_materia).IsRequired();
                entity.Property(e => e.Id_comision).IsRequired();
            });

           
            modelBuilder.Entity<AlumnoInscripcion>(entity =>
            {
                entity.HasKey(e => e.Id_inscripcion);
                entity.Property(e => e.Id_inscripcion).ValueGeneratedOnAdd();
                entity.Property(e => e.Id_alumno).IsRequired();
                entity.Property(e => e.Id_curso).IsRequired();
                entity.Property(e => e.Condicion).HasMaxLength(50);
                entity.Property(e => e.Nota);

                entity.HasOne<Persona>()
                    .WithMany()
                    .HasForeignKey(ai => ai.Id_alumno)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Curso>()
                    .WithMany()
                    .HasForeignKey(ai => ai.Id_curso)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            
            modelBuilder.Entity<DocenteCurso>(entity =>
            {
                entity.HasKey(e => e.Id_dictado);
                entity.Property(e => e.Id_dictado).ValueGeneratedOnAdd();
                entity.Property(e => e.Id_docente).IsRequired();
                entity.Property(e => e.Id_curso).IsRequired();
                entity.Property(e => e.Cargo).IsRequired();

                entity.HasOne<Persona>()
                    .WithMany()
                    .HasForeignKey(dc => dc.Id_docente)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Curso>()
                    .WithMany()
                    .HasForeignKey(dc => dc.Id_curso)
                    .OnDelete(DeleteBehavior.Restrict);
            });

           
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
            });

            
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
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FechaCreacion)
                    .IsRequired();

                entity.Property(e => e.Activo)
                    .IsRequired();

                entity.Property(e => e.Id_persona)
                    .IsRequired();

                // Restricciones únicas
                entity.HasIndex(e => e.Username)
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .IsUnique();

                entity.HasIndex(e => e.Id_persona)
                    .IsUnique();

                //entity.HasIndex(e => e.Cambia_clave)
                  //  .IsUnique();

                entity.HasOne<Persona>()
                    .WithMany()
                    .HasForeignKey(ai => ai.Id_persona)
                    .OnDelete(DeleteBehavior.Restrict);

                // Usuario administrador inicial con Id_persona=1
                //var adminUser = new Domain.Model.Usuario(1, "admin", "admin@tpi.com", "admin123", DateTime.Now, true, 1);
               
                //entity.HasData(new
                //{
                //Id = adminUser.Id,
                //Username = adminUser.Username,
                //Email = adminUser.Email,
                //PasswordHash = adminUser.PasswordHash,
                //    Salt = adminUser.Salt,
                //FechaCreacion = adminUser.FechaCreacion,
                //Activo = adminUser.Activo,
                //    Id_persona = adminUser.Id_persona
                //}); 
            });
        }
    }
}
