USE [BdRockFood]
GO

/****** Object:  Table [dbo].[Person]    Script Date: 21.06.2021 11:18:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PersonCopy](
	[PersonId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ImageName] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[About] [nvarchar](max) NULL,
 )
GO

INSERT INTO [dbo].[PersonCopy]           
     SELECT * From [dbo].[Person]
GO


