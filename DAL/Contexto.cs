using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Register.Entidades;
using System.Data.Entity;

namespace Register.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Inscripcion> Inscripcion { get; set; }

        public Contexto() : base("ConStr")
        {
        }
    }
}
