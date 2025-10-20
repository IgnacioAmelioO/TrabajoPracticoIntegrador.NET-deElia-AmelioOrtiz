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

namespace WindowsForm
{
    public partial class InscripcionDocente : Form
    {
        public InscripcionDocente()
        {
            InitializeComponent();
            this.Load += InscripcionDocente_Load;

            cargosComboBox.Items.Add(new { Text = "Titular", Value = 1 });
            cargosComboBox.Items.Add(new { Text = "Auxiliar", Value = 2 });
            cargosComboBox.Items.Add(new { Text = "Suplente", Value = 3 });
            cargosComboBox.DisplayMember = "Text";
            cargosComboBox.ValueMember = "Value";
            cargosComboBox.SelectedIndex = 0;
        }

        private int _idDocente;

        public int IdDocente
        {
            get => _idDocente;
            set
            {
                _idDocente = value;
            }
        }

        private async void InscripcionDocente_Load(object sender, EventArgs e)
        {
            await LoadAvailableCursosAsync();
        }

        private async Task LoadAvailableCursosAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                var cursosTask = CursoApiClient.GetAllAsync();
                var materiasTask = MateriaApiClient.GetAllAsync();
                var comisionesTask = ComisionApiClient.GetAllAsync();
                var docenteCursosTask = DocenteCursoApiClient.GetByDocenteAsync(_idDocente);

                await Task.WhenAll(cursosTask, materiasTask, comisionesTask, docenteCursosTask);

                var cursos = await cursosTask;
                var materias = await materiasTask;
                var comisiones = await comisionesTask;
                var docenteCursos = await docenteCursosTask;

                var cursosInscriptos = docenteCursos.Select(dc => dc.Id_curso).ToList();
                var cursosDisponibles = cursos.Where(c => !cursosInscriptos.Contains(c.Id_curso)).ToList();

                var cursosView = cursosDisponibles
                    .Select(curso => {
                        var materia = materias.FirstOrDefault(m => m.Id_materia == curso.Id_materia);
                        var comision = comisiones.FirstOrDefault(c => c.Id_comision == curso.Id_comision);

                        return new
                        {
                            curso.Id_curso,
                            Materia = materia?.Desc_materia ?? "Desconocida",
                            Comision = comision?.Desc_comision ?? "Desconocida",
                            AnioCalendario = curso.Anio_calendario,
                            Cupo = curso.Cupo
                        };
                    })
                    .ToList();

                cursoDataGridView.DataSource = cursosView;

                cursoDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                cursoDataGridView.Columns["Id_curso"].Visible = false;

                cursoDataGridView.Columns["Materia"].HeaderText = "Materia";
                cursoDataGridView.Columns["Comision"].HeaderText = "Comisión";
                cursoDataGridView.Columns["AnioCalendario"].HeaderText = "Año Calendario";
                cursoDataGridView.Columns["Cupo"].HeaderText = "Cupo";

                cursoDataGridView.Columns["Materia"].DisplayIndex = 0;
                cursoDataGridView.Columns["Comision"].DisplayIndex = 1;
                cursoDataGridView.Columns["AnioCalendario"].DisplayIndex = 2;
                cursoDataGridView.Columns["Cupo"].DisplayIndex = 3;

                if (cursosView.Count > 0)
                {
                    labelNoData.Visible = false;
                    cursoDataGridView.Visible = true;
                    inscribirseButton.Enabled = true;
                    cursoDataGridView.Rows[0].Selected = true;
                }
                else
                {
                    labelNoData.Visible = true;
                    cursoDataGridView.Visible = false;
                    inscribirseButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los cursos disponibles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                labelNoData.Visible = true;
                labelNoData.Text = "Error al cargar los datos.";
                cursoDataGridView.Visible = false;
                inscribirseButton.Enabled = false;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void inscribirseButton_Click(object sender, EventArgs e)
        {
            if (cursoDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Por favor seleccione un curso para inscribirse.");
                return;
            }

            if (cargosComboBox.SelectedItem == null)
            {
                MessageBox.Show("Por favor seleccione un cargo.");
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                int idCurso = (int)cursoDataGridView.CurrentRow.Cells["Id_curso"].Value;
                dynamic selectedCargo = cargosComboBox.SelectedItem;
                int cargo = selectedCargo.Value;

                var docenteCurso = new DocenteCursoDTO
                {
                    Id_dictado = 0,
                    Id_docente = _idDocente,
                    Id_curso = idCurso,
                    Cargo = cargo
                };

                await DocenteCursoApiClient.AddAsync(docenteCurso);
                
                MessageBox.Show("Inscripción realizada con éxito.", "Inscripción", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar la inscripción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
