CREATE PROCEDURE [dbo].[spSale_Lookup]
	@CashierId NVARCHAR(128),
	@SaleDate DATETIME2
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id 
	FROM [dbo].[Sale]
	WHERE CashierId = @CashierId 
		AND SaleDate  = @SaleDate; 
END