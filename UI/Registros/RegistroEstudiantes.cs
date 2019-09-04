using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Register.UI.Registros
{
    public partial class RegistroEstudiantes : Form
    {
        public RegistroEstudiantes()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IDnumericUpDown.Value = 0;
            tbMatricula.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbApellidos.Text = string.Empty;
            tbNombre.Text = string.Empty;
            tbSexo.Text = string.Empty;
            tbEmail.Text = string.Empty;
        }

        private void BtNuevo_Click(object sender, EventArgs e)
        {

        }

        private void BtGuardar_Click(object sender, EventArgs e)
        {

        }

        private void BtEliminar_Click(object sender, EventArgs e)
        {

        }

        private void BtBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
