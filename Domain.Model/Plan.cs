using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace Domain.Model
{
    public class Plan
    {
        public int Id_plan { get; private set; }
        public string Desc_plan { get; private set; }
        public int Id_especialidad { get; private set; }


        public Plan(int id_plan, string descripcion, int id_esp)
        {
            SetId_plan(id_plan);
            SetDesc_plan(descripcion);
            SetId_especialidad(id_esp);
        }

        public void SetId_plan(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id_plan = id;
        }
        public void SetDesc_plan(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripcion no puede ser nula o vacía.", nameof(descripcion));
            Desc_plan = descripcion;
        }

        public void SetId_especialidad(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id_especialidad = id;
        }



    }
}