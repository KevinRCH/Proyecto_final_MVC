use [Master]
go

Create database[DBBiblioteca_ProyectoFinal]
go
use [DBBiblioteca_ProyectoFinal]
go

-----------------------------------------------
Create table[T_USUARIOS](
[ID_persona] int not null identity,
[Nombre] varchar(50) not null,
[Apellidos] varchar(50) not null,
[Correo] varchar(50) not null,
[Clave] varchar(20) not null,
[Codigo] varchar(100) null,
[Id_Tipopersona] int not null,
[Estado] bit not null,
[Fecha_creacion] datetime null,
)
go

Create table [T_TIPOPERSONA](
[ID_TipoPersona] int not null identity,
[Descripcion] varchar(50) not null,
[Estado] bit not null,
[Fecha_creacion] datetime null,
)
go
-----------------------------------------------
Alter table [T_USUARIOS]
ADD Constraint [PK_Usuarios] Primary key clustered(
[ID_persona]
)
go
Alter table [T_TIPOPERSONA]
ADD Constraint [PK_TipoPersona] Primary key clustered(
[ID_TipoPersona]
)
go
-----------------------------------------------
Create table [T_AUTOR](
[ID_Autor] int not null identity,
[NombreApellidos] varchar(100) not null,
[Estado] bit not null,
[Fecha_creacion] datetime null,
)
go
Create table [T_CATEGORIA_LIBRO](
[ID_Categoria] int not null identity,
[Nombre] varchar(50) not null,
[Estado] bit not null,
[Fecha_creacion] datetime null,
)
go
Create table [T_EDITORIAL](
[ID_Editorial] int not null identity,
[Nombre] varchar(50) not null,
[Correo] varchar(50) null,
[Pais] varchar(50) null,
[Estado] bit not null,
[Fecha_creacion] datetime null,
)
go
Create table [T_Libro](
[ID_Libro] int not null identity,
[Titulo] varchar(50) not null,
[ISBN] varchar(20) null,
[URL_Imagen] varchar(200) null,
[Id_Autor] int not null,
[Id_Categoria] int not null,
[Id_Editorial] int not null,
[Ubicacion] varchar(50) null,
[Ejemplares] int not null,
[Ejemplares_Disponibles] int null,
[Estado] bit not null,
[Fecha_creacion] datetime null,
)
go
-----------------------------------------------
Alter table [T_AUTOR]
ADD Constraint [PK_Autor] Primary key clustered(
[ID_Autor]
)
go
Alter table [T_CATEGORIA_LIBRO]
ADD Constraint [PK_Categoria] Primary key clustered(
[ID_Categoria]
)
go
Alter table [T_EDITORIAL]
ADD Constraint [PK_Editorial] Primary key clustered(
[ID_Editorial]
)
go
Alter table [T_Libro]
ADD Constraint [PK_Libro] Primary key clustered(
[ID_Libro]
)
go
---------------------------------------------
Create table [T_ESTADO_PRESTAMO](
[ID_Estado] int not null identity,
[Descripcion] varchar(100) null,
[Estado] bit not null,
[Fecha_creacion] datetime null,
)
Create table [T_PRESTAMO](
[ID_Prestamo] int not null identity,
[ID_Estado_Prestamo] int not null,
[ID_Persona] int not null,
[ID_Libro] int not null,
[Fecha_Devolucion] datetime null,
[Fecha_Devolucion_Real] datetime null,
[Estado_Entrega] varchar(100)  null,
[Estado_Recibido] varchar(100) null,
[Estado] bit not null,
[Fecha_creacion] datetime null,
)
go
-----------------------------------------------
Alter table [T_ESTADO_PRESTAMO]
ADD Constraint [PK_EstadoPrestamo] Primary key clustered(
[ID_Estado]
)
go
Alter table [T_PRESTAMO]
ADD Constraint [PK_Prestamo] Primary key clustered(
[ID_Prestamo]
)
go
-------------------------------------------------------------------------------
Alter PROCEDURE [dbo].[sp_Registrar_Prestamo]
(

	
	@Descripcion varchar(100),
	@Estado2 bit,
	@ID_Persona int,
	@ID_Libro int,
	@Estado_Entrega varchar(100),
	@Estado bit

	
	
	
)
AS
BEGIN
			if EXISTS(Select * from [dbo].[T_Libro] where [ID_Libro]=@ID_Libro)
				BEGIN
					
					declare @Ejemplares as int= (Select [Ejemplares]from[dbo].[T_Libro] where [ID_Libro]=@ID_Libro)
					declare @Ejemplares_disponibles as int= (Select [Ejemplares_Disponibles] from[dbo].[T_Libro] where [ID_Libro]=@ID_Libro)
					if(@Ejemplares_disponibles>0)
					begin
						INSERT INTO [dbo].[T_ESTADO_PRESTAMO] ([Descripcion],[Estado],[Fecha_creacion])
						VALUES (@Descripcion,@Estado2,GETDATE())

						declare @Estado_prestamoID as int= (Select Max([ID_Estado]) from [dbo].[T_ESTADO_PRESTAMO])

						INSERT INTO [dbo].[T_PRESTAMO] ([ID_Estado_Prestamo],[ID_Persona],[ID_Libro],[Fecha_Devolucion],[Fecha_Devolucion_Real], [Estado_Entrega],[Estado],[Fecha_creacion])
						VALUES (@Estado_prestamoID,@ID_Persona, @ID_Libro,DATEADD(day, 15, GETDATE()),GETDATE(),@Estado_Entrega,@Estado,GETDATE());
						UPdate [dbo].[T_Libro] set [Ejemplares_Disponibles]=[Ejemplares_Disponibles]-1 where [ID_Libro]=@ID_Libro

					end

				END

END

exec [dbo].[sp_Registrar_Prestamo]'Pendiente','1','4','1','Optimo','1'
SELECT DATEADD(day, 15, GETDATE()) AS NewDate;
SELECT * from [dbo].[T_ESTADO_PRESTAMO];
SELECT * from [dbo].[T_PRESTAMO];

Alter PROCEDURE [dbo].[sp_Devolucion_Prestamo]
(
	@ID_persona int,
	@Codigo varchar(100),
	@ID_Prestamo int,
	@Estado_Recibido varchar(100)
)
AS
BEGIN
			if EXISTS(Select * from [dbo].[T_USUARIOS] where [ID_persona]=@ID_persona And [Codigo]=@Codigo)
				BEGIN

					declare @ID_Libro as int= (Select[ID_Libro] from [dbo].[T_PRESTAMO] where [ID_Prestamo]=@ID_Prestamo)
					declare @Ejemplares as int= (Select [Ejemplares]from[dbo].[T_Libro] where [ID_Libro]=@ID_Libro)
					declare @Ejemplares_disponibles as int= (Select [Ejemplares_Disponibles] from[dbo].[T_Libro] where [ID_Libro]=@ID_Libro)

					if(@Ejemplares_disponibles<@Ejemplares)
					begin
					declare @ID_estado as int= (Select [ID_Estado_Prestamo] from [dbo].[T_PRESTAMO] where [ID_Prestamo]=@ID_Prestamo)
						UPdate [dbo].[T_ESTADO_PRESTAMO] set [Estado]=0 where[ID_Estado]=@ID_estado
						UPdate [dbo].[T_ESTADO_PRESTAMO] set [Descripcion]='Devuelto' where[ID_Estado]=@ID_estado

						UPdate [dbo].[T_PRESTAMO] set [Fecha_Devolucion_Real]=GETDATE() where[ID_Prestamo]=@ID_Prestamo
						UPdate [dbo].[T_PRESTAMO] set [Estado_Recibido]=@Estado_Recibido where[ID_Prestamo]=@ID_Prestamo
						UPdate [dbo].[T_Libro] set [Ejemplares_Disponibles]=([Ejemplares_Disponibles]+1) where [ID_Libro]=@ID_Libro

					end

				END

END

exec [dbo].[sp_Devolucion_Prestamo]'4','123','7','En excelente estado'
SELECT * from [dbo].[T_ESTADO_PRESTAMO];
SELECT * from [dbo].[T_PRESTAMO];