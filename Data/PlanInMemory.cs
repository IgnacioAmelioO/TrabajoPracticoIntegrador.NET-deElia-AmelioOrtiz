using Domain.Model;
using System.Collections.Generic;
using System.Numerics;

namespace Data
{
    public class PlanInMemory
    {
        public static List<Plan> Planes;

        static PlanInMemory()
        {
            Planes = new List<Plan>
                { new Plan(1, "Plan orientado al desarrollo de software", 1),
                  new Plan(2, "Plan enfocado en la electrónica y sistemas embebidos", 2),
                  new Plan(3, "Plan dedicado a la ingeniería industrial y optimización de procesos", 3),
                  new Plan(4, "Plan de prueba", 1),
                  new Plan(5, "Plan de prueba 2", 2)
                };
        }
    }
}
