using Domain.Model;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class EspecialidadRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public Especialidad Add(Especialidad especialidad)
        {
            using var context = CreateContext();
            context.Especialidades.Add(especialidad);
            context.SaveChanges();
            return especialidad;
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var especialidad = context.Especialidades.Find(id);
            if (especialidad != null)
            {
                context.Especialidades.Remove(especialidad);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Especialidad? Get(int id)
        {
            using var context = CreateContext();
            return context.Especialidades.Find(id);
        }

        public IEnumerable<Especialidad> GetAll()
        {
            using var context = CreateContext();
            return context.Especialidades.ToList();
        }

        public bool Update(Especialidad especialidad)
        {
            using var context = CreateContext();
            var existingEspecialidad = context.Especialidades.Find(especialidad.Id_especialidad);
            if (existingEspecialidad != null)
            {
                existingEspecialidad.SetDesc_esp(especialidad.Desc_esp);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DescriptionExists(string descripcion, int? idToExclude = null)
        {
            using var context = CreateContext();
            var query = context.Especialidades.Where(e => e.Desc_esp.ToLower() == descripcion.ToLower());

            if (idToExclude.HasValue)
            {
                query = query.Where(e => e.Id_especialidad != idToExclude.Value);
            }

            return query.Any();
        }

        public IEnumerable<Especialidad> GetByCriteria(EspecialidadCriteria criteria)
        {
            const string sql = @"
                SELECT Id_especialidad, Desc_esp
                FROM Especialidades 
                WHERE Desc_esp LIKE @SearchTerm 
                ORDER BY Id_especialidad";

            var especialidades = new List<Especialidad>();
            string? connectionString = new TPIContext().Database.GetConnectionString();
            
            if (connectionString == null)
            {
                return especialidades;
            }
            
            string searchPattern = $"%{criteria.Texto}%";

            using var connection = new Microsoft.Data.SqlClient.SqlConnection(connectionString);
            using var command = new Microsoft.Data.SqlClient.SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SearchTerm", searchPattern);

            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var especialidad = new Especialidad(
                    reader.GetInt32(0),    // Id_especialidad
                    reader.GetString(1)    // Desc_esp
                );

                especialidades.Add(especialidad);
            }

            return especialidades;
        }
    }
}
