-- Activity-1
-- Average Aggregate
SELECT AVG(UnitPrice) AS AverageValue
FROM Northwind.dbo.Products;
-- Minimum Aggregate
SELECT Min(UnitPrice) AS MinimumValue
FROM Northwind.dbo.Products;
-- Sum Aggregate
SELECT Sum(UnitPrice) AS Total
FROM Northwind.dbo.Products;
-- Count Aggregate
SELECT Count(UnitPrice) AS NumberOfFrieghts
FROM Northwind.dbo.Products;
-- Standard Deviation Aggregate
SELECT StDev(UnitPrice) AS StandardDeviation
FROM Northwind.dbo.Products;
-- Standard Deviation for Population Aggregate
SELECT StDevP(UnitPrice) AS NumberOfFrieghts
FROM Northwind.dbo.Products;
-- Variance Aggregate
SELECT Var(UnitPrice) AS Variance
FROM Northwind.dbo.Products;
-- Variance for Population Aggregate
SELECT VarP(UnitPrice) AS VariancePopulation
FROM Northwind.dbo.Products;
-- Maximum Aggregate
SELECT Max(UnitPrice) AS MaximumValue
FROM Northwind.dbo.Products;

-- Activity-2
-- Average Aggregate
SELECT CategoryID, AVG(UnitPrice) as AvgUnitPrice
FROM Northwind.dbo.Products
GROUP BY CategoryID
HAVING AVG(UnitPrice) > 25;
-- Sum Aggregate
SELECT CategoryID, Sum(UnitPrice) as PriceTotal
FROM Northwind.dbo.Products
GROUP BY CategoryID
HAVING Sum(UnitPrice) > 250;