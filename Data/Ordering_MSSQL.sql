create database Ordering
use Ordering
go

create table Delivery
(
	Id varchar(50) primary key,
	CustomerID varchar(50),
	FirstName nvarchar(50) not null,
	Lastname nvarchar(50) not null,
	_Address nvarchar(50) not null,
	Phone varchar(10) not null,
	Email varchar(50) not null,
)
go

create table Payment
(
	Id varchar(50) primary key,
	CardName varchar(50),
	CardNumber varchar(20),
	Expiration varchar(20),
	CVV varchar(10),
)
go

create table _Order
(
	Id varchar(50) primary key,
	OrderDate datetime not null,
	_Status int not null, -- Chờ xác nhận, đang giao hàng, giao hàng thành công.
	ConfirmDate datetime,
	PaymentMethod int, -- Phương thức thanh toán.
	StaffId varchar(50) not null, -- Id người xác nhận.
	IsDetele bit default 0,
	CustomerId varchar(50) not null,
	PaymentId varchar(50),
	foreign key (CustomerId) references Delivery(Id),
	foreign key (PaymentId) references Payment(Id),
)
go

create table Order_Detail
(
	Id varchar(50) primary key,
	UnitPrice decimal(10,5) not null, -- Giá sản phẩm.
	Quantity int not null,
	VAT int default 0,
	_OrderId varchar(50) not null,
	foreign key (_OrderId) references _Order(Id),
)
go