CREATE OR ALTER PROCEDURE [dbo].[spOrders_GetAll_Json]
AS
	SELECT 
	Id
,	PurchaseDate
,	Total
,	(select 
		[Id], [OrderId], [Item], [Price]
	from dbo.OrderDetails
	where orderId = M.id
	FOR JSON AUTO) LineItems
FROM DBO.Orders M
FOR JSON AUTO
