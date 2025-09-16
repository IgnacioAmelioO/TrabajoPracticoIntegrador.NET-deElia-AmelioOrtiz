using Domain.Model;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class PersonaRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public Persona Add(Persona persona)
        {
            using var context = CreateContext();
            context.Personas.Add(persona);
            context.SaveChanges();
            return persona;
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var persona = context.Personas.Find(id);
            if (persona != null)
            {
                context.Personas.Remove(persona);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Persona? Get(int id)
        {
            using var context = CreateContext();
            return context.Personas.Find(id);
        }

        public IEnumerable<Persona> GetAll()
        {
            using var context = CreateContext();
            return context.Personas.ToList();
        }

        public bool Update(Persona persona)
        {
            using var context = CreateContext();
            var existingPersona = context.Personas.Find(persona.Id_persona);
            if (existingPersona != null)
            {
                existingPersona.SetNombre(persona.Nombre);
                existingPersona.SetApellido(persona.Apellido);
                existingPersona.SetDireccion(persona.Direccion);
                existingPersona.SetEmail(persona.Email);
                existingPersona.SetTelefono(persona.Telefono);
                existingPersona.SetFecha_nac(persona.Fecha_nac);
                existingPersona.SetLegajo(persona.Legajo);
                existingPersona.SetTipo_persona(persona.Tipo_persona);
                existingPersona.SetId_plan(persona.Id_plan);

                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool EmailExists(string email, int? idToExclude = null)
        {
            using var context = CreateContext();
            var query = context.Personas.Where(p => p.Email.ToLower() == email.ToLower());

            if (idToExclude.HasValue)
            {
                query = query.Where(p => p.Id_persona != idToExclude.Value);
            }

            return query.Any();
        }

        public IEnumerable<Persona> GetByCriteria(PersonaCriteria criteria)
        {
            const string sql = @"
                SELECT Id_persona, Nombre, Apellido, Direccion, Email, Telefono, Fecha_nac, Legajo, Tipo_persona, Id_plan
                FROM Personas 
                WHERE Nombre LIKE @SearchTerm 
                   OR Apellido LIKE @SearchTerm 
                   OR Email LIKE @SearchTerm 
                   OR Legajo LIKE @SearchTerm
                   OR Tipo_persona LIKE @SearchTerm
                ORDER BY Apellido, Nombre";

            var personas = new List<Persona>();
            
            using var context = CreateContext();
            string? connectionString = context.Database.GetConnectionString();

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
                var persona = new Persona(
                    reader.GetInt32(0),    // Id_persona
                    reader.GetString(1),   // Nombre
                    reader.GetString(2),   // Apellido
                    reader.GetString(3),   // Direccion
                    reader.GetString(4),   // Email
                    reader.GetString(5),   // Telefono
                    DateOnly.FromDateTime(reader.GetDateTime(6)), // Fecha_nac
                    reader.GetString(7),   // Legajo
                    reader.GetString(8),   // Tipo_persona
                    reader.GetInt32(9)     // Id_plan
                );

                personas.Add(persona); // habria que cerrar la conexion una vez que se termina de leer todo?
            }

            return personas;
        }
    }
}