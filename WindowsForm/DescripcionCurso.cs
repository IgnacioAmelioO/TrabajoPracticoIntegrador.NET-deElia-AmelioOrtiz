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
using Api.Clients;

namespace WindowsForm
{
    public partial class DescripcionCurso : Form
    {
        private CursoDTO curso;
        private List<AlumnoInscripcionDTO> inscripciones = new List<AlumnoInscripcionDTO>();
        private List<PersonaDTO> alumnos = new List<PersonaDTO>();
        private readonly string[] condicionesValidas = new string[] { "Activo", "Regular", "Aprobado", "Libre" };
        
        public DescripcionCurso()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.Load += DescripcionCurso_Load;
        }

        public CursoDTO Curso
        {
            get => curso;
            set
            {
                curso = value;
            }
        }

        private async void DescripcionCurso_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = $"Alumnos inscriptos al curso:";

            ConfigurarGrillaAlumnos();

            await CargarAlumnosInscriptosAsync();
        }

        private async Task CargarAlumnosInscriptosAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                var inscripcionesResponse = await AlumnoInscripcionApiClient.GetByCursoAsync(this.Curso.Id_curso);

                inscripciones = inscripcionesResponse.ToList();

                var alumnosIds = inscripciones.Select(i => i.Id_alumno).ToList();
                var personasResponse = await PersonaApiClient.GetAllAsync();
                alumnos = personasResponse
                    .Where(p => alumnosIds.Contains(p.Id_persona))
                    .ToList();

                var materiasResponse = await MateriaApiClient.GetAllAsync();
                var comisionesResponse = await ComisionApiClient.GetAllAsync();
                
                var materia = materiasResponse.FirstOrDefault(m => m.Id_materia == curso.Id_materia);
                var comision = comisionesResponse.FirstOrDefault(c => c.Id_comision == curso.Id_comision);

                lblMateria.Text = $"Materia: {materia?.Desc_materia ?? "Desconocida"}";
                lblComision.Text = $"Comisión: {comision?.Desc_comision ?? "Desconocida"}";
                lblAño.Text = $"Año Calendario: {curso.Anio_calendario}";
                lblCupo.Text = $"Cupo: {curso.Cupo}";

                CargarDatosEnGrillaAlumnos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los alumnos inscriptos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        
        private void ConfigurarGrillaAlumnos()
        {
            dgvAlumnos.AutoGenerateColumns = false;
            dgvAlumnos.Columns.Clear();

            var colIdInscripcion = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id_inscripcion",
                Name = "Id_inscripcion",
                HeaderText = "ID",
                Visible = false
            };

            var colLegajo = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Legajo",
                Name = "Legajo",
                HeaderText = "Legajo",
                Width = 70,
                ReadOnly = true
            };

            var colNombre = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreCompleto",
                Name = "NombreCompleto",
                HeaderText = "Nombre y Apellido",
                Width = 200,
                ReadOnly = true
            };

            var colNota = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nota",
                Name = "Nota",
                HeaderText = "Nota",
                Width = 60
            };
            
            var colCondicion = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Condicion",
                Name = "Condicion",
                HeaderText = "Condición (calculada al guardar)",
                Width = 180,
                ReadOnly = true
            };
            
            dgvAlumnos.Columns.AddRange(new DataGridViewColumn[] {
                colIdInscripcion, colLegajo, colNombre, colNota, colCondicion
            });
        }

        private void CargarDatosEnGrillaAlumnos()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(CargarDatosEnGrillaAlumnos));
                return;
            }
            
            dgvAlumnos.DataSource = null;

            var dt = new DataTable();
            dt.Columns.Add("Id_inscripcion", typeof(int));
            dt.Columns.Add("Legajo", typeof(string));
            dt.Columns.Add("NombreCompleto", typeof(string));
            dt.Columns.Add("Nota", typeof(string));
            dt.Columns.Add("Condicion", typeof(string));
            
            foreach (var inscripcion in inscripciones)
            {
                var alumno = alumnos.FirstOrDefault(a => a.Id_persona == inscripcion.Id_alumno);
                if (alumno == null) continue;
                
                string condicion = inscripcion.Condicion ?? "Activo";
                if (!condicionesValidas.Contains(condicion))
                {
                    condicion = "Activo";
                }
                
                dt.Rows.Add(
                    inscripcion.Id_inscripcion,
                    alumno.Legajo,
                    $"{alumno.Nombre} {alumno.Apellido}",
                    inscripcion.Nota?.ToString() ?? "",
                    condicion
                );
            }
            
            dgvAlumnos.DataSource = dt;
            
            lblNoAlumnos.Visible = dt.Rows.Count == 0;
        }
        
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                bool cambiosGuardados = false;
                
                var dt = dgvAlumnos.DataSource as DataTable;
                if (dt == null)
                {
                    MessageBox.Show("Error al acceder a los datos de la tabla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                for (int i = 0; i < dgvAlumnos.Rows.Count; i++)
                {
                    if (dgvAlumnos.Rows[i].IsNewRow) continue;
                    
                    DataGridViewRow row = dgvAlumnos.Rows[i];
                    int idInscripcion = Convert.ToInt32(row.Cells["Id_inscripcion"].Value);
                    var inscripcion = inscripciones.FirstOrDefault(ins => ins.Id_inscripcion == idInscripcion);
                    
                    if (inscripcion != null)
                    {
                        string notaStr = row.Cells["Nota"].Value?.ToString() ?? "";
                        int? notaNueva = string.IsNullOrEmpty(notaStr) ? null : int.Parse(notaStr);
                        
                        string condicionNueva = "Activo";
                        
                        if (notaNueva.HasValue)
                        {
                            if (notaNueva.Value < 6)
                            {
                                condicionNueva = "Libre";
                            }
                            else if (notaNueva.Value >= 6 && notaNueva.Value < 8)
                            {
                                condicionNueva = "Regular";
                            }
                            else 
                            {
                                condicionNueva = "Aprobado";
                            }
                        }
                        
                        row.Cells["Condicion"].Value = condicionNueva;
                        
                        if (inscripcion.Nota != notaNueva || inscripcion.Condicion != condicionNueva)
                        {
                            inscripcion.Nota = notaNueva;
                            inscripcion.Condicion = condicionNueva;
                            
                            await AlumnoInscripcionApiClient.UpdateAsync(inscripcion);
                            cambiosGuardados = true;
                        }
                    }
                }
                
                if (cambiosGuardados)
                {
                    MessageBox.Show("Los cambios se han guardado correctamente.", "Guardar Cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se detectaron cambios para guardar.", "Guardar Cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Error en el formato de alguna nota. Las notas deben ser números enteros.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los cambios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
