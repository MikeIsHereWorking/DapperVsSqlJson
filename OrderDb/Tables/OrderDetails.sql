CREATE TABLE [dbo].[OrderDetails]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [OrderId] INT NOT NULL, 
    [Item] NVARCHAR(50) NULL, 
    [Price] MONEY NULL
)
