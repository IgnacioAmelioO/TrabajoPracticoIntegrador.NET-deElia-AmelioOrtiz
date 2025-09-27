using System;

namespace Domain.Model
{
    public class Materia
    {
        public int Id_materia { get; private set; }
        public string Desc_materia { get; private set; }
        public int Hs_semanales { get; private set; }
        public int Hs_totales { get; private set; }
        public int Id_plan { get; private set; }

       
        private Materia() { }

        public Materia(int id, string descripcion, int hsSem, int hsTot, int idPlan)
        {
            SetId_materia(id);
            SetDesc_materia(descripcion);
            SetHs_semanales(hsSem);
            SetHs_totales(hsTot);
            SetId_plan(idPlan);
        }

        public void SetId_materia(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id_materia = id;
        }

        public void SetDesc_materia(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción no puede ser nula o vacía.", nameof(descripcion));
            Desc_materia = descripcion;
        }

        public void SetHs_semanales(int hsSem)
        {
            if (hsSem < 0)
                throw new ArgumentException("Las horas semanales deben ser mayores o iguales a 0.", nameof(hsSem));
            Hs_semanales = hsSem;
        }

        public void SetHs_totales(int hsTot)
        {
            if (hsTot < 0)
                throw new ArgumentException("Las horas totales deben ser mayores o iguales a 0.", nameof(hsTot));
            Hs_totales = hsTot;
        }

        public void SetId_plan(int idPlan)
        {
            if (idPlan < 0)
                throw new ArgumentException("El Id de plan debe ser mayor que 0.", nameof(idPlan));
            Id_plan = idPlan;
        }
    }
}