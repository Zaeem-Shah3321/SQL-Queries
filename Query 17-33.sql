--Query 17
Select Name
from Employees
WHERE LEN(Name) = 6;
--Query 18
Select *
From Employees
WHERE MONTH(HireDate) = 1;
--Query 19
SELECT CONCAT(Name, ' works for ', ManagerName) AS Relationship
FROM employees;
--Query 20
Select *
From Employees
Where Designation = 'Clerk';
--Query 21
Select *
From Employees
Where Experience > 27;
--Query 22
Select *
From Employees
Where Salary < 3500;
--Query 23
Select EmployeeName, JobName, Salary
From Employees
Where Designation = 'ANALYST';
--Query 24
SELECT *
FROM Employees
WHERE YEAR(JoinDate) = 1991;
--Query 25
SELECT EmployeeID, EmployeeName, HireDate, Salary
FROM Employees
WHERE HireDate < '1991-04-01';
--Query 26
SELECT EmployeeName, JobName
FROM Employees
WHERE ReportsToManager IS NULL OR ReportsToManager = '';
--Query 27
SELECT *
FROM Employees
WHERE HireDate  = '1991-05-01';
--Query 28
SELECT EmployeeID, EmployeeName, Salary, DATEDIFF(CURDATE(), StartDate) AS Experience
FROM Employees
WHERE ManagerID = 68319;
--Query 29
SELECT EmployeeID, EmployeeName, Salary, DATEDIFF(CURDATE(), StartDate) AS Experience
FROM Employees
WHERE Salary > 100;
--Query 30
SELECT EmployeeName
FROM Employees
WHERE DATEDIFF(RetirementDate, StartDate) >= 2920 AND RetirementDate > '1999-12-31';
--Query 31
SELECT *
FROM Employees
WHERE Salary % 2 <> 0;
--Query 32
SELECT *
FROM Employees
WHERE COUNT(Salary) = 3;
--Query 33
Select *
From Employees
WHERE MONTH(HireDate) = 4;