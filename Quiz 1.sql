use Northwind
--Task 1
--select CategoryName,Description
--from [dbo].[Categories]
--where CategoryName like 'M%'

--Task 2
--select ContactName, CustomerID, CompanyName
--from [dbo].[Customers]
--where Country = 'USA'

--Task 3
--select CategoryName, Description 
--from [dbo].[Categories]

--Task 4
--select *
--from [dbo].[Suppliers]
--where Fax != 'Null'

--Task 5
--select CustomerID
--from [dbo].[Orders]
--where RequiredDate between 'Jan 1,1997' and 'Jan 1,1998'

--Task 6
--select CompanyName, ContactName
--from [dbo].[Customers]
--where Country = 'Maxico' or Country = 'Sweden' or Country = 'Germany'

--Task 7
--use Northwind
--select Count(Discontinued) as Discont
--from dbo.Products
