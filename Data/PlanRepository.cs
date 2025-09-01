using Domain.Model;
using Microsoft.Data.SqlClient; // Cambiado de System.Data.SqlClient
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class PlanRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Plan plan)
        {
            using var context = CreateContext();
            context.Planes.Add(plan);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var plan = context.Planes.Find(id);
            if (plan != null)
            {
                context.Planes.Remove(plan);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Plan? Get(int id)
        {
            using var context = CreateContext();
            return context.Planes.Find(id);
        }

        public IEnumerable<Plan> GetAll()
        {
            using var context = CreateContext();
            return context.Planes.ToList();
        }

        public bool Update(Plan plan)
        {
            using var context = CreateContext();
            var existingPlan = context.Planes.Find(plan.Id_plan);
            if (existingPlan != null)
            {
                existingPlan.SetDesc_plan(plan.Desc_plan);
                existingPlan.SetId_especialidad(plan.Id_especialidad);
                

                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DescriptionExists(string description)
        {
            using var context = CreateContext();
            return context.Planes.Any(p => p.Desc_plan == description);
        }


        public IEnumerable<Plan> GetByCriteria(PlanCriteria criteria)
        {
            const string sql = @"
                SELECT Id_plan, Desc_plan, Id_especialidad
                FROM Planes 
                WHERE Desc_plan LIKE @SearchTerm 
                   OR Id_especialidad LIKE @SearchTerm 
                ORDER BY Id_especialidad";

            var planes = new List<Plan>();
            string? connectionString = new TPIContext().Database.GetConnectionString();
            
            if (connectionString == null)
            {
              
                throw new InvalidOperationException("No se pudo obtener la cadena de conexión.");
            }
            
            string searchPattern = $"%{criteria.Texto}%";

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SearchTerm", searchPattern);

            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var plan = new Plan(
                    reader.GetInt32(0),    // Id
                    reader.GetString(1),   // Desc_plan
                    reader.GetInt32(2)     // Id_especialidad
                );

                planes.Add(plan);
            }

            return planes;
        }
    }
}
