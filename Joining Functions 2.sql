use DB1
--create table Enroll
--(
--	StudentID int,
--	CourseID varchar (5),
--	Year int
--)

--insert into Enroll
--values
--(1, 'C1', 2021),
--(2, 'C2', 2022),
--(3, 'C3', 2023)
--(1, 'C4', 2023)

--select E2.StudentID
--from Enroll as E1, Enroll as E2
--where E1.StudentID = E2.StudentID
--AND E1.CourseID <> E2.CourseID

select E1.StudentID
from Enroll as E1
join Enroll as E2
On E1.StudentID = E2.StudentID
Where E1.CourseID <> E2.CourseID
