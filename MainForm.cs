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

        private void RegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroEstudiantes registro = new RegistroEstudiantes();
            this.Hide();
            registro.Show();
            
        }

        private void ConsultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaEstudiantes consulta = new ConsultaEstudiantes();
            this.Hide();
            consulta.Show();
        }
    }
}
