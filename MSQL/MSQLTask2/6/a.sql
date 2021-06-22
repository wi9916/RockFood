USE [Northwind]
GO

SELECT [dbo].[Suppliers].[Country], [dbo].[Suppliers].[Region], COUNT([dbo].[Suppliers].[Region]) as amount
	FROM [dbo].[Suppliers]
	GROUP BY [dbo].[Suppliers].[Country], [dbo].[Suppliers].[Region]
	HAVING COUNT([dbo].[Suppliers].[Region]) > 1
GO
