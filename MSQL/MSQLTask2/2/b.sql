USE [BdRockFood]
GO

UPDATE [dbo].[Person]
   SET [About] = 'Id = ' + CONVERT(NVARCHAR(20),[PersonId])
 WHERE [PersonId] = 1
GO


