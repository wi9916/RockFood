USE [BdRockFood]
GO
/****** Object:  UserDefinedFunction [dbo].[Function_GenerateID]    Script Date: 01.07.2021 16:05:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER FUNCTION [dbo].[Function_GenerateID](	@TableName NVARCHAR(50))
RETURNS NVARCHAR(50)
AS
BEGIN	
	DECLARE @res NVARCHAR(50)
	DECLARE @rndValue NVARCHAR(50)
	SELECT @rndValue = Rnd
	FROM rndView
	SET @res = @TableName + '_'+ @rndValue
	RETURN @res
END
