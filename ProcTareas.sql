create database GestionTareas
-- Creando tabla
CREATE TABLE Tareas(
    CodigoTarea INT,
	NombreMateria VARCHAR(100),
    NombreTarea VARCHAR(100),
	Estado bit,
	Fecha datetime default getdate(),
    Tarea TEXT
)

-- ---> PROCEDIMIENTO PARA REGISTRAR LA TAREA <---
ALTER PROC SP_RegistrarTarea(
@Codigo int, 
@Materia varchar(100),
@Nombre varchar(100),
@Estado bit,
@Tarea TEXT,
@Mensaje varchar(500) output)
AS
BEGIN
set @Mensaje= ''
	if not exists(select * from Tareas where CodigoTarea = @Codigo)
	BEGIN
		INSERT INTO Tareas(CodigoTarea,NombreMateria,NombreTarea,Estado,Tarea)VALUES
		(@Codigo,@Materia,@Nombre,@Estado,@Tarea)
		set @Mensaje= 'Tarea Registrada'
	END
	ELSE
		set @Mensaje= 'Este código registrado en otra tarea, ingresa otro que sea valido'
END

-- PRUEBA DE PROC
declare @mensaje varchar(500)
EXEC SP_RegistrarTarea 111,'Mate','Hacer proyecto',1,'adasdasdasdasd',@mensaje output

select * from Tareas

-- ---> PROCEDIMIENTO PARA MODIFICAR LA TAREA <---
alter PROC SP_ModificarTarea(
@CodigoAnterior int,
@CodigoNuevo int, 
@Materia varchar(100),
@Nombre varchar(100),
@Estado bit,
@Tarea TEXT,
@Mensaje varchar(500) output)
AS
BEGIN
set @Mensaje= ''
	if not exists(select * from Tareas where CodigoTarea = @CodigoNuevo AND CodigoTarea != @CodigoAnterior)
	BEGIN
		UPDATE Tareas SET
		CodigoTarea = @CodigoNuevo,
		NombreMateria = @Materia,
		NombreTarea = @Nombre,
		Estado = @Estado,
		Tarea = @Tarea
		WHERE CodigoTarea = @CodigoAnterior
		set @Mensaje= 'Tarea modificada correctamente.'
	END
	ELSE
		set @Mensaje= 'Este código registrado en otra tarea, ingresa otro que sea valido'
END

declare @mensaje varchar(500)
declare @respuesta bit
EXEC SP_ModificarTarea 234,234,'Locochon','reasd',1,'nose',@respuesta output,@mensaje output

select * from Tareas

-- ---> PROCEDIMIENTO PARA MODIFICAR LA TAREA <---
CREATE PROC SP_EliminarTarea(
@Codigo int,
@Mensaje varchar(500) output
)AS
BEGIN
	DELETE FROM Tareas WHERE CodigoTarea = @Codigo
	SET @Mensaje = 'Tarea eliminada correctamente.'
END
-- PRUEBA DE PROC
declare @mensaje varchar(500)
EXEC SP_EliminarTarea 6756,@mensaje output