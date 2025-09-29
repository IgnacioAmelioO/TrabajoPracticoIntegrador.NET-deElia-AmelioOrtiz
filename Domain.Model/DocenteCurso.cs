using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class DocenteCurso
    {
        public int Id_dictado { get; private set; }
        public int Id_curso { get; private set; }
        public int Id_docente { get; private set; }
        public int Cargo { get; private set; } // 1: Titular, 2: Auxiliar, 3: Suplente
        private DocenteCurso() { }
        public DocenteCurso(int id_dictado, int id_curso, int id_docente, int cargo)
        {
            SetId_dictado(id_dictado);
            SetId_curso(id_curso);
            SetId_docente(id_docente);
            SetCargo(cargo);
        }
        public void SetId_dictado(int id_dictado)
        {
            if (id_dictado < 0)
                throw new ArgumentException("El Id de dictado debe ser mayor o igual a 0.", nameof(id_dictado));
            Id_dictado = id_dictado;
        }
        public void SetId_curso(int id_curso)
        {
            if (id_curso <= 0)
                throw new ArgumentException("El Id de curso debe ser mayor que 0.", nameof(id_curso));
            Id_curso = id_curso;
        }
        public void SetId_docente(int id_docente)
        {
            if (id_docente <= 0)
                throw new ArgumentException("El Id de docente debe ser mayor que 0.", nameof(id_docente));
            Id_docente = id_docente;
        }
        public void SetCargo(int cargo)
        {
            if (cargo < 1 || cargo > 3)
                throw new ArgumentException("El cargo debe ser 1 (Titular), 2 (Auxiliar) o 3 (Suplente).", nameof(cargo));
            Cargo = cargo;
        }
    }
}
