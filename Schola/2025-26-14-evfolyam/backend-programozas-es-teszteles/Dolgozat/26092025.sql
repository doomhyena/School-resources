-- 1.

SELECT SUM(od.Quantity * od.UnitPrice * (1 - od.Discount)) AS Revenue_1997
FROM OrderDetails od
JOIN Orders o ON od.OrderID = o.OrderID
JOIN Products p ON od.ProductID = p.ProductID
JOIN ProductCategories c ON p.ProductCategoryID = c.ProductCategoryID
WHERE c.ProductCategoryName = 'Confections'
  AND YEAR(o.OrderDate) = 1997;


-- 2.

SELECT p.ProductID,
       p.ProductName,
       SUM(od.Quantity) AS TotalQuantitySold
FROM OrderDetails od
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY p.ProductID, p.ProductName
ORDER BY TotalQuantitySold DESC;

-- 3.

SELECT p.ProductID,
       p.ProductName,
       SUM(od.Quantity) AS TotalQuantitySold
FROM OrderDetails od
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY p.ProductID, p.ProductName
ORDER BY TotalQuantitySold DESC;

-- 4.

SELECT TOP 1 
       p.ProductID,
       p.ProductName,
       SUM(od.Quantity) AS TotalQuantitySold
FROM OrderDetails od
JOIN Orders o ON od.OrderID = o.OrderID
JOIN Products p ON od.ProductID = p.ProductID
WHERE YEAR(o.OrderDate) = 1998
GROUP BY p.ProductID, p.ProductName
ORDER BY TotalQuantitySold DESC;
