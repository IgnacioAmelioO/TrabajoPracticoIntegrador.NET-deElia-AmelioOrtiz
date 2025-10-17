using Domain.Model;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CursoRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public Curso Add(Curso curso)
        {
            using var context = CreateContext();
            context.Cursos.Add(curso);
            context.SaveChanges();
            return curso;
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var curso = context.Cursos.Find(id);
            if (curso != null)
            {
                context.Cursos.Remove(curso);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Curso? Get(int id)
        {
            using var context = CreateContext();
            return context.Cursos.Find(id);
        }

        public IEnumerable<Curso> GetAll()
        {
            using var context = CreateContext();
            return context.Cursos.ToList();
        }

        // Actualizar todos los campos relevantes: año, cupo, materia y comisión
        public bool Update(Curso curso)
        {
            using var context = CreateContext();
            var existingCurso = context.Cursos.Find(curso.Id_curso);
            if (existingCurso != null)
            {
                // Aplicar validaciones/sets a través de los métodos del aggregate (evita asignaciones directas)
                existingCurso.SetAnio_calendario(curso.Anio_calendario);
                existingCurso.SetCupo(curso.Cupo);
                existingCurso.SetId_materia(curso.Id_materia);
                existingCurso.SetId_comision(curso.Id_comision);

                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool CursoExists(int anio_calendario, int id_materia, int id_comision, int? idToExclude = null)
        {
            using var context = CreateContext();
            var query = context.Cursos.Where(c => c.Anio_calendario == anio_calendario && 
                                                  c.Id_materia == id_materia && 
                                                  c.Id_comision == id_comision);

            if (idToExclude.HasValue)
            {
                query = query.Where(c => c.Id_curso != idToExclude.Value);
            }

            return query.Any();
        }
    }
}
