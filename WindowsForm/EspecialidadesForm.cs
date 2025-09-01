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
    public partial class EspecialidadForm : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        public bool EditMode { get; set; } = false;

        private EspecialidadDTO especialidad;
        public EspecialidadDTO Especialidad
        {
            get => especialidad;
            set
            {
                especialidad = value;
                if (IsHandleCreated)
                {
                    SetEspecialidad();

                }
                else
                {

                }
            }
        }
        public EspecialidadForm()
        {
            InitializeComponent();
            Load += EspecialidadForm_Load;

        }
        private void EspecialidadForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (especialidad != null) SetEspecialidad();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar: {ex.Message}");
            }
        }

        private void SetEspecialidad()

        {
            if (especialidad == null) return;
            textBoxID_especialidad.Text = especialidad.Id_especialidad.ToString();
            textBoxDesc_especialidad.Text = especialidad.Desc_esp;

        }
        private bool ValidarCampos()
        {

            if (string.IsNullOrWhiteSpace(textBoxDesc_especialidad.Text))
            {
                MessageBox.Show("La descripción no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private async void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            EspecialidadApiClient client = new EspecialidadApiClient();

            this.Especialidad.Desc_esp = textBoxDesc_especialidad.Text.Trim();


            try
            {
                if (this.EditMode)
                {
                    await EspecialidadApiClient.UpdateAsync(this.Especialidad);
                    MessageBox.Show("Especialidad actualizada correctamente.");
                }
                else
                {
                    await EspecialidadApiClient.AddAsync(this.Especialidad);
                    MessageBox.Show("Especialidad creada correctamente.");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar persona:\n{ex.Message}\n{ex.StackTrace}");
            }
        }


        private void buttonCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
