CREATE PROCEDURE [dbo].[spOrders_GetAll]
AS
begin
	select [Id], [PurchaseDate], [Total]
	from dbo.Orders;
end
