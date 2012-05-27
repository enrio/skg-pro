Use xBXEv1
Select * From Pol_Action
Select * From Pol_Right
Select * From Pol_Role
Select * From Pol_User
Select * From Pol_UserRight
Select * From Pol_UserRole
Select * From Pol_RoleRight
Select * From Tra_Group
Select * From Tra_Kind
Select * From Tra_Vehicle
Select * From Tra_Detail

Select U.*, Rr.* From Pol_RoleRight Rr
	Join Pol_Right R On R.Id = Rr.Pol_RightId
	Join Pol_UserRole Ur On Ur.Pol_RoleId = Rr.Pol_RoleId
	Join Pol_User U On U.Id = Ur.Pol_UserId