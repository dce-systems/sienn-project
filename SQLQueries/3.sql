-- Top 3 categories with info about numbers of available and average price(...)

SELECT TOP(3)
	c.Code AS 'Category code'
   ,c.Description AS 'Category description'
   ,AVG(p.Price) AS 'Average price'
   ,COUNT(p.IsAvailable) AS 'Number of available products'
FROM Products p
LEFT JOIN ProductCategory pc ON p.Id = pc.ProductId
LEFT JOIN Categories c ON pc.CategoryId = c.Id
WHERE
	p.IsAvailable = 1
GROUP BY 
    c.Code
   ,c.Description
ORDER BY
	AVG(p.Price) DESC