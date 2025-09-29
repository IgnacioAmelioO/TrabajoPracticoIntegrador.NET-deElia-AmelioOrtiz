using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class AlumnoInscripcion
    {
        public int Id_inscripcion { get; private set; }
        public int Id_alumno { get; private set; }
        public int Id_curso { get; private set; }
        public int? Nota { get; private set; }
        public string? Condicion { get; private set; }
        // Constructor sin parámetros para Entity Framework
        private AlumnoInscripcion() { }
        public AlumnoInscripcion(int id_inscripcion, int id_alumno, int id_curso, int? nota = null, string? condicion = null)
        {
            SetId_inscripcion(id_inscripcion);
            SetId_alumno(id_alumno);
            SetId_curso(id_curso);
            SetNota(nota);
            SetCondicion(condicion);
        }
        public void SetId_inscripcion(int id_inscripcion)
        {
            if (id_inscripcion < 0)
                throw new ArgumentException("El Id de inscripción debe ser mayor o igual a 0.", nameof(id_inscripcion));
            Id_inscripcion = id_inscripcion;
        }
        public void SetId_alumno(int id_alumno)
        {
            if (id_alumno <= 0)
                throw new ArgumentException("El Id de alumno debe ser mayor que 0.", nameof(id_alumno));
            Id_alumno = id_alumno;
        }
        public void SetId_curso(int id_curso)
        {
            if (id_curso <= 0)
                throw new ArgumentException("El Id de curso debe ser mayor que 0.", nameof(id_curso));
            Id_curso = id_curso;
        }
        public void SetNota(int? nota)
        {
            if (nota != null && (nota < 0 || nota > 10))
                throw new ArgumentException("La nota debe estar entre 0 y 10.", nameof(nota));
            Nota = nota;
        }
        public void SetCondicion(string? condicion)
        {
            Condicion = condicion;
        }
    }
}
