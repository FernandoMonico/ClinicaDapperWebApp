/* Creación de Procedimientos Almacenados */
USE Clinica;
GO
/* ------------------------------------------------------------------------------------------------ */
/* Doctor Create */
CREATE PROCEDURE SP_DoctorCreate
	@Id INT,
	@Nombre VARCHAR(60),
	@Apellido VARCHAR(60),
	@Especialidad VARCHAR(60)
AS
BEGIN
	INSERT INTO Doctor (Nombre, Apellido, Especialidad) VALUES (@Nombre, @Apellido, @Especialidad)
END;

EXEC SP_DoctorCreate
	@Id = 0,
    @Nombre = 'Lucia',
    @Apellido = 'Mendez',
    @Especialidad = 'Cardiología';

/* Doctor Select */
CREATE PROCEDURE SP_DoctorGetAll
AS
BEGIN
	SELECT * FROM Doctor
END;

EXEC SP_DoctorGetAll;
/* ------------------------------------------------------------------------------------------------ */
/* Paciente Create */
CREATE PROCEDURE SP_PacienteCreate
	@Id INT,
	@Nombre VARCHAR(60),
	@Apellido VARCHAR(60),
	@Altura DECIMAL(6,2),
	@Peso DECIMAL(6,2),
	@FechaNacimiento DATETIME
AS
BEGIN
	INSERT INTO Paciente(Nombre, Apellido, Altura, Peso, FechaNacimiento) values (@Nombre, @Apellido, @Altura, @Peso, @FechaNacimiento)
END;

EXEC SP_PacienteCreate
	@Id = 0,
    @Nombre = 'Lucia',
    @Apellido = 'Mendez',
    @Altura = 1.65,
	@Peso = 120,
	@FechaNacimiento = '19901224';

/* Paciente Select */
CREATE PROCEDURE SP_PacienteGetAll
AS
BEGIN
	SELECT * FROM Paciente
END;

EXEC SP_PacienteGetAll;

/* Paciente GetById */
CREATE PROCEDURE SP_PacienteGetById
	@id INT
AS
BEGIN
	SELECT * FROM Paciente WHERE Id = @id
END;

EXEC SP_PacienteGetById
	@id = 5

/* Paciente Update */
CREATE PROCEDURE SP_PacienteUpdate
	@Id INT,
	@Nombre VARCHAR(60),
	@Apellido VARCHAR(60),
	@Altura DECIMAL(6,2),
	@Peso DECIMAL(6,2),
	@FechaNacimiento DATETIME
AS
BEGIN
	UPDATE Paciente SET Nombre = @Nombre, Apellido = @Apellido, Altura = @Altura, Peso = @Peso, FechaNacimiento = @FechaNacimiento WHERE Id = @Id
END;

EXEC SP_PacienteUpdate
	@Id = 1,
    @Nombre = 'Lucia',
    @Apellido = 'Menedez',
    @Altura = 1.60,
	@Peso = 110,
	@FechaNacimiento = '19901224';

/* Paciente Delete */
CREATE PROCEDURE SP_PacienteDelete
	@id INT
AS
BEGIN
DELETE Paciente WHERE Id = @id
END;

EXECUTE SP_PacienteDelete
	@id = 5
/* ------------------------------------------------------------------------------------------------ */
