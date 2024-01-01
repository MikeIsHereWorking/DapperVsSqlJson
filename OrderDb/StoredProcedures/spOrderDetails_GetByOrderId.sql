CREATE PROCEDURE [dbo].[spOrderDetails_GetByOrderId]
	@OrderId int
AS
begin
	select [Id], [OrderId], [Item], [Price]
	from dbo.OrderDetails
	where OrderId = @OrderId;
end
