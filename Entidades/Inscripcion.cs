using System;
using System.ComponentModel.DataAnnotations;

namespace Register.Entidades
{
    public class Inscripcion
    {
        [Key]
        public int Id { get; set; }
        public int EstudianteID { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentarios { get; set; }
        public float Monto { get; set; }
        public float Balance { get; set; }
        public float Deposito { get; set; }

        public Inscripcion()
        {
            Id = 0;
            EstudianteID = 0;
            Fecha = DateTime.Now;
            Comentarios = "";
            Monto = 0;
            Balance = 0;
            Deposito = 0;
        }

        public Inscripcion(int id, int estudianteID, DateTime fecha, string comentarios, float monto, float balance, float deposito)
        {
            Id = id;
            EstudianteID = estudianteID;
            Fecha = fecha;
            Comentarios = comentarios ?? throw new ArgumentNullException(nameof(comentarios));
            Monto = monto;
            Balance = balance;
            Deposito = deposito;
        }
    }
}
