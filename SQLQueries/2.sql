--	Available products that are assigned to more than one category

SELECT 	
	p.Code
   ,p.Price
   ,p.Description
   ,p.DeliveryDate 
FROM Products p
LEFT JOIN ProductCategory pc ON p.Id = pc.ProductId
WHERE
	p.IsAvailable = 1
GROUP BY 
	p.Code
   ,p.Price
   ,p.Description
   ,p.DeliveryDate
HAVING 
   COUNT(pc.Id) > 1