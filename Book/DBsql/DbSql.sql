CREATE DATABASE DB_Library
GO

use DB_Library;

-- 账户信息表
create TABLE T_Account(
	UserId int primary key identity(10001,1),
	Account varchar(18) not null unique,
	[Password] varchar(64) not null,
	CreateDate datetime default getdate(),
	ModifyDate datetime default getdate()
)

insert into T_Account([Password],Account) 
	values('ZwsUcorZkCrsujLiL6T2vQ==','Action');

-- 图书信息表	
create table T_Book(
	BookId int primary key identity(10001,1),
	Name varchar(128) not null,
	Price decimal(6,2) default 0.00,
	UserId int default 10001,
	CreateDate datetime default getdate(),
	ModifyDate datetime default getdate()
)