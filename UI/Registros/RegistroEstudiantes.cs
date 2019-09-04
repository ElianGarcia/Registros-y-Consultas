using Register.BLL;
using Register.Entidades;
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
            tbCedula.Text = string.Empty;
            tbSexo.Text = string.Empty;
            tbTelefono.Text = string.Empty;
            tbCelular.Text = string.Empty;
            tbEmail.Text = string.Empty;
            FechaNacimientoTimePicker.Value = DateTime.Now;
            tbBalance.Text = string.Empty;
            MyErrorProvider.Clear();
        }

        private Estudiante LlenaCLase()
        {
            Estudiante estudiante = new Estudiante();
            estudiante.Id = Convert.ToInt32(IDnumericUpDown.Value);
            estudiante.Matricula = tbMatricula.Text;
            estudiante.Nombre = tbNombre.Text;
            estudiante.Apellidos = tbApellidos.Text;
            estudiante.Cedula = tbCedula.Text;
            estudiante.Telefono = tbTelefono.Text;
            estudiante.Celular = tbCelular.Text;
            estudiante.Email = tbEmail.Text;
            estudiante.FechaNacimiento = FechaNacimientoTimePicker.Value;
            estudiante.Sexo = (char) cbSexo.SelectedItem;
            estudiante.Balance = Convert.ToDouble(tbBalance.Text);
            return estudiante;
        }

        private void LlenaCampos(Estudiante estudiante)
        {
            IDnumericUpDown.Value = estudiante.Id;
            tbMatricula.Text = estudiante.Matricula;
            tbNombre.Text = estudiante.Nombre;
            tbApellidos.Text = estudiante.Apellidos;
            tbCedula.Text = estudiante.Cedula;
            tbTelefono.Text = estudiante.Telefono;
            tbCelular.Text = estudiante.Celular;
            tbEmail.Text = estudiante.Email;
            FechaNacimientoTimePicker.Value  = estudiante.FechaNacimiento;
            cbSexo.SelectedItem = estudiante.Sexo;
            tbBalance.Text = estudiante.Balance.ToString();

        }

        private bool Validar()
        {
            bool realizado = false;
            MyErrorProvider.Clear();

            if(string.IsNullOrWhiteSpace(tbNombre.Text))
            {
                MyErrorProvider.SetError(tbNombre, "EL CAMPO NOMBRE NO PUEDE ESTAR VACIO");
                tbNombre.Focus();
                realizado = false;
            }

            if (string.IsNullOrWhiteSpace(tbApellidos.Text))
            {
                MyErrorProvider.SetError(tbApellidos, "EL CAMPO APELLIDOS NO PUEDE ESTAR VACIO");
                tbApellidos.Focus();
                realizado = false;
            }

            if (string.IsNullOrWhiteSpace(tbMatricula.Text))
            {
                MyErrorProvider.SetError(tbNombre, "EL CAMPO MATRICULA NO PUEDE ESTAR VACIO");
                tbMatricula.Focus();
                realizado = false;
            }

            //
            //TODO: Completar validaciones...
            //
            return realizado;
        }

        private void BtNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtGuardar_Click(object sender, EventArgs e)
        {

        }

        private void BtEliminar_Click(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();

            int id;
            int.TryParse(IDnumericUpDown.Text, out id);

            Limpiar();

            if (EstudiantesBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            } else
            {
                MyErrorProvider.SetError(IDnumericUpDown, "No se puede eliminar un estudiante inexistente");
            }

        }

        private void BtBuscar_Click(object sender, EventArgs e)
        {
            int id;
            Estudiante estudiante = new Estudiante();
            int.TryParse(IDnumericUpDown.Text, out id);

            Limpiar();

            estudiante = EstudiantesBLL.Buscar(id);

            if(estudiante != null)
            {
                LlenaCampos(estudiante);
            }
            else
            {
                MessageBox.Show("Estudiante No Encontrado");
            }

        }
    }
}
