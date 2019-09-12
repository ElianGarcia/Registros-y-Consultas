using Register.DAL;
using Register.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Register.BLL
{
    public class InscripcionesBLL
    {
        public static bool Guardar(Inscripcion inscripcion)
        {
            bool realizado = false;
            Contexto db = new Contexto();
            Estudiante estudiante = new Estudiante();
            estudiante.Id = inscripcion.EstudianteID;

            try
            {
                if (db.Inscripcion.Add(inscripcion) != null)
                    realizado = db.SaveChanges() > 0;
                db.Estudiante.Find(estudiante.Id).Balance = inscripcion.Balance;
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

        public static bool Modificar(Inscripcion inscripcion)
        {
            bool realizado = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(inscripcion).State = EntityState.Modified;
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
                var eliminar = db.Inscripcion.Find(id);
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

        public static Inscripcion Buscar(int id)
        {
            Contexto db = new Contexto();
            Inscripcion inscripcion = new Inscripcion();

            try
            {
                inscripcion = db.Inscripcion.Find(id);
            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                db.Dispose();
            }

            return inscripcion;
        }

        public static List<Inscripcion> GetList(Expression<Func<Inscripcion, bool>> inscripcion)
        {
            List<Inscripcion> Lista = new List<Inscripcion>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Inscripcion.Where(inscripcion).ToList();
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
