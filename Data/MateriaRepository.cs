using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class MateriaRepository
    {
        public void Add(Materia materia)
        {
            using var context = new TPIContext();
            context.Materias.Add(materia);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = new TPIContext();
            var materia = context.Materias.Find(id);
            if (materia == null) return false;
            context.Materias.Remove(materia);
            context.SaveChanges();
            return true;
        }

        public Materia? Get(int id)
        {
            using var context = new TPIContext();
            return context.Materias.Find(id);
        }

        public IEnumerable<Materia> GetAll()
        {
            using var context = new TPIContext();
            return context.Materias.AsNoTracking().ToList();
        }

        public bool Update(Materia materia)
        {
            using var context = new TPIContext();
            var existing = context.Materias.Find(materia.Id_materia);
            if (existing == null) return false;

            existing.SetDesc_materia(materia.Desc_materia);
            existing.SetHs_semanales(materia.Hs_semanales);
            existing.SetHs_totales(materia.Hs_totales);
            existing.SetId_plan(materia.Id_plan);

            context.SaveChanges();
            return true;
        }

        public bool MateriaExists(string descMateria, int idPlan, int? idMateria = null)
        {
            using var context = new TPIContext();
            return context.Materias.Any(m =>
                m.Desc_materia == descMateria &&
                m.Id_plan == idPlan &&
                (!idMateria.HasValue || m.Id_materia != idMateria.Value));
        }
    }
}