using Register.BLL;
using Register.Entidades;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace Register.UI.Registros
{
    public partial class RegistroInscripcion : Form
    {
        public RegistroInscripcion()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IDInscripcionUpDown.Value = 0;
            IDnumericUpDown.Value = 0;
            FechaTimePicker.Value = DateTime.Now;
            tbComentario.Text = string.Empty;
            tbBalance.Text = string.Empty;
            tbMonto.Text = string.Empty;
            tbDeposito.Text = string.Empty;
            errorProvider.Clear();
        }

        private Inscripcion LlenaCLase()
        {
            if (!Validar())
                return null;

            Inscripcion inscripcion = new Inscripcion();
            inscripcion.Id = Convert.ToInt32(IDInscripcionUpDown.Value);
            inscripcion.Comentarios = tbComentario.Text;
            inscripcion.Deposito = Convert.ToSingle(tbDeposito.Text);
            
            inscripcion.Balance = Convert.ToSingle(tbMonto.Text);
            inscripcion.Balance = (inscripcion.Balance) - (Convert.ToSingle(tbDeposito.Text));
            
            tbBalance.Text = inscripcion.Balance.ToString();
            inscripcion.Fecha = FechaTimePicker.Value;
            inscripcion.Monto = Convert.ToSingle(tbMonto.Text);

            return inscripcion;
        }

        private void LlenaCampos(Inscripcion inscripcion)
        {
            IDInscripcionUpDown.Value = inscripcion.Id;
            tbMonto.Text = inscripcion.Monto.ToString();
            tbComentario.Text = inscripcion.Comentarios;
            tbDeposito.Text = inscripcion.Deposito.ToString();
            FechaTimePicker.Value = inscripcion.Fecha;
            tbBalance.Text = inscripcion.Balance.ToString();
        }

        private bool Validar()
        {
            bool realizado = true;
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(tbMonto.Text))
            {
                errorProvider.SetError(tbMonto, "EL CAMPO MONTO NO PUEDE ESTAR VACIO");
                tbMonto.Focus();
                realizado = false;
            }

            if (string.IsNullOrWhiteSpace(tbDeposito.Text))
            {
                errorProvider.SetError(tbDeposito, "EL CAMPO MONTO NO PUEDE ESTAR VACIO");
                tbDeposito.Focus();
                realizado = false;
            }

            if (string.IsNullOrWhiteSpace(tbComentario.Text))
            {
                errorProvider.SetError(tbComentario, "EL CAMPO COMENTARIOS NO PUEDE ESTAR VACIO");
                tbComentario.Focus();
                realizado = false;
            }

            if (FechaTimePicker.Value == DateTime.Now)
            {
                errorProvider.SetError(FechaTimePicker, "EL CAMPO FECHA NO PUEDE SER IGUAL A LA FECHA ACTUAL");
                FechaTimePicker.Focus();
                realizado = false;
            }

            return realizado;
        }

        private bool Existe()
        {
            Inscripcion inscripcion = InscripcionesBLL.Buscar((int)IDInscripcionUpDown.Value);

            return (inscripcion != null);
        }

        private bool EstudianteExiste()
        {
            Estudiante estudiante = EstudiantesBLL.Buscar(Convert.ToInt32(IDnumericUpDown.Value));
            return (estudiante != null);
        }

        private void BtBuscar_Click(object sender, EventArgs e)
        {
            int id;
            Inscripcion inscripcion = new Inscripcion();
            int.TryParse(IDInscripcionUpDown.Text, out id);

            Limpiar();

            inscripcion = InscripcionesBLL.Buscar(id);

            if (inscripcion != null)
            {
                LlenaCampos(inscripcion);
            }
            else
            {
                MessageBox.Show("Inscripcion No Encontrada");
            }
        }

        private void BtGuardar_Click(object sender, EventArgs e)
        {
            Inscripcion inscripcion = new Inscripcion();
            bool realizado = false;

            if (!Validar())
                return;

            inscripcion = LlenaCLase();

            if (Convert.ToInt32(IDInscripcionUpDown.Value) == 0 && EstudianteExiste() == true)
                realizado = InscripcionesBLL.Guardar(inscripcion);
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("NO SE PUEDE MODIFICAR UNA INSCRIPCION INEXISTENTE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                realizado = InscripcionesBLL.Modificar(inscripcion);
            }

            if (realizado)
            {
                //Limpiar();
                MessageBox.Show("GUARDADO EXITOSAMENTE", "GUARDADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("NO SE PUDO GUARDAR", "NO GUARDADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtEliminar_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            int id;
            int.TryParse(IDInscripcionUpDown.Text, out id);

            Limpiar();

            if (InscripcionesBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminada correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                errorProvider.SetError(IDInscripcionUpDown, "No se puede eliminar una inscripcion inexistente");
            }
        }

        private void BtNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void TbMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;

            if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == cultureInfo.NumberFormat.NumberDecimalSeparator)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void TbDeposito_KeyPress(object sender, KeyPressEventArgs e)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;

            if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == cultureInfo.NumberFormat.NumberDecimalSeparator)
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
