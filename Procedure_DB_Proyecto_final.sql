USE [DBBiblioteca_ProyectoFinal]
GO

Create PROCEDURE [dbo].[sp_Registrar_Prestamo]
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


Create PROCEDURE [dbo].[sp_Devolucion_Prestamo]
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