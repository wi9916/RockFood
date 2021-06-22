USE [Northwind]
GO

SELECT *
  FROM [dbo].[Customers]
  Where  [Region] = 'SP' 

UNION

SELECT *
  FROM [dbo].[Customers]
  Where  [City] = 'Sao Paulo'
  Order By [CustomerID]
GO


