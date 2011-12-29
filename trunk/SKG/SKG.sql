/*
Author:		Nguyen Van Toan
Email:		nvt87x@gmail.com
Phone:		01645 515 010
Date time:	29/12/2011 10:00 PM
--------------------------------------------------------------------------------------
Use Master;

If Exists(Select * From SysDatabases Where Name = 'SKG')
	Drop Database SKG;

Create Database SKG
	Collate Vietnamese_Ci_Ai;

Use SKG;
*/

Set Dateformat Dmy
Go

--------------------------------------------------------------------------------------
--> Tạo các bảng ---------------------------------------------------------------------
--------------------------------------------------------------------------------------
-- [1] User: người dùng
CREATE TABLE Users
(
	Id			bigint IDENTITY(1,1)	NOT NULL,
	Acc			nvarchar(50) UNIQUE		NOT NULL,	-- Tài khoản
	Pass		nvarchar(200)			NOT NULL,	-- Mật khẩu
	[Name]		nvarchar(200)			NOT NULL,	-- Họ tên
	Birth		datetime				NULL,		-- Ngày tháng năm sinh
	[Address]	nvarchar(200)			NULL,		-- Địa chỉ
	Phone		varchar(200)			NULL,		-- Điện thoại
	[Role]		int						NOT NULL,	-- Loại quyền
	CONSTRAINT PK_Users PRIMARY KEY(Id)
)
GO

-- [2] Groups: nhóm loại xe
CREATE TABLE Groups
(
	Id			bigint IDENTITY(1,1)	NOT NULL,
	[Name]		nvarchar(200)			NOT NULL,	-- Tên nhóm loại xe
	CONSTRAINT PK_Groups PRIMARY KEY(Id)
)
GO

-- [3] Kinds: loại xe
CREATE TABLE Kinds
(
	Id			bigint IDENTITY(1,1)	NOT NULL,
	[Name]		nvarchar(200)			NOT NULL,	-- Tên loại xe
	GroupId		bigint					NULL,		-- Mã nhóm loại xe
	Descript	nvarchar(200)			NULL,		-- Mô tả nhóm xe
	LengthMin	numeric(18,2)			NULL,		-- Chiều dài tối thiểu
	LengthMax	numeric(18,2)			NULL,		-- Chiều dài tối đa
	ChairMin	int						NULL,		-- Số ghế tối thiểu
	ChairMax	int						NULL,		-- Số ghế tối đa
	WeightMin	numeric(18,2)			NULL,		-- Trọng tải tối thiểu
	WeightMax	numeric(18,2)			NULL,		-- Trọng tải tối đa
	Money1		numeric(18,2)			NULL,		-- Đơn giá nửa ngày
	Money2		numeric(18,2)			NULL,		-- Đơn giá một ngày
	[Type]		nvarchar(5)				NOT NULL	-- Loại tiền	
	CONSTRAINT PK_Kinds PRIMARY KEY(Id),
	CONSTRAINT FK_Kinds FOREIGN KEY(GroupId) REFERENCES Groups(Id)
)
GO

-- [4] Vehicles: danh sách xe
CREATE TABLE Vehicles
(
	Id			bigint IDENTITY(1,1)	NOT NULL,
	KindId		bigint					NOT NULL,	-- Mã loại xe
	Number		nvarchar(200) UNIQUE	NOT NULL,	-- Biển số xe (không trùng nhau)
	Descript	nvarchar(200)			NULL,		-- Mô tả xe (trọng tải/số ghế ngồi)
	[Length]	numeric(18,2)			NULL,		-- Chiều dài
	Chair		int						NULL,		-- Số ghế
	[Weight]	numeric(18,2)			NULL,		-- Trọng tải
	[Name]		nvarchar(200)			NULL,		-- Họ tên chủ xe
	Birth		datetime				NULL,		-- Ngày tháng năm sinh
	[Address]	nvarchar(200)			NULL,		-- Địa chỉ
	Phone		nvarchar(200)			NULL,		-- Điện thoại
	CONSTRAINT PK_Vehicles PRIMARY KEY(Id),
	CONSTRAINT FK_Vehicles_KindId FOREIGN KEY(KindId) REFERENCES Kinds(Id)
)
GO

-- [5] Details: quản lí xe ra vào
CREATE TABLE Details
(
	Id			bigint IDENTITY(1,1)	NOT NULL,
	AccIn		bigint					NULL,		-- Mã nhân viên cho xe vào
	AccOut		bigint					NULL,		-- Mã nhân viên cho xe ra
	Number		nvarchar(200)			NOT NULL,	-- Biển số xe
	DateIn		datetime				NULL,		-- Giờ vào bến
	DateOut		datetime				NULL,		-- Giờ xuất bến
	[Day]		int						NULL,		-- Số ngày đậu tại bến
	[Hour]		int						NULL,		-- Số giờ lẻ đậu tại bến
	Price1		numeric(18,2)			NULL,		-- Đơn giá
	Price2		numeric(18,2)			NULL,		-- Đơn giá
	[Money]		numeric(18,2)			NULL,		-- Thành tiền
	CONSTRAINT PK_Details PRIMARY KEY(Id),
	CONSTRAINT FK_Details_AccIn FOREIGN KEY(AccIn) REFERENCES Users(Id),
	CONSTRAINT FK_Details_AccOut FOREIGN KEY(AccOut) REFERENCES Users(Id)
)
GO

--------------------------------------------------------------------------------------
--| Tạo các bảng ---------------------------------------------------------------------
--------------------------------------------------------------------------------------

--------------------------------------------------------------------------------------
--> Thêm dữ liệu vào các bảng --------------------------------------------------------
--------------------------------------------------------------------------------------
-- [1] User: người dùng
Set Identity_Insert Users On
Insert Into Users(Id, Acc, Pass, [Name], Birth, [Address], Phone, [Role]) Values(1, N'admin', N'admin', N'Nguyễn Văn Toàn', '21/1/1987', N'Tân Hoà, Lai Vung, Đồng Tháp', '01645 515 010', 0)
Insert Into Users(Id, Acc, Pass, [Name], Birth, [Address], Phone, [Role]) Values(2, N'triet', N'triet', N'Võ Minh Triết', '1/1/1987', N'TP. Hồ Chí Minh', '0982 878 707', 1)
Insert Into Users(Id, Acc, Pass, [Name], Birth, [Address], Phone, [Role]) Values(3, N'bv1', N'bv1', N'Bảo Vệ Một', '1/1/1980', N'Bình Dương', '01645 515 210', 2)
Insert Into Users(Id, Acc, Pass, [Name], Birth, [Address], Phone, [Role]) Values(4, N'bv2', N'bv2', N'Bảo Vệ Hai', '1/1/1980', N'Bình Phước', '01645 515 110', 3)
Insert Into Users(Id, Acc, Pass, [Name], Birth, [Address], Phone, [Role]) Values(5, N'bv3', N'bv3', N'Bảo Vệ Ba', '1/1/1980', N'Đồng Nai', '01645 515 000', 4)
Insert Into Users(Id, Acc, Pass, [Name], Birth, [Address], Phone, [Role]) Values(6, N'bv4', N'bv4', N'Bảo Vệ Bốn', '1/1/1980', N'Bình Dương', '01645 515 210', 5)
Insert Into Users(Id, Acc, Pass, [Name], Birth, [Address], Phone, [Role]) Values(7, N'bv5', N'bv5', N'Bảo Vệ Năm', '1/1/1980', N'Bình Phước', '01645 515 110', 5)
Insert Into Users(Id, Acc, Pass, [Name], Birth, [Address], Phone, [Role]) Values(8, N'bv6', N'bv6', N'Bảo Vệ Sáu', '1/1/1980', N'Đồng Nai', '01645 515 000', 5)
Set Identity_Insert Users Off
Go

-- [2] Groups: nhóm loại xe
Set Identity_Insert Groups On
Insert Into Groups(Id, [Name]) Values(1, N'Xe tải lưu đậu & vãng lai')
Insert Into Groups(Id, [Name]) Values(2, N'Xe khách lưu đậu ngày (cứ 24giờ tính 1ngày)')
Insert Into Groups(Id, [Name]) Values(3, N'Taxi vãng lai')
Insert Into Groups(Id, [Name]) Values(4, N'Xe ba bánh')
Insert Into Groups(Id, [Name]) Values(5, N'Xe khách vãng lai, quá cảnh, trung chuyển (trong vòng 60phút)')
Set Identity_Insert Groups Off
Go

-- [3] Kinds: loại xe
Set Identity_Insert Kinds On
Insert Into Kinds(Id, [Name], GroupId, Money1, Money2, [Type], LengthMin, LengthMax, ChairMin, ChairMax, WeightMin, WeightMax) Values(1, N'Tải trọng < 2,5tấn', 1, 10000, 20000, N'VNĐ', NULL, NULL, NULL, NULL, 0, 2.49)
Insert Into Kinds(Id, [Name], GroupId, Money1, Money2, [Type], LengthMin, LengthMax, ChairMin, ChairMax, WeightMin, WeightMax) Values(2, N'2,5tấn ≤ tải trọng < 5tấn hoặc dài < 6m', 1, 15000, 25000, N'VNĐ', 0, 5.99, NULL, NULL, 2.5, 4.99)
Insert Into Kinds(Id, [Name], GroupId, Money1, Money2, [Type], LengthMin, LengthMax, ChairMin, ChairMax, WeightMin, WeightMax) Values(3, N'5tấn ≤ tải trọng < 10tấn hoặc 6m ≤ dài < 8m', 1, 15000, 30000, N'VNĐ', 6, 7.99, NULL, NULL, 5, 9.99)
Insert Into Kinds(Id, [Name], GroupId, Money1, Money2, [Type], LengthMin, LengthMax, ChairMin, ChairMax, WeightMin, WeightMax) Values(4, N'10tấn ≤ tải trọng < 15tấn hoặc dài ≥ 8m', 1, 20000, 35000, N'VNĐ', 8, 99, NULL, NULL, 10, 14.99)
Insert Into Kinds(Id, [Name], GroupId, Money1, Money2, [Type], LengthMin, LengthMax, ChairMin, ChairMax, WeightMin, WeightMax) Values(5, N'Container 20feet', 1, 25000, 45000, N'VNĐ', NULL, NULL, NULL, NULL, NULL, NULL)
Insert Into Kinds(Id, [Name], GroupId, Money1, Money2, [Type], LengthMin, LengthMax, ChairMin, ChairMax, WeightMin, WeightMax) Values(6, N'Container 40feet', 1, 25000, 45000, N'VNĐ', NULL, NULL, NULL, NULL, NULL, NULL)
Insert Into Kinds(Id, [Name], GroupId, Money1, Money2, [Type], LengthMin, LengthMax, ChairMin, ChairMax, WeightMin, WeightMax) Values(7, N'Số ghế < 16', 2, NULL, 20000, N'VNĐ', NULL, NULL, 0, 15, NULL, NULL)
Insert Into Kinds(Id, [Name], GroupId, Money1, Money2, [Type], LengthMin, LengthMax, ChairMin, ChairMax, WeightMin, WeightMax) Values(8, N'16 ≤ số ghế ≤ 40', 2, NULL, 25000, N'VNĐ', NULL, NULL, 16, 40, NULL, NULL)
Insert Into Kinds(Id, [Name], GroupId, Money1, Money2, [Type], LengthMin, LengthMax, ChairMin, ChairMax, WeightMin, WeightMax) Values(9, N'Số ghế > 40', 2, NULL, 30000, N'VNĐ', NULL, NULL, 41, 99, NULL, NULL)
Insert Into Kinds(Id, [Name], GroupId, Money1, Money2, [Type], LengthMin, LengthMax, ChairMin, ChairMax, WeightMin, WeightMax) Values(10, N'Taxi vãng lai', 3, NULL, 8000, N'VNĐ', NULL, NULL, NULL, NULL, NULL, NULL)
Insert Into Kinds(Id, [Name], GroupId, Money1, Money2, [Type], LengthMin, LengthMax, ChairMin, ChairMax, WeightMin, WeightMax) Values(11, N'Xe ba bánh', 4, NULL, 5000, N'VNĐ', NULL, NULL, NULL, NULL, NULL, NULL)
Insert Into Kinds(Id, [Name], GroupId, Money1, Money2, [Type], LengthMin, LengthMax, ChairMin, ChairMax, WeightMin, WeightMax) Values(12, N'Xe khách vãng lai, quá cảnh, trung chuyển (trong vòng 60phút)', 5, NULL, 2030, N'VNĐ', NULL, NULL, 0, 99, NULL, NULL)
Set Identity_Insert Kinds Off
Go

-- [4] Vehicles: danh sách xe
Set Identity_Insert Vehicles On
Insert Into Vehicles(Id, KindId, Number, Chair, [Weight], [Name], Birth, [Address], Phone) Values(1, 1, N'66N-105.90', NULL, 1, N'Nguyễn Văn Toàn', '21/7/1987', N'Tân Hoà, Lai Vung, Đồng Tháp', '01645 515 010')
Insert Into Vehicles(Id, KindId, Number, Chair, [Weight], [Name], Birth, [Address], Phone) Values(2, 2, N'76P-570.00', NULL, 3, N'Nguyễn Thị Thu Thuỷ', '1/1/1991', N'Tân Hoà, Lai Vung, Đồng Tháp', '01645 515 111')
Insert Into Vehicles(Id, KindId, Number, Chair, [Weight], [Name], Birth, [Address], Phone) Values(3, 3, N'86F-1374', NULL, 8, N'Trương Văn Một', '1/1/1990', N'Tân Hoà, Lai Vung, Đồng Tháp', '01645 515 112')
Insert Into Vehicles(Id, KindId, Number, Chair, [Weight], [Name], Birth, [Address], Phone) Values(4, 4, N'65T-1132', NULL, 12, N'Nguyễn Thị Loan', '7/1/1990', N'Tân Hoà, Lai Vung, Đồng Tháp', '01645 515 113')
Insert Into Vehicles(Id, KindId, Number, Chair, [Weight], [Name], Birth, [Address], Phone) Values(5, 5, N'67N-105.91', NULL, NULL, N'Nguyễn Thị Tài', '1/9/1989', N'Tân Hoà, Lai Vung, Đồng Tháp', '01645 515 114')
Insert Into Vehicles(Id, KindId, Number, Chair, [Weight], [Name], Birth, [Address], Phone) Values(6, 6, N'66P-570.99', NULL, NULL, N'Nguyễn Văn Thủ', '1/5/1979', N'Tân Hoà, Lai Vung, Đồng Tháp', '01645 515 115')
Insert Into Vehicles(Id, KindId, Number, Chair, [Weight], [Name], Birth, [Address], Phone) Values(7, 7, N'63F-1374', NULL, NULL, N'Nguyễn Kim Kim', '4/1/1990', N'Tân Hoà, Lai Vung, Đồng Tháp', '01645 515 116')
Insert Into Vehicles(Id, KindId, Number, Chair, [Weight], [Name], Birth, [Address], Phone) Values(8, 8, N'64T-1132', 45, NULL, N'Châu Nhuận Phát', '1/1/1989', N'Tân Hoà, Lai Vung, Đồng Tháp', '01645 515 117')
Insert Into Vehicles(Id, KindId, Number, Chair, [Weight], [Name], Birth, [Address], Phone) Values(9, 8, N'62N-105.95', 25, NULL, N'Phát Văn Minh', '1/1/1981', N'Tân Hoà, Lai Vung, Đồng Tháp', '01645 515 118')
Insert Into Vehicles(Id, KindId, Number, Chair, [Weight], [Name], Birth, [Address], Phone) Values(10, 9, N'63P-570.10', NULL, NULL, N'Lỳ Như Trâu', '1/1/1981', N'Tân Hoà, Lai Vung, Đồng Tháp', '01645 515 119')
Insert Into Vehicles(Id, KindId, Number, Chair, [Weight], [Name], Birth, [Address], Phone) Values(11, 10, N'63P-570.11', NULL, NULL, N'Lỳ Như Bò', '2/2/1981', N'Tân Hoà, Lai Vung, Đồng Tháp', '01645 515 129')
Insert Into Vehicles(Id, KindId, Number, Chair, [Weight], [Name], Birth, [Address], Phone) Values(12, 11, N'63P-570.12', NULL, NULL, N'Lỳ Như Heo', '3/2/1981', N'Tân Hoà, Lai Vung, Đồng Tháp', '01645 515 139')
Insert Into Vehicles(Id, KindId, Number, Chair, [Weight], [Name], Birth, [Address], Phone) Values(13, 12, N'63P-570.13', NULL, NULL, N'Lỳ Như Mèo', '4/1/1981', N'Tân Hoà, Lai Vung, Đồng Tháp', '01645 515 149')
Set Identity_Insert Vehicles Off
Go

-- [5] Details: quản lí xe ra vào

Set Identity_Insert Details On
Insert Into Details(Id, AccIn, AccOut, Number, DateIn) Values(1, 3, NULL, N'66N-105.90', '29/11/2011 00:00:00')
Insert Into Details(Id, AccIn, AccOut, Number, DateIn) Values(2, 3, NULL, N'76P-570.00', '29/11/2011 00:00:00')
Insert Into Details(Id, AccIn, AccOut, Number, DateIn) Values(3, 3, NULL, N'86F-1374', '29/11/2011 00:00:00')
Insert Into Details(Id, AccIn, AccOut, Number, DateIn) Values(4, 3, NULL, N'65T-1132', '29/11/2011 00:00:00')
Insert Into Details(Id, AccIn, AccOut, Number, DateIn) Values(5, 3, NULL, N'67N-105.91', '29/11/2011 00:00:00')
Set Identity_Insert Details Off
Go

--------------------------------------------------------------------------------------
--> Thêm dữ liệu vào các bảng --------------------------------------------------------
--------------------------------------------------------------------------------------

--------------------------------------------------------------------------------------
--> Xử lí dữ liệu --------------------------------------------------------------------
--------------------------------------------------------------------------------------
-- [1] Lấy danh sách xe đang ở trong bến
Create Procedure Details_In
As
	Select * From Details Where AccOut Is Null
	Order By Number
Go
--------------------------------------------------------------------------------------
-- [2] Lấy danh sách xe đang ở ngoài bến
Create Procedure Details_Out
As
	Select * From Details
	Where AccOut Is Not Null
		And Number Not In (Select Number From Details Where AccOut Is Null)
	Order By Number
Go
--------------------------------------------------------------------------------------
Create Function TimeSpanUnits(@Unit char(1), @TimeSpan datetime)
Returns int
As
	Begin
		Return case @Unit
			When 'd' Then Datediff(day, 0, @TimeSpan)
			When 'h' Then Datediff(hour, 0, @TimeSpan)
			When 'm' Then Datediff(minute, 0, @TimeSpan)
			When 's' Then Datediff(second, 0, @TimeSpan)
			Else Null End
    End
Go
--------------------------------------------------------------------------------------
-- [3] Lấy giờ hiện tại
Create Function CurrentTime()
Returns datetime
As
	Begin
		Return GetDate()
	End
Go
--------------------------------------------------------------------------------------
-- [4] Lấy danh sách biển số xe cho vào bến hợp lí
Create Procedure Vehicles_In
As
	Select a.* From Vehicles a Left Join Details b On b.Number = a.Number
	Where (b.DateOut Is Not Null
		And a.Number In (Select Number From Vehicles Where Number Not In (Select Number From Details Where DateOut Is Null))
		And DateOut >= (Select Max(c.DateOut) From Details c Where c.Number = b.Number))
		Or (b.AccIn Is Null And b.AccOut Is Null)
Go
--------------------------------------------------------------------------------------
-- [5] Lấy danh sách biển số xe cho ra bến hợp lí
Create Procedure Vehicles_Out
As
	-- Cách 1
	Select a.* From Vehicles a Join Details b On b.Number = a.Number
	Where b.AccOut Is Null
	Order By a.Number Asc

	-- Cách 2
	/*Select * From Vehicles
	Where Number In (Select Number From Details Where AccOut Is Null)
	Order By Number Asc*/
Go
--------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------
--| Xử lí dữ liệu --------------------------------------------------------------------
--------------------------------------------------------------------------------------
