

create table Categories
(
Id int primary Key identity(1,1),
CategoryName nvarchar(50)
)

create table Products
(
Id int primary Key identity(1,1),
CategoryId int references Categories(Id),
Description nvarchar(500),
Price int 
)

create table Orders
(
Id int primary Key identity(1,1),
CustomerName nvarchar(50),
OrderDate datetime
)

create table OrderLines
(
Id int primary Key identity(1,1),
OrderId int references Orders(Id),
ProductId int references Products(Id),
price int,
[Count] int,
)