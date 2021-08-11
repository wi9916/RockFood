USE [Northwind]
GO

SELECT *
  FROM [dbo].[Products]
  WHERE [UnitPrice] > (SELECT AVG([UnitPrice]) FROM [dbo].[Products])  
  ORDER BY [UnitPrice]
GO


