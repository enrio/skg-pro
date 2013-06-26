Use Master
Go

If Exists(Select * From SysDatabases Where Name = 'xSKGv1')
	Drop Database xSKGv1

Restore Database xSKGv1
From Disk = 'C:\BXE-27.06.13.01.00.00.bak'

Set Dateformat Dmy
Declare @fr Datetime
Declare @to Datetime
Set @fr = '25/01/2013 1:00:01'
Set @to = '26/01/2013 1:00:00'

Select Tra_Vehicle.Code, Tra_Detail.* From Tra_Detail Join Tra_Vehicle
On Tra_Detail.VehicleId = Tra_Vehicle.Id
Where DateOut >= @fr And DateOut <= @to
And UserOutId Is Not Null
And Tra_Detail.Code = 'FIXED'
Order By [Order]

Select Tra_Vehicle.Code, Tra_Detail.* From Tra_Detail Join Tra_Vehicle
On Tra_Detail.VehicleId = Tra_Vehicle.Id
Where DateOut >= @fr And DateOut <= @to
And UserOutId Is Not Null
And Tra_Detail.Code <> 'FIXED'
Order By [Order]

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

declare @name nvarchar(max)
set @name = convert(nvarchar, getdate(), 4)
set @name = @name + '.' + convert(nvarchar, getdate(), 8)
set @name = replace(@name, ':', '.')

declare @cmd nvarchar(max)
set @cmd = 'BACKUP DATABASE xSKGv1
TO DISK = ''D:\xSKGv1\BXE-' + @name + '.bak''
WITH FORMAT,
MEDIANAME = ''xSKGv1'',
NAME = ''xSKGv1 Full backup'''

EXECUTE sp_executesql @cmd