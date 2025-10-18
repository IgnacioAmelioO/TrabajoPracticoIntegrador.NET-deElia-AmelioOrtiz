using System;

namespace DTOs
{
    public class AlumnoInscripcionDTO
    {
        public int Id_inscripcion { get; set; }
        public int Id_alumno { get; set; }
        public int Id_curso { get; set; }
        public int? Nota { get; set; }
        public string? Condicion { get; set; }
    }
}
