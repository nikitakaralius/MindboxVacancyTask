SELECT [dbo].[Products].[Name] AS ProductName, [dbo].[Categories].[Name] AS CategoryName
FROM ProductCategories
LEFT JOIN [dbo].[Products] ON [dbo].[ProductCategories].[ProductId] = [dbo].[Products].[Id]
LEFT JOIN [dbo].[Categories] ON [dbo].[ProductCategories].[CategoryId] = [dbo].[Categories].[Id]