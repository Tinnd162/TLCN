create database Inventory
use Inventory
go


create table Supplier
(
	Id varchar(50) primary key,
	Supplier varchar(50) not null
)
go

create table Category
(
	Id varchar(50) primary key,
	CategoryName nvarchar(50) not null,
	_Description nvarchar(max),
	UpdateDate datetime, -- Ngày cập nhật danh sách sản phẩm.
	IsDelete int default 0,
)
go

create table Brand
(
	Id varchar(50) primary key,
	Brand varchar(50) not null,
	_Description nvarchar(max),
)
go

create table PriceLog
(
	Id varchar(50) primary key,
	Price decimal(10,5) not null, -- Giá thành tiền cuối cùng.
	UserUpdate varchar(50) not null,
	UpdateDate datetime not null, -- Ngày cập nhật giá.
)
go

create table Product
(
	Id varchar(50) primary key,
	ProductName varchar(50) not null,
	_Description nvarchar(max),
	LinkImage varchar(max),
	_Character nvarchar(max) not null, -- Đặc trưng sản phẩm.
	UnitPrice decimal(10,5) not null, -- Giá tiền ban đầu.
	Stock int not null,
	UpdateDate datetime, -- Ngày cập nhật thông tin sản phẩm.
	DeleteDate datetime, -- Ngày xóa sản phẩm.
	_Status int default 0, -- 0 còn hàng, 1 hết hàng.  
	IsDelete int default 0,
	IsDiscontinued int default 0, -- 0 còn sản xuất, 1 ngưng sản xuất.
	SupplierId varchar(50) not null,
	BrandId varchar(50) not null,
	CategoryId varchar(50) not null,
	PriceId varchar(50) not null,
	foreign key (PriceId) references PriceLog(Id),
	foreign key (CategoryId) references Category(Id),
	foreign key (SupplierId) references Supplier(Id),
	foreign key (BrandId) references Brand(Id),
)
go

create table Device
(
	Id varchar(50) primary key,
	SerialNumber varchar(50) not null,
	_Description nvarchar(50), -- Mô tả sản phẩm.
	ImportDate datetime, -- Ngày nhập sản phẩm.
	ActivateDate datetime, -- Ngày kích hoạt.
	IsActivate int default 0, -- 0 chưa kích hoạt, 1 đã kích hoạt.
	ProdudctId varchar(50) not null,
	ImportUser varchar(50) not null,
	foreign key (ProdudctId) references Product(Id),
)
go
