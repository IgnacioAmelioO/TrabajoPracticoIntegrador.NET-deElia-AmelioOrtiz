using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForm;
using Api.Clients;

namespace WindowsForms
{
    public partial class PersonaForm : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        public bool EditMode { get; set; } = false;

        private PersonaDTO persona;
        public PersonaDTO Persona
        {
            get => persona;
            set
            {
                persona = value;
                if (IsHandleCreated)
                {
                    SetPersona();
                    buttonCrear.Text = "Guardar cambios";
                }
                else
                {
                    buttonCrear.Text = "Crear";
                }
            }
        }

        public PersonaForm()
        {
            InitializeComponent();
            Load += PersonaForm_Load;
        }

        private async void PersonaForm_Load(object sender, EventArgs e)
        {
            var tiposPersona = new List<TipoPersona>
            {
                new TipoPersona { Descripcion = "Alumno" },
                new TipoPersona { Descripcion = "Docente" }
            };

            comboBoxTipo_persona.DataSource = tiposPersona;
            comboBoxTipo_persona.DisplayMember = "Descripcion";
            comboBoxTipo_persona.ValueMember = "Descripcion";

            try
            {
                var planes = await httpClient.GetFromJsonAsync<List<PlanDTO>>("https://localhost:7003/planes");
                comboBoxId_plan.DataSource = planes;
                comboBoxId_plan.DisplayMember = "Desc_plan";
                comboBoxId_plan.ValueMember = "Id_plan";

                // Solo se llama a SetPersona si la persona ya estaba seteada antes del Load
                if (persona != null) SetPersona();
            }
            catch (Exception ex)
            {

            }
        }

        private void SetPersona()
        {
            if (persona == null) return;
            textBoxId_persona.Text = persona.Id_persona.ToString();
            textBoxNombre.Text = persona.Nombre;
            textBoxApellido.Text = persona.Apellido;
            textBoxDireccion.Text = persona.Direccion;
            textBoxEmail.Text = persona.Email;
            textBoxTelefono.Text = persona.Telefono;
            textBoxLegajo.Text = persona.Legajo;
            dateTimePickerFecha_nacimiento.Value = persona.Fecha_nac.ToDateTime(TimeOnly.MinValue);

            comboBoxTipo_persona.SelectedValue = persona.Tipo_persona;
            comboBoxId_plan.SelectedValue = persona.Id_plan;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
            {
                MessageBox.Show("El campo Nombre es obligatorio.");
                textBoxNombre.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxApellido.Text))
            {
                MessageBox.Show("El campo Apellido es obligatorio.");
                textBoxApellido.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxDireccion.Text))
            {
                MessageBox.Show("El campo Dirección es obligatorio.");
                textBoxDireccion.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show("El campo Email es obligatorio.");
                textBoxEmail.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxTelefono.Text))
            {
                MessageBox.Show("El campo Teléfono es obligatorio.");
                textBoxTelefono.Focus();
                return false;
            }

            if (comboBoxTipo_persona.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un Tipo de Persona.");
                comboBoxTipo_persona.Focus();
                return false;
            }
            if (comboBoxId_plan.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un Plan.");
                comboBoxId_plan.Focus();
                return false;
            }
            if (dateTimePickerFecha_nacimiento.Value.Date > DateTime.Today)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser futura.");
                dateTimePickerFecha_nacimiento.Focus();
                return false;
            }

            return true;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            PersonaApiClient client = new PersonaApiClient();

            var fechaDateOnly = DateOnly.FromDateTime(dateTimePickerFecha_nacimiento.Value);

            this.Persona.Nombre = textBoxNombre.Text.Trim();
            this.Persona.Apellido = textBoxApellido.Text.Trim();
            this.Persona.Direccion = textBoxDireccion.Text.Trim();
            this.Persona.Email = textBoxEmail.Text.Trim();
            this.Persona.Telefono = textBoxTelefono.Text.Trim();
            this.Persona.Legajo = textBoxLegajo.Text.Trim();
            this.Persona.Tipo_persona = comboBoxTipo_persona.SelectedValue.ToString();
            this.Persona.Id_plan = (int)comboBoxId_plan.SelectedValue;
            this.Persona.Fecha_nac = fechaDateOnly;

            try
            {
                if (this.EditMode)
                {
                    await PersonaApiClient.UpdateAsync(this.Persona);
                    MessageBox.Show("Persona actualizada correctamente.");
                }
                else
                {
                    await PersonaApiClient.AddAsync(this.Persona);
                    MessageBox.Show("Persona creada correctamente.");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar persona:\n{ex.Message}\n{ex.StackTrace}");
            }
        }

        public class TipoPersona
        {
            public string Descripcion { get; set; }
        }

        private void canelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
