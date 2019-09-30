using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parcial1_AP.Entidades;
using Parcial1_AP.BLL;
namespace Parcial1_AP.UI.Consultas
{
    public partial class Consulta : Form
    {
        public Consulta()
        {
            InitializeComponent();
        }

        private void Consultarbutton1_Click(object sender, EventArgs e)
        {
            var listado = new List<Evaluacion>();

            if (CriterioTextBox.Text.Trim().Length > 0 || FiltrarComboBox.SelectedIndex==3)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0://todo
                        listado = EvaluacionBLL.GetList(p => true);
                        break;

                    case 1://ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = EvaluacionBLL.GetList(p => p.ID == id);
                        break;

                    case 2://Estudiante
                        listado = EvaluacionBLL.GetList(p => p.Estudiante.Contains(CriterioTextBox.Text));
                        break;
                    case 3://Fecha
                        listado = EvaluacionBLL.GetList(p => p.Fecha>=DesdeDateTimePicker.Value.Date && p.Fecha <= HastaDateTimePicker.Value);
                        break;

                }
            }
            else
            {
                listado = EvaluacionBLL.GetList(p => true);
            }

           
            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = listado;
        }

        private void CriterioTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

