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
using Api.Clients;

namespace WindowsForm
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void personaButton_Click(object sender, EventArgs e)
        {
            PersonaLista personaLista = new PersonaLista();
            personaLista.ShowDialog();
        }

        private void especialidadButton_Click(object sender, EventArgs e)
        {
            EspecialidadesLista especialidadLista = new EspecialidadesLista();
            especialidadLista.ShowDialog();
        }
    }
}
