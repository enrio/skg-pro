Create View V_STATION
As
Select * From Pol_Dictionary
Where [Type] = 'STATION'
Go

Create View V_PROVINCE
As
Select * From Pol_Dictionary
Where [Type] = 'PROVINCE'
Go

Create View V_AREA
As
Select * From Pol_Dictionary
Where [Type] = 'AREA'
Go

Create View V_REGION
As
Select * From Pol_Dictionary
Where [Type] = 'REGION'
Go

--drop  Procedure Find_Tariff
Create Procedure Find_Tariff
@id uniqueidentifier,
@idyy uniqueidentifier
as
declare  @idxx uniqueidentifier
select @idxx = b.Id from 
	(select v.* from 
		(select v.* from 
			(select b.* from V_STATION a join V_PROVINCE b on a.ParentId = b.Id where a.Id = @id) as B 
join V_AREA v on B.ParentId = v.Id) as C join V_REGION v on C.ParentId = v.Id) as D join Tra_Tariff b on D.Code = b.Code

update Tra_Registry set TariffId = @idxx where Id = @idyy

--exec Find_Tariff '1BFA1858-67C9-4AC0-92B3-62AE24A1200A', 'A4BFFB86-6C28-4205-85AB-00834A3FCB19'
go
--drop Trigger AutoSetTariff
Create Trigger AutoSetTariff
On Tra_Registry
After Insert, Update
As
declare  @a uniqueidentifier
declare  @b uniqueidentifier
--select @a = Id, @b = DepartureId from Inserted
--exec Find_Tariff @b, @a


DECLARE vendor_cursor CURSOR FOR 
select Id, DepartureId from Inserted

OPEN vendor_cursor

FETCH NEXT FROM vendor_cursor 
INTO @a, @b

WHILE @@FETCH_STATUS = 0
BEGIN
	exec Find_Tariff @b, @a
    FETCH NEXT FROM vendor_cursor 
	INTO @a, @b
END 
CLOSE vendor_cursor;
DEALLOCATE vendor_cursor;

--update Tra_Registry set [Text] =''