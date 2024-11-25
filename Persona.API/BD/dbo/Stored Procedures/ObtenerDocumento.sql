-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE ObtenerDocumento
	-- Add the parameters for the stored procedure here
	@Id AS uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [Id]
           ,[Nombre]
           ,[Ruta]
           ,[Tipo]
	FROM [dbo].[Documentos]
    WHERE Id=@Id
END