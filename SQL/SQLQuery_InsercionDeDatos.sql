use Proyecto_GymMaster
GO

/*Usuarios principales*/
INSERT INTO Usuario (id_rol, nombre, email, telefono, dni, fecha_nacimiento, estado, contraseña, apellido)
VALUES (1, 'Gimnasio', 'gymmaster@gmail.com', '3794556789', '12345678', '2010-05-20', 1, 'administrador', 'Gymmaster');
GO

INSERT INTO Usuario (id_rol, nombre, email, telefono, dni, fecha_nacimiento, estado, contraseña, apellido)
VALUES (2, 'Pablo', 'pablogomez@gmail.com', '3794114567', '55555555', '2005-03-30', 1, 'profesor', 'Gomez');
GO

/*Insertar 10 usuarios rol coach*/
INSERT INTO Usuario (id_rol, nombre, apellido, email, telefono, dni, fecha_nacimiento, estado, contraseña) VALUES
(2, 'Sofía', 'Martínez', 'sofia.martinez@gmail.com', '1134567890', '40123456', '1995-06-15', 1, 'password1'),
(2, 'Lucas', 'Gómez', 'lucas.gomez@hotmail.com', '1122334455', '40234567', '1992-09-20', 1, 'password2'),
(2, 'Camila', 'Fernández', 'camila.fernandez@yahoo.com', '1167894321', '40345678', '1997-02-11', 1, 'password3'),
(2, 'Mateo', 'López', 'mateo.lopez@gmail.com', '1156789123', '40456789', '1990-12-05', 1, 'password4'),
(2, 'Valentina', 'Díaz', 'valentina.diaz@gmail.com', '1145678932', '40567890', '1993-07-18', 1, 'password5'),
(2, 'Tomás', 'Pérez', 'tomas.perez@hotmail.com', '1178912345', '40678901', '1989-03-29', 1, 'password6'),
(2, 'Martina', 'Sánchez', 'martina.sanchez@gmail.com', '1134561234', '40789012', '1996-11-09', 1, 'password7'),
(2, 'Santiago', 'Romero', 'santiago.romero@yahoo.com', '1123456789', '40890123', '1991-05-22', 1, 'password8'),
(2, 'Florencia', 'Torres', 'florencia.torres@gmail.com', '1161234567', '40901234', '1994-08-03', 1, 'password9'),
(2, 'Benjamin', 'Ramírez', 'benjamin.ramirez@hotmail.com', '1176543210', '41012345', '1988-01-17', 1, 'password10');
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