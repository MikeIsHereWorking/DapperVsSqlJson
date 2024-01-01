CREATE PROCEDURE [dbo].[spOrders_GetAll_Json]
AS
	SELECT 
	Id
,	PurchaseDate
,	Total
,	(select 
		[Id], [OrderId], [Item], [Price]
	from dbo.OrderDetails
	FOR JSON AUTO) OrderDetailModel
FROM DBO.Orders
FOR JSON AUTO
