CREATE PROCEDURE [dbo].[spOrderDetails_GetByDate]
	@StartDate datetime2,
	@EndDate datetime2
AS
begin
	select [od].[Id], [od].[OrderId], [od].[Item], [od].[Price]
	from dbo.OrderDetails od
	inner join dbo.Orders o on o.Id = od.OrderId
	where o.PurchaseDate between @StartDate and @EndDate;
end
