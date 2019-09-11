using Register.BLL;
using Register.Entidades;
using System;
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
            Inscripcion inscripcion = new Inscripcion();
            inscripcion.Id = Convert.ToInt32(IDnumericUpDown.Value);
            inscripcion.Comentarios = tbComentario.Text;
            inscripcion.Deposito = Convert.ToSingle(tbDeposito.Text);
            inscripcion.Balance = Convert.ToSingle(tbBalance.Text);
            inscripcion.Fecha = FechaTimePicker.Value;
            inscripcion.Monto = Convert.ToSingle(tbMonto.Text);

            return inscripcion;
        }

        private void LlenaCampos(Inscripcion inscripcion)
        {
            IDnumericUpDown.Value = inscripcion.Id;
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
            Inscripcion inscripcion = InscripcionesBLL.Buscar((int)IDnumericUpDown.Value);

            return (inscripcion != null);
        }

        private void BtBuscar_Click(object sender, EventArgs e)
        {
            int id;
            Inscripcion inscripcion = new Inscripcion();
            int.TryParse(IDnumericUpDown.Text, out id);

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

        private void BtNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtGuardar_Click(object sender, EventArgs e)
        {
            Inscripcion inscripcion = new Inscripcion();
            bool realizado = false;

            if (!Validar())
                return;

            inscripcion = LlenaCLase();

            if (IDnumericUpDown.Value == 0)
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
                Limpiar();
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
            int.TryParse(IDnumericUpDown.Text, out id);

            Limpiar();

            if (InscripcionesBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminada correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                errorProvider.SetError(IDnumericUpDown, "No se puede eliminar una inscripcion inexistente");
            }
        }
    }
}
