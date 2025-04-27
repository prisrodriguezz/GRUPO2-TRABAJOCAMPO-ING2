USE Proyecto_GymMaster;
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

CREATE PROCEDURE SP_LISTAR_EJERCICIOS
AS
BEGIN
    SELECT * FROM Ejercicio;
END;
GO

CREATE PROCEDURE SP_LISTAR_PLAN_ENTRENAMIENTO
AS
BEGIN
    SELECT * FROM PlanEntrenamiento
END
GO

/*PROCEDIMIENTOS PARA AGREGAR UN PLAN DE ENTRENAMIENTO*/
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

CREATE PROCEDURE SP_ELIMINAR_USUARIO_PLAN
    @id_plan INT
AS
BEGIN
    DELETE FROM Usuario_Plan
    WHERE id_plan = @id_plan;
END;