create database GestionTareas

GO

use GestionTareas

GO

-- Creando tabla
CREATE TABLE Tareas(
    CodigoTarea INT,
	NombreMateria VARCHAR(100),
    NombreTarea VARCHAR(100),
	Estado bit,
	Fecha datetime default getdate(),
    Tarea TEXT
)

GO

-- ---> PROCEDIMIENTO PARA REGISTRAR LA TAREA <---
CREATE PROC SP_RegistrarTarea(
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

GO

-- ---> PROCEDIMIENTO PARA MODIFICAR LA TAREA <---
CREATE PROC SP_ModificarTarea(
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

GO

-- ---> PROCEDIMIENTO PARA MODIFICAR LA TAREA <---
CREATE PROC SP_EliminarTarea(
@Codigo int,
@Mensaje varchar(500) output
)AS
BEGIN
	DELETE FROM Tareas WHERE CodigoTarea = @Codigo
	SET @Mensaje = 'Tarea eliminada correctamente.'
END
