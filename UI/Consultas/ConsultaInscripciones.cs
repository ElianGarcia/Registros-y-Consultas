using Register.BLL;
using Register.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Register.UI.Consultas
{
    public partial class ConsultaInscripciones : Form
    {
        public ConsultaInscripciones()
        {
            InitializeComponent();
        }

        private void BtConsulta_Click(object sender, EventArgs e)
        {
            var listado = new List<Inscripcion>();

            if (tbCriterio.Text.Trim().Length > 0)
            {
                switch (cbFiltrar.SelectedIndex)
                {
                    case 0:
                        listado = InscripcionesBLL.GetList(inscripcion => true);
                        break;

                    case 1:
                        int id = Convert.ToInt32(tbCriterio.Text);
                        listado = InscripcionesBLL.GetList(inscripcion => inscripcion.Id == id);
                        break;
                }

                listado = listado.Where(c => c.Fecha.Date >= DesdeDateTimePicker.Value.Date && c.Fecha.Date <= HastaDateTimePicker.Value.Date).ToList();
            }
            else
            {
                listado = InscripcionesBLL.GetList(p => true);
            }

            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = listado;
        }
    }
}
