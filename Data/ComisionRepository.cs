using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class ComisionRepository
    {
        public void Add(Comision comision)
        {
            using var context = new TPIContext();
            context.Comisiones.Add(comision);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = new TPIContext();
            var comision = context.Comisiones.Find(id);
            if (comision == null) return false;
            context.Comisiones.Remove(comision);
            context.SaveChanges();
            return true;
        }

        public Comision? Get(int id)
        {
            using var context = new TPIContext();
            return context.Comisiones.Find(id);
        }

        public IEnumerable<Comision> GetAll()
        {
            using var context = new TPIContext();
            return context.Comisiones.AsNoTracking().ToList();
        }

        public bool Update(Comision comision)
        {
            using var context = new TPIContext();
            var existing = context.Comisiones.Find(comision.Id_comision);
            if (existing == null) return false;

            existing.SetDesc_comision(comision.Desc_comision);
            existing.SetAnio_especialidad(comision.Anio_especialidad);
            existing.SetId_plan(comision.Id_plan);

            context.SaveChanges();
            return true;
        }

        public bool ComisionExists(string descComision, int anioEspecialidad, int idPlan, int? idComision = null)
        {
            using var context = new TPIContext();
            return context.Comisiones.Any(c =>
                c.Desc_comision == descComision &&
                c.Anio_especialidad == anioEspecialidad &&
                c.Id_plan == idPlan &&
                (!idComision.HasValue || c.Id_comision != idComision.Value));
        }
    }
}