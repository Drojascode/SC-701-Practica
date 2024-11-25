-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EditarPersona]
	-- Add the parameters for the stored procedure here
	 @Id  UniqueIdentifier
    ,@Identificacion nvarchar(max)
	,@Nombre nvarchar(max)
    ,@Apellido nvarchar(max)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	    
    -- Insert statements for procedure here
	UPDATE [dbo].[Personas]
	SET           
           [Identificacion]=@Identificacion
           ,[Nombre]=@Nombre
           ,[Apellido]=@Apellido
	WHERE [Id]=@Id
	SELECT @Id
END