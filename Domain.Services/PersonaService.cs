using Domain.Model;
using Data;

namespace Domain.Services
{
    public class PersonaService
    {
        public void Add(Persona persona)
        {
            persona.SetId(GetNextId());
            persona.SetLegajo(GetNextLegajo());

            PersonaInMemory.Personas.Add(persona);
        }

        public bool Delete(int id)
        {
            Persona? personaToDelete = PersonaInMemory.Personas.Find(x => x.Id_persona == id);

            if (personaToDelete != null)
            {
                PersonaInMemory.Personas.Remove(personaToDelete);

                return true;
            }
            else
            {
                return false;
            }
        }

        public Persona Get(int id)
        {
            //Deberia devolver un objeto cloneado 
            return PersonaInMemory.Personas.Find(x => x.Id_persona == id);
        }

        public IEnumerable<Persona> GetAll()
        {
            //Devuelvo una lista nueva cada vez que se llama a GetAll
            //pero idealmente deberia implementar un Deep Clone
            return PersonaInMemory.Personas.ToList();
        }

        public bool Update(Persona persona)
        {
            Persona? personaToUpdate = PersonaInMemory.Personas.Find(x => x.Id_persona == persona.Id_persona);

            if (personaToUpdate != null)
            {

                personaToUpdate.SetNombre(persona.Nombre);
                personaToUpdate.SetApellido(persona.Apellido);
                personaToUpdate.SetEmail(persona.Email);
                personaToUpdate.SetDireccion(persona.Direccion);
                personaToUpdate.SetTelefono(persona.Telefono);
                personaToUpdate.SetTipo_persona(persona.Tipo_persona);
                personaToUpdate.SetFecha_nac(persona.Fecha_nac);
                personaToUpdate.SetId_plan(persona.Id_plan);


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

            if (PersonaInMemory.Personas.Count > 0)
            {
                nextId = PersonaInMemory.Personas.Max(x => x.Id_persona) + 1;
            }
            else
            {
                nextId = 1;
            }

            return nextId;
        }


        //Adaptar en un futuro para los legajos de docentes y alumnos
        private static string GetNextLegajo()
        {
            string nextLegajo;

            if (PersonaInMemory.Personas.Count > 0)
            {
                nextLegajo = "A" + (PersonaInMemory.Personas.Max(x => x.Id_persona) + 1);
            }
            else
            {
                nextLegajo = "A1";
            }

            return nextLegajo;
        }
    }
}


