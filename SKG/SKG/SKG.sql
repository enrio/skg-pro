/*
author:		nguyen van toan
email:		nvt87x@gmail.com
yahoo:		teqzex18
phone:		01645 515 010
date time:	29/12/2011 10:00
*/
--------------------------------------------------------------------------------------

use master
go

if exists(select * from sysdatabases where name = 'skg') drop database skg
go

create database skg collate vietnamese_ci_ai
go

use skg
go

/**/

set dateformat dmy
go

--------------------------------------------------------------------------------------
--> create all tables ----------------------------------------------------------------
--------------------------------------------------------------------------------------
-- 
create table pol_dm_role
(
	id_role					bigint identity(1,1)	not null,
	id_role_parent			bigint					null,
	role_system_name		nvarchar(max)			null,
	role_display_name		nvarchar(max)			null,
	role_description		nvarchar(max)			null,
	build_in				bit						null,
	role_name				nvarchar(max)			null,
	constraint pk_pol_dm_role primary key(id_role)
 )
 go

-- 
create table pol_dm_right
(
	id_right				bigint identity(1,1)	not null,
	id_right_parent			bigint					null,
	right_system_name		nvarchar(max)			null,
	right_display_name		nvarchar(max)			null,
	right_description		nvarchar(max)			null,
	build_in				bit						null,
	right_name				nvarchar(max)			null,
	constraint pk_pol_dm_right primary key(id_right)
)
go

--  
create table pol_dm_action
(
	id_action				int identity(1,1)		not null,
	action_name				nvarchar(max)			not null,
	action_description		nvarchar(max)			null,
	constraint pk_pol_dm_action primary key(id_action)
)
go

-- 
create table pol_dm_user
(
	id_user					bigint identity(1,1)	not null,
	[user_name]				nvarchar(max)			not null,
	user_password			nvarchar(max)			null constraint df_pol_dm_user_user_password  default (''),
	user_fullname			nvarchar(max)			null,
	user_description		nvarchar(max)			null,
	password_must_change	bit						null,
	password_cannot_change	bit						null,
	password_expire			bit						null,
	password_days			int						null,
	password_complex		bit						null,
	user_disable			bit						null,
	build_in				bit						null,
	id_nhansu				bigint					null,
	constraint pk_pol_dm_user primary key(id_user)
)
go

-- 
create table pol_action_role
(
	id_action				int						not null,
	id_role					bigint					not null,
	id_right				bigint					not null,
	constraint pk_pol_action_role primary key(id_action, id_role, id_right) 
)
go

-- 
create table pol_action_user
(
	id_action				int						not null,
	id_user					bigint					not null,
	id_right				bigint					not null,
	constraint pk_pol_action_right primary key(id_action, id_user, id_right) 
)
go

-- 
create table pol_role_right
(
	id_role					bigint					not null,
	id_right				bigint					not null,
	allow_add				bit						null,
	allow_edit				bit						null,
	allow_delete			bit						null,
	allow_query				bit						null,
	allow_print				bit						null,
	allow_full				bit						null,
	allow_none				bit						null,
	constraint pk_pol_role_right primary key(id_role, id_right) 
)
go

-- 
create table pol_user_role
(
	id_user					bigint					not null,
	id_role					bigint					not null,
	allow_add				bit						null,
	allow_edit				bit						null,
	allow_delete			bit						null,
	allow_query				bit						null,
	allow_print				bit						null,
	allow_full				bit						null,
	allow_none				bit						null,
	constraint pk_pol_user_role primary key(id_user, id_role) 
)
go

-- 
create table pol_user_right
(
	id_user					bigint					not null,
	id_right				bigint					not null,
	allow_add				bit						null,
	allow_edit				bit						null,
	allow_delete			bit						null,
	allow_query				bit						null,
	allow_print				bit						null,
	allow_full				bit						null,
	allow_none				bit						null,
	constraint pk_pol_user_right primary key(id_user, id_right) 
)
go
--------------------------------------------------------------------------------------
--| create all tables ----------------------------------------------------------------
--------------------------------------------------------------------------------------
