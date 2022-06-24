SELECT [dbo].[Product].[Name] AS ProductName, [dbo].[Category].[Name] AS CategoryName
FROM ProductCategories
LEFT JOIN [dbo].[Product] ON [dbo].[ProductCategories].[ProductId] = [dbo].[Product].[Id]
LEFT JOIN [dbo].[Category] ON [dbo].[ProductCategories].[CategoryId] = [dbo].[Category].[Id]