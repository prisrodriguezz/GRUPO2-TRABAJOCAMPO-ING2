use Proyecto_GymMaster
GO

INSERT INTO Rol (descripcion)
VALUES ('Administrador'), ('Coach');
GO

-- ASIGNACION DE VISTAS PARA CADA ROL
INSERT INTO Permiso(id_rol, nombreMenu)
VALUES (1, 'menuUsuarios'),
       (1, 'menuMantenimiento'),
       (1, 'menuAlumnos'),
       (1, 'menuPagos'),
	   (1, 'menuPlanes');

INSERT INTO Permiso(id_rol, nombreMenu)
VALUES (2, 'menuAlumnos'),
       (2, 'menuPlanes');
GO

/*Usuarios principales*/
INSERT INTO Usuario (id_rol, nombre, email, telefono, dni, fecha_nacimiento, estado, contrase�a, apellido)
VALUES (1, 'Gimnasio', 'gymmaster@gmail.com', '3794556789', '12345678', '2010-05-20', 1, 'administrador', 'Gymmaster');
GO

INSERT INTO Usuario (id_rol, nombre, email, telefono, dni, fecha_nacimiento, estado, contrase�a, apellido)
VALUES (2, 'Pablo', 'pablogomez@gmail.com', '3794114567', '55555555', '2005-03-30', 1, 'profesor', 'Gomez');
GO

/*Insertar 10 usuarios rol coach*/
INSERT INTO Usuario (id_rol, nombre, apellido, email, telefono, dni, fecha_nacimiento, estado, contrase�a) VALUES
(2, 'Sof�a', 'Mart�nez', 'sofia.martinez@gmail.com', '1134567890', '40123456', '1995-06-15', 1, 'password1'),
(2, 'Lucas', 'G�mez', 'lucas.gomez@hotmail.com', '1122334455', '40234567', '1992-09-20', 1, 'password2'),
(2, 'Camila', 'Fern�ndez', 'camila.fernandez@yahoo.com', '1167894321', '40345678', '1997-02-11', 1, 'password3'),
(2, 'Mateo', 'L�pez', 'mateo.lopez@gmail.com', '1156789123', '40456789', '1990-12-05', 1, 'password4'),
(2, 'Valentina', 'D�az', 'valentina.diaz@gmail.com', '1145678932', '40567890', '1993-07-18', 1, 'password5'),
(2, 'Tom�s', 'P�rez', 'tomas.perez@hotmail.com', '1178912345', '40678901', '1989-03-29', 1, 'password6'),
(2, 'Martina', 'S�nchez', 'martina.sanchez@gmail.com', '1134561234', '40789012', '1996-11-09', 1, 'password7'),
(2, 'Santiago', 'Romero', 'santiago.romero@yahoo.com', '1123456789', '40890123', '1991-05-22', 1, 'password8'),
(2, 'Florencia', 'Torres', 'florencia.torres@gmail.com', '1161234567', '40901234', '1994-08-03', 1, 'password9'),
(2, 'Benjamin', 'Ram�rez', 'benjamin.ramirez@hotmail.com', '1176543210', '41012345', '1988-01-17', 1, 'password10');
GO

/*Insertar 10 ejercicios*/
INSERT INTO Ejercicio (nombre, repeticiones, tiempo) VALUES
('Burpees', 20, 60),
('Deadlift', 12, 90),
('Wall Ball Shots', 25, 70),
('Kettlebell Swings', 15, 50),
('Box Jumps', 20, 40),
('Pull Ups', 10, 60),
('Snatch', 8, 120),
('Overhead Squats', 12, 90),
('Push Press', 15, 60),
('Rowing', NULL, 300);
Go

-- Insertar medios de pago
INSERT INTO MedioDePago (nombre, comision, fechaCreacion, estado)
VALUES 
('Efectivo', 0.00, '2023-01-01', 1),
('Tarjeta de Cr�dito', 10.00, '2023-01-01', 1),
('Transferencia Bancaria', 2.50, '2023-01-01', 1),
('Mercado Pago', 5.00, '2023-01-01', 1);
GO

-- Insertar membres�as (necesarias para asociar a alumnos)
INSERT INTO Membresia (nombre, duracion, fecha_creacion, costo, estado)
VALUES 
('Membres�a B�sica', 30, '2023-01-01', 5000.00, 1),
('Membres�a Premium', 30, '2023-01-01', 8000.00, 1),
('Membres�a Anual', 365, '2023-01-01', 50000.00, 1);
GO

-- Insertar planes de entrenamiento (necesarios para alumnos)
INSERT INTO PlanEntrenamiento (nombre, fechaInicio, fechaFin, cantSeries, estado)
VALUES 
('Plan Inicial', '2023-01-01', '2023-12-31', 3, 1),
('Plan Intermedio', '2023-01-01', '2023-12-31', 4, 1),
('Plan Avanzado', '2023-01-01', '2023-12-31', 5, 1);
GO

-- Asignar a un Coach a dos planes diferentes
EXEC SP_ASOCIAR_USUARIO_PLAN @id_usuario = 2, @id_plan = 1; -- Plan Inicial
EXEC SP_ASOCIAR_USUARIO_PLAN @id_usuario = 2, @id_plan = 2; -- Plan Intermedio

-- Asignar a otros coaches
EXEC SP_ASOCIAR_USUARIO_PLAN @id_usuario = 3, @id_plan = 1; -- Sofía Martínez al Plan Inicial
EXEC SP_ASOCIAR_USUARIO_PLAN @id_usuario = 4, @id_plan = 3; -- Lucas Gómez al Plan Avanzado
EXEC SP_ASOCIAR_USUARIO_PLAN @id_usuario = 5, @id_plan = 3; -- Camila Fernandez al Plan Avanzado
EXEC SP_ASOCIAR_USUARIO_PLAN @id_usuario = 6, @id_plan = 2; -- Mateo Lopez al Plan Avanzado

-- Insertar algunos alumnos (asociados a usuarios, membres�as y planes)
INSERT INTO Alumno (id_usuario, id_membresia, id_plan, nombre, apellido, email, telefono, dni, fecha_nacimiento, contacto_emergencia, sexo, observaciones, estado)
VALUES 
(2, 1, 1, 'Juan', 'P�rez', 'juan.perez@gmail.com', '3794123456', '12345678', '1990-05-15', 'Mar�a P�rez - 3794123457', 'Masculino', 'Ninguna', 1),
(2, 2, 2, 'Ana', 'G�mez', 'ana.gomez@gmail.com', '3794234567', '23456789', '1992-08-20', 'Carlos G�mez - 3794234568', 'Femenino', 'Alergia a nueces', 1),
(3, 3, 3, 'Carlos', 'L�pez', 'carlos.lopez@gmail.com', '3794345678', '34567890', '1988-03-10', 'Laura L�pez - 3794345679', 'Masculino', 'Lesi�n de rodilla previa', 1);
GO

-- Insertar pagos
-- Pago 1: Juan P�rez paga su membres�a b�sica
DECLARE @id_pago1 INT;
EXEC SP_REGISTRAR_PAGO 
    @id_usuario = 1, 
    @id_alumno = 1, 
    @id_medioPago = 1, 
    @fecha = '2024-10-01', 
    @cantidad = 1, 
    @total = 5000.00,
	@recargo = 0.00,
    @id_pago = @id_pago1 OUTPUT;

EXEC SP_REGISTRAR_PAGO_DETALLE 
    @id_pago = @id_pago1, 
    @id_membresia = 1, 
    @periodo = 1, 
    @monto = 5000.00;
GO

-- Pago 2: Ana G�mez paga su membres�a premium con tarjeta (incluye comisi�n)
DECLARE @id_pago2 INT;
EXEC SP_REGISTRAR_PAGO 
    @id_usuario = 1, 
    @id_alumno = 2, 
    @id_medioPago = 2, 
    @fecha = '2025-04-05', 
    @cantidad = 1, 
    @total = 8800.00, -- 8000 + 10% comisi�n
	@recargo = 800.00,
    @id_pago = @id_pago2 OUTPUT;

EXEC SP_REGISTRAR_PAGO_DETALLE 
    @id_pago = @id_pago2, 
    @id_membresia = 2, 
    @periodo = 1, 
    @monto = 8000.00;
GO

-- Pago 3: Carlos L�pez paga su membres�a anual con transferencia
DECLARE @id_pago3 INT;
EXEC SP_REGISTRAR_PAGO 
    @id_usuario = 1, 
    @id_alumno = 3, 
    @id_medioPago = 3, 
    @fecha = '2024-04-10', 
    @cantidad = 1, 
    @total = 51250.00, -- 50000 + 2.5% comisi�n
	@recargo = 1250.00,
    @id_pago = @id_pago3 OUTPUT;

EXEC SP_REGISTRAR_PAGO_DETALLE 
    @id_pago = @id_pago3, 
    @id_membresia = 3, 
    @periodo = 1, 
    @monto = 50000.00;
GO

-- Pago 4: Juan P�rez paga su segunda cuota con recargo por demora
DECLARE @id_pago4 INT;
EXEC SP_REGISTRAR_PAGO 
    @id_usuario = 1, 
    @id_alumno = 1, 
    @id_medioPago = 1, 
    @fecha = '2024-11-15', -- Pag� 15 d�as despu�s del vencimiento
    @cantidad = 1, 
    @total = 5500.00, -- 5000 + 10% recargo
	@recargo = 500.00,
    @id_pago = @id_pago4 OUTPUT;

EXEC SP_REGISTRAR_PAGO_DETALLE 
    @id_pago = @id_pago4, 
    @id_membresia = 1, 
    @periodo = 2, 
    @monto = 5000.00;
GO

-- Pago 5: Ana G�mez paga su segunda cuota a tiempo
DECLARE @id_pago5 INT;
EXEC SP_REGISTRAR_PAGO 
    @id_usuario = 1, 
    @id_alumno = 2, 
    @id_medioPago = 4, 
    @fecha = '2025-05-05', 
    @cantidad = 1, 
    @total = 8400.00, -- 8000 + 5% comisi�n (Mercado Pago)
	@recargo = 400.00,
    @id_pago = @id_pago5 OUTPUT;

EXEC SP_REGISTRAR_PAGO_DETALLE 
    @id_pago = @id_pago5, 
    @id_membresia = 2, 
    @periodo = 2, 
    @monto = 8000.00;
GO