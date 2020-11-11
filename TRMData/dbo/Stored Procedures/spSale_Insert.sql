CREATE PROCEDURE [dbo].[spSale_Insert]
	@Id INT,
	@CashierId NVARCHAR(128),
	@SaleDate DATETIME2,
	@SubTotal money,
	@Tax money,
	@Total money
AS
BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO [dbo].[Sale](CashierId, SaleDate, SubTotal, Tax, Total)
	VALUES (@CashierId, @SaleDate, @SubTotal, @Tax, @Total);

	SELECT @Id = @@IDENTITY;

END