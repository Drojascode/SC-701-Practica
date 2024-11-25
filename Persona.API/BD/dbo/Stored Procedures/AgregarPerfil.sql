CREATE PROCEDURE [dbo].[AgregarPerfil]
	@IdPersona Uniqueidentifier,
	@Foto uniqueidentifier,
	@Video Varchar(Max),
	@Curriculum uniqueidentifier
AS
	INSERT INTO Perfiles (IdPersona, Foto, Video, Curriculum) 
	VALUES (@IdPersona, @Foto, @Video, @Curriculum)
	SELECT @IdPersona
