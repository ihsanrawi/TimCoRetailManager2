CREATE PROCEDURE [dbo].[spInventory_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [ProductId], [Quantity], [PurchasePrice], [PurchaseDate] 
	FROM dbo.Inventory;
END