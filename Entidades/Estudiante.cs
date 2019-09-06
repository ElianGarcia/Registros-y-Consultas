using System;
using System.ComponentModel.DataAnnotations;

namespace Register.Entidades
{
    public class Estudiante
    {
        [Key]
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Balance { get; set; }

        public Estudiante(int id, string matricula, string nombre, string apellidos, string cedula, string telefono, string celular, string email, DateTime fechaNacimiento, string sexo, string balance)
        {
            Id = id;
            Matricula = matricula;
            Nombre = nombre;
            Apellidos = apellidos;
            Cedula = cedula;
            Telefono = telefono;
            Celular = celular;
            Email = email;
            FechaDeNacimiento = fechaNacimiento;
            Sexo = sexo;
            Balance = balance;
        }

        public Estudiante()
        {
            Id = 0;
            Matricula = string.Empty;
            Nombre = string.Empty;
            Apellidos = string.Empty;
            Cedula = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Email = string.Empty;
            FechaDeNacimiento = DateTime.Now;
            Sexo = string.Empty;
            Balance = string.Empty;
        }
    }
}
