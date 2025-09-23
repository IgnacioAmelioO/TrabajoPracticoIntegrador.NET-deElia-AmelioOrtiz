using DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Api.Clients;

namespace WindowsForm
{
    public partial class PlanesLista : Form
    {
        public PlanesLista()
        {
            InitializeComponent();
            this.Load += PlanesLista_Load;
        }

        private void PlanesLista_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private async void buscarButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(inputIdPlan.Text, out int idBuscado))
            {
                PlanDTO plan = await PlanApiClient.GetAsync(idBuscado);
                planesGrid.DataSource = plan != null ? new List<PlanDTO> { plan } : new List<PlanDTO>();
            }
            else
            {
                MessageBox.Show("Por favor ingresá un ID válido (número).");
            }
        }

        private async void GetAllAndLoad()
        {
            planesGrid.DataSource = null;
            var planes = await PlanApiClient.GetAllAsync();
            planesGrid.DataSource = planes.ToList();

            if (planesGrid.Rows.Count > 0)
            {
                planesGrid.Rows[0].Selected = true;
                eliminarButton.Enabled = true;
                modificarButton.Enabled = true;
            }
            else
            {
                eliminarButton.Enabled = false;
                modificarButton.Enabled = false;
            }
        }

        private void mostrarButton_Click(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            int id = this.SelectedItem().Id_plan;
            await PlanApiClient.DeleteAsync(id);
            this.GetAllAndLoad();
        }

        private PlanDTO SelectedItem()
        {
            return (PlanDTO)planesGrid.SelectedRows[0].DataBoundItem;
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            if (planesGrid.CurrentRow != null)
            {
                int id = (int)planesGrid.CurrentRow.Cells["Id_plan"].Value;
                PlanDTO plan = await PlanApiClient.GetAsync(id);

                if (plan != null)
                {
                    var form = new PlanesForm
                    {
                        Plan = plan,
                        EditMode = true
                    };
                    var result = form.ShowDialog();
                    this.GetAllAndLoad();
                }
                else
                {
                    MessageBox.Show("No se pudo obtener el plan seleccionado.");
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un plan para editar.");
            }
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            var form = new PlanesForm();
            form.ShowDialog();
            this.GetAllAndLoad();
        }

        private void mostrarTodosButton_Click(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }
    }
}
