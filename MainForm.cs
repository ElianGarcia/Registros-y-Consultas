using Register.UI.Consultas;
using Register.UI.Registros;
using System;
using System.Windows.Forms;

namespace Register
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void InscripcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroInscripcion registroInscripcion = new RegistroInscripcion();
            registroInscripcion.MdiParent = this;
            registroInscripcion.Show();
        }

        private void EstudianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroEstudiantes registro = new RegistroEstudiantes();
            registro.MdiParent = this;
            registro.Show();
        }

        private void InscripcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaInscripciones consultaInscripciones = new ConsultaInscripciones();
            consultaInscripciones.MdiParent = this;
            consultaInscripciones.Show();
        }

        private void EstudiantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaEstudiantes consultaEstudiantes = new ConsultaEstudiantes();
            consultaEstudiantes.MdiParent = this;
            consultaEstudiantes.Show();
        }
    }
}
