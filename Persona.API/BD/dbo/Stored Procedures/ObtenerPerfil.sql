CREATE PROCEDURE [dbo].[ObtenerPerfil]
	@IdPersona Uniqueidentifier
AS
	SELECT * FROM Perfiles WHERE IdPersona = @IdPersona
RETURN 0
