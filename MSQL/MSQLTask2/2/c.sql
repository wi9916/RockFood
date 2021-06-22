USE [BdRockFood]
GO

UPDATE [dbo].[Person]
   SET [About] = 'Good Seller - ' + CONVERT(NVARCHAR(20),s.RatingFromCustomers)
   FROM [dbo].[Person] p
   INNER JOIN [dbo].[Seller] s
   on p.PersonId = s.PersonId
 WHERE s.RatingFromCustomers > 5
GO
