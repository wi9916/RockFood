SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE ProcedureMergeXML (@Request xml)
AS
BEGIN	
	BEGIN TRANSACTION
    BEGIN TRY
    DECLARE @xmlDoc integer;
    EXEC sp_XML_preparedocument @xmlDoc OUTPUT, @Request;
    MERGE INTO [dbo].[Person1] as target
        USING 
        (
            SELECT * FROM OPENXML (@xmlDoc, 'Persons/Person', 0) 
            WITH 
            (
                PersonId integer,
				Name nvarchar(50),
				ImageName nvarchar(50),
				PhoneNumber nvarchar(50),
				Email nvarchar(50),
				About nvarchar(50)
            )
        ) as source (PersonId, Name, ImageName, PhoneNumber, Email, About)
        ON (target.PersonId = source.PersonId)
        WHEN MATCHED THEN 
			UPDATE 
				SET 
				 Name = source.Name, 
				 ImageName = source.ImageName,
				 PhoneNumber = source.PhoneNumber,
				 Email = source.Email,
				 About = source.About
        WHEN NOT MATCHED THEN 
			INSERT (PersonId, Name, ImageName, PhoneNumber, Email, About)
			VALUES (source.PersonId,source.Name,source.ImageName,source.PhoneNumber,source.Email,source.About);
    EXEC sp_XML_removedocument @xmlDoc;
    COMMIT
END TRY
BEGIN CATCH
    ROLLBACK
	EXEC sp_XML_removedocument @xmlDoc;
END CATCH
END
GO


