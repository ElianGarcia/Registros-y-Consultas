using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Entidades
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string FechaNacimiento { get; set; }
        public char Sexo { get; set; }
        public double Balance { get; set; }

        public Estudiante(int id, string matricula, string nombre, string apellidos, string cedula, string telefono, string celular, string email, string fechaNacimiento, char sexo, double balance)
        {
            Id = id;
            Matricula = matricula;
            Nombre = nombre;
            Apellidos = apellidos;
            Cedula = cedula;
            Telefono = telefono;
            Celular = celular;
            Email = email;
            FechaNacimiento = fechaNacimiento;
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
            FechaNacimiento = string.Empty;
            Sexo = ' ';
            Balance = 0.0;
        }
    }
}
