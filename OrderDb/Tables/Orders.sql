CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PurchaseDate] DATETIME2 NULL, 
    [Total] MONEY NULL
)
