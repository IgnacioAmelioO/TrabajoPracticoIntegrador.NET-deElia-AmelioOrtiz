-- Usar master para creación de la base de datos
USE master;
GO

-- Eliminar la base de datos si existe
IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'TrabajoPracticoIntegrador')
BEGIN
    DROP DATABASE TrabajoPracticoIntegrador;
END
GO

-- Crear la base de datos
CREATE DATABASE TrabajoPracticoIntegrador;
GO

-- Seleccionar la base de datos creada
USE TrabajoPracticoIntegrador;
GO

-- Eliminar tablas existentes si las hubiera (orden considerando relaciones)
DROP TABLE IF EXISTS DocentesCursos;
DROP TABLE IF EXISTS AlumnosInscripciones;
DROP TABLE IF EXISTS Cursos;
DROP TABLE IF EXISTS Materias;
DROP TABLE IF EXISTS Comisiones;
DROP TABLE IF EXISTS Personas;
DROP TABLE IF EXISTS Planes;
DROP TABLE IF EXISTS Especialidades;
GO

-- Crear tabla Especialidades
CREATE TABLE Especialidades (
    Id_especialidad INT IDENTITY(1,1) PRIMARY KEY,
    Desc_esp NVARCHAR(100) NOT NULL
);

-- Crear tabla Planes
CREATE TABLE Planes (
    Id_plan INT IDENTITY(1,1) PRIMARY KEY,
    Desc_plan NVARCHAR(100) NOT NULL,
    Id_especialidad INT NOT NULL,
    CONSTRAINT FK_Planes_Especialidades FOREIGN KEY (Id_especialidad) 
        REFERENCES Especialidades(Id_especialidad)
);

-- Crear tabla Personas
CREATE TABLE Personas (
    Id_persona INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Direccion NVARCHAR(200) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Telefono NVARCHAR(20) NOT NULL,
    Legajo NVARCHAR(20) NOT NULL,
    Tipo_persona NVARCHAR(50) NOT NULL,
    Id_plan INT NOT NULL,
    Fecha_nac DATE NOT NULL,
    CONSTRAINT FK_Personas_Planes FOREIGN KEY (Id_plan) 
        REFERENCES Planes(Id_plan)
);

-- Crear tabla Cursos
CREATE TABLE Cursos (
    Id_curso INT IDENTITY(1,1) PRIMARY KEY,
    Anio_calendario INT NOT NULL,
    Cupo INT NOT NULL,
    Id_materia INT NOT NULL,
    Id_comision INT NOT NULL
);

-- Crear tabla AlumnosInscripciones
CREATE TABLE AlumnosInscripciones (
    Id_inscripcion INT IDENTITY(1,1) PRIMARY KEY,
    Id_alumno INT NOT NULL,
    Id_curso INT NOT NULL,
    Condicion NVARCHAR(50) NULL,
    Nota INT NULL,
    CONSTRAINT FK_AlumnosInscripciones_Personas FOREIGN KEY (Id_alumno) 
        REFERENCES Personas(Id_persona),
    CONSTRAINT FK_AlumnosInscripciones_Cursos FOREIGN KEY (Id_curso) 
        REFERENCES Cursos(Id_curso)
);

-- Crear tabla DocentesCursos
CREATE TABLE DocentesCursos (
    Id_dictado INT IDENTITY(1,1) PRIMARY KEY,
    Id_docente INT NOT NULL,
    Id_curso INT NOT NULL,
    Cargo INT NOT NULL, -- 1: Titular, 2: Auxiliar, 3: Suplente
    CONSTRAINT FK_DocentesCursos_Personas FOREIGN KEY (Id_docente) 
        REFERENCES Personas(Id_persona),
    CONSTRAINT FK_DocentesCursos_Cursos FOREIGN KEY (Id_curso) 
        REFERENCES Cursos(Id_curso)
);

-- Crear tabla Materias
CREATE TABLE Materias (
    Id_materia INT IDENTITY(1,1) PRIMARY KEY,
    Desc_materia NVARCHAR(100) NOT NULL,
    Hs_semanales INT NOT NULL,
    Hs_totales INT NOT NULL,
    Id_plan INT NOT NULL,
    CONSTRAINT FK_Materias_Planes FOREIGN KEY (Id_plan)
        REFERENCES Planes(Id_plan)
);

-- Crear tabla Comisiones
CREATE TABLE Comisiones (
    Id_comision INT IDENTITY(1,1) PRIMARY KEY,
    Desc_comision NVARCHAR(100) NOT NULL,
    Anio_especialidad INT NOT NULL,
    Id_plan INT NOT NULL,
    CONSTRAINT FK_Comisiones_Planes FOREIGN KEY (Id_plan)
        REFERENCES Planes(Id_plan)
);

-- Insertar datos de ejemplo en Especialidades
INSERT INTO Especialidades (Desc_esp) VALUES 
('Ingeniería en Sistemas'),
('Ingeniería Industrial'),
('Licenciatura en Informática');

-- Insertar datos de ejemplo en Planes
INSERT INTO Planes (Desc_plan, Id_especialidad) VALUES 
('Plan 2015 - Ingeniería en Sistemas', 1),
('Plan 2018 - Ingeniería Industrial', 2),
('Plan 2020 - Licenciatura en Informática', 3);

-- Insertar datos de ejemplo en Materias
INSERT INTO Materias (Desc_materia, Hs_semanales, Hs_totales, Id_plan) VALUES
('Programación I', 4, 64, 1),
('Matemática II', 3, 48, 1),
('Física I', 2, 32, 2);

-- Insertar datos de ejemplo en Comisiones
INSERT INTO Comisiones (Desc_comision, Anio_especialidad, Id_plan) VALUES
('A', 1, 1),
('B', 1, 1),
('C', 2, 2);

INSERT INTO Cursos (Anio_calendario, Cupo, Id_materia, Id_comision) VALUES
(2025, 30, 1, 1),  -- Programación I - Comision A
(2025, 25, 2, 2),  -- Matemática II - Comision B
(2025, 20, 3, 3);  -- Física I - Comision C

GO

PRINT 'Base de datos y todas las tablas creadas con datos de ejemplo correctamente';
