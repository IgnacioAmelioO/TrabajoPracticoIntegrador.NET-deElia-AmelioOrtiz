using Api.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms;

namespace WindowsForm
{
    public partial class VistaDocente : Form
    {
        private int _idDocente;

        public VistaDocente()
        {
            InitializeComponent();
            this.Load += VistaDocente_Load;
        }

        public VistaDocente(int idDocente) : this()
        {
            _idDocente = idDocente;
        }

        private async void VistaDocente_Load(object sender, EventArgs e)
        {
            await LoadDocenteCursosAsync();
        }

        private async Task LoadDocenteCursosAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Obtener todos los cursos, materias y comisiones para realizar el mapeo
                var cursosTask = CursoApiClient.GetAllAsync();
                var materiasTask = MateriaApiClient.GetAllAsync();
                var comisionesTask = ComisionApiClient.GetAllAsync();
                var docenteCursosTask = DocenteCursoApiClient.GetByDocenteAsync(_idDocente);

                await Task.WhenAll(cursosTask, materiasTask, comisionesTask, docenteCursosTask);

                var cursos = await cursosTask;
                var materias = await materiasTask;
                var comisiones = await comisionesTask;
                var docenteCursos = await docenteCursosTask;


                // Crear una colección de objetos anónimos con la información combinada
                var docenteCursosView = docenteCursos
                    .Join(cursos,
                          dc => dc.Id_curso,
                          c => c.Id_curso,
                          (docenteCurso, curso) => new { DocenteCurso = docenteCurso, Curso = curso })
                    .Select(x =>
                    {
                        var materia = materias.FirstOrDefault(m => m.Id_materia == x.Curso.Id_materia);
                        var comision = comisiones.FirstOrDefault(c => c.Id_comision == x.Curso.Id_comision);

                        // Mapear el valor numérico del cargo a una cadena descriptiva
                        string cargoDescripcion = x.DocenteCurso.Cargo switch
                        {
                            1 => "Titular",
                            2 => "Auxiliar",
                            3 => "Suplente",
                            _ => "Desconocido"  // Para manejar casos no esperados
                        };

                        return new
                        {
                            x.DocenteCurso.Id_dictado,
                            x.DocenteCurso.Id_curso,
                            x.DocenteCurso.Id_docente,
                            x.DocenteCurso.Cargo,
                            Materia = materia?.Desc_materia ?? "Desconocida",
                            Comision = comision?.Desc_comision ?? "Desconocida",
                            AnioCalendario = x.Curso.Anio_calendario,
                            Cupo = x.Curso.Cupo,
                            CargoDescripcion = cargoDescripcion
                        };
                    })
                    .ToList();

                // Configurar el DataGridView
                cursosMateriaDataGridView.DataSource = docenteCursosView;

                // Configurar la apariencia y el formato de las columnas
                cursosMateriaDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                // Ocultar columnas que no son necesarias para la visualización
                cursosMateriaDataGridView.Columns["Id_dictado"].Visible = false;
                cursosMateriaDataGridView.Columns["Id_curso"].Visible = false;
                cursosMateriaDataGridView.Columns["Id_docente"].Visible = false;
                cursosMateriaDataGridView.Columns["Cargo"].Visible = false;

                // Renombrar columnas para mejor legibilidad
                cursosMateriaDataGridView.Columns["CargoDescripcion"].HeaderText = "Cargo";
                cursosMateriaDataGridView.Columns["Materia"].HeaderText = "Materia";
                cursosMateriaDataGridView.Columns["Comision"].HeaderText = "Comisión";
                cursosMateriaDataGridView.Columns["AnioCalendario"].HeaderText = "Año Calendario";
                cursosMateriaDataGridView.Columns["Cupo"].HeaderText = "Cupo";

                // Establecer el orden de las columnas
                cursosMateriaDataGridView.Columns["Materia"].DisplayIndex = 0;
                cursosMateriaDataGridView.Columns["Comision"].DisplayIndex = 1;
                cursosMateriaDataGridView.Columns["CargoDescripcion"].DisplayIndex = 2;
                cursosMateriaDataGridView.Columns["AnioCalendario"].DisplayIndex = 3;
                cursosMateriaDataGridView.Columns["Cupo"].DisplayIndex = 4;

                if (docenteCursosView.Count > 0)
                {
                    labelNoData.Visible = false;
                }
                else
                {
                    labelNoData.Visible = true;
                    labelNoData.Text = "El docente no tiene cursos asignados.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los cursos del docente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                labelNoData.Visible = true;
                labelNoData.Text = "Error al cargar los datos.";
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void descripcionButton_Click(object sender, EventArgs e)
        {
            if (cursosMateriaDataGridView.CurrentRow != null)
            {
                int id = (int)cursosMateriaDataGridView.CurrentRow.Cells["Id_curso"].Value;


                CursoDTO curso = await CursoApiClient.GetAsync(id);

                if (curso != null)
                {

                    var form = new DescripcionCurso
                    {
                        Curso = curso,
                    };

                    var result = form.ShowDialog();

                }
                else
                {
                    MessageBox.Show("No se pudo obtener el curso seleccionada.");
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un curso para ver los detalles.");
            }
        }

        private async void inscripcionButton_Click(object sender, EventArgs e)
        {
            InscripcionDocente form = new InscripcionDocente();
            form.IdDocente = _idDocente;
            var result = form.ShowDialog();

            // Si la inscripción fue exitosa, actualizar la lista de cursos
            if (result == DialogResult.OK)
            {
                await LoadDocenteCursosAsync();
            }
        }
    }
}
