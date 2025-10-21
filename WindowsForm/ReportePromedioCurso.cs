using Api.Clients;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class ReportePromedioCurso : Form
    {
        public ReportePromedioCurso()
        {
            InitializeComponent();
        }

        private async void ReportePromedioCurso_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Cargar cursos desde la API
                var cursos = await CursoApiClient.GetAllAsync();

                if (cursos == null || !cursos.Any())
                {
                    MessageBox.Show("No hay cursos disponibles para generar reportes.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var cursosView = cursos.Select(c => new
                {
                    c.Id_curso,
                    Nombre = "Curso " + c.Id_curso + " - " + c.Anio_calendario
                }).ToList();

                cbCursos.DataSource = cursosView;
                cbCursos.DisplayMember = "Nombre";
                cbCursos.ValueMember = "Id_curso";
            }
            catch (UnauthorizedAccessException)
            {
                // Esta excepción se maneja automáticamente por el framework
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los cursos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (cbCursos.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un curso primero.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idCurso = (int)cbCursos.SelectedValue;
                
                // Deshabilitar el botón durante la generación del reporte
                btnGenerarReporte.Enabled = false;
                btnGenerarReporte.Text = "Generando...";
                Cursor = Cursors.WaitCursor;

                // Usar el nuevo ReportApiClient para generar el reporte
                string ruta = await ReporteApiClient.GenerarReportePromedioCursoAsync(idCurso);
                
                MessageBox.Show($"Reporte generado correctamente:\n{ruta}", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Preguntar si desea abrir el archivo generado
                var resultado = MessageBox.Show("¿Desea abrir el reporte ahora?", "Reporte generado",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = ruta,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"No se pudo abrir el archivo: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Esta excepción se maneja automáticamente por el framework
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Restaurar el estado del botón
                btnGenerarReporte.Enabled = true;
                btnGenerarReporte.Text = "Generar Reporte";
                Cursor = Cursors.Default;
            }
        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
