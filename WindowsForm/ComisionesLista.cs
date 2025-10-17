using DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Api.Clients;
using System.Collections.Generic;

namespace WindowsForms
{
    public partial class ComisionesLista : Form
    {
        private readonly HttpClient httpClient = new HttpClient();

        public ComisionesLista()
        {
            InitializeComponent();
            Load += ComisionesLista_Load;
        }

        private async void ComisionesLista_Load(object sender, EventArgs e)
        {
            await CargarComisiones();
        }

        private async Task CargarComisiones()
        {
            try
            {
                IEnumerable<ComisionDTO> lista = await ComisionApiClient.GetAllAsync();
                dgvComisiones.DataSource = null;
                dgvComisiones.DataSource = new List<ComisionDTO>(lista);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar comisiones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ComisionDTO? GetSeleccionada()
        {
            if (dgvComisiones.CurrentRow == null) return null;
            return dgvComisiones.CurrentRow.DataBoundItem as ComisionDTO;
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            using var form = new ComisionesForm();
            form.EditMode = false;
            form.Comision = new ComisionDTO();
            if (form.ShowDialog(this) == DialogResult.OK)
                await CargarComisiones();
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            var sel = GetSeleccionada();
            if (sel == null)
            {
                MessageBox.Show("Seleccione una comisión.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var entidad = await ComisionApiClient.GetAsync(sel.Id_comision);
                if (entidad == null)
                {
                    MessageBox.Show("Entidad no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await CargarComisiones();
                    return;
                }

                using var form = new ComisionesForm();
                form.EditMode = true;
                form.Comision = entidad;
                if (form.ShowDialog(this) == DialogResult.OK)
                    await CargarComisiones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener comisión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var sel = GetSeleccionada();
            if (sel == null)
            {
                MessageBox.Show("Seleccione una comisión.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Eliminar la comisión seleccionada?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                await ComisionApiClient.DeleteAsync(sel.Id_comision);
                await CargarComisiones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRefrescar_Click(object sender, EventArgs e)
        {
            await CargarComisiones();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
