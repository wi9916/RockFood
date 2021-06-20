USE [Northwind]
GO

SELECT *
  FROM [dbo].[Customers]
  Where  [Region] = 'SP' 

INTERSECT

SELECT *
  FROM [dbo].[Customers]
  Where  [City] = 'Sao Paulo'
  Order By [CustomerID]
GO