
INSERT INTO OrderDb.DBO.Orders
( PurchaseDate, Total)
VALUES('10/1/2023', 50),
('10/15/2023', 150),
('10/18/2023', 115)

INSERT INTO OrderDb.DBO.OrderDetails
( OrderId, Item, Price)
VALUES 
(1, 'Gum', 15),
(1, 'Grass Seed', 35),
(2, 'Gum', 15),
(2, 'Chacoal', 50),
(2, 'Coat', 85),
(3, 'Excyclopedia Book A', 10),
(3, 'Excyclopedia Book B', 10),
(3, 'Excyclopedia Book C', 10),
(3, 'Excyclopedia Book D', 10),
(3, 'Excyclopedia Book E', 10),
(3, 'Excyclopedia Book F', 10),
(3, 'Excyclopedia Book G', 10),
(3, 'Excyclopedia Book H', 10),
(3, 'Excyclopedia Book I', 10),
(3, 'Excyclopedia Book K', 10),
(3, 'Excyclopedia Book L', 10)