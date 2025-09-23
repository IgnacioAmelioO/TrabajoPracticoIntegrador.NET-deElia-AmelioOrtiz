using DTOs;
using System;
using System.Windows.Forms;
using Api.Clients;

namespace WindowsForm
{
    public partial class PlanesForm : Form
    {
        public bool EditMode { get; set; } = false;
        private PlanDTO plan;
        public PlanDTO Plan
        {
            get => plan;
            set
            {
                plan = value;
                if (IsHandleCreated)
                {
                    SetPlan();
                    buttonCrear.Text = "Guardar cambios";
                }
                else
                {
                    buttonCrear.Text = "Crear";
                }
            }
        }

        public PlanesForm()
        {
            InitializeComponent();
            Load += PlanesForm_Load;
        }

        private async void PlanesForm_Load(object sender, EventArgs e)
        {
            var especialidades = await EspecialidadApiClient.GetAllAsync();
            comboBoxEspecialidad.DataSource = especialidades;
            comboBoxEspecialidad.DisplayMember = "Desc_especialidad";
            comboBoxEspecialidad.ValueMember = "Id_especialidad";
            if (plan != null) SetPlan();
        }

        private void SetPlan()
        {
            if (plan == null) return;
            textBoxIdPlan.Text = plan.Id_plan.ToString();
            textBoxDescPlan.Text = plan.Desc_plan;
            comboBoxEspecialidad.SelectedValue = plan.Id_especialidad;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(textBoxDescPlan.Text))
            {
                MessageBox.Show("La descripción es obligatoria.");
                textBoxDescPlan.Focus();
                return false;
            }
            if (comboBoxEspecialidad.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una especialidad.");
                comboBoxEspecialidad.Focus();
                return false;
            }
            return true;
        }

        private async void buttonCrear_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            var nuevoPlan = new PlanDTO
            {
                Id_plan = EditMode ? plan.Id_plan : 0,
                Desc_plan = textBoxDescPlan.Text,
                Id_especialidad = (int)comboBoxEspecialidad.SelectedValue
            };
            try
            {
                if (EditMode)
                {
                    await PlanApiClient.UpdateAsync(nuevoPlan);
                    MessageBox.Show("Plan actualizado correctamente.");
                }
                else
                {
                    await PlanApiClient.AddAsync(nuevoPlan);
                    MessageBox.Show("Plan creado correctamente.");
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el plan:\n{ex.Message}");
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}