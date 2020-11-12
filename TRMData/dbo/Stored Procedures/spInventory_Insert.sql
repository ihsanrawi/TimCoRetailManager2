CREATE PROCEDURE [dbo].[spInventory_Insert]
	--[ProductId], [Quantity], [PurchasePrice], [PurchaseDate]
	@ProductId INT,
	@Quantity INT,
	@PurchasePrice MONEY,
	@PurchaseDate DATETIME2
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.Inventory(ProductId, Quantity, PurchasePrice, PurchaseDate)
	VALUES (@ProductId, @Quantity, @PurchasePrice, @PurchaseDate);

END
