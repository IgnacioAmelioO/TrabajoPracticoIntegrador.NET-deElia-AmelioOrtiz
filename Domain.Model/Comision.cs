using System;

namespace Domain.Model
{
    public class Comision
    {
        public int Id_comision { get; private set; }
        public string Desc_comision { get; private set; }
        public int Anio_especialidad { get; private set; }
        public int Id_plan { get; private set; }

        // Constructor sin parámetros para Entity Framework
        private Comision() { }

        public Comision(int id, string descripcion, int anioEspecialidad, int idPlan)
        {
            SetId_comision(id);
            SetDesc_comision(descripcion);
            SetAnio_especialidad(anioEspecialidad);
            SetId_plan(idPlan);
        }

        public void SetId_comision(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id_comision = id;
        }

        public void SetDesc_comision(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción no puede ser nula o vacía.", nameof(descripcion));
            Desc_comision = descripcion;
        }

        public void SetAnio_especialidad(int anio)
        {
            if (anio <= 0)
                throw new ArgumentException("El año debe ser mayor que 0.", nameof(anio));
            Anio_especialidad = anio;
        }

        public void SetId_plan(int idPlan)
        {
            if (idPlan < 0)
                throw new ArgumentException("El Id de plan debe ser mayor que 0.", nameof(idPlan));
            Id_plan = idPlan;
        }
    }
}