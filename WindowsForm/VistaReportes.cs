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
    public partial class VistaReportes : Form
    {
        public VistaReportes()
        {
            InitializeComponent();
        }

        private void notaPromCursoButton_Click(object sender, EventArgs e)
        {
            ReportePromedioCurso promedioCursoForm = new ReportePromedioCurso();
            promedioCursoForm.ShowDialog();
        }
    }
}
