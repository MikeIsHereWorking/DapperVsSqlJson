CREATE PROCEDURE [dbo].[spOrderDetails_GetAll]
AS
begin
	select [Id], [OrderId], [Item], [Price]
	from dbo.OrderDetails;
end
