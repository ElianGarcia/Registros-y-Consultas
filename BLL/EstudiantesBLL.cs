using Register.DAL;
using Register.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Register.BLL
{
    public class EstudiantesBLL
    {

        public static bool Guardar(Estudiante estudiante)
        {
            bool realizado = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Estudiante.Add(estudiante) != null)
                    realizado = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                db.Dispose();
            }

            return realizado;
        }

        public static bool Modificar(Estudiante estudiante)
        {
            bool realizado = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(estudiante).State = EntityState.Modified;
                realizado = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                db.Dispose();
            }

            return realizado;
        }

        public static bool Eliminar(int id)
        {
            bool realizado = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.Estudiante.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                realizado = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                db.Dispose();
            }

            return realizado;
        }

        public static Estudiante Buscar(int id)
        {
            Contexto db = new Contexto();
            Estudiante estudiante = new Estudiante();

            try
            {
                estudiante = db.Estudiante.Find(id);
            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                db.Dispose();
            }

            return estudiante;
        }

        public static List<Estudiante> GetList(Expression<Func<Estudiante, bool>> estudiante)
        {
            List<Estudiante> Lista = new List<Estudiante>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Estudiante.Where(estudiante).ToList();
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
    }
}
