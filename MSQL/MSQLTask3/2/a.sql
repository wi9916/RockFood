USE [Northwind]
GO

SELECT [CategoryName],
	(SELECT MAX([UnitPrice])
		FROM [dbo].[Products]
		WHERE [dbo].[Categories].[CategoryID] = [dbo].[Products].[CategoryID]			
		)
  FROM [dbo].[Categories]
GO


