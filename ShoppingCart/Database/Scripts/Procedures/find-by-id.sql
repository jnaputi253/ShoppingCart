USE ShoppingCart

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE sp_FindItemById

	@Id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [Id], [Name], [Description], [Price]
	FROM dbo.Items
	WHERE Id = @Id
		
END
GO
