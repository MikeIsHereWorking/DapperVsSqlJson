CREATE PROCEDURE [dbo].[spOrders_GetById]
	@Id int
AS
begin
	select [Id], [PurchaseDate], [Total]
	from dbo.Orders
	where Id = @Id;
end
