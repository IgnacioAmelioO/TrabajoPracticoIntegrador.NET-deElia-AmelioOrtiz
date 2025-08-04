namespace DTOs
{
    public class Persona
    {
        public int Id_persona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Direccion { get; set; }
        public string Email { get; set; }

        public string Telefono { get; set; }

        public DateOnly Fecha_nac { get; set; }

        public string Legajo { get; set; }

        public string Tipo_persona { get; set; }

        public int Id_plan { get; set; }
    }
}
