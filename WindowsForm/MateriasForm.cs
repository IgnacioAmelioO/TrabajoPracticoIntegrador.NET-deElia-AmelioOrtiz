using DTOs;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Api.Clients;

namespace WindowsForms
{
    public partial class MateriasForm : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        public bool EditMode { get; set; } = false;

        private MateriaDTO materia;
        public MateriaDTO Materia
        {
            get => materia;
            set
            {
                materia = value;
                if (IsHandleCreated)
                {
                    SetMateria();
                }
            }
        }

        public MateriasForm()
        {
            InitializeComponent();
            Load += MateriasForm_Load;
        }

        private async void MateriasForm_Load(object sender, EventArgs e)
        {
            await CargarPlanes();
            if (materia != null) SetMateria();
        }

        private async Task CargarPlanes()
        {
            var planes = await PlanApiClient.GetAllAsync();
            comboBoxPlan.DataSource = planes;
            comboBoxPlan.DisplayMember = "Desc_plan";
            comboBoxPlan.ValueMember = "Id_plan";
        }

        private void SetMateria()
        {
            if (materia == null) return;
            textBoxID_materia.Text = materia.Id_materia.ToString();
            textBoxDesc_materia.Text = materia.Desc_materia;
            numericUpDownHsSem.Value = materia.Hs_semanales;
            numericUpDownHsTot.Value = materia.Hs_totales;
            comboBoxPlan.SelectedValue = materia.Id_plan;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(textBoxDesc_materia.Text))
            {
                MessageBox.Show("La descripción no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (comboBoxPlan.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un plan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private async void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            MateriaApiClient client = new MateriaApiClient();

            this.Materia.Desc_materia = textBoxDesc_materia.Text.Trim();
            this.Materia.Hs_semanales = (int)numericUpDownHsSem.Value;
            this.Materia.Hs_totales = (int)numericUpDownHsTot.Value;
            this.Materia.Id_plan = (int)comboBoxPlan.SelectedValue;

            try
            {
                if (this.EditMode)
                {
                    await MateriaApiClient.UpdateAsync(this.Materia);
                    MessageBox.Show("Materia actualizada correctamente.");
                }
                else
                {
                    await MateriaApiClient.AddAsync(this.Materia);
                    MessageBox.Show("Materia creada correctamente.");
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar materia:\n{ex.Message}\n{ex.StackTrace}");
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
