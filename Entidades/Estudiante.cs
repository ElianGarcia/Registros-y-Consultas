using System;
using System.ComponentModel.DataAnnotations;

namespace Register.Entidades
{
    public class Estudiantes
    {
        [Key]
        public int EstudianteId { get; set; }
        public string Matricula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string Sexo { get; set; }
        public float Balance { get; set; }

        public Estudiantes(int id, string matricula, string nombre, string apellidos, string cedula, string telefono, string celular, string email, DateTime fechaNacimiento, string sexo, float balance)
        {
            EstudianteId = id;
            Matricula = matricula;
            Nombres = nombre;
            Apellidos = apellidos;
            Cedula = cedula;
            Telefono = telefono;
            Celular = celular;
            Email = email;
            FechaDeNacimiento = fechaNacimiento;
            Sexo = sexo;
            Balance = balance;
        }

        public Estudiantes()
        {
            EstudianteId = 0;
            Matricula = string.Empty;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            Cedula = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Email = string.Empty;
            FechaDeNacimiento = DateTime.Now;
            Sexo = string.Empty;
            Balance = 0;
        }
    }
}
