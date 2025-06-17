USE Proyecto_GymMaster;
GO

GO
CREATE PROCEDURE SP_LISTAR_EJERCICIOS
AS
BEGIN
    SELECT * FROM Ejercicio;
END;
GO

GO
CREATE PROCEDURE SP_LISTAR_PLAN_ENTRENAMIENTO
AS
BEGIN
    SELECT * FROM PlanEntrenamiento
END
GO

/*PROCEDIMIENTOS PARA AGREGAR UN PLAN DE ENTRENAMIENTO*/
GO
CREATE PROCEDURE SP_AGREGAR_PLAN_ENTRENAMIENTO
    @nombre NVARCHAR(100),
    @fechaInicio DATE,
    @fechaFin DATE,
    @cantSeries INT,
	@estado BIT,
    @respuesta INT OUTPUT,
    @mensaje NVARCHAR(500) OUTPUT
AS
BEGIN
    BEGIN TRY
        -- Verificar si ya existe un plan con el mismo nombre
        IF EXISTS (SELECT 1 FROM PlanEntrenamiento WHERE nombre = @nombre AND fechaInicio = @fechaInicio AND fechaFin = @fechaFin AND cantSeries = @cantSeries)
        BEGIN
            SET @respuesta = 0;
            SET @mensaje = 'Ya existe un plan de entrenamiento con la misma informacion.';
            RETURN;
        END

        -- Insertar el nuevo plan de entrenamiento
        INSERT INTO PlanEntrenamiento (nombre, fechaInicio, fechaFin, cantSeries, estado)
        VALUES (@nombre, @fechaInicio, @fechaFin, @cantSeries, @estado);

        SET @respuesta = SCOPE_IDENTITY();
        SET @mensaje = 'Plan de entrenamiento agregado exitosamente.';
    END TRY
    BEGIN CATCH
        SET @respuesta = 0;
        SET @mensaje = ERROR_MESSAGE();
    END CATCH
END;
GO

/*PROCEDIMIENTOS PARA EDITAR UN PLAN DE ENTRENAMIENTO*/
GO
CREATE PROCEDURE SP_EDITAR_PLAN_ENTRENAMIENTO
    @id_plan INT,
    @nombre NVARCHAR(100),
    @fechaInicio DATE,
    @fechaFin DATE,
    @cantSeries INT,
	@estado BIT,
    @respuesta INT OUTPUT,
    @mensaje NVARCHAR(500) OUTPUT
AS
BEGIN
    BEGIN TRY
        -- Verificar si existe el plan con el ID dado
        IF NOT EXISTS (SELECT 1 FROM PlanEntrenamiento WHERE id_plan = @id_plan)
        BEGIN
            SET @respuesta = 0;
            SET @mensaje = 'El plan de entrenamiento no existe.';
            RETURN;
        END

        -- Actualizar el plan de entrenamiento
        UPDATE PlanEntrenamiento
        SET nombre = @nombre,
            fechaInicio = @fechaInicio,
            fechaFin = @fechaFin,
            cantSeries = @cantSeries,
			estado = @estado
        WHERE id_plan = @id_plan;

        SET @respuesta = @id_plan;
        SET @mensaje = 'Plan de entrenamiento actualizado exitosamente.';
    END TRY
    BEGIN CATCH
        SET @respuesta = 0;
        SET @mensaje = ERROR_MESSAGE();
    END CATCH
END;
GO

/*PROCEDIMIENTOS PARA ELIMINAR UN PLAN DE ENTRENAMIENTO*/
GO
CREATE PROCEDURE SP_ELIMINAR_PLAN_ENTRENAMIENTO
    @id_plan INT,
    @respuesta INT OUTPUT,
    @mensaje NVARCHAR(500) OUTPUT
AS
BEGIN
    BEGIN TRY
        -- Verificar si existe el plan con el ID dado
        IF NOT EXISTS (SELECT 1 FROM PlanEntrenamiento WHERE id_plan = @id_plan)
        BEGIN
            SET @respuesta = 0;
            SET @mensaje = 'El plan de entrenamiento no existe.';
            RETURN;
        END

        -- Verificar si hay alumnos asociados al plan
        IF EXISTS (SELECT 1 FROM Alumno WHERE id_plan = @id_plan AND estado = 1)
        BEGIN
            SET @respuesta = 0;
            SET @mensaje = 'No se puede eliminar el plan de entrenamiento porque hay alumnos asociados.';
            RETURN;
        END

        -- Cambiar el estado del plan de entrenamiento a 0 (eliminación lógica)
        UPDATE PlanEntrenamiento
        SET estado = 0
        WHERE id_plan = @id_plan;

        SET @respuesta = 1;
        SET @mensaje = 'Plan de entrenamiento eliminado exitosamente.';
    END TRY
    BEGIN CATCH
        SET @respuesta = 0;
        SET @mensaje = ERROR_MESSAGE();
    END CATCH
END;
GO

/*PROCEDIMIENTOS PARA RESTAURAR UN PLAN DE ENTRENAMIENTO*/
GO
CREATE PROCEDURE SP_RESTAURAR_PLAN_ENTRENAMIENTO
    @id_plan INT,
    @respuesta INT OUTPUT,
    @mensaje NVARCHAR(500) OUTPUT
AS
BEGIN
    BEGIN TRY
        -- Verificar si existe el plan de entrenamiento y ha sido eliminado lógicamente
        IF NOT EXISTS (SELECT 1 FROM PlanEntrenamiento WHERE id_plan = @id_plan AND estado = 0)
        BEGIN
            SET @respuesta = 0;
            SET @mensaje = 'El plan de entrenamiento no existe o ya está activo.';
            RETURN;
        END

        -- Restaurar el plan de entrenamiento (cambiar el estado a 1)
        UPDATE PlanEntrenamiento
        SET estado = 1
        WHERE id_plan = @id_plan;

        SET @respuesta = 1;
        SET @mensaje = 'Plan de entrenamiento restaurado exitosamente.';
    END TRY
    BEGIN CATCH
        SET @respuesta = 0;
        SET @mensaje = ERROR_MESSAGE();
    END CATCH
END;
GO

/*PROCEDIMIENTOS PARA OBTENER UN PLAN DE ENTRENAMIENTO*/
GO
CREATE PROCEDURE SP_OBTENER_PLAN_ENTRENAMIENTO_PORID(
   @id_plan INT
)
AS
BEGIN
   SET NOCOUNT ON;  -- Evitar el conteo de filas afectadas

   SELECT 
      id_plan,
	  nombre,
	  fechaInicio,
	  fechaFin,
	  cantSeries,
	  estado
   FROM 
      PlanEntrenamiento 
   WHERE 
      id_plan = @id_plan;
END
GO

/*PROCEDIMIENTOS ALMACENADOS PARA LAS TABLA 'PLAN_EJERCICIO', 'USUARIO_PLAN'*/
GO
CREATE PROCEDURE SP_ASOCIAR_PLAN_EJERCICIO
    @id_plan INT,
    @id_ejercicio INT
AS
BEGIN
    BEGIN TRY
        -- Insertar la relación entre el plan y el ejercicio
        INSERT INTO Plan_Ejercicio (id_plan, id_ejercicio)
        VALUES (@id_plan, @id_ejercicio);
    END TRY
    BEGIN CATCH
        -- Manejar cualquier error
        PRINT ERROR_MESSAGE();
    END CATCH
END;
GO

GO
CREATE PROCEDURE SP_ELIMINAR_PLAN_EJERCICIO
    @id_plan INT
AS
BEGIN
    DELETE FROM Plan_Ejercicio
    WHERE id_plan = @id_plan;
END;
GO

CREATE PROCEDURE SP_ASOCIAR_USUARIO_PLAN
    @id_usuario INT,
    @id_plan INT
AS
BEGIN
    BEGIN TRY
        -- Insertar la relación entre el usuario y el plan
        INSERT INTO Usuario_Plan (id_usuario, id_plan)
        VALUES (@id_usuario, @id_plan);
    END TRY
    BEGIN CATCH
        -- Manejar cualquier error
        PRINT ERROR_MESSAGE();
    END CATCH
END;
GO

GO
CREATE PROCEDURE SP_ELIMINAR_USUARIO_PLAN
    @id_plan INT
AS
BEGIN
    DELETE FROM Usuario_Plan
    WHERE id_plan = @id_plan;
END;
GO
-- PROCEDIMIENTOS PARA LISTAR LAS ASOCIACIONES DE COACHS Y EJERCICIOS AL PLAN

GO
CREATE PROCEDURE SP_LISTAR_EJERCICIOS_POR_PLAN
    @id_plan INT
AS
BEGIN
    SELECT e.id_ejercicio, e.nombre, e.repeticiones, e.tiempo
    FROM Ejercicio e
    INNER JOIN Plan_Ejercicio pe ON e.id_ejercicio = pe.id_ejercicio
    WHERE pe.id_plan = @id_plan;
END;
GO

GO
CREATE PROCEDURE SP_LISTAR_COACHS_POR_PLAN
    @id_plan INT
AS
BEGIN
    SELECT u.id_usuario, u.nombre, u.apellido, u.dni, u.email, u.fecha_nacimiento, u.telefono
    FROM Usuario u
    INNER JOIN Usuario_Plan up ON u.id_usuario = up.id_usuario
    WHERE up.id_plan = @id_plan;
END;
GO

-- PROCEDIMIENTO PARA FILTRAR LOS PLANES ASOCIADO A UN COACH
GO
CREATE PROCEDURE SP_LISTAR_PLAN_POR_COACHS
    @id_usuario INT
AS
BEGIN
    SELECT p.id_plan, p.nombre, p.fechaInicio, p.fechaFin, p.cantSeries, p.estado
    FROM PlanEntrenamiento p
    INNER JOIN Usuario_Plan up ON p.id_plan = up.id_plan
    WHERE up.id_usuario = @id_usuario;
END;
GO

GO
CREATE PROCEDURE SP_LISTARMEMBRESIAS
AS
BEGIN
    SELECT id_membresia, nombre, duracion, fecha_creacion, costo, estado
    FROM Membresia
END
GO

GO
CREATE PROCEDURE SP_REGISTRARALUMNO
    @id_usuario INT,
    @id_membresia INT,
    @id_plan INT,

    @nombre NVARCHAR(100),
    @apellido NVARCHAR(100),
    @email NVARCHAR(100),
    @telefono NVARCHAR(50),
    @foto NVARCHAR(MAX),
    @dni NVARCHAR(20),
    @fecha_nacimiento DATE,
    @contacto_emergencia NVARCHAR(100),
    @sexo NVARCHAR(10),
    @observaciones NVARCHAR(MAX),
    @estado BIT,

	-- parametros de salida
   @idUsuarioResultado int output,
   @mensaje varchar(500) output
AS
BEGIN
	set @idUsuarioResultado = 0
	set @mensaje = ''

	IF NOT EXISTS (select * from Alumno where dni = @dni)
		BEGIN
			INSERT INTO Alumno (id_usuario, id_membresia, id_plan, nombre, apellido, email, telefono, foto, dni, fecha_nacimiento, contacto_emergencia, sexo, observaciones, estado)
			VALUES (@id_usuario, @id_membresia, @id_plan, @nombre, @apellido, @email, @telefono, @foto, @dni, @fecha_nacimiento, @contacto_emergencia, @sexo, @observaciones, @estado);
	
			set @idUsuarioResultado = SCOPE_IDENTITY() 
			set @mensaje = 'Alumno registrado exitosamente!'
		END
	ELSE
		set @mensaje = 'Ya existe un alumno registrado con el mismo DNI'

END
GO

GO
CREATE PROC SP_ELIMINARALUMNO(
   @id_alumno int,
   
   -- parametros de salida
   @respuesta bit output,
   @mensaje varchar(500) output
)
as
  set @respuesta = 0
  set @mensaje = ''

begin

     -- Eliminación lógica, se actualiza el campo 'estado' a 0 (inactivo)
      UPDATE Alumno SET estado = 0 WHERE id_alumno = @id_alumno

      SET @respuesta = 1
      SET @mensaje = 'El alumno ha sido dado de baja correctamente!'

end
GO

GO
CREATE PROC SP_RESTAURARALUMNO(
   @id_alumno int,
   
   -- parametros de salida
   @respuesta bit output,
   @mensaje varchar(500) output
)
as
  set @respuesta = 0
  set @mensaje = ''

begin

     -- Restauracion lógica, se actualiza el campo 'estado' a 1 (activo)
      UPDATE Alumno SET estado = 1 WHERE id_alumno = @id_alumno

      SET @respuesta = 1
      SET @mensaje = 'El alumno ha sido dado de alta correctamente!'

end
GO

GO
CREATE PROCEDURE SP_EDITARALUMNO
	@id_alumno INT,
    @id_usuario INT,
    @id_membresia INT,
    @id_plan INT,

    @nombre NVARCHAR(100),
    @apellido NVARCHAR(100),
    @email NVARCHAR(100),
    @telefono NVARCHAR(50),
    @foto NVARCHAR(MAX),
    @dni NVARCHAR(20),
    @fecha_nacimiento DATE,
    @contacto_emergencia NVARCHAR(100),
    @sexo NVARCHAR(10),
    @observaciones NVARCHAR(MAX),
    @estado BIT,

	-- parametros de salida
   @respuesta bit output,
   @mensaje varchar(500) output
AS
BEGIN
  set @respuesta = 0
  set @mensaje = ''

	IF NOT EXISTS (select * from Alumno where dni = @dni AND id_alumno != @id_alumno)
		BEGIN
			UPDATE Alumno SET
			id_usuario = @id_usuario,
			id_membresia = @id_membresia,
			id_plan = @id_plan,
			nombre = @nombre,
			apellido = @apellido,
			email = @email,
			telefono = @telefono,
			foto = @foto,
			dni = @dni,
			fecha_nacimiento = @fecha_nacimiento,
			contacto_emergencia = @contacto_emergencia,
			sexo = @sexo,
			observaciones = @observaciones,
			estado = @estado
			WHERE id_alumno = @id_alumno
			
	
			set @respuesta = 1 
			set @mensaje = 'Alumno actualizado exitosamente!'
		END
	ELSE
		set @mensaje = 'Ya existe un alumno registrado con el mismo DNI'
END
GO

GO
CREATE PROCEDURE SP_VerificarCuotaAlumno
    @id_alumno INT,
    @cuotaAlDia VARCHAR(10) OUTPUT,
    @mesesAdeudados INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ultimaFechaPago DATE;
    DECLARE @duracionMembresia INT;
    DECLARE @fechaCubierta DATE;
    
    -- Obtener la última fecha de pago y la duración de la membresía del alumno
    SELECT @ultimaFechaPago = MAX(p.fecha),
           @duracionMembresia = m.duracion
    FROM Pago p
    JOIN Alumno a ON p.id_alumno = a.id_alumno
    JOIN Membresia m ON a.id_membresia = m.id_membresia
    WHERE a.id_alumno = @id_alumno
    GROUP BY m.duracion;
    
    -- Calcular la fecha hasta dónde alcanza la membresía
    SET @fechaCubierta = DATEADD(DAY, @duracionMembresia, @ultimaFechaPago);
    
    -- Verificar si la fecha cubierta es mayor o igual a la fecha actual
    IF @fechaCubierta >= GETDATE()
    BEGIN
        SET @cuotaAlDia = 'Si';
        SET @mesesAdeudados = 0;
    END
    ELSE
    BEGIN
        SET @cuotaAlDia = 'No';
        
        -- Calcular la cantidad de meses adeudados
        SET @mesesAdeudados = DATEDIFF(MONTH, @fechaCubierta, GETDATE());
    END
END;
GO

GO
CREATE PROCEDURE SP_REGISTRAR_PAGO
    @id_usuario INT,
    @id_alumno INT,
    @id_medioPago INT,
    @fecha DATE,
    @cantidad DECIMAL(10, 2),
    @total DECIMAL(10, 2),
	@recargo DECIMAL(10,2),
    @id_pago INT OUTPUT
AS
BEGIN
    INSERT INTO Pago (id_usuario, id_alumno, id_medioPago, fecha, cantidad, total, recargo)
    VALUES (@id_usuario, @id_alumno, @id_medioPago, @fecha, @cantidad, @total, @recargo);
    
    SET @id_pago = SCOPE_IDENTITY(); -- Obtener el id_pago generado
END;
GO

CREATE PROCEDURE SP_REGISTRAR_PAGO_DETALLE
    @id_pago INT,
    @id_membresia INT,
    @periodo INT,
    @monto DECIMAL(10, 2)
AS
BEGIN
    INSERT INTO PagoDetalle (id_pago, id_membresia, periodo, monto)
    VALUES (@id_pago, @id_membresia, @periodo, @monto);
END;
GO

GO
CREATE PROCEDURE SP_LISTAR_PAGOS
AS
BEGIN
    SELECT id_pago, id_usuario, id_alumno, id_medioPago, fecha, cantidad, total, recargo
    FROM Pago;
END;
GO

GO
CREATE PROCEDURE SP_LISTAR_DETALLES_PAGO
    @id_pago INT
AS
BEGIN
    SELECT id_pagoDetalle, id_pago, id_membresia, periodo, monto
    FROM PagoDetalle
    WHERE id_pago = @id_pago;
END;
GO

GO
CREATE PROCEDURE SP_ObtenerFechasAdeudadas
    @id_alumno INT
AS
BEGIN
   SET NOCOUNT ON;

    -- CTE para obtener la última fecha de pago del alumno y la duración de su membresía
    ;WITH UltimaFecha AS (
        SELECT 
            a.id_alumno,
            m.duracion,
            MAX(p.fecha) AS ultimaFechaPago
        FROM 
            Alumno a
        JOIN 
            Membresia m ON a.id_membresia = m.id_membresia
        LEFT JOIN 
            Pago p ON a.id_alumno = p.id_alumno
        WHERE 
            a.id_alumno = @id_alumno
        GROUP BY 
            a.id_alumno, m.duracion
    ),
    FechasAdeudadas AS (
        -- Generar fechas de pago a partir de la última fecha de pago
        SELECT 
            u.id_alumno,
            DATEADD(DAY, (ROW_NUMBER() OVER (ORDER BY (SELECT NULL))) * u.duracion, u.ultimaFechaPago) AS fecha_adeudada
        FROM 
            UltimaFecha u
        CROSS APPLY 
            (SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 
             UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8
             UNION ALL SELECT 9 UNION ALL SELECT 10 UNION ALL SELECT 11 UNION ALL SELECT 12) AS n(n)
    )
    -- Selecciona las fechas de pago vencidas y la correspondiente al mes actual
    SELECT 
        a.id_alumno,
        a.nombre,
        a.apellido,
		a.dni,
        f.fecha_adeudada,
		m.nombre AS nombreMembresia,
		m.costo
    FROM 
        FechasAdeudadas f
    JOIN 
        Alumno a ON f.id_alumno = a.id_alumno
    JOIN 
        UltimaFecha u ON u.id_alumno = a.id_alumno
	JOIN 
		Membresia m ON m.id_membresia = a.id_membresia
    WHERE 
        -- Solo fechas vencidas o la del próximo pago dentro del mes actual
        f.fecha_adeudada <= GETDATE() -- Filtra solo las fechas de pago vencidas
        OR (MONTH(f.fecha_adeudada) = MONTH(GETDATE()) AND YEAR(f.fecha_adeudada) = YEAR(GETDATE())) -- Y la fecha correspondiente al mes actual
    ORDER BY 
        f.fecha_adeudada;

END;