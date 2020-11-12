CREATE PROCEDURE [dbo].[spSale_SaleReport]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [S].[SaleDate], [S].[SubTotal], [S].[Tax], [S].[Total]
		, U.FirstName, U.LastName, U.EmailAddress
	FROM dbo.Sale S
	INNER JOIN dbo.[USER] U ON U.Id = S.CashierId
END
