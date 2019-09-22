
using Register.Entidades;
using System.Data.Entity;

namespace Register.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Estudiantes> Estudiante { get; set; }
        public DbSet<Inscripcion> Inscripcion { get; set; }

        public Contexto() : base("ConStr")
        {
        }
    }
}
