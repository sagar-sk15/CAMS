-- =============================================
-- Script Template
-- =============================================
delete from Country
delete from States
delete from Districts
delete from CityVillages

/*Script to add Country to the database table Country*/

INSERT INTO [CAMS].[dbo].[Country]
           ([CountryName]
           ,[CallingCode]
           ,[AgeStd]
           ,[Currency]
           ,[CurrencyCode]
           ,[Symbol]
           ,[TimeZone]
           ,[FinancialYearStart]
           ,[FinancialYearEnd]
           ,[Status])
     VALUES
           ('India'
           ,'+91'
           ,18
           ,'Indian Rupee'
           ,'INR'
           ,NCHAR(8425)
           ,'(GMT + 05:30) Chennai, Kolkata, Mumbai, New Delhi'
           ,'April'
           ,'March'
           ,'Active')
GO

/*Script to add States to the database table States*/

INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Andhra Pradesh'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Arunachal Pradesh'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Assam'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Bihar'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Chhattisgarh'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Goa'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Gujarat'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Haryana'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Himachal Pradesh'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Jammu and Kashmir'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Jharkhand'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Karnataka'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Kerala'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Madhya Pradesh'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Maharashtra'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Manipur'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Meghalaya'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Mizoram'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Nagaland'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Orissa'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Punjab'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Rajasthan'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Sikkim'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Tamil Nadu'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Tripura'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Uttar Pradesh'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'Uttarakhand'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('State'
           ,'West Bengal'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('UnionTerritory'
           ,'Andaman and Nicobar'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('UnionTerritory'
           ,'Chandigarh'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('UnionTerritory'
           ,'Dadra and Nagar Haveli'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('UnionTerritory'
           ,'Daman and Diu'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('UnionTerritory'
           ,'Lakshadweep'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('UnionTerritory'
           ,'National Capital Territory of Delhi'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[States]
           ([RegionType]
           ,[RegionName]
           ,[CountryId])
     VALUES
           ('UnionTerritory'
           ,'Pondicherry'
           ,1)
GO

/*Script to add Districts to the database table Districts*/
--===========================================================
-- Andhra Pradesh
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Adilabad'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Anantapur'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Chittoor'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('East Godavari'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Guntur'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Hyderabad'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('YSR district'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Karimnagar'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Khammam'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Krishna (N T R District)'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kurnool'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Mahbubnagar'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Medak'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Nalgonda'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Nellore'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Nizamabad'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Prakasam'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Rangareddi'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Srikakulam'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Vishakhapatnam'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Vizianagaram'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Warangal'
           ,1)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('West Godavari'
           ,1)
GO
--===========================================================
-- Arunachal Pradesh
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Anjaw'
           ,2)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Changlang'
           ,2)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('East Kameng'
           ,2)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('East Siang'
           ,2)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Lohit'
           ,2)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Lower Subansiri'
           ,2)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Papum Pare'
           ,2)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Tawang'
           ,2)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Tirap'
           ,2)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dibang Valley'
           ,2)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Upper Siang'
           ,2)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Upper Subansiri'
           ,2)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('West Kameng'
           ,2)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('West Siang'
           ,2)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Upper Dibang Valley'
           ,2)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kurung Kumey'
           ,2)
GO
--===========================================================
-- Assam
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Barpeta'
           ,3)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bongaigaon'
           ,3)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Cachar'
           ,3)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Darrang'
           ,3)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dhemaji'
           ,3)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dhubri'
           ,3)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dibrugarh'
           ,3)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Goalpara'
           ,3)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Golaghat'
           ,3)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Hailakandi'
           ,3)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jorhat'
           ,3)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Karbi Anglong'
           ,3)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Karimganj'
           ,3)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kokrajhar'
           ,3)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Lakhimpur'
           ,3)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Marigaon'
           ,3)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Nagaon'
           ,3)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Nalbari'
           ,3)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dima Hasao'
           ,3)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sibsagar'
           ,3)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sonitpur'
           ,3)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Tinsukia'
           ,3)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kamrup'
           ,3)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kamrup Metropolitan'
           ,3)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Baksa'
           ,3)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Udalguri'
           ,3)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Chirang'
           ,3)
GO
--===========================================================
-- Bihar
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Araria'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Arwal'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Aurangabad'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Banka'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Begusarai'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bhagalpur'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bhojpur'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Buxar'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Darbhanga'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('East Champaran'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Gaya'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Gopalganj'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jamui'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jehanabad'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Khagaria'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kishanganj'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kaimur'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Katihar'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Lakhisarai'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Madhubani'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Munger'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Madhepura'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Muzaffarpur'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Nalanda'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Nawada'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Patna'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Purnia'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Rohtas'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Saharsa'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Samastipur'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sheohar'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sheikhpura'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Saran'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sitamarhi'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Supaul'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Siwan'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Vaishali(Akshay)'
           ,4)
GO
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('West Champaran'
           ,4)
GO
--===========================================================
-- Chhattisgarh 
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bastar'
           ,5)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bijapur'
           ,5)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bilaspur'
           ,5)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dantewada'
           ,5)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dhamtari'
           ,5)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Durg'
           ,5)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jashpur'
           ,5)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Janjgir-Champa'
           ,5)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Korba'
           ,5)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Koriya'
           ,5)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kanker'
           ,5)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kawardha'
           ,5)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Mahasamund'
           ,5)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Narayanpur'
           ,5)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Raigarh'
           ,5)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Rajnandgaon'
           ,5)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Raipur'
           ,5)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Surajpur'
           ,5)
--===========================================================
-- Goa
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('North Goa'
           ,6)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('South Goa'
           ,6)
--===========================================================
-- Gujarat
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ahmedabad'
           ,7)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Amreli District'
           ,7)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Anand'
           ,7)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Banaskantha'
           ,7)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bharuch'
           ,7)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bhavnagar'
           ,7)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dahod'
           ,7)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('The Dangs'
           ,7)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Gandhinagar'
           ,7)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jamnagar'
           ,7)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Junagadh'
           ,7)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kutch'
           ,7)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kheda'
           ,7)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Mehsana'
           ,7)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Narmada'
           ,7)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Navsari'
           ,7)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Patan'
           ,7)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Panchmahal'
           ,7)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Porbandar'
           ,7)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Rajkot'
           ,7)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sabarkantha'
           ,7)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Surendranagar'
           ,7)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Surat'
           ,7)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Tapi'
           ,7)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Vadodara'
           ,7)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Valsad'
           ,7)
--===========================================================
-- Haryana
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ambala'
           ,8)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bhiwani'
           ,8)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Faridabad'
           ,8)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Fatehabad'
           ,8)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Gurgaon'
           ,8)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Hisar'
           ,8)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jhajjar'
           ,8)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jind'
           ,8)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kaithal'
           ,8)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Karnal'
           ,8)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kurukshetra'
           ,8)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Mahendragarh'
           ,8)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Mewat'
           ,8)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Palwal'
           ,8)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Panchkula'
           ,8)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Panipat'
           ,8)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Rewari'
           ,8)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Rohtak'
           ,8)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sirsa'
           ,8)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sonipat'
           ,8)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Yamuna Nagar'
           ,8)
--===========================================================
-- Himachal Pradesh
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bilaspur'
           ,9)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Chamba'
           ,9)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Hamirpur'
           ,9)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kangra'
           ,9)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kinnaur'
           ,9)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kullu'
           ,9)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Lahaul and Spiti'
           ,9)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Mandi'
           ,9)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Shimla'
           ,9)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sirmaur'
           ,9)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Solan'
           ,9)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Una'
           ,9)
--===========================================================
-- Jammu and Kashmir
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Anantnag'
           ,10)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Badgam'
           ,10)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bandipore'
           ,10)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Baramula'
           ,10)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Doda'
           ,10)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ganderbal'
           ,10)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jammu'
           ,10)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kargil'
           ,10)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kathua'
           ,10)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kishtwar'
           ,10)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kupwara'
           ,10)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kulgam'
           ,10)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Leh'
           ,10)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Poonch'
           ,10)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Pulwama'
           ,10)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Rajauri'
           ,10)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ramban'
           ,10)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Reasi'
           ,10)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Samba'
           ,10)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Shopian'
           ,10)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Srinagar'
           ,10)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Udhampur district'
           ,10)
--===========================================================
-- Jharkhand
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ranchi'
           ,11)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Lohardaga'
           ,11)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Gumla'
           ,11)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Simdega'
           ,11)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Palamu'
           ,11)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Latehar'
           ,11)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Garhwa'
           ,11)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('West Singhbhum'
           ,11)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Saraikela Kharsawan'
           ,11)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('East Singhbhum'
           ,11)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dumka'
           ,11)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jamtara'
           ,11)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sahebganj'
           ,11)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Pakur'
           ,11)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Godda'
           ,11)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Hazaribagh'
           ,11)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Chatra'
           ,11)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Koderma'
           ,11)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Giridih'
           ,11)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dhanbad'
           ,11)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bokaro'
           ,11)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Deoghar'
           ,11)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Khunti'
           ,11)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ramgarh'
           ,11)

--===========================================================
-- Karnataka 
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bidar'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Belgaum'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bijapur'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bagalkot'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bellary'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bangalore Rural District'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bangalore Urban district'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Chamarajnagar'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Chikmagalur'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Chitradurga'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Davanagere'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dharwad'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dakshina Kannada'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Gadag'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Gulbarga'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Hassan'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Haveri District'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kodagu'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kolar'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Koppal'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Mandya'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Mysore'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Raichur'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Shimoga'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Tumkur'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Udupi'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Uttara Kannada'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ramanagara'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Chikballapur'
           ,12)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Yadgir'
           ,12)

--===========================================================
-- Kerala  
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Alappuzha'
           ,13)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ernakulam'
           ,13)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Idukki'
           ,13)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kollam'
           ,13)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kannur'
           ,13)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kasaragod'
           ,13)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kottayam'
           ,13)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kozhikode'
           ,13)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Malappuram'
           ,13)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Palakkad'
           ,13)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Pathanamthitta'
           ,13)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Thrissur'
           ,13)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Thiruvananthapuram'
           ,13)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Wayanad'
           ,13)
--===========================================================
-- Madhya Pradesh 
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Alirajpur'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Anuppur'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ashok Nagar'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Balaghat'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Barwani'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Betul'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bhind'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bhopal'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Burhanpur'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Chhatarpur'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Chhindwara'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Damoh'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Datia'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dewas'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dhar'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dindori'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Guna'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Gwalior'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Harda'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Hoshangabad'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Indore'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jabalpur'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jhabua'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Katni'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Khandwa'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Khargone'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Mandla'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Mandsaur'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Morena'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Narsinghpur'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Neemuch'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Panna'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Rewa'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Rajgarh'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ratlam'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Raisen'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sagar'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Satna'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sehore'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Seoni'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Shahdol'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Shajapur'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sheopur'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Shivpuri'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sidhi'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Singrauli'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Tikamgarh'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ujjain'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Umaria'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Vidisha'
           ,14)
--===========================================================
-- Maharashtra 
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ahmednagar'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Akola'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Amravati'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Aurangabad'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bhandara'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Beed'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Buldhana'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Chandrapur'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dhule'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Gadchiroli'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Gondia'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Hingoli'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jalgaon'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jalna'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kolhapur'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Latur'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Mumbai City'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Mumbai suburban'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Nandurbar'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Nanded'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Nagpur'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Nashik'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Osmanabad'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Parbhani'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Pune'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Raigad'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ratnagiri'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sindhudurg'
           ,14)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sangli'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Solapur'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Satara'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Thane'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Wardha'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Washim'
           ,15)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Yavatmal'
           ,15)

--===========================================================
-- Manipur 
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bishnupur'
           ,16)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Churachandpur'
           ,16)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Chandel'
           ,16)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Imphal East'
           ,16)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Senapati'
           ,16)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Tamenglong'
           ,16)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Thoubal'
           ,16)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ukhrul'
           ,16)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Imphal West'
           ,16)
--===========================================================
-- Meghalaya 
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('East Garo Hills'
           ,17)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('East Khasi Hills'
           ,17)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jaintia Hills'
           ,17)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ri Bhoi'
           ,17)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('South Garo Hills'
           ,17)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('West Garo Hills'
           ,17)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('West Khasi Hills'
           ,17)
--===========================================================
-- Mizoram  
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Aizawl'
           ,18)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Champhai'
           ,18)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kolasib'
           ,18)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Lawngtlai'
           ,18)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Lunglei'
           ,18)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Mamit'
           ,18)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Saiha'
           ,18)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Serchhip'
           ,18)
--===========================================================
-- Nagaland
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dimapur'
           ,19)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kiphire'
           ,19)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kohima'
           ,19)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Longleng'
           ,19)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Mokokchung'
           ,19)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Mon'
           ,19)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Peren'
           ,19)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Phek'
           ,19)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Tuensang'
           ,19)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Wokha'
           ,19)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Zunheboto'
           ,19)
--===========================================================
-- Orissa  
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Angul'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Boudh'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bhadrak'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bolangir'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bargarh'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Baleswar'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Cuttack'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Debagarh'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dhenkanal'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ganjam'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Gajapati'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jharsuguda'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jajapur'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jagatsinghpur'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Khordha'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kendujhar'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kalahandi'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kandhamal'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Koraput'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kendrapara'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Malkangiri'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Mayurbhanj'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Nabarangpur'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Nuapada'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Nayagarh'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Puri'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Rayagada'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sambalpur'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Subarnapur'
           ,20)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sundargarh '
           ,20)
--===========================================================
-- Punjab  
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Amritsar'
           ,21)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Barnala'
           ,21)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bathinda'
           ,21)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Faridkot'
           ,21)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Fatehgarh Sahib'
           ,21)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Fazilka'
           ,21)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ferozepur'
           ,21)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Gurdaspur'
           ,21)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Hoshiarpur'
           ,21)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jalandhar'
           ,21)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kapurthala'
           ,21)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ludhiana'
           ,21)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Mansa'
           ,21)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Moga'
           ,21)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Muktsar'
           ,21)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Pathankot'
           ,21)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Patiala'
           ,21)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Rupnagar'
           ,21)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sahibzada Ajit Singh Nagar-Mohali'
           ,21)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sangrur'
           ,21)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Shahid Bhagat Singh Nagar'
           ,21)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Tarn Taran'
           ,21)
--===========================================================
-- Rajasthan 
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ajmer'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Alwar'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bikaner'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Barmer'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Banswara'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bharatpur'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Baran'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bundi'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bhilwara'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Churu'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Chittorgarh'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dausa'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dholpur'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dungapur'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ganganagar'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Hanumangarh'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jhunjhunu'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jalore'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jodhpur'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jaipur'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jaisalmer'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jhalawar'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Karauli'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kota'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Nagaur'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Pali'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Pratapgarh'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Rajsamand'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sikar'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sawai Madhopur'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sirohi'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Tonk'
           ,22)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Udaipur'
           ,22)
--===========================================================
-- Sikkim  
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('East Sikkim'
           ,23)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('North Sikkim'
           ,23)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('South Sikkim'
           ,23)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('West Sikkim'
           ,23)
--===========================================================
-- Tamil Nadu  
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ariyalur'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Chennai'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Coimbatore'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Cuddalore'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dharmapuri'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dindigul'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Erode'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kanchipuram'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kanniyakumari'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Karur'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Krishnagiri'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Madurai'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Nagapattinam'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Namakkal'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Nilgiris'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Perambalur'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Pudukkottai'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ramanathapuram'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Salem'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sivaganga'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Thanjavur'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Theni'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Thoothukudi'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Thiruvarur'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Tirunelveli'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Tiruchirappalli'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Thiruvallur'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Tiruppur'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Tiruvannamalai'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Vellore'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Villupuram'
           ,24)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Virudhunagar'
           ,24)
--===========================================================
-- Tripura   
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dhalai'
           ,25)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('North Tripura'
           ,25)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('South Tripura'
           ,25)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('West Tripura'
           ,25)
--===========================================================
-- Uttar Pradesh  
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Agra'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Allahabad'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Aligarh'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ambedkar Nagar'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Auraiya'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Azamgarh'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Barabanki'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Budaun'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bagpat'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bahraich'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bijnor'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ballia'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Banda'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Balrampur'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bareilly'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Basti'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bulandshahar'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Chandauli'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Chhatrapati Shahuji Maharaj Nagar'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Chitrakoot'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Deoria'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Etah'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kanshi Ram Nagar'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Etawah'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Firozabad'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Farrukhabad'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Fatehpur'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Faizabad'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Gautam Buddha Nagar'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Gonda'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ghazipur'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Gorakhpur'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ghaziabad'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Hamirpur'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Hardoi'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Mahamaya Nagar'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jhansi'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jalaun'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jyotiba Phule Nagar'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jaunpur District'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Ramabai Nagar (Kanpur Dehat)'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kannauj'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kanpur Nagar'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kaushambi'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kushinagar'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Lalitpur'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Lakhimpur-Kheri'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Lucknow'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Mau'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Meerut'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Maharajganj'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Mahoba'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Mirzapur'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Moradabad'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Mainpuri'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Mathura'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Muzaffarnagar'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Pilibhit'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Pratapgarh'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Rampur'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Raebareli'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Saharanpur'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sitapur'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Shahjahanpur'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sant Kabir Nagar'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Siddharthnagar'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sonbhadra'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sant Ravidas Nagar'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Sultanpur'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Shravasti'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Unnao'
           ,26)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Varanasi'
           ,26)
--===========================================================
-- Uttarakhand  
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Almora'
           ,27)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bageshwar'
           ,27)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Chamoli'
           ,27)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Champawat'
           ,27)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dehradun'
           ,27)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Haridwar'
           ,27)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Nainital'
           ,27)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Pauri Garhwal'
           ,27)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Pithoragarh'
           ,27)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Rudraprayag'
           ,27)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Tehri Garhwal'
           ,27)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Udham Singh Nagar'
           ,27)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Uttarkashi'
           ,27)
--===========================================================
-- West Bengal   
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Birbhum'
           ,28)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bankura'
           ,28)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Bardhaman'
           ,28)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Darjeeling'
           ,28)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dakshin Dinajpur'
           ,28)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Hooghly'
           ,28)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Howrah'
           ,28)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Jalpaiguri'
           ,28)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Cooch Behar'
           ,28)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Kolkata'
           ,28)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Malda'
           ,28)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Paschim Medinipur'
           ,28)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Purba Medinipur'
           ,28)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Murshidabad'
           ,28)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Nadia'
           ,28)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('North 24 Parganas'
           ,28)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('South 24 Parganas'
           ,28)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Purulia'
           ,28)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Uttar Dinajpur'
           ,28)
--===========================================================
-- Andaman and Nicobar   
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('North and Middle Andaman district'
           ,29)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('South Andaman district '
           ,29)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Nicobar district '
           ,29)
--===========================================================
-- Chandigarh  
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Chandigarh'
           ,30)
--===========================================================
-- Dadra and Nagar Haveli  
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Dadra and Nagar Haveli'
           ,31)
--===========================================================
-- Daman and Diu  
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Daman'
           ,32)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Diu'
           ,32)
--===========================================================
-- Lakshadweep  
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Lakshadweep'
           ,33)
--===========================================================
-- National Capital Territory of Delhi  
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Central Delhi'
           ,34)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('North Delhi'
           ,34)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('South Delhi'
           ,34)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('East Delhi'
           ,34)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('North East Delhi'
           ,34)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('South West Delhi'
           ,34)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('New Delhi'
           ,34)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('North West Delhi'
           ,34)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('West Delhi'
           ,34)
--===========================================================
-- Pondicherry  
--===========================================================
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Karaikal'
           ,35)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Mahe'
           ,35)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Pondicherry'
           ,35)
INSERT INTO [CAMS].[dbo].[Districts]
           ([DistrictName]
           ,[StateId])
     VALUES
           ('Yanam'
           ,35)

/*Script to add CityVillage to the database table CityVillage*/

INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Adilabad ','City' ,' ',1) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Anantapur ','City' ,' ',2) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Chittoor ','City' ,' ',3) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('East Godavari ','City' ,' ',4) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Guntur ','City' ,' ',5) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Hyderabad ','City' ,' ',6) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('YSR district ','City' ,' ',7) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Karimnagar ','City' ,' ',8) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Khammam ','City' ,' ',9) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Krishna (N T R District) ','City' ,' ',10) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kurnool ','City' ,' ',11) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Mahbubnagar ','City' ,' ',12) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Medak ','City' ,' ',13) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Nalgonda ','City' ,' ',14) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Nellore ','City' ,' ',15) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Nizamabad ','City' ,' ',16) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Prakasam ','City' ,' ',17) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Rangareddi ','City' ,' ',18) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Srikakulam ','City' ,' ',19) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Vishakhapatnam ','City' ,' ',20) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Vizianagaram ','City' ,' ',21) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Warangal ','City' ,' ',22) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('West Godavari ','City' ,' ',23) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Anjaw ','City' ,' ',24) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Changlang ','City' ,' ',25) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('East Kameng ','City' ,' ',26) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('East Siang ','City' ,' ',27) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Lohit ','City' ,' ',28) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Lower Subansiri ','City' ,' ',29) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Papum Pare ','City' ,' ',30) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Tawang ','City' ,' ',31) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Tirap ','City' ,' ',32) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dibang Valley ','City' ,' ',33) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Upper Siang ','City' ,' ',34) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Upper Subansiri ','City' ,' ',35) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('West Kameng ','City' ,' ',36) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('West Siang ','City' ,' ',37) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Upper Dibang Valley ','City' ,' ',38) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kurung Kumey ','City' ,' ',39) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Barpeta ','City' ,' ',40) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bongaigaon ','City' ,' ',41) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Cachar ','City' ,' ',42) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Darrang ','City' ,' ',43) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dhemaji ','City' ,' ',44) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dhubri ','City' ,' ',45) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dibrugarh ','City' ,' ',46) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Goalpara ','City' ,' ',47) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Golaghat ','City' ,' ',48) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Hailakandi ','City' ,' ',49) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jorhat ','City' ,' ',50) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Karbi Anglong ','City' ,' ',51) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Karimganj ','City' ,' ',52) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kokrajhar ','City' ,' ',53) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Lakhimpur ','City' ,' ',54) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Marigaon ','City' ,' ',55) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Nagaon ','City' ,' ',56) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Nalbari ','City' ,' ',57) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dima Hasao ','City' ,' ',58) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sibsagar ','City' ,' ',59) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sonitpur ','City' ,' ',60) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Tinsukia ','City' ,' ',61) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kamrup ','City' ,' ',62) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kamrup Metropolitan ','City' ,' ',63) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Baksa ','City' ,' ',64) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Udalguri ','City' ,' ',65) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Chirang ','City' ,' ',66) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Araria ','City' ,' ',67) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Arwal ','City' ,' ',68) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Aurangabad ','City' ,' ',69) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Banka ','City' ,' ',70) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Begusarai ','City' ,' ',71) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bhagalpur ','City' ,' ',72) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bhojpur ','City' ,' ',73) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Buxar ','City' ,' ',74) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Darbhanga ','City' ,' ',75) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('East Champaran ','City' ,' ',76) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Gaya ','City' ,' ',77) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Gopalganj ','City' ,' ',78) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jamui ','City' ,' ',79) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jehanabad ','City' ,' ',80) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Khagaria ','City' ,' ',81) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kishanganj ','City' ,' ',82) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kaimur ','City' ,' ',83) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Katihar ','City' ,' ',84) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Lakhisarai ','City' ,' ',85) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Madhubani ','City' ,' ',86) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Munger ','City' ,' ',87) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Madhepura ','City' ,' ',88) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Muzaffarpur ','City' ,' ',89) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Nalanda ','City' ,' ',90) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Nawada ','City' ,' ',91) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Patna ','City' ,' ',92) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Purnia ','City' ,' ',93) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Rohtas ','City' ,' ',94) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Saharsa ','City' ,' ',95) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Samastipur ','City' ,' ',96) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sheohar ','City' ,' ',97) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sheikhpura ','City' ,' ',98) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Saran ','City' ,' ',99) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sitamarhi ','City' ,' ',100) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Supaul ','City' ,' ',101) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Siwan ','City' ,' ',102) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Vaishali(Akshay) ','City' ,' ',103) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('West Champaran ','City' ,' ',104) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bastar ','City' ,' ',105) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bijapur ','City' ,' ',106) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bilaspur ','City' ,' ',107) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dantewada ','City' ,' ',108) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dhamtari ','City' ,' ',109) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Durg ','City' ,' ',110) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jashpur ','City' ,' ',111) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Janjgir-Champa ','City' ,' ',112) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Korba ','City' ,' ',113) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Koriya ','City' ,' ',114) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kanker ','City' ,' ',115) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kawardha ','City' ,' ',116) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Mahasamund ','City' ,' ',117) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Narayanpur ','City' ,' ',118) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Raigarh ','City' ,' ',119) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Rajnandgaon ','City' ,' ',120) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Raipur ','City' ,' ',121) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Surajpur ','City' ,' ',122) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('North Goa ','City' ,' ',123) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('South Goa ','City' ,' ',124) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ahmedabad ','City' ,' ',125) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Amreli District ','City' ,' ',126) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Anand ','City' ,' ',127) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Banaskantha ','City' ,' ',128) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bharuch ','City' ,' ',129) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bhavnagar ','City' ,' ',130) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dahod ','City' ,' ',131) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('The Dangs ','City' ,' ',132) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Gandhinagar ','City' ,' ',133) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jamnagar ','City' ,' ',134) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Junagadh ','City' ,' ',135) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kutch ','City' ,' ',136) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kheda ','City' ,' ',137) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Mehsana ','City' ,' ',138) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Narmada ','City' ,' ',139) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Navsari ','City' ,' ',140) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Patan ','City' ,' ',141) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Panchmahal ','City' ,' ',142) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Porbandar ','City' ,' ',143) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Rajkot ','City' ,' ',144) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sabarkantha ','City' ,' ',145) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Surendranagar ','City' ,' ',146) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Surat ','City' ,' ',147) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Tapi ','City' ,' ',148) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Vadodara ','City' ,' ',149) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Valsad ','City' ,' ',150) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ambala ','City' ,' ',151) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bhiwani ','City' ,' ',152) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Faridabad ','City' ,' ',153) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Fatehabad ','City' ,' ',154) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Gurgaon ','City' ,' ',155) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Hisar ','City' ,' ',156) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jhajjar ','City' ,' ',157) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jind ','City' ,' ',158) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kaithal ','City' ,' ',159) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Karnal ','City' ,' ',160) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kurukshetra ','City' ,' ',161) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Mahendragarh ','City' ,' ',162) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Mewat ','City' ,' ',163) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Palwal ','City' ,' ',164) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Panchkula ','City' ,' ',165) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Panipat ','City' ,' ',166) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Rewari ','City' ,' ',167) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Rohtak ','City' ,' ',168) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sirsa ','City' ,' ',169) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sonipat ','City' ,' ',170) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Yamuna Nagar ','City' ,' ',171) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bilaspur ','City' ,' ',172) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Chamba ','City' ,' ',173) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Hamirpur ','City' ,' ',174) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kangra ','City' ,' ',175) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kinnaur ','City' ,' ',176) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kullu ','City' ,' ',177) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Lahaul and Spiti ','City' ,' ',178) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Mandi ','City' ,' ',179) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Shimla ','City' ,' ',180) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sirmaur ','City' ,' ',181) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Solan ','City' ,' ',182) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Una ','City' ,' ',183) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Anantnag ','City' ,' ',184) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Badgam ','City' ,' ',185) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bandipore ','City' ,' ',186) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Baramula ','City' ,' ',187) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Doda ','City' ,' ',188) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ganderbal ','City' ,' ',189) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jammu ','City' ,' ',190) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kargil ','City' ,' ',191) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kathua ','City' ,' ',192) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kishtwar ','City' ,' ',193) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kupwara ','City' ,' ',194) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kulgam ','City' ,' ',195) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Leh ','City' ,' ',196) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Poonch ','City' ,' ',197) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Pulwama ','City' ,' ',198) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Rajauri ','City' ,' ',199) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ramban ','City' ,' ',200) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Reasi ','City' ,' ',201) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Samba ','City' ,' ',202) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Shopian ','City' ,' ',203) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Srinagar ','City' ,' ',204) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Udhampur district ','City' ,' ',205) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ranchi ','City' ,' ',206) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Lohardaga ','City' ,' ',207) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Gumla ','City' ,' ',208) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Simdega ','City' ,' ',209) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Palamu ','City' ,' ',210) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Latehar ','City' ,' ',211) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Garhwa ','City' ,' ',212) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('West Singhbhum ','City' ,' ',213) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Saraikela Kharsawan ','City' ,' ',214) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('East Singhbhum ','City' ,' ',215) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dumka ','City' ,' ',216) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jamtara ','City' ,' ',217) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sahebganj ','City' ,' ',218) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Pakur ','City' ,' ',219) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Godda ','City' ,' ',220) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Hazaribagh ','City' ,' ',221) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Chatra ','City' ,' ',222) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Koderma ','City' ,' ',223) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Giridih ','City' ,' ',224) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dhanbad ','City' ,' ',225) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bokaro ','City' ,' ',226) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Deoghar ','City' ,' ',227) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Khunti ','City' ,' ',228) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ramgarh ','City' ,' ',229) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bidar ','City' ,' ',230) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Belgaum ','City' ,' ',231) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bijapur ','City' ,' ',232) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bagalkot ','City' ,' ',233) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bellary ','City' ,' ',234) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bangalore Rural District ','City' ,' ',235) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bangalore Urban district ','City' ,' ',236) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Chamarajnagar ','City' ,' ',237) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Chikmagalur ','City' ,' ',238) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Chitradurga ','City' ,' ',239) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Davanagere ','City' ,' ',240) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dharwad ','City' ,' ',241) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dakshina Kannada ','City' ,' ',242) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Gadag ','City' ,' ',243) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Gulbarga ','City' ,' ',244) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Hassan ','City' ,' ',245) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Haveri District ','City' ,' ',246) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kodagu ','City' ,' ',247) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kolar ','City' ,' ',248) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Koppal ','City' ,' ',249) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Mandya ','City' ,' ',250) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Mysore ','City' ,' ',251) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Raichur ','City' ,' ',252) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Shimoga ','City' ,' ',253) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Tumkur ','City' ,' ',254) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Udupi ','City' ,' ',255) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Uttara Kannada ','City' ,' ',256) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ramanagara ','City' ,' ',257) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Chikballapur ','City' ,' ',258) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Yadgir ','City' ,' ',259) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Alappuzha ','City' ,' ',260) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ernakulam ','City' ,' ',261) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Idukki ','City' ,' ',262) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kollam ','City' ,' ',263) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kannur ','City' ,' ',264) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kasaragod ','City' ,' ',265) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kottayam ','City' ,' ',266) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kozhikode ','City' ,' ',267) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Malappuram ','City' ,' ',268) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Palakkad ','City' ,' ',269) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Pathanamthitta ','City' ,' ',270) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Thrissur ','City' ,' ',271) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Thiruvananthapuram ','City' ,' ',272) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Wayanad ','City' ,' ',273) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Alirajpur ','City' ,' ',274) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Anuppur ','City' ,' ',275) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ashok Nagar ','City' ,' ',276) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Balaghat ','City' ,' ',277) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Barwani ','City' ,' ',278) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Betul ','City' ,' ',279) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bhind ','City' ,' ',280) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bhopal ','City' ,' ',281) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Burhanpur ','City' ,' ',282) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Chhatarpur ','City' ,' ',283) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Chhindwara ','City' ,' ',284) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Damoh ','City' ,' ',285) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Datia ','City' ,' ',286) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dewas ','City' ,' ',287) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dhar ','City' ,' ',288) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dindori ','City' ,' ',289) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Guna ','City' ,' ',290) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Gwalior ','City' ,' ',291) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Harda ','City' ,' ',292) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Hoshangabad ','City' ,' ',293) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Indore ','City' ,' ',294) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jabalpur ','City' ,' ',295) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jhabua ','City' ,' ',296) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Katni ','City' ,' ',297) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Khandwa ','City' ,' ',298) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Khargone ','City' ,' ',299) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Mandla ','City' ,' ',300) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Mandsaur ','City' ,' ',301) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Morena ','City' ,' ',302) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Narsinghpur ','City' ,' ',303) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Neemuch ','City' ,' ',304) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Panna ','City' ,' ',305) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Rewa ','City' ,' ',306) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Rajgarh ','City' ,' ',307) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ratlam ','City' ,' ',308) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Raisen ','City' ,' ',309) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sagar ','City' ,' ',310) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Satna ','City' ,' ',311) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sehore ','City' ,' ',312) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Seoni ','City' ,' ',313) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Shahdol ','City' ,' ',314) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Shajapur ','City' ,' ',315) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sheopur ','City' ,' ',316) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Shivpuri ','City' ,' ',317) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sidhi ','City' ,' ',318) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Singrauli ','City' ,' ',319) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Tikamgarh ','City' ,' ',320) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ujjain ','City' ,' ',321) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Umaria ','City' ,' ',322) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Vidisha ','City' ,' ',323) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ahmednagar ','City' ,' ',324) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Akola ','City' ,' ',325) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Amravati ','City' ,' ',326) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Aurangabad ','City' ,' ',327) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bhandara ','City' ,' ',328) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Beed ','City' ,' ',329) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Buldhana ','City' ,' ',330) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Chandrapur ','City' ,' ',331) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dhule ','City' ,' ',332) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Gadchiroli ','City' ,' ',333) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Gondia ','City' ,' ',334) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Hingoli ','City' ,' ',335) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jalgaon ','City' ,' ',336) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jalna ','City' ,' ',337) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kolhapur ','City' ,' ',338) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Latur ','City' ,' ',339) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Mumbai City ','City' ,' ',340) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Mumbai suburban ','City' ,' ',341) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Nandurbar ','City' ,' ',342) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Nanded ','City' ,' ',343) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Nagpur ','City' ,' ',344) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Nashik ','City' ,' ',345) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Osmanabad ','City' ,' ',346) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Parbhani ','City' ,' ',347) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Pune ','City' ,' ',348) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Raigad ','City' ,' ',349) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ratnagiri ','City' ,' ',350) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sindhudurg ','City' ,' ',351) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sangli ','City' ,' ',352) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Solapur ','City' ,' ',353) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Satara ','City' ,' ',354) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Thane ','City' ,' ',355) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Wardha ','City' ,' ',356) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Washim ','City' ,' ',357) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Yavatmal ','City' ,' ',358) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bishnupur ','City' ,' ',359) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Churachandpur ','City' ,' ',360) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Chandel ','City' ,' ',361) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Imphal East ','City' ,' ',362) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Senapati ','City' ,' ',363) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Tamenglong ','City' ,' ',364) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Thoubal ','City' ,' ',365) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ukhrul ','City' ,' ',366) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Imphal West ','City' ,' ',367) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('East Garo Hills ','City' ,' ',368) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('East Khasi Hills ','City' ,' ',369) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jaintia Hills ','City' ,' ',370) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ri Bhoi ','City' ,' ',371) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('South Garo Hills ','City' ,' ',372) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('West Garo Hills ','City' ,' ',373) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('West Khasi Hills ','City' ,' ',374) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Aizawl ','City' ,' ',375) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Champhai ','City' ,' ',376) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kolasib ','City' ,' ',377) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Lawngtlai ','City' ,' ',378) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Lunglei ','City' ,' ',379) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Mamit ','City' ,' ',380) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Saiha ','City' ,' ',381) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Serchhip ','City' ,' ',382) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dimapur ','City' ,' ',383) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kiphire ','City' ,' ',384) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kohima ','City' ,' ',385) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Longleng ','City' ,' ',386) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Mokokchung ','City' ,' ',387) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Mon ','City' ,' ',388) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Peren ','City' ,' ',389) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Phek ','City' ,' ',390) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Tuensang ','City' ,' ',391) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Wokha ','City' ,' ',392) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Zunheboto ','City' ,' ',393) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Angul ','City' ,' ',394) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Boudh ','City' ,' ',395) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bhadrak ','City' ,' ',396) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bolangir ','City' ,' ',397) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bargarh ','City' ,' ',398) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Baleswar ','City' ,' ',399) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Cuttack ','City' ,' ',400) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Debagarh ','City' ,' ',401) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dhenkanal ','City' ,' ',402) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ganjam ','City' ,' ',403) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Gajapati ','City' ,' ',404) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jharsuguda ','City' ,' ',405) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jajapur ','City' ,' ',406) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jagatsinghpur ','City' ,' ',407) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Khordha ','City' ,' ',408) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kendujhar ','City' ,' ',409) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kalahandi ','City' ,' ',410) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kandhamal ','City' ,' ',411) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Koraput ','City' ,' ',412) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kendrapara ','City' ,' ',413) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Malkangiri ','City' ,' ',414) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Mayurbhanj ','City' ,' ',415) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Nabarangpur ','City' ,' ',416) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Nuapada ','City' ,' ',417) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Nayagarh ','City' ,' ',418) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Puri ','City' ,' ',419) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Rayagada ','City' ,' ',420) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sambalpur ','City' ,' ',421) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Subarnapur ','City' ,' ',422) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sundargarh  ','City' ,' ',423) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Amritsar ','City' ,' ',424) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Barnala ','City' ,' ',425) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bathinda ','City' ,' ',426) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Faridkot ','City' ,' ',427) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Fatehgarh Sahib ','City' ,' ',428) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Fazilka ','City' ,' ',429) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ferozepur ','City' ,' ',430) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Gurdaspur ','City' ,' ',431) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Hoshiarpur ','City' ,' ',432) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jalandhar ','City' ,' ',433) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kapurthala ','City' ,' ',434) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ludhiana ','City' ,' ',435) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Mansa ','City' ,' ',436) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Moga ','City' ,' ',437) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Muktsar ','City' ,' ',438) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Pathankot ','City' ,' ',439) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Patiala ','City' ,' ',440) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Rupnagar ','City' ,' ',441) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sahibzada Ajit Singh Nagar-Mohali ','City' ,' ',442) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sangrur ','City' ,' ',443) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Shahid Bhagat Singh Nagar ','City' ,' ',444) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Tarn Taran ','City' ,' ',445) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ajmer ','City' ,' ',446) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Alwar ','City' ,' ',447) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bikaner ','City' ,' ',448) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Barmer ','City' ,' ',449) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Banswara ','City' ,' ',450) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bharatpur ','City' ,' ',451) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Baran ','City' ,' ',452) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bundi ','City' ,' ',453) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bhilwara ','City' ,' ',454) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Churu ','City' ,' ',455) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Chittorgarh ','City' ,' ',456) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dausa ','City' ,' ',457) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dholpur ','City' ,' ',458) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dungapur ','City' ,' ',459) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ganganagar ','City' ,' ',460) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Hanumangarh ','City' ,' ',461) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jhunjhunu ','City' ,' ',462) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jalore ','City' ,' ',463) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jodhpur ','City' ,' ',464) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jaipur ','City' ,' ',465) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jaisalmer ','City' ,' ',466) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jhalawar ','City' ,' ',467) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Karauli ','City' ,' ',468) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kota ','City' ,' ',469) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Nagaur ','City' ,' ',470) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Pali ','City' ,' ',471) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Pratapgarh ','City' ,' ',472) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Rajsamand ','City' ,' ',473) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sikar ','City' ,' ',474) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sawai Madhopur ','City' ,' ',475) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sirohi ','City' ,' ',476) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Tonk ','City' ,' ',477) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Udaipur ','City' ,' ',478) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('East Sikkim ','City' ,' ',479) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('North Sikkim ','City' ,' ',480) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('South Sikkim ','City' ,' ',481) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('West Sikkim ','City' ,' ',482) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ariyalur ','City' ,' ',483) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Chennai ','City' ,' ',484) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Coimbatore ','City' ,' ',485) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Cuddalore ','City' ,' ',486) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dharmapuri ','City' ,' ',487) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dindigul ','City' ,' ',488) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Erode ','City' ,' ',489) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kanchipuram ','City' ,' ',490) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kanniyakumari ','City' ,' ',491) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Karur ','City' ,' ',492) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Krishnagiri ','City' ,' ',493) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Madurai ','City' ,' ',494) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Nagapattinam ','City' ,' ',495) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Namakkal ','City' ,' ',496) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Nilgiris ','City' ,' ',497) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Perambalur ','City' ,' ',498) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Pudukkottai ','City' ,' ',499) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ramanathapuram ','City' ,' ',500) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Salem ','City' ,' ',501) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sivaganga ','City' ,' ',502) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Thanjavur ','City' ,' ',503) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Theni ','City' ,' ',504) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Thoothukudi ','City' ,' ',505) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Thiruvarur ','City' ,' ',506) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Tirunelveli ','City' ,' ',507) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Tiruchirappalli ','City' ,' ',508) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Thiruvallur ','City' ,' ',509) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Tiruppur ','City' ,' ',510) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Tiruvannamalai ','City' ,' ',511) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Vellore ','City' ,' ',512) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Villupuram ','City' ,' ',513) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Virudhunagar ','City' ,' ',514) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dhalai ','City' ,' ',515) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('North Tripura ','City' ,' ',516) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('South Tripura ','City' ,' ',517) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('West Tripura ','City' ,' ',518) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Agra ','City' ,' ',519) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Allahabad ','City' ,' ',520) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Aligarh ','City' ,' ',521) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ambedkar Nagar ','City' ,' ',522) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Auraiya ','City' ,' ',523) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Azamgarh ','City' ,' ',524) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Barabanki ','City' ,' ',525) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Budaun ','City' ,' ',526) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bagpat ','City' ,' ',527) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bahraich ','City' ,' ',528) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bijnor ','City' ,' ',529) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ballia ','City' ,' ',530) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Banda ','City' ,' ',531) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Balrampur ','City' ,' ',532) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bareilly ','City' ,' ',533) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Basti ','City' ,' ',534) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bulandshahar ','City' ,' ',535) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Chandauli ','City' ,' ',536) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Chhatrapati Shahuji Maharaj Nagar ','City' ,' ',537) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Chitrakoot ','City' ,' ',538) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Deoria ','City' ,' ',539) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Etah ','City' ,' ',540) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kanshi Ram Nagar ','City' ,' ',541) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Etawah ','City' ,' ',542) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Firozabad ','City' ,' ',543) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Farrukhabad ','City' ,' ',544) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Fatehpur ','City' ,' ',545) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Faizabad ','City' ,' ',546) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Gautam Buddha Nagar ','City' ,' ',547) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Gonda ','City' ,' ',548) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ghazipur ','City' ,' ',549) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Gorakhpur ','City' ,' ',550) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ghaziabad ','City' ,' ',551) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Hamirpur ','City' ,' ',552) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Hardoi ','City' ,' ',553) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Mahamaya Nagar ','City' ,' ',554) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jhansi ','City' ,' ',555) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jalaun ','City' ,' ',556) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jyotiba Phule Nagar ','City' ,' ',557) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jaunpur District ','City' ,' ',558) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Ramabai Nagar (Kanpur Dehat) ','City' ,' ',559) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kannauj ','City' ,' ',560) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kanpur Nagar ','City' ,' ',561) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kaushambi ','City' ,' ',562) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kushinagar ','City' ,' ',563) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Lalitpur ','City' ,' ',564) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Lakhimpur-Kheri ','City' ,' ',565) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Lucknow ','City' ,' ',566) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Mau ','City' ,' ',567) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Meerut ','City' ,' ',568) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Maharajganj ','City' ,' ',569) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Mahoba ','City' ,' ',570) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Mirzapur ','City' ,' ',571) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Moradabad ','City' ,' ',572) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Mainpuri ','City' ,' ',573) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Mathura ','City' ,' ',574) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Muzaffarnagar ','City' ,' ',575) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Pilibhit ','City' ,' ',576) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Pratapgarh ','City' ,' ',577) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Rampur ','City' ,' ',578) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Raebareli ','City' ,' ',579) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Saharanpur ','City' ,' ',580) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sitapur ','City' ,' ',581) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Shahjahanpur ','City' ,' ',582) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sant Kabir Nagar ','City' ,' ',583) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Siddharthnagar ','City' ,' ',584) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sonbhadra ','City' ,' ',585) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sant Ravidas Nagar ','City' ,' ',586) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Sultanpur ','City' ,' ',587) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Shravasti ','City' ,' ',588) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Unnao ','City' ,' ',589) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Varanasi ','City' ,' ',590) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Almora ','City' ,' ',591) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bageshwar ','City' ,' ',592) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Chamoli ','City' ,' ',593) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Champawat ','City' ,' ',594) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dehradun ','City' ,' ',595) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Haridwar ','City' ,' ',596) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Nainital ','City' ,' ',597) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Pauri Garhwal ','City' ,' ',598) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Pithoragarh ','City' ,' ',599) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Rudraprayag ','City' ,' ',600) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Tehri Garhwal ','City' ,' ',601) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Udham Singh Nagar ','City' ,' ',602) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Uttarkashi ','City' ,' ',603) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Birbhum ','City' ,' ',604) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bankura ','City' ,' ',605) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Bardhaman ','City' ,' ',606) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Darjeeling ','City' ,' ',607) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dakshin Dinajpur ','City' ,' ',608) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Hooghly ','City' ,' ',609) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Howrah ','City' ,' ',610) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Jalpaiguri ','City' ,' ',611) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Cooch Behar ','City' ,' ',612) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Kolkata ','City' ,' ',613) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Malda ','City' ,' ',614) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Paschim Medinipur ','City' ,' ',615) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Purba Medinipur ','City' ,' ',616) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Murshidabad ','City' ,' ',617) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Nadia ','City' ,' ',618) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('North 24 Parganas ','City' ,' ',619) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('South 24 Parganas ','City' ,' ',620) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Purulia ','City' ,' ',621) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Uttar Dinajpur ','City' ,' ',622) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('North and Middle Andaman district ','City' ,' ',623) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('South Andaman district  ','City' ,' ',624) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Nicobar district  ','City' ,' ',625) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Chandigarh ','City' ,' ',626) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Dadra and Nagar Haveli ','City' ,' ',627) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Daman ','City' ,' ',628) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Diu ','City' ,' ',629) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Lakshadweep ','City' ,' ',630) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Central Delhi ','City' ,' ',631) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('North Delhi ','City' ,' ',632) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('South Delhi ','City' ,' ',633) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('East Delhi ','City' ,' ',634) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('North East Delhi ','City' ,' ',635) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('South West Delhi ','City' ,' ',636) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('New Delhi ','City' ,' ',637) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('North West Delhi ','City' ,' ',638) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('West Delhi ','City' ,' ',639) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Karaikal ','City' ,' ',640) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Mahe ','City' ,' ',641) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Pondicherry ','City' ,' ',642) GO
INSERT INTO [CAMS].[dbo].[CityVillages]([Name],[CityOrVillage],[STDCode] ,[DistrictId])VALUES ('Yanam ','City' ,' ',643) GO
