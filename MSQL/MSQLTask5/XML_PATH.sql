USE [BdRockFood]
GO

SELECT [PersonId] AS '@PersonId'
      ,[Name] AS '@Name'
      ,[ImageName] AS '@ImageName'
      ,[PhoneNumber] AS '@PhoneNumber'
      ,[Email] AS '@Email'
      ,[About] AS '@About'
  FROM [dbo].[Person]
  FOR XML PATH ('Person'), ROOT ('Persons')
GO


