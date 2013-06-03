update tra_detail set  code ='FIXED'
where id in (select tra_detail.id  from tra_detail
join tra_vehicle on tra_vehicle.id = tra_detail.vehicleid
where tra_detail.code =''
and tra_vehicle.fixed = 1)
GO
update tra_detail set  code ='GROUP_0'
where id in (select tra_detail.id  from tra_detail 
join tra_vehicle on tra_vehicle.id = tra_detail.vehicleid
join tra_tariff on tra_tariff.id  = tra_vehicle.tariffid
join pol_dictionary on pol_dictionary.id = tra_tariff.groupid
where tra_detail.code =''
and tra_vehicle.fixed = 0
and pol_dictionary.code = 'GROUP_0')
GO
update tra_detail set  code ='GROUP_1'
where id in (select tra_detail.id  from tra_detail 
join tra_vehicle on tra_vehicle.id = tra_detail.vehicleid
join tra_tariff on tra_tariff.id  = tra_vehicle.tariffid
join pol_dictionary on pol_dictionary.id = tra_tariff.groupid
where tra_detail.code =''
and tra_vehicle.fixed = 0
and pol_dictionary.code = 'GROUP_1')
GO
Select * From Tra_Vehicle
Go
Select * From Tra_Vehicle
Where Fixed = 0
Go
Select * From Tra_Vehicle
Where Fixed = 1
Go
Select Code, Count(*) From Tra_Vehicle
Group By Code
Having Count(*) > 1
Go
Select * From Tra_Detail