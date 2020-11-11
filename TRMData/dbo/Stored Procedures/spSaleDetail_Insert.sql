CREATE PROCEDURE [dbo].[spSaleDetail_Insert]
	@SaleId INT,
	@ProductId INT,
	@Quantity INT,
	@PurchasePrice money,
	@Tax money
AS
BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO [dbo].[SaleDetail](SaleId, ProductId, Quantity, PurchasePrice, Tax)
	VALUES (@SaleId, @ProductId, @Quantity, @PurchasePrice, @Tax);
END