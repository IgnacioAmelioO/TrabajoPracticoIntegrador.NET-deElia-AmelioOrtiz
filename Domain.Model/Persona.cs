using System.Text.RegularExpressions;

namespace Domain.Model
{
    public class Persona
    {
        public int Id_persona { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Direccion { get; private set; }
        public string Email { get; private set; }
        public string Telefono { get; private set; }
        public DateOnly Fecha_nac { get; private set; }
        public string Legajo { get; private set; }
        public string Tipo_persona { get; private set; }
        public int Id_plan { get; private set; }

        // Constructor sin parámetros para Entity Framework
        private Persona() { }


        public Persona(int id, string nombre, string apellido, string direccion, string email, string telefono, DateOnly fecha_nac, string legajo, string tipo_persona, int id_plan)
        {
            SetId(id);
            SetNombre(nombre);
            SetApellido(apellido);
            SetDireccion(direccion);
            SetEmail(email);
            SetTelefono(telefono);
            SetFecha_nac(fecha_nac);
            SetLegajo(legajo);
            SetTipo_persona(tipo_persona);
            SetId_plan(id_plan);
        }

        // resto de métodos igual...
        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id_persona = id;
        }

        public void SetLegajo(string legajo)
        {
            Legajo = legajo;
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede ser nulo o vacío.", nameof(nombre));
            Nombre = nombre;
        }

        public void SetApellido(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido no puede ser nulo o vacío.", nameof(apellido));
            Apellido = apellido;
        }

        public void SetDireccion(string direccion)
        {
            if (string.IsNullOrWhiteSpace(direccion))
                throw new ArgumentException("La direccion no puede ser nula o vacía.", nameof(direccion));
            Direccion = direccion;
        }

        public void SetTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                throw new ArgumentException("El telefono no puede ser nulo o vacío.", nameof(telefono));
            Telefono = telefono;
        }

        public void SetTipo_persona(string tipo_persona)
        {
            if (string.IsNullOrWhiteSpace(tipo_persona))
                throw new ArgumentException("El tipo de persona no puede ser nulo o vacío.", nameof(tipo_persona));
            if (tipo_persona != "Docente" && tipo_persona != "Alumno")
                throw new ArgumentException("El tipo de persona debe ser 'Docente' o 'Alumno'.", nameof(tipo_persona));
            Tipo_persona = tipo_persona;
        }

        public void SetEmail(string email)
        {
            if (!EsEmailValido(email))
                throw new ArgumentException("El email no tiene un formato válido.", nameof(email));
            Email = email;
        }

        public void SetFecha_nac(DateOnly fecha_nac)
        {
            if (fecha_nac > DateOnly.MaxValue)
                throw new ArgumentException("La fecha de nacimiento no puede ser en el futuro.", nameof(fecha_nac));
            Fecha_nac = fecha_nac;
        }

        public void SetId_plan(int id_plan)
        {
            if (id_plan < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id_plan));
            Id_plan = id_plan;
        }

        private static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
