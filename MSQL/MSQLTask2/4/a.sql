USE [Northwind]
GO

SELECT *
  FROM [dbo].[Customers]
  Where  [Region] = 'SP' or [City] = 'Sao Paulo'
  Order By [CustomerID]
GO