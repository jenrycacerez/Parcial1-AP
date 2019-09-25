using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_AP.Entidades
{
    public class Evaluacion
    {
        [Key]
        public int ID { get; set; }

        public DateTime Fecha { get; set; }

        public string Estudiante { get; set; }

        public decimal Valor { get; set; }

        public decimal Logrado{ get; set; }

        public decimal Perdido { get; set; }
        

        public Evaluacion()
        {
            ID = 0;
            Fecha = DateTime.Now;
            Estudiante = string.Empty;
            Valor = 0;
            Logrado = 0;
            Perdido = 0;


        }





    }
}



