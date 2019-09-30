using Parcial1_AP.UI.Registros;
using Parcial1_AP.UI.Consultas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1_AP
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void RegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.Show();
        }

        private void ConsultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta consulta = new Consulta();
            consulta.Show();

        }
    }
}
