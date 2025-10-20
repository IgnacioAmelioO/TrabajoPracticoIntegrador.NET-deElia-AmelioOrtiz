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
            context.AlumnosInscripciones.Add(inscripcion);
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

            context.AlumnosInscripciones.Add(inscripcion);
            context.SaveChanges();

            return inscripcion;
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var ent = context.AlumnosInscripciones.Find(id);
            if (ent != null)
            {
                context.AlumnosInscripciones.Remove(ent);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public AlumnoInscripcion? Get(int id)
        {
            using var context = CreateContext();
            return context.AlumnosInscripciones.Find(id);
        }

        public IEnumerable<AlumnoInscripcion> GetAll()
        {
            using var context = CreateContext();
            return context.AlumnosInscripciones.ToList();
        }

        
        public IEnumerable<AlumnoInscripcion> GetByAlumno(int id_alumno)
        {
            using var context = CreateContext();
            return context.AlumnosInscripciones
                .Where(a => a.Id_alumno == id_alumno)
                .ToList();
        }

        public IEnumerable<AlumnoInscripcion> GetByCurso(int id_curso)
        {
            using var context = CreateContext();
            return context.AlumnosInscripciones
                .Where(a => a.Id_curso == id_curso)
                .ToList();
        }

        public bool Update(AlumnoInscripcion inscripcion)
        {
            using var context = CreateContext();
            var existing = context.AlumnosInscripciones.Find(inscripcion.Id_inscripcion);
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
            var query = context.AlumnosInscripciones.Where(a => a.Id_alumno == id_alumno && a.Id_curso == id_curso);
            if (idToExclude.HasValue) query = query.Where(a => a.Id_inscripcion != idToExclude.Value);
            return query.Any();
        }
    }
}