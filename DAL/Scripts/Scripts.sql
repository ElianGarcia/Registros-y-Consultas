create database EstudiantesDB
go
use EstudiantesDB
go 
create table Estudiantes 
(
 Id int primary key identity,
 Matricula varchar(9) not null,
 Nombre varchar(15) not null,
 Apellidos varchar(20) not null,
 Cedula varchar(11) not null,
 Telefono varchar(11),
 Celular varchar(11) not null,
 Sexo char(1) not null,
 FechaDeNacimiento Date,
 Balance money,
 Email varchar(25),
 )