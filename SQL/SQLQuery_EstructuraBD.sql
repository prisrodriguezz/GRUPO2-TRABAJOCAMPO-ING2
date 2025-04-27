-- Crear base de datos
CREATE DATABASE Proyecto_GymMaster;
GO

-- Usar la base de datos recién creada
USE Proyecto_GymMaster;
GO

-- Crear tabla Rol
CREATE TABLE Rol (
    id_rol INT PRIMARY KEY IDENTITY(1,1),
    descripcion NVARCHAR(100) NOT NULL
);
GO

-- Crear tabla Usuario
CREATE TABLE Usuario (
    id_usuario INT PRIMARY KEY IDENTITY(1,1),
    id_rol INT FOREIGN KEY REFERENCES Rol(id_rol),
    nombre NVARCHAR(100) NOT NULL,
    apellido NVARCHAR(100) NOT NULL,
    email NVARCHAR(100) NOT NULL,
    telefono NVARCHAR(50),
    dni NVARCHAR(20),
    fecha_nacimiento DATE,
    estado BIT NOT NULL,
    contraseña NVARCHAR(255)
);
GO

-- Crear tabla Membresia
CREATE TABLE Membresia (
    id_membresia INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    duracion INT,
    fecha_creacion DATE,
    costo DECIMAL(10, 2),
    estado BIT NOT NULL
);
GO

-- Crear tabla PlanEntrenamiento
CREATE TABLE PlanEntrenamiento (
    id_plan INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    fechaInicio DATE,
    fechaFin DATE,
    cantSeries INT,
    estado BIT NOT NULL
);
GO

-- Crear tabla Ejercicio
CREATE TABLE Ejercicio (
    id_ejercicio INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    repeticiones INT,
    tiempo INT
);
GO

-- Crear tabla Plan_Ejercicio
CREATE TABLE Plan_Ejercicio (
    id_plan INT FOREIGN KEY REFERENCES PlanEntrenamiento(id_plan),
    id_ejercicio INT FOREIGN KEY REFERENCES Ejercicio(id_ejercicio),
    PRIMARY KEY (id_plan, id_ejercicio)
);
GO

-- Crear tabla Alumno
CREATE TABLE Alumno (
    id_alumno INT PRIMARY KEY IDENTITY(1,1),
    id_usuario INT FOREIGN KEY REFERENCES Usuario(id_usuario),
    id_membresia INT FOREIGN KEY REFERENCES Membresia(id_membresia),
    id_plan INT FOREIGN KEY REFERENCES PlanEntrenamiento(id_plan),
    nombre NVARCHAR(100) NOT NULL,
    apellido NVARCHAR(100) NOT NULL,
    email NVARCHAR(100),
    telefono NVARCHAR(50),
    foto NVARCHAR(MAX),
    dni NVARCHAR(20),
    fecha_nacimiento DATE,
    contacto_emergencia NVARCHAR(100),
    sexo NVARCHAR(10),
    observaciones NVARCHAR(MAX),
    estado BIT NOT NULL
);
GO

-- Crear tabla Usuario_Plan
CREATE TABLE Usuario_Plan (
    id_usuario INT FOREIGN KEY REFERENCES Usuario(id_usuario),
    id_plan INT FOREIGN KEY REFERENCES PlanEntrenamiento(id_plan),
    PRIMARY KEY (id_usuario, id_plan)
);
GO

-- Crear tabla MedioDePago
CREATE TABLE MedioDePago (
    id_medioPago INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    comision DECIMAL(5, 2),
    fechaCreacion DATE,
    estado BIT NOT NULL
);
GO

-- Crear tabla Pago
CREATE TABLE Pago (
    id_pago INT PRIMARY KEY IDENTITY(1,1),
    id_usuario INT FOREIGN KEY REFERENCES Usuario(id_usuario),
    id_alumno INT FOREIGN KEY REFERENCES Alumno(id_alumno),
    id_medioPago INT FOREIGN KEY REFERENCES MedioDePago(id_medioPago),
    fecha DATE,
    cantidad DECIMAL(10, 2),
    total DECIMAL(10, 2),
    recargo DECIMAL(10, 2)
);
GO

-- Crear tabla PagoDetalle
CREATE TABLE PagoDetalle (
    id_pagoDetalle INT PRIMARY KEY IDENTITY(1,1),
    id_pago INT FOREIGN KEY REFERENCES Pago(id_pago),
    id_membresia INT FOREIGN KEY REFERENCES Membresia(id_membresia),
    periodo INT,
    monto DECIMAL(10, 2)
);
GO

-- Crear tabla Permiso
CREATE TABLE Permiso(
    id_permiso INT PRIMARY KEY IDENTITY(1,1),
    id_rol INT REFERENCES Rol(id_rol),
    nombreMenu NVARCHAR(100) NOT NULL
);
GO