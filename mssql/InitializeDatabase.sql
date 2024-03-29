CREATE DATABASE Storehouse
GO


USE [Storehouse]
GO

CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1, 1),
	[Name] [nvarchar](256) NOT NULL
)
GO

ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products_Id] PRIMARY KEY CLUSTERED (Id)
GO


USE [Storehouse]
GO

CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1, 1),
	[Name] [nvarchar](256) NOT NULL
)
GO

ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories_Id] PRIMARY KEY CLUSTERED (Id)
GO

ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [Unique_Categories_Name] UNIQUE ([Name])
GO


USE [Storehouse]
GO

CREATE TABLE [dbo].[ProductCategories](
	[Id] [int] IDENTITY(1, 1),
	[ProductId] [int] NOT NULL,
	[CategoryId] [int] NULL
)
GO

ALTER TABLE [dbo].[ProductCategories]
ADD CONSTRAINT [PK_ProductCategories_Id] PRIMARY KEY CLUSTERED (Id)
GO

ALTER TABLE [dbo].[ProductCategories]
WITH CHECK ADD CONSTRAINT [FK_ProductCategories_ProductId] FOREIGN KEY (ProductId)
REFERENCES [dbo].[Products] (Id)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ProductCategories]
WITH CHECK ADD CONSTRAINT [FK_ProductCategories_CategoryId] FOREIGN KEY (CategoryId)
REFERENCES [dbo].[Categories] (Id)
ON UPDATE CASCADE
ON DELETE SET NULL
GO


USE [Storehouse]
GO

INSERT [dbo].[Categories] (Name) VALUES
('Mechanic Keyboards'),
('Keyboards'),
('Headphones'),
('Wireless Headphones'),
('Laptops'),
('ARM Laptops'),
('Phones'),
('Apple'),
('Cameras')
GO

INSERT [dbo].[Products] (Name) VALUES
('Razer Blackwidow 2014'),
('Apple AirPods Pro'),
('Anne Pro 2'),
('Apple Magic Keyboard'),
('AMD Ryzen 7 5800X'),
('Apple iPhone'),
('Blackmagic'),
('MacBook Air 2022 M2'),
('Mango'),
('Pilot pen')
GO

INSERT [dbo].[ProductCategories] (ProductId, CategoryId) VALUES
(1, 1),
(1, 2),
(2, 3),
(2, 4),
(2, 8),
(3, 1),
(3, 2),
(4, 2),
(4, 8),
(5, NULL),
(6, 7),
(6, 8),
(7, 9),
(8, 5),
(8, 6),
(8, 8),
(9, NULL),
(10, NULL)
GO