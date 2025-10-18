using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DocenteCursoRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public DocenteCurso Add(DocenteCurso docenteCurso)
        {
            using var context = CreateContext();
            context.DocentesCursos.Add(docenteCurso);
            context.SaveChanges();
            return docenteCurso;
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var docenteCurso = context.DocentesCursos.Find(id);
            if (docenteCurso != null)
            {
                context.DocentesCursos.Remove(docenteCurso);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public DocenteCurso? Get(int id)
        {
            using var context = CreateContext();
            return context.DocentesCursos.Find(id);
        }

        public IEnumerable<DocenteCurso> GetAll()
        {
            using var context = CreateContext();
            return context.DocentesCursos.ToList();
        }

        public bool Update(DocenteCurso docenteCurso)
        {
            using var context = CreateContext();
            var existingDocenteCurso = context.DocentesCursos.Find(docenteCurso.Id_dictado);
            if (existingDocenteCurso != null)
            {
                existingDocenteCurso.SetId_curso(docenteCurso.Id_curso);
                existingDocenteCurso.SetId_docente(docenteCurso.Id_docente);
                existingDocenteCurso.SetCargo(docenteCurso.Cargo);
                
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<DocenteCurso> GetByDocente(int idDocente)
        {
            using var context = CreateContext();
            return context.DocentesCursos
                .Where(dc => dc.Id_docente == idDocente)
                .ToList();
        }

        public IEnumerable<DocenteCurso> GetByCurso(int idCurso)
        {
            using var context = CreateContext();
            return context.DocentesCursos
                .Where(dc => dc.Id_curso == idCurso)
                .ToList();
        }

        public bool ExistsByDocenteAndCurso(int idDocente, int idCurso, int? idDictadoToExclude = null)
        {
            using var context = CreateContext();
            var query = context.DocentesCursos
                .Where(dc => dc.Id_docente == idDocente && dc.Id_curso == idCurso);

            if (idDictadoToExclude.HasValue)
            {
                query = query.Where(dc => dc.Id_dictado != idDictadoToExclude.Value);
            }

            return query.Any();
        }
    }
}
