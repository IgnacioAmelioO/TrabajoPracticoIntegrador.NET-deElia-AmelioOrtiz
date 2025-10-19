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
    public partial class DescripcionCurso : Form
    {
        public DescripcionCurso()
        {
            InitializeComponent();
        }
        private CursoDTO curso;
        public CursoDTO Curso
        {
            get => curso;
            set
            {
                curso = value;
            }
        }


    }
}
