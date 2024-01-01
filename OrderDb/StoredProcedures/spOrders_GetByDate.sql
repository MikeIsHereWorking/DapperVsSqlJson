CREATE PROCEDURE [dbo].[spOrders_GetByDate]
	@StartDate datetime2,
	@EndDate datetime2
AS
begin
	select [Id], [PurchaseDate], [Total]
	from dbo.Orders
	where PurchaseDate between @StartDate and @EndDate;
end
