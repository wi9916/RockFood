DECLARE @Request xml
SET @Request = '<Persons>
  <Person PersonId="1" Name="Amy Warner" ImageName="img/Avatar/Amy" PhoneNumber="077777777" Email="Amy@mail.com" About="Id = 2" />
  <Person PersonId="2" Name="Kristin Oliver" ImageName="img/Avatar/Kristin" PhoneNumber="077777777" Email="Kristin@mail.com" About="Test Peson A" />
  <Person PersonId="3" Name="Clarence Wilson" ImageName="img/Avatar/Clarence" PhoneNumber="077777777" Email="Clarence@mail.com" About="Test Peson A" />
  <Person PersonId="4" Name="Michael Thompson" ImageName="img/Avatar/Michael" PhoneNumber="077777777" Email="Michael@mail.com" About="Test Peson A" />
  <Person PersonId="5" Name="Jason Wood" ImageName="img/Avatar/Jason" PhoneNumber="077777777" Email="Jason@mail.com" About="Test Peson A" />
  <Person PersonId="6" Name="Lisa Spencer" Email="Lisa@mail.com" About="Test Peson B" />
  <Person PersonId="7" Name="Heidi Reynolds" Email="Heidi@mail.com" About="Test Peson B" />
  <Person PersonId="8" Name="Lucille Brooks" Email="Lucille@mail.com" About="Test Peson B" />
  <Person PersonId="9" Name="Cody Salazar" Email="Cody@mail.com" About="Test Peson B" />
  <Person PersonId="10" Name="Paul Hughes" Email="Paul@mail.com" About="Good Seller - 10" />
  <Person PersonId="11" Name="Charly Visloy" ImageName="img/Avatar/Charly" PhoneNumber="056746344" Email="Charly@mail.com" About="procedure_GenerateId" />
  <Person PersonId="12" Name="Cler Adams" ImageName="img/Avatar/Cler" PhoneNumber="056746344" Email="Cler@mail.com" About="procedure_GenerateId" />
  <Person PersonId="13" Name="Alik Mercer" ImageName="img/Avatar/Alik" PhoneNumber="01222224212" Email="Alik@mail.com" About="Function_GenerateId" />
</Persons>'

EXEC [dbo].[ProcedureMergeXML]
		@Request