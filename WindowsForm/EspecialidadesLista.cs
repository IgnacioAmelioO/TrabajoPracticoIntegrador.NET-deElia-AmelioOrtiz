using DTOs;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms;

namespace WindowsForms
{
    public partial class EspecialidadesLista : Form
    {
        public EspecialidadesLista()
        {
            InitializeComponent();
            this.Load += Especialidades_Load;
        }

        private void Especialidades_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private async void buscarButton_click(object sender, EventArgs e)
        {
            if (int.TryParse(inputIdEspecialidad.Text, out int idBuscado))
            {
                Especialidad especialidad = await EspecialidadApiClient.GetAsync(idBuscado);
                this.especialidadesGrid.DataSource = especialidad != null ? new List<Especialidad> { especialidad } : new List<Especialidad>();
            }
            else
            {
                MessageBox.Show("Por favor ingresá un ID válido (número).");
            }
        }

        private async void GetAllAndLoad()
        {
            this.especialidadesGrid.DataSource = null;
            var especialidades = await EspecialidadApiClient.GetAllAsync();

            this.especialidadesGrid.DataSource = especialidades.ToList();

            if (this.especialidadesGrid.Rows.Count > 0)
            {
                this.especialidadesGrid.Rows[0].Selected = true;
                this.eliminarButton.Enabled = true;
                this.modificarButton.Enabled = true;
            }
            else
            {
                this.eliminarButton.Enabled = false;
                this.modificarButton.Enabled = false;
            }
        }

        private void mostrarButton_Click(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            int id;

            id = this.SelectedItem().Id_especialidad;
            await EspecialidadApiClient.DeleteAsync(id);

            this.GetAllAndLoad();
        }

        private Especialidad SelectedItem()
        {
            Especialidad especialidad;

            especialidad = (Especialidad)especialidadesGrid.SelectedRows[0].DataBoundItem;

            return especialidad;
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            if (especialidadesGrid.CurrentRow != null)
            {
                int id = (int)especialidadesGrid.CurrentRow.Cells["Id_especialidad"].Value;

                // Obtener la persona desde la API  
                Especialidad especialidad = await EspecialidadApiClient.GetAsync(id);

                if (especialidad != null)
                {
                    // Abrir el formulario en modo edición  
                    var form = new EspecialidadForm
                    {
                        Especialidad = especialidad,
                        EditMode = true // muy importante para que el botón diga "Guardar cambios"  
                    };

                    var result = form.ShowDialog();
                    this.GetAllAndLoad();
                }
                else
                {
                    MessageBox.Show("No se pudo obtener la especialidad seleccionada.");
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione una especialidad para editar.");
            }
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            EspecialidadForm especialidadDetalle = new EspecialidadForm();

            Especialidad especialidadNueva = new Especialidad();

            especialidadDetalle.Especialidad = especialidadNueva;

            especialidadDetalle.ShowDialog();

            this.GetAllAndLoad();
        }
    }
}
