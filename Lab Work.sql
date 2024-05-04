--Query 1
--SELECT 
--    CustomerID,
--    (SELECT TOP 1 OrderID FROM Orders WHERE Orders.CustomerID = Customers.CustomerID) AS OrderID,
--    (SELECT TOP 1 OrderDate FROM Orders WHERE Orders.CustomerID = Customers.CustomerID) AS OrderDate
--FROM 
--    Customers;

--Query 2
--SELECT
--    Customers.CustomerID,
--    NULL AS OrderID,
--    NULL AS OrderDate
--FROM 
--    Customers
--WHERE 
--    Customers.CustomerID NOT IN (SELECT DISTINCT CustomerID FROM Orders);

--Query 3
--SELECT 
--    Orders.CustomerID,
--    Orders.OrderID,
--    Orders.OrderDate
--FROM 
--    Orders
--WHERE 
--    MONTH(Orders.OrderDate) = 7 
--    AND YEAR(Orders.OrderDate) = 1997;

--Query 4

