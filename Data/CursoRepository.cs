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
        // Se modifica solo el cupo?? / Se puede modificar todo??
        public bool Update(Curso curso)
        {
            using var context = CreateContext();
            var existingCurso = context.Cursos.Find(curso.Id_curso);
            if (existingCurso != null)
            {
                existingCurso.SetCupo(curso.Cupo);
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
