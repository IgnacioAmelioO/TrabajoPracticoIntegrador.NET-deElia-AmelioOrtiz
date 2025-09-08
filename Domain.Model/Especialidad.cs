using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Especialidad
    {
        public int Id_especialidad { get; private set; }
        public string Desc_esp { get; private set; }

        // Constructor sin parámetros para Entity Framework
        private Especialidad() { }

        public Especialidad(int id, string descripcion)
        {
            SetId_especialidad(id);
            SetDesc_esp(descripcion);
        }

        public void SetId_especialidad(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id_especialidad = id;
        }

        public void SetDesc_esp(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("El nombre no puede ser nulo o vacío.", nameof(descripcion));
            Desc_esp = descripcion;
        }
    }
}