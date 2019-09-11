CREATE DATABASE EstudiantesDB
GO
USE EstudiantesDB
GO

CREATE TABLE Estudiantes
(
	Id int primary key identity,
	Matricula varchar(9),
	Nombre varchar(15),
	Apellidos varchar(25),
	Cedula varchar(11),
	Telefono varchar(11),
	Celular varchar(11),
	Email varchar (25),
	FechaDeNacimiento date,
	Sexo varchar(2),
	Balance float
)

GO
CREATE TABLE Incripciones
(
	Id int primary key identity,
	EstudianteID int,
	Comentarios varchar(80),
	Fecha date,
	Balance float,
	Monto float,
	Deposito float
)