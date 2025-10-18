using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class AlumnoInscripcionRepository
    {
        private TPIContext CreateContext() => new TPIContext();

        public AlumnoInscripcion Add(AlumnoInscripcion inscripcion)
        {
            using var context = CreateContext();
            context.AlumnoInscripciones.Add(inscripcion);
            context.SaveChanges();
            return inscripcion;
        }

      
        public AlumnoInscripcion AddWithCupoCheck(AlumnoInscripcion inscripcion)
        {
            using var context = CreateContext();

            var curso = context.Cursos.Find(inscripcion.Id_curso);
            if (curso == null)
                
                throw new KeyNotFoundException($"Curso con id {inscripcion.Id_curso} no encontrado.");

            if (curso.Cupo <= 0)
                throw new InvalidOperationException("No hay cupo disponible en el curso seleccionado.");

            curso.SetCupo(curso.Cupo - 1);

            context.AlumnoInscripciones.Add(inscripcion);
            context.SaveChanges();

            return inscripcion;
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var ent = context.AlumnoInscripciones.Find(id);
            if (ent != null)
            {
                context.AlumnoInscripciones.Remove(ent);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public AlumnoInscripcion? Get(int id)
        {
            using var context = CreateContext();
            return context.AlumnoInscripciones.Find(id);
        }

        public IEnumerable<AlumnoInscripcion> GetAll()
        {
            using var context = CreateContext();
            return context.AlumnoInscripciones.ToList();
        }

        
        public IEnumerable<AlumnoInscripcion> GetByAlumno(int id_alumno)
        {
            using var context = CreateContext();
            return context.AlumnoInscripciones
                .Where(a => a.Id_alumno == id_alumno)
                .ToList();
        }

        public bool Update(AlumnoInscripcion inscripcion)
        {
            using var context = CreateContext();
            var existing = context.AlumnoInscripciones.Find(inscripcion.Id_inscripcion);
            if (existing != null)
            {
                
                existing.SetId_alumno(inscripcion.Id_alumno);
                existing.SetId_curso(inscripcion.Id_curso);
                existing.SetNota(inscripcion.Nota);
                existing.SetCondicion(inscripcion.Condicion);

                context.SaveChanges();
                return true;
            }
            return false;
        }

        
        public bool ExistsByAlumnoCurso(int id_alumno, int id_curso, int? idToExclude = null)
        {
            using var context = CreateContext();
            var query = context.AlumnoInscripciones.Where(a => a.Id_alumno == id_alumno && a.Id_curso == id_curso);
            if (idToExclude.HasValue) query = query.Where(a => a.Id_inscripcion != idToExclude.Value);
            return query.Any();
        }
    }
}