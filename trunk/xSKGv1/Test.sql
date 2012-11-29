Select Code, Count(*) From Tra_Vehicle
Group By Code
Having Count(*) > 1

Select * From Tra_Vehicle
Where Code Like '%.%'

Select * From Tra_Vehicle
Where Code Like '%-%'

Select * From Tra_Detail
Where [Order] = 0
Order By [Order]

Select * From Tra_Detail
Where UserOutId Is Null
Order By [Order]

Select * From Tra_Detail
Order By [Order]