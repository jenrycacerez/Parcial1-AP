using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Parcial1_AP.DAL;
using Parcial1_AP.Entidades;
namespace Parcial1_AP.BLL
{
    public class EvaluacionBLL
    {
        
            public static bool Guardar(Evaluacion evaluacion)
            {
                bool paso = false;
                Contexto db = new Contexto();
                try
                {
                    if (db.Evaluacion.Add(evaluacion) != null)
                        paso = db.SaveChanges() > 0;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    db.Dispose();
                }

                return paso;


            }

            public static bool Modificar(Evaluacion evaluacion)
            {
                bool paso = false;
                Contexto db = new Contexto();

                try
                {
                    db.Entry(evaluacion).State = EntityState.Modified;
                    paso = (db.SaveChanges() > 0);
                }

                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    db.Dispose();
                }

                return paso;


            }

            public static bool Eliminar(int id)
            {
                bool paso = false;
                Contexto db = new Contexto();
                try
                {
                    var eliminar = db.Evaluacion.Find(id);
                    db.Entry(eliminar).State = EntityState.Deleted;

                    paso = (db.SaveChanges() > 0);
                }

                catch (Exception)
                {
                    //throw;
                }
                finally
                {
                    db.Dispose();
                }

                return paso;


            }

            public static Evaluacion Buscar(int id)
            {
                Contexto db = new Contexto();
                Evaluacion personas = new Evaluacion();
                try
                {
                    personas = db.Evaluacion.FirstOrDefault(p => p.ID == id);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    db.Dispose();
                }
                return personas;

            }
            public static List<Evaluacion> GetList(Expression<Func<Evaluacion, bool>> evaluacion)
            {
                List<Evaluacion> Lista = new List<Evaluacion>();
                Contexto db = new Contexto();
                try
                {
                    Lista = db.Evaluacion.Where(evaluacion).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    db.Dispose();
                }
                return Lista;


            }
            public static int SeleccionarPronostico(Evaluacion evaluacion)
            {
                int ItemSeleccionado = 0;
                decimal auxiliar;
                decimal resultado;

                auxiliar = (evaluacion.Logrado / evaluacion.Valor) * 100;
                resultado = 100 - auxiliar;

                if (resultado < 25)
                    ItemSeleccionado = 0;
                else if (resultado >= 25 && resultado <= 30)
                    ItemSeleccionado = 1;
                else if (resultado > 25)
                    ItemSeleccionado = 2;

                return ItemSeleccionado;
            }
    }

}

      





