USE [Northwind]
GO

SELECT [FirstName]
      ,[LastName]
	  ,[TerritoryDescription]
	  ,[RegionDescription]
  FROM [dbo].[Employees]

  LEFT OUTER JOIN [dbo].[EmployeeTerritories]
  ON [dbo].[EmployeeTerritories].[EmployeeID] = [dbo].[Employees].[EmployeeID]

  LEFT OUTER JOIN [dbo].[Territories]
  ON [dbo].[EmployeeTerritories].[TerritoryID] = [dbo].[Territories].[TerritoryID]

  LEFT OUTER JOIN [dbo].[Region]
  ON [dbo].[Region].[RegionID] = [dbo].[Territories].[RegionID]
GO


