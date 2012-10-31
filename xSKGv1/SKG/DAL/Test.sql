Use xSKGv1
Select * From Pol_Dictionary Order By [Type], [Order]
Select * From Pol_User
Select * From Pol_UserRight
Select * From Pol_UserRole
Select * From Pol_RoleRight
Select * From Pol_Selection
Select * From Pol_Chat

select * from Tra_Tariff
select * from Tra_Vehicle order by [Order]

Select * From Pol_Dictionary
Order By Substring(Code, 1, 3), [Order]

Select * From Pol_Dictionary 
Where [Type] = 'RIGHT'
Order By Substring(Code, 1, 3), [Order]

Select U.*, Rr.* From Pol_RoleRight Rr
	Join Pol_Dictionary R On R.Id = Rr.Pol_RightId
	Join Pol_UserRole Ur On Ur.Pol_RoleId = Rr.Pol_RoleId
	Join Pol_User U On U.Id = Ur.Pol_UserId

Delete From Pol_Dictionary Where ParentId Is Not Null
Delete From Pol_Dictionary

Select B.Code, A.Code, A.[Order], A.DateOut, * From Tra_Detail A
Join Tra_Vehicle B On A.Tra_VehicleId = B.Id
Join Pol_User C On A.Pol_UserOutId = C.Id
Where C.Acc = 'admin'
Order By A.[Code], A.DateOut

Select B.Code, A.Code, A.[Order], A.DateOut, * From Tra_Detail A
Join Tra_Vehicle B On A.Tra_VehicleId = B.Id
Join Pol_User C On A.Pol_UserOutId = C.Id
Where C.Acc = 'cr'
Order By A.[Code], A.DateOut

Select B.Code, A.Code, A.[Order], A.DateOut, * From Tra_Detail A
Join Tra_Vehicle B On A.Tra_VehicleId = B.Id
Join Pol_User C On A.Pol_UserOutId = C.Id
Where C.Acc = 'ntt'
Order By A.[Code], A.DateOut

Delete From Tra_Detail
Select * From Tra_Detail