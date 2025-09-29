using DTOs;
using System;
using System.Windows.Forms;
using Api.Clients;

namespace WindowsForm
{
    public partial class CursosForm : Form
    {
        public bool EditMode { get; set; } = false;
        private CursoDTO curso;
        public CursoDTO Curso
        {
            get => curso;
            set
            {
                curso = value;
                if (IsHandleCreated)
                {
                    SetCurso();
                    buttonCrear.Text = "Guardar cambios";
                }
                else
                {
                    buttonCrear.Text = "Crear";
                }
            }
        }

        public CursosForm()
        {
            InitializeComponent();
            Load += CursosForm_Load;
        }

        private async void CursosForm_Load(object sender, EventArgs e)
        {
            
            comboBoxMateria.DataSource = await MateriaApiClient.GetAllAsync();
            comboBoxMateria.DisplayMember = "Desc_materia";
            comboBoxMateria.ValueMember = "Id_materia";

            comboBoxComision.DataSource = await ComisionApiClient.GetAllAsync();
            comboBoxComision.DisplayMember = "Desc_comision";
            comboBoxComision.ValueMember = "Id_comision";

            if (curso != null) SetCurso();
        }

        private void SetCurso()
        {
            if (curso == null) return;
            textBoxIdCurso.Text = curso.Id_curso.ToString();
            textBoxAnio.Text = curso.Anio_calendario.ToString();
            textBoxCupo.Text = curso.Cupo.ToString();
            comboBoxMateria.SelectedValue = curso.Id_materia;
            comboBoxComision.SelectedValue = curso.Id_comision;
        }

        private bool ValidarCampos()
        {
            if (!int.TryParse(textBoxAnio.Text, out int anio) || anio <= 0)
            {
                MessageBox.Show("Ingrese un año válido.");
                textBoxAnio.Focus();
                return false;
            }
            if (!int.TryParse(textBoxCupo.Text, out int cupo) || cupo <= 0)
            {
                MessageBox.Show("Ingrese un cupo válido.");
                textBoxCupo.Focus();
                return false;
            }
            if (comboBoxMateria.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una materia.");
                comboBoxMateria.Focus();
                return false;
            }
            if (comboBoxComision.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una comisión.");
                comboBoxComision.Focus();
                return false;
            }
            return true;
        }

        private async void buttonCrear_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            var nuevoCurso = new CursoDTO
            {
                Id_curso = EditMode ? curso.Id_curso : 0,
                Anio_calendario = int.Parse(textBoxAnio.Text),
                Cupo = int.Parse(textBoxCupo.Text),
                Id_materia = (int)comboBoxMateria.SelectedValue,
                Id_comision = (int)comboBoxComision.SelectedValue
            };
            try
            {
                if (EditMode)
                {
                    await CursoApiClient.UpdateAsync(nuevoCurso);
                    MessageBox.Show("Curso actualizado correctamente.");
                }
                else
                {
                    await CursoApiClient.AddAsync(nuevoCurso);
                    MessageBox.Show("Curso creado correctamente.");
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el curso:\n{ex.Message}");
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}               