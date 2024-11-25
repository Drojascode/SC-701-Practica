-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AgregarPersona]
	-- Add the parameters for the stored procedure here
    @Identificacion nvarchar(max)
	,@Nombre nvarchar(max)
    ,@Apellido nvarchar(max)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	    DECLARE @Id AS UniqueIdentifier = NewId();		
    -- Insert statements for procedure here
	INSERT INTO [dbo].[Personas]
           ([Id]
           ,[Identificacion]
           ,[Nombre]
           ,[Apellido])
     VALUES
           (@Id,
		   @Identificacion,
		   @Nombre,
		   @Apellido)
	SELECT @Id
END