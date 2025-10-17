using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Api.Clients;
using DTOs;

namespace WindowsForm
{
    public partial class UsuarioForm : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private PersonaDTO persona;
        private UsuarioDTO usuario;
        public PersonaDTO Persona {            
            get => persona;
            set
            {
                persona = value;
                if (IsHandleCreated && persona != null)
                {
                    UpdatePersonaInfo();
                }
            }
        }

        public UsuarioForm()
        {
            InitializeComponent();
        }

        private void UpdatePersonaInfo()
        {
            if (persona != null)
            {
                labelPersonaInfo.Text = $"Crear usuario para: {persona.Nombre} {persona.Apellido}";
                
                // Sugerencia de nombre de usuario basado en el nombre y apellido
                textBoxUsername.Text = GenerateUsernameFromPersona(persona);
            }
        }

        private string GenerateUsernameFromPersona(PersonaDTO persona)
        {
            // Crear un nombre de usuario con la primera letra del nombre y el apellido completo
            if (string.IsNullOrEmpty(persona.Nombre) || string.IsNullOrEmpty(persona.Apellido))
                return string.Empty;
                
            return (persona.Nombre.Substring(0, 1) + persona.Apellido).ToLower()
                .Replace(" ", "")  // Eliminar espacios
                .Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u")  // Eliminar acentos
                .Replace("ñ", "n"); // Reemplazar ñ
        }

        private async void UsuarioForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (persona == null)
                {
                    MessageBox.Show("No se ha proporcionado una persona válida para crear el usuario.", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                UpdatePersonaInfo();

                // Verificar si ya existe un usuario para esta persona
                var existingUser = await UsuarioApiClient.GetByPersonaIdAsync(persona.Id_persona);
                if (existingUser != null)
                {
                    MessageBox.Show($"Ya existe un usuario para esta persona: {existingUser.Username}", 
                        "Usuario existente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text))
            {
                MessageBox.Show("Debe ingresar un nombre de usuario.", 
                    "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxUsername.Focus();
                return false;
            }

            if (textBoxUsername.Text.Length < 3)
            {
                MessageBox.Show("El nombre de usuario debe tener al menos 3 caracteres.", 
                    "Nombre de usuario inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxUsername.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Debe ingresar una contraseña.", 
                    "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPassword.Focus();
                return false;
            }

            if (textBoxPassword.Text.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", 
                    "Contraseña inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPassword.Focus();
                return false;
            }

            if (textBoxPassword.Text != textBoxConfirmPassword.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", 
                    "Contraseña inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxConfirmPassword.Focus();
                return false;
            }

            return true;
        }

        private async void buttonCrear_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                // Deshabilitar el botón durante el proceso
                buttonCrear.Enabled = false;
                buttonCrear.Text = "Creando...";
                Cursor = Cursors.WaitCursor;

                // Crear el objeto UsuarioDTO
                var nuevoUsuario = new UsuarioDTO
                {
                    Username = textBoxUsername.Text.Trim(),
                    Email = persona.Email,  // Usar el email de la persona
                    FechaCreacion = DateTime.Now,
                    Activo = true,
                    Id_persona = persona.Id_persona,
                    // Cambia_clave = false // No es necesario cambiar la clave al primer inicio de sesión
                };

                // Usar la API para crear el usuario
                // Nota: La contraseña se envía por separado para seguridad en algunos casos,
                // pero aquí la incluimos en el objeto para simplificar
                // En una implementación real, podría enviarse en un objeto diferente o en un campo temporal
                nuevoUsuario.Password = textBoxPassword.Text;  // Este campo debe existir en el DTO pero no se almacena como tal

                var usuarioCreado = await UsuarioApiClient.AddAsync(nuevoUsuario);

                MessageBox.Show($"Usuario '{usuarioCreado.Username}' creado correctamente para {persona.Nombre} {persona.Apellido}.", 
                    "Usuario creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear usuario: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Restaurar el estado del botón
                buttonCrear.Enabled = true;
                buttonCrear.Text = "Crear";
                Cursor = Cursors.Default;
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
