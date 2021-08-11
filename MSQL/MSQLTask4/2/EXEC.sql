USE [BdRockFood]
GO

DECLARE	@Idn int
		
EXEC [dbo].[procedure_GenerateId]
		@Id = @Idn OUTPUT
		,@TableName = 'Person'
		,@IdFildName = 'PersonId'

INSERT INTO [dbo].[Person]           
     VALUES
           (@Idn,'Cler Adams','img/Avatar/Cler','056746344','Cler@mail.com','procedure_GenerateId')
GO

