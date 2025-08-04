using Data;
using Domain.Model;



namespace Domain.Services
{
    public class EspecialidadService
    {
        public void Add(Especialidad especialidad)
        {
            especialidad.SetId_especialidad(GetNextId());

            EspecialidadInMemory.Especialidades.Add(especialidad);
        }

        public bool Delete(int id)
        {
            Especialidad? especialidadToDelete = EspecialidadInMemory.Especialidades.Find(x => x.Id_especialidad == id);

            if (especialidadToDelete != null)
            {
                EspecialidadInMemory.Especialidades.Remove(especialidadToDelete);

                return true;
            }
            else
            {
                return false;
            }
        }

        public Especialidad Get(int id)
        {
            // Devuelve la especialidad con el id indicado
            return EspecialidadInMemory.Especialidades.Find(x => x.Id_especialidad == id);
        }

        public IEnumerable<Especialidad> GetAll()
        {
            // Devuelve una lista nueva cada vez que se llama a GetAll
            return EspecialidadInMemory.Especialidades.ToList();
        }

        public bool Update(Especialidad especialidad)
        {
            Especialidad? especialidadToUpdate = EspecialidadInMemory.Especialidades.Find(x => x.Id_especialidad == especialidad.Id_especialidad);

            if (especialidadToUpdate != null)
            {
                especialidadToUpdate.SetDesc_esp(especialidad.Desc_esp);
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

            if (EspecialidadInMemory.Especialidades.Count > 0)
            {
                nextId = EspecialidadInMemory.Especialidades.Max(x => x.Id_especialidad) + 1;
            }
            else
            {
                nextId = 1;
            }

            return nextId;
        }

    }
}

