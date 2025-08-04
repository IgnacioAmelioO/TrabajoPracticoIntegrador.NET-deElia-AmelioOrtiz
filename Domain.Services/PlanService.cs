using System.Collections.Generic;
using Data;
using Domain.Model;



namespace Domain.Services
{
    public class PlanService
    {
        public void Add(Plan plan)
        {
            plan.SetId_plan(GetNextId());

            PlanInMemory.Planes.Add(plan);
        }

        public bool Delete(int id)
        {
            Plan? planToDelete = PlanInMemory.Planes.Find(x => x.Id_plan == id);

            if (planToDelete != null)
            {
                PlanInMemory.Planes.Remove(planToDelete);

                return true;
            }
            else
            {
                return false;
            }
        }

        public Plan Get(int id)
        {
            return PlanInMemory.Planes.Find(x => x.Id_plan == id);
        }

        public IEnumerable<Plan> GetAll()
        {
            return PlanInMemory.Planes.ToList();
        }

        public bool Update(Plan plan)
        {
            Plan? planToUpdate = PlanInMemory.Planes.Find(x => x.Id_plan == plan.Id_plan);

            if (planToUpdate != null)
            {
                planToUpdate.SetDesc_plan(plan.Desc_plan);
                planToUpdate.SetId_especialidad(plan.Id_especialidad);
                return true;
            }
            else
            {
                return false;
            }
        }
        private static int GetNextId()
        {
            int nextId;

            if (PlanInMemory.Planes.Count > 0)
            {
                nextId = PlanInMemory.Planes.Max(x => x.Id_plan) + 1;
            }
            else
            {
                nextId = 1;
            }

            return nextId;
        }

    }
}
