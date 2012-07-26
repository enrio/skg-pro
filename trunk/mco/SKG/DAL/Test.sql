Use xSKGv1
Select * From Pol_Action
Select * From Pol_Right
Select * From Pol_Role
Select * From Pol_User
Select * From Pol_UserRight
Select * From Pol_UserRole
Select * From Pol_RoleRight
Select * From Pol_Lang

Select * From Pol_Right
Order By Substring(Code, 1, 3), [Order]

Select * From Pol_Right 
Where [Level] = 3
Order By Substring(Code, 1, 3), [Order]

Select U.*, Rr.* From Pol_RoleRight Rr
	Join Pol_Right R On R.Id = Rr.Pol_RightId
	Join Pol_UserRole Ur On Ur.Pol_RoleId = Rr.Pol_RoleId
	Join Pol_User U On U.Id = Ur.Pol_UserId