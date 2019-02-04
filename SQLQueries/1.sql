-- Unavailable products which delivery is expected in current month

SELECT * FROM Products
WHERE 
	  IsAvailable = 0 
  AND MONTH(DeliveryDate) = MONTH(GETDATE())
  AND YEAR(DeliveryDate) = YEAR(GETDATE())