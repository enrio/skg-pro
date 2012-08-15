Create View V_STATION
As
select * from Pol_Dictionary
where [type] = 'STATION'

Create View V_PROVINCE
As
select * from Pol_Dictionary
where [type] = 'PROVINCE'

Create View V_AREA
As
select * from Pol_Dictionary
where [type] = 'AREA'

Create View V_REGION
As
select * from Pol_Dictionary
where [type] = 'REGION'

Create View A
as
select b.* from V_REGION a join Tra_Tariff b on a.Code = b.Code


(select b.* from V_STATION a join V_PROVINCE b on a.ParentId = b.Id) as B




Create View D
as

Create Procedure Find_Tariff
@code nvarchar
as
select b.* from 
	(select v.* from 
		(select v.* from 
			(select b.* from V_STATION a join V_PROVINCE b on a.ParentId = b.Id where a.Code = 'STATION_0') as B 
join V_AREA v on B.ParentId = v.Id) as C join V_REGION v on C.ParentId = v.Id) as D join Tra_Tariff b on D.Code = b.Code

exec Find_Tariff 'STATION_0'