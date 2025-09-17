-- 1.feladat: Jelenísd meg az évvenkénti forgalmat! ORDERS és ORDER DETAILS

-- SELECT YEAR(o.OrderDate) AS OrderYear, SUM(od.Quantity * od.UnitPrice * (1 - od.Discount)) AS TotalSales
-- FROM Orders o
-- JOIN [Order Details] od ON o.OrderID = od.OrderID
-- GROUP BY YEAR(o.OrderDate)
-- ORDER BY OrderYear;

-- 2.feladat:Jelenísd meg melyik termékből mekkora bevételt hozott (termék neve)

-- SELECT p.ProductName, SUM(od.Quantity * od.UnitPrice * (1 - od.Discount)) AS TotalRevenue
-- FROM [Order Details] od
-- JOIN Products p ON od.ProductID = p.ProductID
-- GROUP BY p.ProductName
-- ORDER BY TotalRevenue DESC;

-- 3.feladat: Jelenísd meg az évvenkénti forgalmat kategóriánként! ORDERS és ORDER DETAILS

-- SELECT YEAR(o.OrderDate) AS OrderYear, c.CategoryName, SUM(od.Quantity * od.UnitPrice * (1 - od.Discount)) AS TotalSales
-- FROM Orders o
-- JOIN [Order Details] od ON o.OrderID = od.OrderID
-- JOIN Products p ON od.ProductID = p.ProductID
-- JOIN Categories c ON p.CategoryID = c.CategoryID
-- GROUP BY YEAR(o.OrderDate), c.CategoryName
-- ORDER BY OrderYear, c.CategoryName;

-- 4.feladat: Melyik vevő mennyit vásárolt?

SELECT c.CompanyName, SUM(od.Quantity * od.UnitPrice * (1 - od.Discount)) AS TotalSpent
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.CompanyName
ORDER BY TotalSpent DESC;
