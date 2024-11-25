-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [AgregarDocumento]
	-- Add the parameters for the stored procedure here
	@Id AS uniqueidentifier
	,@Nombre AS VARCHAR(MAX)
	,@Ruta AS VARCHAR(MAX)
	,@Tipo AS VARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Documentos]
           ([Id]
           ,[Nombre]
           ,[Ruta]
           ,[Tipo])
     VALUES
           (@Id
           ,@Nombre
           ,@Ruta
           ,@Tipo)
END