USE [BdRockFood]
GO

INSERT INTO [dbo].[Test]
           ([TestId]
           ,[Text])
     VALUES
           ([dbo].[Function_GenerateID]('Test'),'FunctionId')
GO


