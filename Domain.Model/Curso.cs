using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Curso
    {
        public int Id_curso { get; private set; }
        public int Anio_calendario { get; private set; }
        public int Cupo { get; private set; }
        public int Id_materia { get; private set; }
        public int Id_comision { get; private set; }

        private Curso() { }
        public Curso(int id_curso, int anio_calendario, int cupo, int id_materia, int id_comision)
        {
            SetId_curso(id_curso);
            SetAnio_calendario(anio_calendario);
            SetCupo(cupo);
            SetId_materia(id_materia);
            SetId_comision(id_comision);
        }
        public void SetId_curso(int id_curso)
        {
            if (id_curso < 0)
                throw new ArgumentException("El Id de curso debe ser mayor o igual a 0.", nameof(id_curso));
            Id_curso = id_curso;
        }
        public void SetAnio_calendario(int anio_calendario)
        {
            if (anio_calendario <= 0)
                throw new ArgumentException("El año calendario debe ser mayor que 0.", nameof(anio_calendario));
            Anio_calendario = anio_calendario;
        }
        public void SetCupo(int cupo)
        {
            if (cupo <= 0)
                throw new ArgumentException("El cupo debe ser mayor que 0.", nameof(cupo));
            Cupo = cupo;
        }
        public void SetId_materia(int id_materia)
        {
            if (id_materia <= 0)
                throw new ArgumentException("El Id de materia debe ser mayor que 0.", nameof(id_materia));
            Id_materia = id_materia;
        }
        public void SetId_comision(int id_comision)
        {
            if (id_comision <= 0)
                throw new ArgumentException("El Id de comisión debe ser mayor que 0.", nameof(id_comision));
            Id_comision = id_comision;
        }
    }
}
