USE [Northwind]
GO

SELECT *
  FROM [dbo].[Customers]
  Where  [Region] = 'SP' 

EXCEPT

SELECT *
  FROM [dbo].[Customers]
  Where  [City] = 'Sao Paulo'
  Order By [CustomerID]
GO