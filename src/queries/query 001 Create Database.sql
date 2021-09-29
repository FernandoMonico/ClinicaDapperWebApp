/* Creación de base de datos y tablas */
USE master;
GO

DROP DATABASE IF EXISTS Clinica;

CREATE DATABASE Clinica;
GO

USE Clinica;
GO

CREATE TABLE Paciente(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nombre VARCHAR(60) NOT NULL,
	Apellido VARCHAR(60) NOT NULL,
	Peso DECIMAL NOT NULL,
	Altura DECIMAL NOT NULL,
	FechaNacimiento DATE NOT NULL
);

CREATE TABLE Doctor(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nombre VARCHAR(60) NOT NULL,
	Apellido VARCHAR(60) NOT NULL,
	Especialidad VARCHAR(60) NOT NULL
);

CREATE TABLE Cita(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	FechaConsulta DATETIME NOT NULL,
	PacienteId INT NOT NULL,
	DoctorId INT NOT NULL

	CONSTRAINT FK_Cita_Paciente FOREIGN KEY(PacienteId) REFERENCES Paciente(Id),
	CONSTRAINT FK_Cita_Doctor FOREIGN KEY(DoctorId) REFERENCES Doctor(Id)
);

CREATE TABLE Consulta(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Diagnostico VARCHAR(60) NOT NULL,
	CitaId INT NOT NULL

	CONSTRAINT FK_Consulta_Cita FOREIGN KEY(CitaId) REFERENCES Cita(Id)
);

/* Procedimientos Almacenados */

/* Doctor Create */
CREATE PROCEDURE dbo.SP_DoctorCreate
	@Nombre VARCHAR(60),
	@Apellido VARCHAR(60),
	@Especialidad VARCHAR(60)
AS
BEGIN
	INSERT INTO Doctor([Nombre], [Apellido], [Especialidad]) VALUES (@Nombre, @Apellido, @Especialidad)
END;

EXEC SP_DoctorCreate 
    @Nombre = 'Lucia',
    @Apellido = 'Mendez',
    @Especialidad = 'Cardiologo';

/* Doctor Select */
CREATE PROCEDURE dbo.SP_DoctorGetAll
AS
BEGIN
	SELECT * FROM Doctor
END;

EXEC SP_DoctorGetAll;

/* Paciente Create */
CREATE PROCEDURE dbo.SP_PacienteCreate
	@Nombre VARCHAR(60),
	@Apellido VARCHAR(60),
	@Altura DECIMAL,
	@Peso DECIMAL,
	@FechaNacimiento DATETIME
AS
BEGIN
	INSERT INTO Paciente([Nombre], [Apellido], [Altura], [Peso], [FechaNacimiento]) values (@Nombre, @Apellido, @Altura, @Peso, @FechaNacimiento)
END;

EXEC SP_PacienteCreate 
    @Nombre = 'Lucia',
    @Apellido = 'Mendez',
    @Altura = 1.65,
	@Peso = 120,
	@FechaNacimiento = '19901224';

/* Paciente Select */
CREATE PROCEDURE dbo.SP_PacienteGetAll
AS
BEGIN
	SELECT * FROM Paciente
END;

EXEC SP_PacienteGetAll;
