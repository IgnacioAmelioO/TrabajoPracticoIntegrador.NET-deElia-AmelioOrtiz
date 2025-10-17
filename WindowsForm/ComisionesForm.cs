using DTOs;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Api.Clients;

namespace WindowsForms
{
    public partial class ComisionesForm : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        public bool EditMode { get; set; } = false;

        private ComisionDTO comision;
        public ComisionDTO Comision
        {
            get => comision;
            set
            {
                comision = value;
                if (IsHandleCreated)
                {
                    SetComision();
                }
            }
        }

        public ComisionesForm()
        {
            InitializeComponent();
            Load += ComisionesForm_Load;
        }

        private async void ComisionesForm_Load(object sender, EventArgs e)
        {
            await CargarPlanes();
            if (comision != null) SetComision();
        }

        private async Task CargarPlanes()
        {
            var planes = await PlanApiClient.GetAllAsync();
            comboBoxPlan.DataSource = planes;
            comboBoxPlan.DisplayMember = "Desc_plan";
            comboBoxPlan.ValueMember = "Id_plan";
        }

        private void SetComision()
        {
            if (comision == null) return;
            textBoxID_comision.Text = comision.Id_comision.ToString();
            textBoxDesc_comision.Text = comision.Desc_comision;
            numericUpDownAnio.Value = comision.Anio_especialidad;
            comboBoxPlan.SelectedValue = comision.Id_plan;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(textBoxDesc_comision.Text))
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
            ComisionApiClient client = new ComisionApiClient();

            this.Comision.Desc_comision = textBoxDesc_comision.Text.Trim();
            this.Comision.Anio_especialidad = (int)numericUpDownAnio.Value;
            this.Comision.Id_plan = (int)comboBoxPlan.SelectedValue;

            try
            {
                if (this.EditMode)
                {
                    await ComisionApiClient.UpdateAsync(this.Comision);
                    MessageBox.Show("Comisión actualizada correctamente.");
                }
                else
                {
                    await ComisionApiClient.AddAsync(this.Comision);
                    MessageBox.Show("Comisión creada correctamente.");
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar comisión:\n{ex.Message}\n{ex.StackTrace}");
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
