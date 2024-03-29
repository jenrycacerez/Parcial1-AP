﻿using Parcial1_AP.BLL;
using Parcial1_AP.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1_AP.UI.Registros
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }
        public void limpiar()
        {
            IDnumericUpDown.Value = 0;
            EstudiantetextBox.Text = string.Empty;
            FechadateTimePicker.Value = DateTime.Now;
            ValortextBox.Text = string.Empty;
            LogradotextBox.Text = string.Empty;
            PerdidotextBox.Text = string.Empty;
            PronosticocomboBox.Text = string.Empty;
            ErrorProvider.Clear();

        }

        private Evaluacion LlenaClase()
        {
            Evaluacion evaluacion = new Evaluacion();
            evaluacion.ID = (int)IDnumericUpDown.Value;
            evaluacion.Fecha = FechadateTimePicker.Value;
            evaluacion.Estudiante = EstudiantetextBox.Text;
            evaluacion.Valor = Convert.ToDecimal(ValortextBox.Text);
            evaluacion.Logrado = Convert.ToDecimal(LogradotextBox.Text);
            evaluacion.Perdido = evaluacion.Valor - evaluacion.Logrado;
            evaluacion.Pronostico = PronosticocomboBox.SelectedIndex;

            return evaluacion;
        }
        private Evaluacion LlenaClase(Evaluacion evaluacion)
        {

            IDnumericUpDown.Value = evaluacion.ID;
            FechadateTimePicker.Value = evaluacion.Fecha;
            EstudiantetextBox.Text = evaluacion.Estudiante;
            ValortextBox.Text = Convert.ToString(evaluacion.Valor);
            LogradotextBox.Text = Convert.ToString(evaluacion.Logrado);
            PerdidotextBox.Text = Convert.ToString(evaluacion.Perdido);
            PronosticocomboBox.SelectedIndex = evaluacion.Pronostico;

            return evaluacion;
        }



        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id;
            Evaluacion evaluacion = new Evaluacion();
            int.TryParse(IDnumericUpDown.Text, out id);

            limpiar();

            evaluacion = EvaluacionBLL.Buscar(id);

            if (evaluacion != null)
            {
              //  MessageBox.Show("Persona Encontrada");
                LlenaClase(evaluacion);
            }
            else
            {
                MessageBox.Show("Persona no Encontada");
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            limpiar();
        }


        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Evaluacion personas = new Evaluacion();

            if (!Validar())
                return;

            Calcular();

            personas = LlenaClase();

            if (IDnumericUpDown.Value == 0)
                paso = EvaluacionBLL.Guardar(personas);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un registro que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = EvaluacionBLL.Modificar(personas);
            }

            if (paso)
            {
                limpiar();
                MessageBox.Show("Guardado", "Existe", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No Guardado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Evaluacion evaluacion = EvaluacionBLL.Buscar(Convert.ToInt32(IDnumericUpDown.Value));

            return (evaluacion != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(Convert.ToString(FechadateTimePicker.Value)))
            {
                ErrorProvider.SetError(FechadateTimePicker, "El campo Fecha no puede estar vacio");
              
                paso = false;
            }
            

            if (string.IsNullOrWhiteSpace(EstudiantetextBox.Text))
            {
                ErrorProvider.SetError(EstudiantetextBox, "El campo Estudiante no puede estar vacio");
               
                paso = false;
            }
            else
            {
                ErrorProvider.SetError(EstudiantetextBox, "");
            }


            if (string.IsNullOrWhiteSpace(ValortextBox.Text))
            {
                ErrorProvider.SetError(ValortextBox, "El campo Valor no puede estar vacio");
               
                paso = false;
            }
            else 
            {
                ErrorProvider.SetError(ValortextBox, "");
            }


            if (string.IsNullOrWhiteSpace(LogradotextBox.Text))
            {
                ErrorProvider.SetError(LogradotextBox, "El campo Logrado no puede estar vacio");
                
                paso = false;
            }
            else
            {
                ErrorProvider.SetError(LogradotextBox, "");
            }

            if (ValortextBox.Text.Trim().Length <= 0 || LogradotextBox.Text.Trim().Length <= 0)
            {
                return false;
            }

            //Validando el valor de los campos Valor y Logrado

            if (Convert.ToDecimal(ValortextBox.Text) < 0 || Convert.ToDecimal(ValortextBox.Text) > 100)
            {
                ErrorProvider.SetError(ValortextBox, "El campo Valor no puede tener un valor menor que 0 ni mayor que 100");
               
                paso = false;
            }

            if (Convert.ToDecimal(LogradotextBox.Text) < 0 || Convert.ToDecimal(LogradotextBox.Text) > 100)
            {
                ErrorProvider.SetError(LogradotextBox, "El campo Logrado no puede tener un valor menor que 0 ni mayor que 100");
        
                paso = false;
            }

            if (Convert.ToDecimal(PerdidotextBox.Text) < 0 || Convert.ToDecimal(PerdidotextBox.Text) > 100)
            {
                ErrorProvider.SetError(PerdidotextBox, "El campo Perdido no puede tener un valor menor que 0 ni mayor que 100");
      
                paso = false;
            }
            else 
            {
                ErrorProvider.SetError(PerdidotextBox, "");
            }

            return paso;
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
            int id;
            int.TryParse(IDnumericUpDown.Text, out id);
            limpiar();
            if (EvaluacionBLL.Eliminar(id))
                MessageBox.Show("Eliminado");
            else
                ErrorProvider.SetError(IDnumericUpDown, "No se puede eliminar una persona que no existe");

        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }

        private void ValortextBox_TextChanged(object sender, EventArgs e)
        {


        }

        private void LogradotextBox_TextChanged(object sender, EventArgs e)
        {
            Calcular();
        }

        private void Calcular()
        {
            try
            {
                if (!Validar())
                    return;

                Evaluacion evaluacion = LlenaClase();
   
                LlenaClase(evaluacion);
                PronosticocomboBox.SelectedIndex = EvaluacionBLL.SeleccionarPronostico(evaluacion);//
               
            }
            catch {
                PerdidotextBox.Text = "0";
            }
        }

    }
}
