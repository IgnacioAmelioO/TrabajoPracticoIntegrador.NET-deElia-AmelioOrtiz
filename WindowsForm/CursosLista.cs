using DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Api.Clients;

namespace WindowsForm
{
    public partial class CursosLista : Form
    {
        public CursosLista()
        {
            InitializeComponent();
            this.Load += CursosLista_Load;
        }

        private void CursosLista_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private async void buscarButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(inputIdCurso.Text, out int idBuscado))
            {
                CursoDTO curso = await CursoApiClient.GetAsync(idBuscado);
                cursosGrid.DataSource = curso != null ? new List<CursoDTO> { curso } : new List<CursoDTO>();
            }
            else
            {
                MessageBox.Show("Por favor ingresá un ID válido (número).");
            }
        }

        private async void GetAllAndLoad()
        {
            cursosGrid.DataSource = null;
            var cursos = await CursoApiClient.GetAllAsync();
            cursosGrid.DataSource = cursos.ToList();

            if (cursosGrid.Rows.Count > 0)
            {
                cursosGrid.Rows[0].Selected = true;
                eliminarButton.Enabled = true;
                modificarButton.Enabled = true;
            }
            else
            {
                eliminarButton.Enabled = false;
                modificarButton.Enabled = false;
            }
        }

        private void mostrarTodosButton_Click(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            int id = this.SelectedItem().Id_curso;
            await CursoApiClient.DeleteAsync(id);
            this.GetAllAndLoad();
        }

        private CursoDTO SelectedItem()
        {
            return (CursoDTO)cursosGrid.SelectedRows[0].DataBoundItem;
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            if (cursosGrid.CurrentRow != null)
            {
                int id = (int)cursosGrid.CurrentRow.Cells["Id_curso"].Value;
                CursoDTO curso = await CursoApiClient.GetAsync(id);

                if (curso != null)
                {
                    var form = new CursosForm
                    {
                        Curso = curso,
                        EditMode = true
                    };
                    var result = form.ShowDialog();
                    this.GetAllAndLoad();
                }
                else
                {
                    MessageBox.Show("No se pudo obtener el curso seleccionado.");
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un curso para editar.");
            }
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            var form = new CursosForm();
            form.ShowDialog();
            this.GetAllAndLoad();
        }
    }
}