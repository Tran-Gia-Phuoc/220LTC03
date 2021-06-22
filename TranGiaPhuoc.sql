CREATE DATABASE HoTenDB
GO
USE HoTenDB
GO

CREATE TABLE UserAccount
(
	ID int IDENTITY(1,1) primary key,
	UserName varchar(50) NULL,
	Password varchar(50) NULL,
	Status varchar(50) NULL
)

CREATE TABLE Category
(
	ID int IDENTITY(1,1) primary key,
	Name nvarchar(50) NULL,
	Description nvarchar(100) NULL
)

CREATE TABLE Product
(
	ID int IDENTITY(1,1) primary key,
	Name nvarchar(50) NULL,
	UnitCost money,
	Quantily int,
	Image varchar(50) NOT NULL,
	Description nvarchar(50) NULL,
	Status nvarchar(50) NULL,
	ID_category int,
	constraint fk_ID_category foreign key (ID_category) references Category(ID)
)

INSERT INTO UserAccount(UserName, Password, Status) VALUES ( 'admin', 'admin', 'Online')
INSERT INTO UserAccount(UserName, Password, Status) VALUES ( 'phuoc', 'phuoc', 'Online')
INSERT INTO UserAccount(UserName, Password, Status) VALUES ( 'nhon', 'nhon', 'Offline')
INSERT INTO UserAccount(UserName, Password, Status) VALUES ( 'tra', 'tra', 'Offline')
INSERT INTO UserAccount(UserName, Password, Status) VALUES ( 'Huy', 'Huy', 'Blocked')
INSERT INTO UserAccount(UserName, Password, Status) VALUES ( 'Phong', 'Phong', 'Blocked')

INSERT INTO Category(Name, Description) VALUES (N'Điện Thoại', 'None')
INSERT INTO Category(Name, Description) VALUES (N'Máy Tính','None')

INSERT INTO Product(Name, UnitCost, Quantily, Image, Description, Status, ID_category) VALUES ( N'IPhone 12 Pro Max 512GB', 41490000, 30,'anh1.PNG', '6GB x 512GB', 'Còn Hàng', 1)
INSERT INTO Product(Name, UnitCost, Quantily, Image, Description, Status, ID_category) VALUES ( N'Samsung Galaxy S21 5G', 14990000, 30, 'anh2.PNG', '8GB x 128GB', 'Còn Hàng', 1)
INSERT INTO Product(Name, UnitCost, Quantily, Image, Description, Status, ID_category) VALUES ( N'Xiaomi Redmi Note 10 Pro', 6990000, 30, 'anh3.PNG', '8GB x 128GB', 'Còn Hàng', 1)
INSERT INTO Product(Name, UnitCost, Quantily, Image, Description, Status, ID_category) VALUES ( N'ASUS Vivobook X515EP EJ006T', 16990000, 10, 'anh4.PNG', 'Core i5 1135G7/Ram 4GB/SSD 512GB', 'Hết Hàng', 2)
INSERT INTO Product(Name, UnitCost, Quantily, Image, Description, Status, ID_category) VALUES ( N'DELL Inspiron 15 N7501 X3MRY1', 28990000, 20, 'anh5.PNG', 'Core i7 10750H/Ram 8GB/SSD 512GB', 'Hết Hàng', 2)
INSERT INTO Product(Name, UnitCost, Quantily, Image, Description, Status, ID_category) VALUES ( N'MACBOOK PRO Touch Bar M1 Silver - Z11F00CF', 43990000, 20, 'anh6.PNG', '8 Core/Ram 16GB/SSD 512GB', 'Còn Hàng', 2)