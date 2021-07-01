USE [BdRockFood]
GO
/****** Object:  UserDefinedFunction [dbo].[Function_GenerateID]    Script Date: 01.07.2021 16:05:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER FUNCTION [dbo].[Function_GenerateID]()
RETURNS INT
AS
BEGIN	
	DECLARE @ret int	
	SELECT @ret = MAX(PersonId)
		FROM [Person]
	RETURN @ret+1
END
