USE [Northwind]
GO

SELECT [dbo].[Region].[RegionID]
      ,[RegionDescription]  
  FROM [dbo].[Territories]

  INNER JOIN [dbo].[EmployeeTerritories]
  ON [dbo].[EmployeeTerritories].[TerritoryID] = [dbo].[Territories].[TerritoryID] 
  
  RIGHT JOIN [dbo].[Region]
  ON [dbo].[Region].[RegionID] = [dbo].[Territories].[RegionID]
  WHERE [dbo].[Territories].[RegionID] is null    
GO