USE [BdRockFood]
GO
/****** Object:  StoredProcedure [dbo].[procedure_GenerateId]    Script Date: 01.07.2021 15:24:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[procedure_GenerateId]	@Id INT OUTPUT
										,@TableName NVARCHAR(40)
										,@IdFildName NVARCHAR(40)
AS 
BEGIN

DECLARE  @IdOut INT
DECLARE  @sql NVARCHAR(256)
DECLARE  @ParmDefinition NVARCHAR(500)

	set @sql = N'select @IdOut = MAX(' + @IdFildName + ') + 1 FROM [dbo].[' + @TableName + ']'
	SET @ParmDefinition = N'@IdOut NVARCHAR(40) OUTPUT'
	exec sp_executesql @sql, @ParmDefinition, @IdOut = @Id OUTPUT	
END
