using DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Api.Clients;
using System.Collections.Generic;

namespace WindowsForms
{
    public partial class MateriasLista : Form
    {
        private readonly HttpClient httpClient = new HttpClient();

        public MateriasLista()
        {
            InitializeComponent();
            Load += MateriasLista_Load;
        }

        private async void MateriasLista_Load(object sender, EventArgs e)
        {
            await CargarMaterias();
        }

        private async Task CargarMaterias()
        {
            try
            {
                IEnumerable<MateriaDTO> lista = await MateriaApiClient.GetAllAsync();
                dgvMaterias.DataSource = null;
                dgvMaterias.DataSource = new List<MateriaDTO>(lista);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar materias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private MateriaDTO? GetSeleccionada()
        {
            if (dgvMaterias.CurrentRow == null) return null;
            return dgvMaterias.CurrentRow.DataBoundItem as MateriaDTO;
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            using var form = new MateriasForm();
            form.EditMode = false;
            form.Materia = new MateriaDTO();
            if (form.ShowDialog(this) == DialogResult.OK)
                await CargarMaterias();
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            var sel = GetSeleccionada();
            if (sel == null)
            {
                MessageBox.Show("Seleccione una materia.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var entidad = await MateriaApiClient.GetAsync(sel.Id_materia);
                if (entidad == null)
                {
                    MessageBox.Show("Entidad no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await CargarMaterias();
                    return;
                }

                using var form = new MateriasForm();
                form.EditMode = true;
                form.Materia = entidad;
                if (form.ShowDialog(this) == DialogResult.OK)
                    await CargarMaterias();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener materia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var sel = GetSeleccionada();
            if (sel == null)
            {
                MessageBox.Show("Seleccione una materia.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Eliminar la materia seleccionada?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                await MateriaApiClient.DeleteAsync(sel.Id_materia);
                await CargarMaterias();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRefrescar_Click(object sender, EventArgs e)
        {
            await CargarMaterias();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
