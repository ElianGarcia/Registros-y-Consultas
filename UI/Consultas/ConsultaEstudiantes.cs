using Register.BLL;
using Register.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Register.UI.Consultas
{
    public partial class ConsultaEstudiantes : Form
    {
        public ConsultaEstudiantes()
        {
            InitializeComponent();
        }

        private void ConsultaButton_Click(object sender, EventArgs e)
        {
            var listado = new List<Estudiante>();

            if (tbCriterio.Text.Trim().Length > 0)
            {
                switch (cbFiltrar.SelectedIndex)
                {
                    case 0:
                        listado = EstudiantesBLL.GetList(estudiante => true);
                        break;

                    case 1:
                        int id = Convert.ToInt32(tbCriterio.Text);
                        listado = EstudiantesBLL.GetList(estudiante => estudiante.Id == id);
                        break;

                    case 2:
                        listado = EstudiantesBLL.GetList(estudiante => estudiante.Nombre.Contains(tbCriterio.Text));
                        break;

                    case 3:
                        listado = EstudiantesBLL.GetList(estudiante => estudiante.Cedula.Contains(tbCriterio.Text));
                        break;

                    case 4:
                        listado = EstudiantesBLL.GetList(estudiante => estudiante.Matricula.Contains(tbCriterio.Text));
                        break;
                }

                listado = listado.Where(c => c.FechaDeNacimiento.Date >= DesdeDateTimePicker.Value.Date && c.FechaDeNacimiento.Date <= HastaDateTimePicker.Value.Date).ToList();
            }
            else
            {
                listado = EstudiantesBLL.GetList(p => true);
            }

            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = listado;
        }
    }
}
