CREATE DATABASE CRUD;
GO
USE CRUD;

CREATE TABLE Usuarios(
	Id_Usuario int identity(1,1),
	Nombre varchar(15),
	Edad int,
	Correo varchar(max),
	Fecha_Nacimiento date,
)
GO

CREATE PROCEDURE sp_load
as begin
	SELECT * FROM Usuarios;
END;
GO

CREATE PROCEDURE sp_create
@Nombre varchar(15),
@Edad int,
@Correo varchar(max),
@Fecha date
as begin
	insert into usuarios values(@Nombre,@Edad,@Correo,@Fecha)
end;
go

CREATE PROCEDURE sp_read
@Id int
as begin
select * from usuarios where Id_Usuario=@Id;
end
go

CREATE PROCEDURE sp_update
@Id INT,
@Nombre varchar(15),
@Edad int,
@Correo varchar(max),
@Fecha date
as begin
	update usuarios set
	nombre=@Nombre,
	edad=@Edad,
	correo=@Correo,
	Fecha_Nacimiento=@Fecha
	WHERE Id_Usuario=@Id
end;
go 

CREATE PROCEDURE sp_delete
@Id int
as begin
delete from usuarios where Id_Usuario=@Id;
end
go