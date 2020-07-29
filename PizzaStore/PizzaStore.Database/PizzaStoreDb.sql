use master;
go

create database PizzaStoreDb;
go

use PizzaStoreDb;
go

create schema Pizza;
go

create table Pizza.Pizza
(
  PizzaId int not null identity(1,1),
  CrustId int not null,
  SizeId int not null,
  [Name] nvarchar(200) not null,
  constraint PK_PizzaId primary key (PizzaId),
  constraint FK_CrustId foreign key (CrustId) references Pizza.Crust(CrustId),
  constraint FK_SizeId foreign key (SizeId) references Pizza.Size(SizeId)
);

create table Pizza.Crust
(
  CrustId int not null identity(1,1),
  [Name] nvarchar(200) not null,
  constraint PK_CrustId primary key (CrustId)
);

create table Pizza.Size
(
  SizeId int not null identity(1,1),
  [Name] nvarchar(200) not null,
  constraint PK_SizeId primary key (SizeId)
);

create table Pizza.Topping
(
  ToppingId int not null identity(1,1),
  [Name] nvarchar(200) not null,
  constraint PK_ToppingId primary key (ToppingId)
);

create table Pizza.PizzaTopping
(
  PizzaToppingId int not null identity(1,1),
  PizzaId int not null,
  ToppingId int not null,
  constraint FK_PizzaId foreign key (PizzaId) references Pizza.Pizza(PizzaId),
  constraint FK_ToppingId foreign key (ToppingId) references Pizza.Topping(ToppingId)
);

SELECT * from Pizza.Pizza;
select * from Pizza.Crust;
select * from Pizza.[Size];
--Docker container command: docker container run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Password12345' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest
