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

Select Tra_Vehicle.Code, Count (*) From Tra_Detail
Join Tra_Vehicle On Tra_Vehicle.Id = Tra_Detail.VehicleId
Where Tra_Detail.UserOutId Is Null
Group By  Tra_Vehicle.Code
Having Count(*) > 1