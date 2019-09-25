using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Parcial1_AP.Entidades;

namespace Parcial1_AP.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Personas> Personas { get; set; }
        
        public Contexto() : base("ConStr")
        {
            
        }



    }

}
