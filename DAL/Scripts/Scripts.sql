CREATE DATABASE EstudiantesDB
GO
USE EstudiantesDB
GO

CREATE TABLE Estudiantes
(
	Id int,
	Matricula varchar(9),
	Nombre varchar(15),
	Apellidos varchar(25),
	Cedula varchar(11),
	Telefono varchar(11),
	Celular varchar(11),
	Email varchar (25),
	FechaDeNacimiento date,
	Sexo varchar(1),
	Balance varchar(8)
)