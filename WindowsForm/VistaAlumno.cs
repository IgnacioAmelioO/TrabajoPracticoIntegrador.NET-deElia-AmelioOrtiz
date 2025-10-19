using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Api.Clients;
using DTOs;

namespace WindowsForm
{
    public partial class VistaAlumno : Form
    {
        
        private PersonaDTO? persona;
        public PersonaDTO? Persona
        {
            get => persona;
            set
            {
                persona = value;
                UpdateWelcomeLabel();
            }
        }

        private List<AlumnoInscripcionDTO> inscripciones = new();

        public VistaAlumno()
        {
            InitializeComponent();
        }

        public VistaAlumno(PersonaDTO personaRecibida) : this() 
        {
            
            this.Persona = personaRecibida;
        }
        private void UpdateWelcomeLabel()
        {
            if (lblWelcome == null) return;
            if (persona == null)
                lblWelcome.Text = "Bienvenido, (no identificado)";
            else
                lblWelcome.Text = $"Bienvenido, {persona.Nombre} {persona.Apellido}";
        }

        private async void VistaAlumno_Load(object sender, EventArgs e)
        {
            UpdateWelcomeLabel();
            await LoadInscripcionesAsync();
        }

        private async void btnRefrescar_Click(object sender, EventArgs e)
        {
            await LoadInscripcionesAsync();
        }

        private async Task LoadInscripcionesAsync()
        {
            try
            {
                inscripcionesGrid.DataSource = null;

                if (persona == null)
                {
                    MessageBox.Show("No se ha proporcionado la persona del usuario conectado. Configure la propiedad Persona antes de mostrar este formulario.", "Usuario no identificado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                try
                {
                    var byAlumno = await AlumnoInscripcionApiClient.GetByAlumnoAsync(persona.Id_persona);
                    inscripciones = byAlumno?.ToList() ?? new List<AlumnoInscripcionDTO>();
                }
                catch
                {

                }

               
                var cursos = (await CursoApiClient.GetAllAsync())?.ToList() ?? new List<CursoDTO>();
                var materias = (await MateriaApiClient.GetAllAsync())?.ToList() ?? new List<MateriaDTO>();
                var comisiones = (await ComisionApiClient.GetAllAsync())?.ToList() ?? new List<ComisionDTO>();

                var view = inscripciones.Select(i =>
                {
                    var curso = cursos.FirstOrDefault(c => c.Id_curso == i.Id_curso);
                    var materia = curso != null ? materias.FirstOrDefault(m => m.Id_materia == curso.Id_materia) : null;
                    var comision = curso != null ? comisiones.FirstOrDefault(cm => cm.Id_comision == curso.Id_comision) : null;

                    return new
                    {
                        Anio_calendario = curso?.Anio_calendario ?? 0,
                        Materia = materia?.Desc_materia ?? "Desconocida",
                        Comision = comision?.Desc_comision ?? "Desconocida",
                        Nota = i.Nota.HasValue ? i.Nota.ToString() : string.Empty,
                        Estado = i.Condicion ?? "Activo"
                    };
                }).ToList();

                inscripcionesGrid.DataSource = view;

                if (inscripcionesGrid.Rows.Count > 0)
                {
                    inscripcionesGrid.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar inscripciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnInscribirse_Click(object sender, EventArgs e)
        {
            if (persona == null)
            {
                MessageBox.Show("Usuario no identificado. No se puede realizar la inscripción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
               
                var cursos = (await CursoApiClient.GetAllAsync())?.ToList() ?? new List<CursoDTO>();
                var disponibles = cursos.Where(c => c.Cupo > 0).ToList();

                var inscriptosIds = inscripciones.Select(i => i.Id_curso).ToHashSet();
                disponibles = disponibles.Where(c => !inscriptosIds.Contains(c.Id_curso)).ToList();

                if (!disponibles.Any())
                {
                    MessageBox.Show("No hay cursos disponibles para inscribirse (o ya estás inscripto en todos los cursos con cupo).", "Sin cursos disponibles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                
                using var selector = new Form
                {
                    Text = "Seleccionar curso para inscribirse",
                    Width = 700,
                    Height = 420,
                    StartPosition = FormStartPosition.CenterParent
                };

                var grid = new DataGridView
                {
                    Dock = DockStyle.Top,
                    Height = 320,
                    ReadOnly = true,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                    AutoGenerateColumns = false
                };

                grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id_curso", HeaderText = "Id", Name = "Id_curso" });
                grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Materia", HeaderText = "Materia" });
                grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Comision", HeaderText = "Comisión" });
                grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Anio_calendario", HeaderText = "Año" });
                grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cupo", HeaderText = "Cupo" });

                var materias = (await MateriaApiClient.GetAllAsync())?.ToList() ?? new List<MateriaDTO>();
                var comisiones = (await ComisionApiClient.GetAllAsync())?.ToList() ?? new List<ComisionDTO>();

                var gridData = disponibles.Select(c => new
                {
                    c.Id_curso,
                    Materia = materias.FirstOrDefault(m => m.Id_materia == c.Id_materia)?.Desc_materia ?? $"Materia {c.Id_materia}",
                    Comision = comisiones.FirstOrDefault(cm => cm.Id_comision == c.Id_comision)?.Desc_comision ?? $"Comisión {c.Id_comision}",
                    c.Anio_calendario,
                    c.Cupo
                }).ToList();

                grid.DataSource = gridData;

                var btnAceptar = new Button { Text = "Inscribirse", Dock = DockStyle.Bottom, Height = 36 };
                var btnCancelar = new Button { Text = "Cancelar", Dock = DockStyle.Bottom, Height = 36 };

                selector.Controls.Add(grid);
                selector.Controls.Add(btnAceptar);
                selector.Controls.Add(btnCancelar);

                btnCancelar.Click += (s, ea) => selector.DialogResult = DialogResult.Cancel;

                btnAceptar.Click += async (s, ea) =>
                {
                    if (grid.CurrentRow == null)
                    {
                        MessageBox.Show("Seleccione un curso para inscribirse.", "Seleccione curso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    int idCurso = (int)grid.CurrentRow.Cells["Id_curso"].Value;

                    try
                    {
                        var nueva = new AlumnoInscripcionDTO
                        {
                            Id_inscripcion = 0,
                            Id_alumno = persona.Id_persona,
                            Id_curso = idCurso,
                            Nota = null,
                            Condicion = "Activo"
                        };

                        await AlumnoInscripcionApiClient.AddAsync(nueva);

                        MessageBox.Show("Inscripción realizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        selector.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al inscribirse: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                var dialog = selector.ShowDialog(this);

                if (dialog == DialogResult.OK)
                {
                    await LoadInscripcionesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener cursos disponibles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
