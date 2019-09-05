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
            cbSexo.Text = string.Empty;
            tbApellidos.Text = string.Empty;
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
            estudiante.Telefono = tbApellidos.Text;
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
            tbApellidos.Text = estudiante.Telefono;
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

            if (string.IsNullOrWhiteSpace(tbMatricula.Text) )
            {
                MyErrorProvider.SetError(tbNombre, "EL CAMPO MATRICULA NO PUEDE ESTAR VACIO");
                tbMatricula.Focus();
                realizado = false;
            }

            if (string.IsNullOrWhiteSpace(IDnumericUpDown.Text))
            {
                MyErrorProvider.SetError(IDnumericUpDown, "EL CAMPO ID NO PUEDE ESTAR VACIO");
                IDnumericUpDown.Focus();
                realizado = false;
            }

            if (string.IsNullOrWhiteSpace(tbCedula.Text))
            {
                MyErrorProvider.SetError(tbCedula, "EL CAMPO CEDULA NO PUEDE ESTAR VACIO");
                tbCedula.Focus();
                realizado = false;
            }

            if (string.IsNullOrWhiteSpace(tbApellidos.Text))
            {
                MyErrorProvider.SetError(tbApellidos, "EL CAMPO TELEFONO NO PUEDE ESTAR VACIO");
                tbApellidos.Focus();
                realizado = false;
            }

            if (string.IsNullOrWhiteSpace(tbCelular.Text))
            {
                MyErrorProvider.SetError(tbCelular, "EL CAMPO CELULAR NO PUEDE ESTAR VACIO");
                tbCelular.Focus();
                realizado = false;
            }

            if (string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                MyErrorProvider.SetError(tbEmail, "EL CAMPO EMAIL NO PUEDE ESTAR VACIO");
                tbEmail.Focus();
                realizado = false;
            }

            if (FechaNacimientoTimePicker.Value == DateTime.Now)
            {
                MyErrorProvider.SetError(FechaNacimientoTimePicker, "EL CAMPO FECHA DE NACIMIENTO NO PUEDE SER IGUAL A LA FECHA ACTUAL");
                FechaNacimientoTimePicker.Focus();
                realizado = false;
            }

            if (string.IsNullOrWhiteSpace(cbSexo.Text))
            {
                MyErrorProvider.SetError(cbSexo, "EL CAMPO SEXO NO PUEDE ESTAR VACIO, POR FAVOR SELECCIONE UNA OPCION");
                cbSexo.Focus();
                realizado = false;
            }

            if (string.IsNullOrWhiteSpace(tbBalance.Text))
            {
                MyErrorProvider.SetError(tbBalance, "EL CAMPO BALANCE NO PUEDE ESTAR VACIO, POR FAVOR SELECCIONE UNA OPCION");
                tbBalance.Focus();
                realizado = false;
            }

            return realizado;
        }

        private bool Existe()
        {
            Estudiante estudiante = EstudiantesBLL.Buscar((int)IDnumericUpDown.Value);

            return (estudiante != null);
        }

        private void BtNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtGuardar_Click(object sender, EventArgs e)
        {
            Estudiante estudiante;
            bool realizado = false;

            if (!Validar())
                return;

            estudiante = LlenaCLase();

            if (IDnumericUpDown.Value == 0)
                realizado = EstudiantesBLL.Guardar(estudiante);
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("NO SE PUEDE MODIFICAR UN ESTUDIANTE INEXISTENTE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                realizado = EstudiantesBLL.Modificar(estudiante);
            }

            if (realizado)
            {
                Limpiar();
                MessageBox.Show("GUARDADO EXITOSAMENTE", "GUARDADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("NO SE PUDO GUARDAR", "NO GUARDADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
