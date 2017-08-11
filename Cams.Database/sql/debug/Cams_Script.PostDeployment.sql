/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
-- =============================================
-- Script Template
-- =============================================
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


INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Andhra Pradesh',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Arunachal Pradesh',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Assam',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Bihar',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Chhattisgarh',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Goa',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Gujarat',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Haryana',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Himachal Pradesh',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Jammu and Kashmir',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Jharkhand',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Karnataka',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Kerala',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Madhya Pradesh',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Maharashtra',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Manipur',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Meghalaya',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Mizoram',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Nagaland',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Orissa',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Punjab',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Rajasthan',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Sikkim',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Tamil Nadu',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Tripura',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Uttar Pradesh',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','Uttarakhand',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('State','West Bengal',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('Union Territory','Andaman and Nicobar',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('Union Territory','Chandigarh',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('Union Territory','Dadra and Nagar Haveli',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('Union Territory','Daman and Diu',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('Union Territory','Lakshadweep',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('Union Territory','Delhi',1)
INSERT INTO [CAMS].[dbo].[States]([RegionType],[RegionName],[CountryId]) VALUES ('Union Territory','Pondicherry',1)

GO

Insert into Districts(DistrictName,StateId) values('Nellore', (select stateid from States where RegionName='Andhra Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Cuddapah', (select stateid from States where RegionName='Andhra Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Karim Nagar', (select stateid from States where RegionName='Andhra Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Kurnool', (select stateid from States where RegionName='Andhra Pradesh'))				
Insert into Districts(DistrictName,StateId) values('West Godavari', (select stateid from States where RegionName='Andhra Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Srikakulam', (select stateid from States where RegionName='Andhra Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Anantpur', (select stateid from States where RegionName='Andhra Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Adilabad', (select stateid from States where RegionName='Andhra Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Chittor', (select stateid from States where RegionName='Andhra Pradesh'))				
Insert into Districts(DistrictName,StateId) values('east Godavari', (select stateid from States where RegionName='Andhra Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Guntur', (select stateid from States where RegionName='Andhra Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Hyderabad Urban', (select stateid from States where RegionName='Andhra Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Khammam', (select stateid from States where RegionName='Andhra Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Krishna', (select stateid from States where RegionName='Andhra Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Mehboobnagar', (select stateid from States where RegionName='Andhra Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Medak', (select stateid from States where RegionName='Andhra Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Nalgonda', (select stateid from States where RegionName='Andhra Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Nizamabad', (select stateid from States where RegionName='Andhra Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Prakasam', (select stateid from States where RegionName='Andhra Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Ranga Reddy', (select stateid from States where RegionName='Andhra Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Vishakapatnam', (select stateid from States where RegionName='Andhra Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Vizianagaram', (select stateid from States where RegionName='Andhra Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Warangal', (select stateid from States where RegionName='Andhra Pradesh'))				
				
				
Insert into Districts(DistrictName,StateId) values('Karimganj', (select stateid from States where RegionName='Assam'))				
Insert into Districts(DistrictName,StateId) values('Darrang', (select stateid from States where RegionName='Assam'))				
Insert into Districts(DistrictName,StateId) values('Dibrugarh', (select stateid from States where RegionName='Assam'))				
Insert into Districts(DistrictName,StateId) values('Morigaon', (select stateid from States where RegionName='Assam'))				
Insert into Districts(DistrictName,StateId) values('Tinsukia', (select stateid from States where RegionName='Assam'))				
Insert into Districts(DistrictName,StateId) values('Bongaigaon', (select stateid from States where RegionName='Assam'))				
Insert into Districts(DistrictName,StateId) values('Nalbari', (select stateid from States where RegionName='Assam'))				
Insert into Districts(DistrictName,StateId) values('Kokrajhar', (select stateid from States where RegionName='Assam'))				
Insert into Districts(DistrictName,StateId) values('Kamrup', (select stateid from States where RegionName='Assam'))				
Insert into Districts(DistrictName,StateId) values('Karbi-Anglong', (select stateid from States where RegionName='Assam'))				
Insert into Districts(DistrictName,StateId) values('Nagaon', (select stateid from States where RegionName='Assam'))				
Insert into Districts(DistrictName,StateId) values('N.C.Hills', (select stateid from States where RegionName='Assam'))				
Insert into Districts(DistrictName,StateId) values('Dhemaji', (select stateid from States where RegionName='Assam'))				
Insert into Districts(DistrictName,StateId) values('Hailakandi', (select stateid from States where RegionName='Assam'))				
Insert into Districts(DistrictName,StateId) values('Lakhimpur', (select stateid from States where RegionName='Assam'))				
Insert into Districts(DistrictName,StateId) values('Sonitpur', (select stateid from States where RegionName='Assam'))				
Insert into Districts(DistrictName,StateId) values('Dhubri', (select stateid from States where RegionName='Assam'))				
Insert into Districts(DistrictName,StateId) values('Goalpara', (select stateid from States where RegionName='Assam'))				
Insert into Districts(DistrictName,StateId) values('Barpeta', (select stateid from States where RegionName='Assam'))				
Insert into Districts(DistrictName,StateId) values('Golaghat', (select stateid from States where RegionName='Assam'))				
Insert into Districts(DistrictName,StateId) values('Jorhat', (select stateid from States where RegionName='Assam'))				
Insert into Districts(DistrictName,StateId) values('Sibsagar', (select stateid from States where RegionName='Assam'))				
Insert into Districts(DistrictName,StateId) values('Cachar', (select stateid from States where RegionName='Assam'))				
				
				
Insert into Districts(DistrictName,StateId) values('Diban Valley( Anini Valley)', (select stateid from States where RegionName='Arunachal Pradesh'))				
Insert into Districts(DistrictName,StateId) values('East Kameng Seppa', (select stateid from States where RegionName='Arunachal Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Itanagar', (select stateid from States where RegionName='Arunachal Pradesh'))				
Insert into Districts(DistrictName,StateId) values('East Siang(Passighat)', (select stateid from States where RegionName='Arunachal Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Lohit(Tezu)', (select stateid from States where RegionName='Arunachal Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Lower Subansiri(Ziro)', (select stateid from States where RegionName='Arunachal Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Khonsa', (select stateid from States where RegionName='Arunachal Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Roin', (select stateid from States where RegionName='Arunachal Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Tawang', (select stateid from States where RegionName='Arunachal Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Changalang', (select stateid from States where RegionName='Arunachal Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Dibang Valley', (select stateid from States where RegionName='Arunachal Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Daporijo', (select stateid from States where RegionName='Arunachal Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Bomdila', (select stateid from States where RegionName='Arunachal Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Alog( West Siang )', (select stateid from States where RegionName='Arunachal Pradesh'))				
				
				
Insert into Districts(DistrictName,StateId) values('Muzaffarpur', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Jehanabad', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Gaya', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Patna', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Saran( Chapra )', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Darbhanga', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Saharsa', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Purnea', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Bhagalpur', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Munger', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Aurangabad', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Bhojpur(Arah)', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Begusarai', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('East Champaran', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Gopalganj', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Jamui', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Katihar', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Khagaria', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Madhepura', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Madhubani', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Nalanda', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Nawada', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Rohtas(Sasaram)', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Samastipur', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Sitamarhi', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Siwan', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Vaishali(Hajipur)', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('West Champaran', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Kishanganj', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Araria', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Bhabua', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Banka', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Buxar', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Supaul', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Sekhpura', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Seohar', (select stateid from States where RegionName='Bihar'))				
Insert into Districts(DistrictName,StateId) values('Lakhisarai', (select stateid from States where RegionName='Bihar'))				
				
				
Insert into Districts(DistrictName,StateId) values('Panchmahals', (select stateid from States where RegionName='Gujarat'))				
Insert into Districts(DistrictName,StateId) values('Vadodara', (select stateid from States where RegionName='Gujarat'))				
Insert into Districts(DistrictName,StateId) values('Amrela', (select stateid from States where RegionName='Gujarat'))				
Insert into Districts(DistrictName,StateId) values('Kheda', (select stateid from States where RegionName='Gujarat'))				
Insert into Districts(DistrictName,StateId) values('Ahmedabad', (select stateid from States where RegionName='Gujarat'))				
Insert into Districts(DistrictName,StateId) values('Valsad', (select stateid from States where RegionName='Gujarat'))				
Insert into Districts(DistrictName,StateId) values('Junagadh', (select stateid from States where RegionName='Gujarat'))				
Insert into Districts(DistrictName,StateId) values('Mehsana', (select stateid from States where RegionName='Gujarat'))				
Insert into Districts(DistrictName,StateId) values('Banaskantha', (select stateid from States where RegionName='Gujarat'))				
Insert into Districts(DistrictName,StateId) values('Gandhinagar', (select stateid from States where RegionName='Gujarat'))				
Insert into Districts(DistrictName,StateId) values('Bharuch', (select stateid from States where RegionName='Gujarat'))				
Insert into Districts(DistrictName,StateId) values('Dangs', (select stateid from States where RegionName='Gujarat'))				
Insert into Districts(DistrictName,StateId) values('Jamnagar', (select stateid from States where RegionName='Gujarat'))				
Insert into Districts(DistrictName,StateId) values('Rajkot', (select stateid from States where RegionName='Gujarat'))				
Insert into Districts(DistrictName,StateId) values('Surat', (select stateid from States where RegionName='Gujarat'))				
Insert into Districts(DistrictName,StateId) values('Sabarkantha', (select stateid from States where RegionName='Gujarat'))				
Insert into Districts(DistrictName,StateId) values('Kutch', (select stateid from States where RegionName='Gujarat'))				
Insert into Districts(DistrictName,StateId) values('Bhavnagar', (select stateid from States where RegionName='Gujarat'))				
Insert into Districts(DistrictName,StateId) values('Surendranagar', (select stateid from States where RegionName='Gujarat'))				
Insert into Districts(DistrictName,StateId) values('Navsari', (select stateid from States where RegionName='Gujarat'))				
Insert into Districts(DistrictName,StateId) values('Anand', (select stateid from States where RegionName='Gujarat'))				
Insert into Districts(DistrictName,StateId) values('Narmada', (select stateid from States where RegionName='Gujarat'))				
Insert into Districts(DistrictName,StateId) values('Patan', (select stateid from States where RegionName='Gujarat'))				
Insert into Districts(DistrictName,StateId) values('Porbander', (select stateid from States where RegionName='Gujarat'))				
Insert into Districts(DistrictName,StateId) values('Dahod', (select stateid from States where RegionName='Gujarat'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('Gurgaon', (select stateid from States where RegionName='Haryana'))				
Insert into Districts(DistrictName,StateId) values('Rohtak', (select stateid from States where RegionName='Haryana'))				
Insert into Districts(DistrictName,StateId) values('Ambala', (select stateid from States where RegionName='Haryana'))				
Insert into Districts(DistrictName,StateId) values('Bhiwani', (select stateid from States where RegionName='Haryana'))				
Insert into Districts(DistrictName,StateId) values('Faridabad', (select stateid from States where RegionName='Haryana'))				
Insert into Districts(DistrictName,StateId) values('Hissar', (select stateid from States where RegionName='Haryana'))				
Insert into Districts(DistrictName,StateId) values('Jind', (select stateid from States where RegionName='Haryana'))				
Insert into Districts(DistrictName,StateId) values('Kaithal', (select stateid from States where RegionName='Haryana'))				
Insert into Districts(DistrictName,StateId) values('Karnal', (select stateid from States where RegionName='Haryana'))				
Insert into Districts(DistrictName,StateId) values('Kurukshetra', (select stateid from States where RegionName='Haryana'))				
Insert into Districts(DistrictName,StateId) values('Mahendragarh', (select stateid from States where RegionName='Haryana'))				
Insert into Districts(DistrictName,StateId) values('Panchkula', (select stateid from States where RegionName='Haryana'))				
Insert into Districts(DistrictName,StateId) values('Panipat', (select stateid from States where RegionName='Haryana'))				
Insert into Districts(DistrictName,StateId) values('Sonipat', (select stateid from States where RegionName='Haryana'))				
Insert into Districts(DistrictName,StateId) values('Yamunanagar', (select stateid from States where RegionName='Haryana'))				
Insert into Districts(DistrictName,StateId) values('Sirsa', (select stateid from States where RegionName='Haryana'))				
Insert into Districts(DistrictName,StateId) values('Rewari', (select stateid from States where RegionName='Haryana'))				
Insert into Districts(DistrictName,StateId) values('Jhanjhar', (select stateid from States where RegionName='Haryana'))				
Insert into Districts(DistrictName,StateId) values('Fatehabad', (select stateid from States where RegionName='Haryana'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('Sirmour', (select stateid from States where RegionName='Himachal Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Hamirpur', (select stateid from States where RegionName='Himachal Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Kullu', (select stateid from States where RegionName='Himachal Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Solan', (select stateid from States where RegionName='Himachal Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Mandi', (select stateid from States where RegionName='Himachal Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Chamba', (select stateid from States where RegionName='Himachal Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Bilaspur', (select stateid from States where RegionName='Himachal Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Kangra', (select stateid from States where RegionName='Himachal Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Kinnaur', (select stateid from States where RegionName='Himachal Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Lahaul-Spiti', (select stateid from States where RegionName='Himachal Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Shimla', (select stateid from States where RegionName='Himachal Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Una', (select stateid from States where RegionName='Himachal Pradesh'))				
				
				
Insert into Districts(DistrictName,StateId) values('Kathua', (select stateid from States where RegionName='Jammu and Kashmir'))				
Insert into Districts(DistrictName,StateId) values('Badgan', (select stateid from States where RegionName='Jammu and Kashmir'))				
Insert into Districts(DistrictName,StateId) values('Poonch', (select stateid from States where RegionName='Jammu and Kashmir'))				
Insert into Districts(DistrictName,StateId) values('Rajauri', (select stateid from States where RegionName='Jammu and Kashmir'))				
Insert into Districts(DistrictName,StateId) values('Baramula', (select stateid from States where RegionName='Jammu and Kashmir'))				
Insert into Districts(DistrictName,StateId) values('Doda', (select stateid from States where RegionName='Jammu and Kashmir'))				
Insert into Districts(DistrictName,StateId) values('Udhampur', (select stateid from States where RegionName='Jammu and Kashmir'))				
Insert into Districts(DistrictName,StateId) values('Jammu', (select stateid from States where RegionName='Jammu and Kashmir'))				
Insert into Districts(DistrictName,StateId) values('Kupwara', (select stateid from States where RegionName='Jammu and Kashmir'))				
Insert into Districts(DistrictName,StateId) values('Pulwama', (select stateid from States where RegionName='Jammu and Kashmir'))				
Insert into Districts(DistrictName,StateId) values('Anantnag', (select stateid from States where RegionName='Jammu and Kashmir'))				
Insert into Districts(DistrictName,StateId) values('Srinagar', (select stateid from States where RegionName='Jammu and Kashmir'))				
Insert into Districts(DistrictName,StateId) values('Leh', (select stateid from States where RegionName='Jammu and Kashmir'))				
Insert into Districts(DistrictName,StateId) values('Kargil', (select stateid from States where RegionName='Jammu and Kashmir'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('Mysore', (select stateid from States where RegionName='Karnataka'))				
Insert into Districts(DistrictName,StateId) values('Gulberga', (select stateid from States where RegionName='Karnataka'))				
Insert into Districts(DistrictName,StateId) values('Chitradurga', (select stateid from States where RegionName='Karnataka'))				
Insert into Districts(DistrictName,StateId) values('Kolar', (select stateid from States where RegionName='Karnataka'))				
Insert into Districts(DistrictName,StateId) values('Bijapur', (select stateid from States where RegionName='Karnataka'))				
Insert into Districts(DistrictName,StateId) values('Dakshina Kannada', (select stateid from States where RegionName='Karnataka'))				
Insert into Districts(DistrictName,StateId) values('Raichur', (select stateid from States where RegionName='Karnataka'))				
Insert into Districts(DistrictName,StateId) values('Bellary', (select stateid from States where RegionName='Karnataka'))				
Insert into Districts(DistrictName,StateId) values('Belgaum', (select stateid from States where RegionName='Karnataka'))				
Insert into Districts(DistrictName,StateId) values('Hassan', (select stateid from States where RegionName='Karnataka'))				
Insert into Districts(DistrictName,StateId) values('Dharwad', (select stateid from States where RegionName='Karnataka'))				
Insert into Districts(DistrictName,StateId) values('Bangalore Rural', (select stateid from States where RegionName='Karnataka'))				
Insert into Districts(DistrictName,StateId) values('Shimoga', (select stateid from States where RegionName='Karnataka'))				
Insert into Districts(DistrictName,StateId) values('Mandya', (select stateid from States where RegionName='Karnataka'))				
Insert into Districts(DistrictName,StateId) values('Chickmagalur', (select stateid from States where RegionName='Karnataka'))				
Insert into Districts(DistrictName,StateId) values('Bangalore Urban', (select stateid from States where RegionName='Karnataka'))				
Insert into Districts(DistrictName,StateId) values('Madikeri', (select stateid from States where RegionName='Karnataka'))				
Insert into Districts(DistrictName,StateId) values('Tumkur', (select stateid from States where RegionName='Karnataka'))				
Insert into Districts(DistrictName,StateId) values('Bidar', (select stateid from States where RegionName='Karnataka'))				
Insert into Districts(DistrictName,StateId) values('Karwar', (select stateid from States where RegionName='Karnataka'))				
Insert into Districts(DistrictName,StateId) values('Udupi', (select stateid from States where RegionName='Karnataka'))				
Insert into Districts(DistrictName,StateId) values('Davanagare', (select stateid from States where RegionName='Karnataka'))				
Insert into Districts(DistrictName,StateId) values('Chamrajnagar', (select stateid from States where RegionName='Karnataka'))				
Insert into Districts(DistrictName,StateId) values('Koppal', (select stateid from States where RegionName='Karnataka'))				
Insert into Districts(DistrictName,StateId) values('Haveri', (select stateid from States where RegionName='Karnataka'))				
Insert into Districts(DistrictName,StateId) values('Gadak', (select stateid from States where RegionName='Karnataka'))				
Insert into Districts(DistrictName,StateId) values('Yadgir', (select stateid from States where RegionName='Karnataka'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('Kozhikode', (select stateid from States where RegionName='Kerala'))				
Insert into Districts(DistrictName,StateId) values('Kasaragod', (select stateid from States where RegionName='Kerala'))				
Insert into Districts(DistrictName,StateId) values('Idukki', (select stateid from States where RegionName='Kerala'))				
Insert into Districts(DistrictName,StateId) values('Ernakulam', (select stateid from States where RegionName='Kerala'))				
Insert into Districts(DistrictName,StateId) values('Cannanore', (select stateid from States where RegionName='Kerala'))				
Insert into Districts(DistrictName,StateId) values('Mallapuram', (select stateid from States where RegionName='Kerala'))				
Insert into Districts(DistrictName,StateId) values('Palghat', (select stateid from States where RegionName='Kerala'))				
Insert into Districts(DistrictName,StateId) values('Pathanamthitta', (select stateid from States where RegionName='Kerala'))				
Insert into Districts(DistrictName,StateId) values('Quilon', (select stateid from States where RegionName='Kerala'))				
Insert into Districts(DistrictName,StateId) values('Trichur', (select stateid from States where RegionName='Kerala'))				
Insert into Districts(DistrictName,StateId) values('Wayanad', (select stateid from States where RegionName='Kerala'))				
Insert into Districts(DistrictName,StateId) values('Trivandrum', (select stateid from States where RegionName='Kerala'))				
Insert into Districts(DistrictName,StateId) values('Kottayam', (select stateid from States where RegionName='Kerala'))				
Insert into Districts(DistrictName,StateId) values('Alapuzzha', (select stateid from States where RegionName='Kerala'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('Sindi', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Vidisha', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Jabalpur', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Bhopal', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Hoshangabad', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Indore', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Rewa', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Satna', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Shahdol', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Chhindwara', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Ratlam', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Balaghat', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Betul', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Bhind', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Mandla', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Chhattarpur', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Damoh', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Datia', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Dewas', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Dhar', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Guna', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Gwalior', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Jhabua', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Sehore', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Mandsaur', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Narsinghpur', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Panna', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Raisen', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Rajgarh', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Sagar', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Seoni', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Morena', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Shivpuri', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Shajapur', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Tikamgarh', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Ujjain', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Khandwa', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Khargone', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Dindori', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Umaria', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Badwani', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Sheopur', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Katni', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Neemuch', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Harda', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Anooppur', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Burhanpur', (select stateid from States where RegionName='Madhya Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Ashoknagar', (select stateid from States where RegionName='Madhya Pradesh'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('Aurangabad', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Bandra(Mumbai Suburban district)', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Nagpur', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Pune', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Akola', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Chandrapur', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Jalgaon', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Parbhani', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Sholapur', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Thane', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Latur', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Mumbai-City', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Buldhana', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Dhule', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Kolhpur', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Nanded', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Raigad', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Amravati', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Nashik', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Wardha', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Ahmednagar', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Beed', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Bhandara', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Gadchiroli', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Jalna', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Osmanabad', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Ratnagiri', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Sangli', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Satara', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Sindudurg', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Yavatmal', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Nandurbar', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Washim', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Gondia', (select stateid from States where RegionName='Maharashtra'))				
Insert into Districts(DistrictName,StateId) values('Hingoli', (select stateid from States where RegionName='Maharashtra'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('Imphal East', (select stateid from States where RegionName='Manipur'))				
Insert into Districts(DistrictName,StateId) values('Imphal West', (select stateid from States where RegionName='Manipur'))				
Insert into Districts(DistrictName,StateId) values('Thoubal', (select stateid from States where RegionName='Manipur'))				
Insert into Districts(DistrictName,StateId) values('Bishnupur', (select stateid from States where RegionName='Manipur'))				
Insert into Districts(DistrictName,StateId) values('Chandel', (select stateid from States where RegionName='Manipur'))				
Insert into Districts(DistrictName,StateId) values('Churachandpur', (select stateid from States where RegionName='Manipur'))				
Insert into Districts(DistrictName,StateId) values('Senapati', (select stateid from States where RegionName='Manipur'))				
Insert into Districts(DistrictName,StateId) values('Ukhrul', (select stateid from States where RegionName='Manipur'))				
Insert into Districts(DistrictName,StateId) values('Tamenglong', (select stateid from States where RegionName='Manipur'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('Ri-Bhoi District', (select stateid from States where RegionName='Meghalaya'))				
Insert into Districts(DistrictName,StateId) values('South Garo Hills', (select stateid from States where RegionName='Meghalaya'))				
Insert into Districts(DistrictName,StateId) values('East Khasi Hill', (select stateid from States where RegionName='Meghalaya'))				
Insert into Districts(DistrictName,StateId) values('East Garo Hill', (select stateid from States where RegionName='Meghalaya'))				
Insert into Districts(DistrictName,StateId) values('West Garo Hill', (select stateid from States where RegionName='Meghalaya'))				
Insert into Districts(DistrictName,StateId) values('Jaintia Hill', (select stateid from States where RegionName='Meghalaya'))				
Insert into Districts(DistrictName,StateId) values('West Khasi Hill', (select stateid from States where RegionName='Meghalaya'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('Luglei District', (select stateid from States where RegionName='Mizoram'))				
Insert into Districts(DistrictName,StateId) values('Chimtipui District', (select stateid from States where RegionName='Mizoram'))				
Insert into Districts(DistrictName,StateId) values('Aizawal', (select stateid from States where RegionName='Mizoram'))				
Insert into Districts(DistrictName,StateId) values('Champhai', (select stateid from States where RegionName='Mizoram'))				
Insert into Districts(DistrictName,StateId) values('Mamit', (select stateid from States where RegionName='Mizoram'))				
Insert into Districts(DistrictName,StateId) values('Kolasib', (select stateid from States where RegionName='Mizoram'))				
Insert into Districts(DistrictName,StateId) values('Serchhip', (select stateid from States where RegionName='Mizoram'))				
Insert into Districts(DistrictName,StateId) values('Lawngtlai', (select stateid from States where RegionName='Mizoram'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('Wokha', (select stateid from States where RegionName='Nagaland'))				
Insert into Districts(DistrictName,StateId) values('Phek', (select stateid from States where RegionName='Nagaland'))				
Insert into Districts(DistrictName,StateId) values('Tuensang', (select stateid from States where RegionName='Nagaland'))				
Insert into Districts(DistrictName,StateId) values('Mon', (select stateid from States where RegionName='Nagaland'))				
Insert into Districts(DistrictName,StateId) values('Kohima', (select stateid from States where RegionName='Nagaland'))				
Insert into Districts(DistrictName,StateId) values('Zunheboto', (select stateid from States where RegionName='Nagaland'))				
Insert into Districts(DistrictName,StateId) values('Mokokchung', (select stateid from States where RegionName='Nagaland'))				
Insert into Districts(DistrictName,StateId) values('Dimapur', (select stateid from States where RegionName='Nagaland'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('Khurda', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Navaragpur', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Navapada', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Gajapati', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Boudh', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Bhadrak', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Ganjam', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Dhenkanal', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Angul', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Puri', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Cuttak', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Sambalpur', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Kalhandi', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Koraput', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Phulbani', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Balangir', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Bargah', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Deogarh', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Jagatsinghpur', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Jajpur', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Jharsuguda', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Kendrapara', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Malkangiri', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Nayagarh', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Rayagada', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Sonepur', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Balasore', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Mayurbhanj', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Keonjhar', (select stateid from States where RegionName='Orissa'))				
Insert into Districts(DistrictName,StateId) values('Sundergarh', (select stateid from States where RegionName='Orissa'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('Sangrur', (select stateid from States where RegionName='Punjab'))				
Insert into Districts(DistrictName,StateId) values('Jalandhar', (select stateid from States where RegionName='Punjab'))				
Insert into Districts(DistrictName,StateId) values('Ludhiana', (select stateid from States where RegionName='Punjab'))				
Insert into Districts(DistrictName,StateId) values('Bhatinda', (select stateid from States where RegionName='Punjab'))				
Insert into Districts(DistrictName,StateId) values('Kapurthala', (select stateid from States where RegionName='Punjab'))				
Insert into Districts(DistrictName,StateId) values('Patiala', (select stateid from States where RegionName='Punjab'))				
Insert into Districts(DistrictName,StateId) values('Amritsar', (select stateid from States where RegionName='Punjab'))				
Insert into Districts(DistrictName,StateId) values('Ferozepur', (select stateid from States where RegionName='Punjab'))				
Insert into Districts(DistrictName,StateId) values('Fatehgarh Saheb', (select stateid from States where RegionName='Punjab'))				
Insert into Districts(DistrictName,StateId) values('Ropar', (select stateid from States where RegionName='Punjab'))				
Insert into Districts(DistrictName,StateId) values('Gurdaspur', (select stateid from States where RegionName='Punjab'))				
Insert into Districts(DistrictName,StateId) values('Hosiarpur', (select stateid from States where RegionName='Punjab'))				
Insert into Districts(DistrictName,StateId) values('Faridkot', (select stateid from States where RegionName='Punjab'))				
Insert into Districts(DistrictName,StateId) values('Mansa', (select stateid from States where RegionName='Punjab'))				
Insert into Districts(DistrictName,StateId) values('Moga', (select stateid from States where RegionName='Punjab'))				
Insert into Districts(DistrictName,StateId) values('Muktsar', (select stateid from States where RegionName='Punjab'))				
Insert into Districts(DistrictName,StateId) values('Navansahar', (select stateid from States where RegionName='Punjab'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('Jaipur', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Barmer', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Dungarpur', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Jodhpur', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Kota', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Udaipur', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Bikaner', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Dausa', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Bundi', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Sikar', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Tonk', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Jaisalmer', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Nagaur', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Rajsamand', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Banswara', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Bhilwara', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Ajmer', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Alwar', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Bharatpur', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Chittorgarh', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Churu', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Dholpur', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Ganganagar', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Jalor', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Jhalawar', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Jhunjhunu', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Pali', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Sawai Madhopur', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Sirohi', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Baran', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Hanumangarh', (select stateid from States where RegionName='Rajasthan'))				
Insert into Districts(DistrictName,StateId) values('Karauli', (select stateid from States where RegionName='Rajasthan'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('East', (select stateid from States where RegionName='Sikkim'))				
Insert into Districts(DistrictName,StateId) values('South', (select stateid from States where RegionName='Sikkim'))				
Insert into Districts(DistrictName,StateId) values('West', (select stateid from States where RegionName='Sikkim'))				
Insert into Districts(DistrictName,StateId) values('North', (select stateid from States where RegionName='Sikkim'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('Chennai', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Coimbotore', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Cuddalorei', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Dharmapuri', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Dindigul', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Erode', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Kancheepuram', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Kanniyakumari (HQ : Nagercoil)', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Karur', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Madurai', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Nagapattinam', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Namakkal', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Nilgiris (HQ: Udhagamandalam)', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Perambalur', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Pudukkottai', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Ramanathapuram', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Salem', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Sivaganga', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Thanjavur', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Theni', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Thoothkudi', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Tiruchiorappalli', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Tirunelveli', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Tiruvallur', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Tiruvannamalai', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Tiruvarur', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Vellore', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Villupuram', (select stateid from States where RegionName='Tamil Nadu'))				
Insert into Districts(DistrictName,StateId) values('Virudhunagar', (select stateid from States where RegionName='Tamil Nadu'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('North District', (select stateid from States where RegionName='Tripura'))				
Insert into Districts(DistrictName,StateId) values('South District', (select stateid from States where RegionName='Tripura'))				
Insert into Districts(DistrictName,StateId) values('West District', (select stateid from States where RegionName='Tripura'))				
Insert into Districts(DistrictName,StateId) values('Dhalai District', (select stateid from States where RegionName='Tripura'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('Allahabad', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Aligarh', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Bareilly', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Gonda', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Hardoi', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Kanpur Dehat', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Ghaziabad', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Unnav', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Varanasi', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Faizabad', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Gorakpur', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Jhansi', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Lucknow', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Agra', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Meerut', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Moradabad', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Barabanki', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Mainpuri', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Etawah', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Gazipur', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Etah', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Muzaffar Nagar', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Saharanpur', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Bulandshehar', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Mathura', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Firozabad', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Budaun', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Shahjahanpur', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Pilibhit', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Bijnor', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Rampur', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Kanpur(Nagar)', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Farrukhabad', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Fatehpur', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Pratapgarh', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Jalaun', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Hamirpur', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Lalitpur', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Mirzapur', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Basti', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Deoria', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Raebareili', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Sitapur', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Banda', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Lakhimpur-Khedi', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Bahraich', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Sultanpur', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Mau', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Azamgarh', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Jaunpur', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Balia', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Bhadoi', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Padrauna', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Maharajganj', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Siddharth Nagar', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Sunbhadra', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Mahoba', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Ambedkarnagar', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Gautam Bodda Nagar', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Maha Maya Nagar', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('jyotiba Phoole Nagar', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Kaushambi', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Shooji Maharaj', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Chandauli', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Balrampur', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Shravati', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Bagpat', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Kanooj', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Oraiyya', (select stateid from States where RegionName='Uttar Pradesh'))				
Insert into Districts(DistrictName,StateId) values('Sant Kabir Nagar', (select stateid from States where RegionName='Uttar Pradesh'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('Howrah', (select stateid from States where RegionName='West Bengal'))				
Insert into Districts(DistrictName,StateId) values('Darjeeling', (select stateid from States where RegionName='West Bengal'))				
Insert into Districts(DistrictName,StateId) values('Medinipur', (select stateid from States where RegionName='West Bengal'))				
Insert into Districts(DistrictName,StateId) values('Murshidabad', (select stateid from States where RegionName='West Bengal'))				
Insert into Districts(DistrictName,StateId) values('Coochbehar', (select stateid from States where RegionName='West Bengal'))				
Insert into Districts(DistrictName,StateId) values('Malda', (select stateid from States where RegionName='West Bengal'))				
Insert into Districts(DistrictName,StateId) values('Birbhum', (select stateid from States where RegionName='West Bengal'))				
Insert into Districts(DistrictName,StateId) values('North 24 Parganas', (select stateid from States where RegionName='West Bengal'))				
Insert into Districts(DistrictName,StateId) values('South 24 Parganas', (select stateid from States where RegionName='West Bengal'))				
Insert into Districts(DistrictName,StateId) values('Bankura', (select stateid from States where RegionName='West Bengal'))				
Insert into Districts(DistrictName,StateId) values('Bardhaman', (select stateid from States where RegionName='West Bengal'))				
Insert into Districts(DistrictName,StateId) values('Jalpaiguri', (select stateid from States where RegionName='West Bengal'))				
Insert into Districts(DistrictName,StateId) values('Hooghly', (select stateid from States where RegionName='West Bengal'))				
Insert into Districts(DistrictName,StateId) values('Nadia', (select stateid from States where RegionName='West Bengal'))				
Insert into Districts(DistrictName,StateId) values('Dakshin Dinajpur', (select stateid from States where RegionName='West Bengal'))				
Insert into Districts(DistrictName,StateId) values('Purulia', (select stateid from States where RegionName='West Bengal'))				
Insert into Districts(DistrictName,StateId) values('Uttar Dinajpur', (select stateid from States where RegionName='West Bengal'))				
Insert into Districts(DistrictName,StateId) values('Siliguri', (select stateid from States where RegionName='West Bengal'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('Central Delhi', (select stateid from States where RegionName='Delhi'))				
Insert into Districts(DistrictName,StateId) values('North Delhi', (select stateid from States where RegionName='Delhi'))				
Insert into Districts(DistrictName,StateId) values('South Delhi', (select stateid from States where RegionName='Delhi'))				
Insert into Districts(DistrictName,StateId) values('East Delhi', (select stateid from States where RegionName='Delhi'))				
Insert into Districts(DistrictName,StateId) values('North East Delhi', (select stateid from States where RegionName='Delhi'))				
Insert into Districts(DistrictName,StateId) values('South West Delhi', (select stateid from States where RegionName='Delhi'))				
Insert into Districts(DistrictName,StateId) values('New Delhi', (select stateid from States where RegionName='Delhi'))				
Insert into Districts(DistrictName,StateId) values('North West Delhi', (select stateid from States where RegionName='Delhi'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('North Goa', (select stateid from States where RegionName='Goa'))				
Insert into Districts(DistrictName,StateId) values('South Goa', (select stateid from States where RegionName='Goa'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('Karikal', (select stateid from States where RegionName='Pondicherry'))				
Insert into Districts(DistrictName,StateId) values('Mahe', (select stateid from States where RegionName='Pondicherry'))				
Insert into Districts(DistrictName,StateId) values('Yaman', (select stateid from States where RegionName='Pondicherry'))				
Insert into Districts(DistrictName,StateId) values('Pondicherry', (select stateid from States where RegionName='Pondicherry'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('Lakshdweep', (select stateid from States where RegionName='Lakshadweep'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('Dama', (select stateid from States where RegionName='Daman and Diu'))				
Insert into Districts(DistrictName,StateId) values('Diu', (select stateid from States where RegionName='Daman and Diu'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('Dadra', (select stateid from States where RegionName='Dadra and Nagar Haveli'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('Chandigarh', (select stateid from States where RegionName='Chandigarh'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('Andaman', (select stateid from States where RegionName='Andaman and Nicobar'))				
Insert into Districts(DistrictName,StateId) values('Nicobar', (select stateid from States where RegionName='Andaman and Nicobar'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('Nainital', (select stateid from States where RegionName='Uttarakhand'))				
Insert into Districts(DistrictName,StateId) values('Almora', (select stateid from States where RegionName='Uttarakhand'))				
Insert into Districts(DistrictName,StateId) values('Pitoragarh', (select stateid from States where RegionName='Uttarakhand'))				
Insert into Districts(DistrictName,StateId) values('Udhamsingh Nagar', (select stateid from States where RegionName='Uttarakhand'))				
Insert into Districts(DistrictName,StateId) values('Bageshwar', (select stateid from States where RegionName='Uttarakhand'))				
Insert into Districts(DistrictName,StateId) values('Champawat', (select stateid from States where RegionName='Uttarakhand'))				
Insert into Districts(DistrictName,StateId) values('Garhwal(Pauri)', (select stateid from States where RegionName='Uttarakhand'))				
Insert into Districts(DistrictName,StateId) values('Tehri-Garhwal', (select stateid from States where RegionName='Uttarakhand'))				
Insert into Districts(DistrictName,StateId) values('Chamoli( Gopeshwar )', (select stateid from States where RegionName='Uttarakhand'))				
Insert into Districts(DistrictName,StateId) values('Uttarkashi', (select stateid from States where RegionName='Uttarakhand'))				
Insert into Districts(DistrictName,StateId) values('Dehradun', (select stateid from States where RegionName='Uttarakhand'))				
Insert into Districts(DistrictName,StateId) values('Rudraprayag', (select stateid from States where RegionName='Uttarakhand'))				
Insert into Districts(DistrictName,StateId) values('Haridwar', (select stateid from States where RegionName='Uttarakhand'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('Deoghar', (select stateid from States where RegionName='Jharkhand'))				
Insert into Districts(DistrictName,StateId) values('Dhanbad', (select stateid from States where RegionName='Jharkhand'))				
Insert into Districts(DistrictName,StateId) values('Giridih', (select stateid from States where RegionName='Jharkhand'))				
Insert into Districts(DistrictName,StateId) values('Godda', (select stateid from States where RegionName='Jharkhand'))				
Insert into Districts(DistrictName,StateId) values('Gumla', (select stateid from States where RegionName='Jharkhand'))				
Insert into Districts(DistrictName,StateId) values('Hazaribagh', (select stateid from States where RegionName='Jharkhand'))				
Insert into Districts(DistrictName,StateId) values('Lohardaga', (select stateid from States where RegionName='Jharkhand'))				
Insert into Districts(DistrictName,StateId) values('Palamu', (select stateid from States where RegionName='Jharkhand'))				
Insert into Districts(DistrictName,StateId) values('Ranchi', (select stateid from States where RegionName='Jharkhand'))				
Insert into Districts(DistrictName,StateId) values('Dumka', (select stateid from States where RegionName='Jharkhand'))				
Insert into Districts(DistrictName,StateId) values('Chaibasa(West Singhbhum)', (select stateid from States where RegionName='Jharkhand'))				
Insert into Districts(DistrictName,StateId) values('Jamshedpur(East Singhbhum)', (select stateid from States where RegionName='Jharkhand'))				
Insert into Districts(DistrictName,StateId) values('Bokaro', (select stateid from States where RegionName='Jharkhand'))				
Insert into Districts(DistrictName,StateId) values('Chatra', (select stateid from States where RegionName='Jharkhand'))				
Insert into Districts(DistrictName,StateId) values('Garhwa', (select stateid from States where RegionName='Jharkhand'))				
Insert into Districts(DistrictName,StateId) values('Koderma', (select stateid from States where RegionName='Jharkhand'))				
Insert into Districts(DistrictName,StateId) values('Pakur', (select stateid from States where RegionName='Jharkhand'))				
Insert into Districts(DistrictName,StateId) values('Sahebganj', (select stateid from States where RegionName='Jharkhand'))				
Insert into Districts(DistrictName,StateId) values('Simdega', (select stateid from States where RegionName='Jharkhand'))				
Insert into Districts(DistrictName,StateId) values('Latehar', (select stateid from States where RegionName='Jharkhand'))				
Insert into Districts(DistrictName,StateId) values('Saraikela', (select stateid from States where RegionName='Jharkhand'))				
Insert into Districts(DistrictName,StateId) values('Jamtara', (select stateid from States where RegionName='Jharkhand'))				
				
				
				
Insert into Districts(DistrictName,StateId) values('Bastar', (select stateid from States where RegionName='Chhattisgarh'))				
Insert into Districts(DistrictName,StateId) values('Bilaspur', (select stateid from States where RegionName='Chhattisgarh'))				
Insert into Districts(DistrictName,StateId) values('Dantewada', (select stateid from States where RegionName='Chhattisgarh'))				
Insert into Districts(DistrictName,StateId) values('Dhamtari', (select stateid from States where RegionName='Chhattisgarh'))				
Insert into Districts(DistrictName,StateId) values('Durg', (select stateid from States where RegionName='Chhattisgarh'))				
Insert into Districts(DistrictName,StateId) values('Janjgir-Champa', (select stateid from States where RegionName='Chhattisgarh'))				
Insert into Districts(DistrictName,StateId) values('Jashpur', (select stateid from States where RegionName='Chhattisgarh'))				
Insert into Districts(DistrictName,StateId) values('Kanker', (select stateid from States where RegionName='Chhattisgarh'))				
Insert into Districts(DistrictName,StateId) values('Kawardha', (select stateid from States where RegionName='Chhattisgarh'))				
Insert into Districts(DistrictName,StateId) values('Korba', (select stateid from States where RegionName='Chhattisgarh'))				
Insert into Districts(DistrictName,StateId) values('Koriya', (select stateid from States where RegionName='Chhattisgarh'))				
Insert into Districts(DistrictName,StateId) values('Mahasamund', (select stateid from States where RegionName='Chhattisgarh'))				
Insert into Districts(DistrictName,StateId) values('Raigarh', (select stateid from States where RegionName='Chhattisgarh'))				
Insert into Districts(DistrictName,StateId) values('Rajnandgaon', (select stateid from States where RegionName='Chhattisgarh'))				
Insert into Districts(DistrictName,StateId) values('Surguja', (select stateid from States where RegionName='Chhattisgarh'))				
Insert into Districts(DistrictName,StateId) values('Raipur', (select stateid from States where RegionName='Chhattisgarh'))				

go

insert into CityVillages (Name, DistrictId, CityOrVillage,CreatedBy,ModifiedBy)
select DistrictName , districtid, 'City' ,1,1 from Districts

go
-- =============================================
-- Script Template
-- =============================================

/*Script to add SuperAdmin user to the database table Users*/

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy] 
           ,[FailedPasswordAttemptCount]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]           
           ,[ModifiedBy]           
           ,[LastPassword]
           ,[SecondLastPassword]           
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete], FailedPasswordAttemptWindowStart)
     VALUES
           ('SuperAdmin'
		   ,'Mr'
           ,'SuperAdmin'
           ,'SuperAdmin@ackcezione.com'
           ,9999999999
           ,'QWNrU3VwQDEyMw=='
           ,'SuperAdmin'
           ,NULL
           ,'+91'
           ,1           
           ,0           
           ,1
           ,0
           ,0           
           ,1           
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='           
           ,0
           ,0
           ,0, GETDATE())
GO

/*Script to add SuperAdmin Group to the database table UserGroup*/

INSERT INTO [CAMS].[dbo].[UserGroups]
           ([UserGroupName]
           ,[Description]
           ,[CAId]
           ,[IsActive]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('SuperAdmin'
           ,'SuperAdmin Group'
           ,NULL
           ,1
           ,0
           ,0
           ,0
           ,1           
           ,1)
GO

/*Script to add Technical support team Group to the database table UserGroup*/
INSERT INTO [CAMS].[dbo].[UserGroups]
           ([UserGroupName]
           ,[Description]
           ,[CAId]
           ,[IsActive]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('Technical support team'
           ,'Technical support team Group'
           ,NULL
           ,1
           ,0
           ,0
           ,0
           ,1           
           ,1)
GO

/*Script to add Customer care team Group to the database table UserGroup*/
INSERT INTO [CAMS].[dbo].[UserGroups]
           ([UserGroupName]
           ,[Description]
           ,[CAId]
           ,[IsActive]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('Customer care team'
           ,'Customer care team Group'
           ,NULL
           ,1
           ,0
           ,0
           ,0
           ,1           
           ,1)
GO

/*Script to add Account relationship manager Group to the database table UserGroup*/
INSERT INTO [CAMS].[dbo].[UserGroups]
           ([UserGroupName]
           ,[Description]
           ,[CAId]
           ,[IsActive]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('Account relationship manager'
           ,'Account relationship manager Group'
           ,NULL
           ,1
           ,0
           ,0
           ,0
           ,1           
           ,1)
GO

/*Script to assign SuperAdmin user to SuperAdmin Group*/
INSERT INTO [CAMS].[dbo].[UserUserGroups]
           ([UserGroupid]
           ,[Userid])
     VALUES
           (1,1)
GO


/*Script to add Roles to the database table Role*/
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Manage Ack User Groups' ,1,1,1,1,0,'Users & Groups',1)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Manage Client User Group' ,1,1,1,1,0,'Users & Groups',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Manage Ack User Group Role' ,0,1,1,1,0,'Users & Groups',1)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Manage Client User Group Role' ,0,1,1,1,0,'Users & Groups',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Manage Ack Users' ,1,1,1,1,0,'Users & Groups',1)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Manage Client Users' ,1,1,1,1,0,'Users & Groups',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Manage Ack User Role' ,0,1,1,1,0,'Users & Groups',1)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Manage Client User Role' ,0,1,1,1,0,'Users & Groups',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Client Registration' ,1,1,1,1,0,'Users & Groups',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Country' ,0,1,1,0,0,'Masters',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'State' ,1,1,1,1,0,'Masters',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'District' ,1,1,1,1,0,'Masters',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Commodity' ,1,1,1,1,0,'Masters',1)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Account Master' ,1,1,1,1,0,'Masters',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Subscription Renewal' ,0,1,1,1,0,'Business Registrations',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Email Settings' ,1,1,1,1,0,'Business Registrations',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Send Email' ,1,1,1,1,0,'Business Registrations',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'SMS Settings' ,1,1,1,1,0,'Business Registrations',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Send SMS' ,1,1,1,1,0,'Business Registrations',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'User Activity Log' ,0,1,1,1,0,'Business Registrations',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Manage User Group' ,1,1,1,1,0,'Users & Groups',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Manage User Group Role' ,1,1,1,1,0,'Users & Groups',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Manage Users' ,1,1,1,1,0,'Users & Groups',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Manage User Role' ,1,1,1,1,0,'Users & Groups',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Bank & Branch',1,1,1,1,0,'Masters',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Place' ,1,1,1,1,0,'Masters',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Zone' ,1,1,1,1,0,'Masters',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Labour Charge Type' ,1,1,1,1,0,'Masters',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Measuring Unit' ,1,1,1,1,0,'Masters',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Business Registration' ,1,1,1,1,0,'Business Registrations',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Sister Concern' ,1,1,1,1,0,'Business Registrations',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Holiday Calendar' ,1,1,1,1,0,'Masters',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Commodity Registration' ,1,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Weight & Rate Control' ,0,1,1,1,0,'Masters',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Customer Receipt Book' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Business Settings' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Printing settings' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Round off' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Partners' ,1,1,1,1,0,'Business Registrations',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'APMC' ,1,1,1,1,0,'Masters',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Labour Office',1,1,1,1,0,'Masters',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Suppliers' ,1,1,1,1,0,'Masters',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Supplier return commission' ,1,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Supplier Interest Calculator' ,1,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Transporter' ,1,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Transporter return commission' ,1,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Customers' ,1,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Customer Credit limits' ,0,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Customer Return commission' ,1,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Customer Interest Calculator' ,0,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Consultants' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Employees' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Salary Calculator' ,0,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Attendance Register' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Labour' ,1,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Bank Registration' ,1,1,1,1,0,'Masters',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Cheque Book management' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Interest & Charges' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Bank Interest calculator' ,0,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Reconciliation' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Signatories' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Checklists' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Term Loan' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Term Loan Interest calc' ,0,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Vehicle Loan' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Vehicle Loan Interest calculator' ,0,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Fixed Assets' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Depreciation Calculator' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Investments' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Current Assets' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Expenses' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Income' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Transporters memo' ,1,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Backdated transaction' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Sales Transaction Entry' ,1,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Run Time Packaging charges ',0,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Sales Add on expenses' ,1,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Other Charges' ,1,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Run Time change Tare weight' ,1,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Invoicing' ,0,0,1,1,1,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Backdated Printing' ,0,0,0,0,1,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Billing' ,0,0,1,1,1,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Cess Paid Billing' ,0,0,1,1,1,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Financial Transactions' ,1,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Payment to supplier' ,1,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Payment to transporter' ,1,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Bank deposits' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Payments against expenses' ,1,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Other Payment' ,1,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Receipt from customer' ,1,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Cash withdrawal' ,1,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Other receipts' ,1,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Supplier - Supplier Journal Vouchers' ,1,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Customer - Customer Journal Voucher' ,1,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Transporter – Transporter' ,1,1,1,1,0,'Commodity Registration',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Bank Interest' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Cheque Return' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Bank commission & charges' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Depreciation' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Interest payable to partners' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Loss Distributed to partners' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Profit Payable to Partners' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Loss on sale of asset' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Payable provisions' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Profit on sale of asset' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Receivable provisions' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Salary' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Tax Payable Account' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Provision for bad debts' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Other' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Reminders' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Account Merging' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Supplier to supplier' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Customer to customer' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Transporter to transporter' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Bank to bank' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Partner to partner' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Employee to employee' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Year End Activity' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Data backup' ,1,1,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Cash and Bank book' ,0,0,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Cash Book' ,0,0,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Bank Book' ,0,0,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Financial Reports' ,0,0,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Sales reports' ,0,0,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Journal Voucher Register' ,0,0,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Vouchers' ,0,0,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Ledgers' ,0,0,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Statutory Reports' ,0,0,1,1,0,'Business Controls',0)
GO
INSERT INTO [CAMS].[dbo].[Roles]([RoleName],[IsAddApplicable],[IsEditApplicable]
,[IsViewApplicable],[IsDeleteApplicable],[IsPrintApplicable],[RoleGroup],[IsApplicableForAckUsers])
VALUES( 'Asset Register' ,0,0,1,1,0,'Business Controls',0)
GO

/*Script to add RelationShips to the database table RelationShips*/
INSERT INTO [CAMS].[dbo].[RelationShips]
           ([Name]
           ,[CAId]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('Mother'
           ,0
           ,1           
           ,1)
GO

INSERT INTO [CAMS].[dbo].[RelationShips]
           ([Name]
           ,[CAId]
           ,[CreatedBy]           
           ,[ModifiedBy] )
     VALUES
           ('Father'
           ,0
           ,1           
           ,1 )
GO

INSERT INTO [CAMS].[dbo].[RelationShips]
           ([Name]
           ,[CAId]
           ,[CreatedBy]          
           ,[ModifiedBy])
     VALUES
           ('Brother'
           ,0
           ,1           
           ,1)
GO
INSERT INTO [CAMS].[dbo].[RelationShips]
           ([Name]
           ,[CAId]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('Sister'
           ,0
           ,1           
           ,1)
GO
INSERT INTO [CAMS].[dbo].[RelationShips]
           ([Name]
           ,[CAId]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('Son'
           ,0
           ,1           
           ,1)
GO
INSERT INTO [CAMS].[dbo].[RelationShips]
           ([Name]
           ,[CAId]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('Friend'
           ,0
           ,1           
           ,1)
GO
INSERT INTO [CAMS].[dbo].[RelationShips]
           ([Name]
           ,[CAId]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('Daughter'
           ,0
           ,1          
           ,1)
GO

/*Script to add Designation to the database table Designations*/

INSERT INTO [CAMS].[dbo].[Designations]
           ([DesignationName]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('Account Manager'
           ,1           
           ,1 )
GO

INSERT INTO [CAMS].[dbo].[Designations]
           ([DesignationName]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('Administrator'
           ,1           
           ,1 )
GO

INSERT INTO [CAMS].[dbo].[Designations]
           ([DesignationName]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('Customer care staff'
           ,1           
           ,1 )
GO

INSERT INTO [CAMS].[dbo].[Designations]
           ([DesignationName]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('Technical support staff'
           ,1           
           ,1 )
GO

/*Script to add Commodity Class to the database table CommodityClass*/
INSERT INTO [CAMS].[dbo].[CommodityClasses]
           ([Name]
           ,[IsActive])
     VALUES
           ('Vegetables'
           ,1)
GO

INSERT INTO [CAMS].[dbo].[CommodityClasses]
           ([Name]
           ,[IsActive])
     VALUES
           ('Fruits'
           ,1)
GO

INSERT INTO [CAMS].[dbo].[CommodityClasses]
           ([Name]
           ,[IsActive])
     VALUES
           ('Onion, Potato and Garlic'
           ,1)
GO

INSERT INTO [CAMS].[dbo].[CommodityClasses]
           ([Name]
           ,[IsActive])
     VALUES
           ('Grocery (Grains, Cereals, Spices)'
           ,1)
GO

INSERT INTO [CAMS].[dbo].[CommodityClasses]
           ([Name]
           ,[IsActive])
     VALUES
           ('Oil, Seeds & Dry fruits '
           ,1)
GO

INSERT INTO [CAMS].[dbo].[CommodityClasses]
           ([Name]
           ,[IsActive])
     VALUES
           ('Flower'
           ,1)
GO

INSERT INTO [CAMS].[dbo].[CommodityClasses]
           ([Name]
           ,[IsActive])
     VALUES
           ('Fish and Poultry '
           ,0)
GO

INSERT INTO [CAMS].[dbo].[ChargesPayableTo]
           ([PayableTo]
           ,[IsActive])
     VALUES
           ('APMC'
           ,1)
GO

INSERT INTO [CAMS].[dbo].[ChargesPayableTo]
           ([PayableTo]
           ,[IsActive])
     VALUES
           ('Labour Office'
           ,1)
GO


/*Script to add Banks to the database table Banks*/
INSERT INTO [CAMS].[dbo].[Banks]
           ([BankName]
           ,[Alias]
		   ,[URL]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('ICICI Bank'
           ,'ICICI'
		   ,'www.icicibank.com'
           ,1           
           ,1)
GO

INSERT INTO [CAMS].[dbo].[Banks]
           ([BankName]
           ,[Alias]
		   ,[URL]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('State Bank of India'
           ,'SBI'
		   ,'www.statebankofindia.com'
           ,1           
           ,1)
GO

INSERT INTO [CAMS].[dbo].[Banks]
           ([BankName]
           ,[Alias]
		   ,[URL]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('Kotak Mahindra Bank'
           ,'Kotak'
		   ,'www.kotak.com'
           ,1           
           ,1)
GO

INSERT INTO [CAMS].[dbo].[Banks]
           ([BankName]
           ,[Alias]
		   ,[URL]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('IDBI Bank'
           ,'IDBI'
		   ,'www.idbi.com'
           ,1           
           ,1)
GO

INSERT INTO [CAMS].[dbo].[Banks]
           ([BankName]
           ,[Alias]
		   ,[URL]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('Housing Development Finance Corporation Limited'
		   ,'HDFC'
		   ,'www.hdfcbank.com'
           ,1           
           ,1)
GO

INSERT INTO [CAMS].[dbo].[Banks]
           ([BankName]
           ,[Alias]
		   ,[URL]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('Hongkong and Shanghai Banking Corporation'
		   ,'HSBC'
		   ,'www.hsbc.co.in'
           ,1           
           ,1)
GO

INSERT INTO [CAMS].[dbo].[Banks]
           ([BankName]
           ,[Alias]
		   ,[URL]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('Bank of Maharashtra'
		   ,'BOM'
		   ,'www.bankofmaharashtra.in'
           ,1           
           ,1)
GO

INSERT INTO [CAMS].[dbo].[Banks]
           ([BankName]
           ,[Alias]
		   ,[URL]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('Axis Bank'
		   ,'Axis'
		   ,'www.axisbank.co.in'
           ,1           
           ,1)
GO

INSERT INTO [CAMS].[dbo].[Banks]
           ([BankName]
           ,[Alias]
		   ,[URL]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('Dena Bank'
		   ,'Dena'
		   ,'www.denabank.com'
           ,1           
           ,1)
GO

INSERT INTO [CAMS].[dbo].[Banks]
           ([BankName]
           ,[Alias]
		   ,[URL]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('State Bank of Bikaner & Jaipur'
		   ,'SBBJ'
		   ,'www.sbbjbank.com'
           ,1           
           ,1)
GO

/*Script to give full access to SuperAdmin Group */
--delete from UserGroupRolePermissions
INSERT INTO UserGroupRolePermissions (AllowAdd,AllowEdit,AllowView,AllowDelete,AllowPrint,RoleId)
select IsAddApplicable, IsEditApplicable,IsViewApplicable,IsDeleteApplicable,IsPrintApplicable, Roleid 
from Roles 
--delete from UserGroupRoles
INSERT INTO UserGroupRoles(UserGroupId, UserGroupRolePermissionId)
select (select usergroupid from usergroups where UserGroupName='SuperAdmin'), UserGroupRolePermissionId from UserGroupRolePermissions


/* Script to add BusinessConstitutions to the database table BusinessConstitutions  */
INSERT INTO [CAMS].[dbo].[BusinessConstitutions]([BusinessConstitutionName],[IsActive])
VALUES('Sole Proprietor',1)
GO

INSERT INTO [CAMS].[dbo].[BusinessConstitutions]([BusinessConstitutionName],[IsActive])
VALUES('Partnership',1)
GO

INSERT INTO [CAMS].[dbo].[BusinessConstitutions]([BusinessConstitutionName],[IsActive])
VALUES('Limited liability Partnership',0)
GO

INSERT INTO [CAMS].[dbo].[BusinessConstitutions]([BusinessConstitutionName],[IsActive])
VALUES('Public Limited Company',0)
GO

INSERT INTO [CAMS].[dbo].[BusinessConstitutions]([BusinessConstitutionName],[IsActive])
VALUES('Private limited company',0)
GO

/* Script to add SubscriptionMaster to the database table SubscriptionMaster  */
INSERT INTO [CAMS].[dbo].[SubscriptionMaster]
           ([SubscriptionType]
           ,[TotalNoOfUsers]
           ,[NoOfEmployees]
           ,[NoOfAuditors]
           ,[NoOfAssociates]
           ,[SubscriptionFees]
           ,[RenewalFeesPerAnnum]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('Standard'
           ,10
           ,5
           ,2
           ,3
           ,50000
           ,60
           ,1           
           ,1 )
GO

INSERT INTO [CAMS].[dbo].[SubscriptionMaster]
           ([SubscriptionType]
           ,[TotalNoOfUsers]
           ,[NoOfEmployees]
           ,[NoOfAuditors]
           ,[NoOfAssociates]
           ,[SubscriptionFees]
           ,[RenewalFeesPerAnnum]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('Premium'
           ,15
           ,8
           ,2
           ,5
           ,100000
           ,60
           ,1           
           ,1 )
GO

/* Script to add Addresses to the database table Addresses  */
INSERT INTO [CAMS].[dbo].[Addresses]([AddressLine1],[AddressLine2],[PIN],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[CityVillageId])
VALUES  ('Navi Peth,','b1 c wing c8','411040',1,getdate(),1,getdate(),23)
GO

INSERT INTO [CAMS].[dbo].[Addresses]([AddressLine1],[AddressLine2],[PIN],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[CityVillageId])
VALUES  ('Navi Peth1,','b1 c wing c8','411040',1,getdate(),1,getdate(),24)
GO

INSERT INTO [CAMS].[dbo].[Addresses]([AddressLine1],[AddressLine2],[PIN],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[CityVillageId])
VALUES  ('Rajwada','b1 c wing c8','411040',1,getdate(),1,getdate(),25)
GO

INSERT INTO [CAMS].[dbo].[Addresses]([AddressLine1],[AddressLine2],[PIN],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[CityVillageId])
VALUES  ('Lal MAhal','b1 c wing c8','411040',1,getdate(),1,getdate(),23)
GO

INSERT INTO [CAMS].[dbo].[Addresses]([AddressLine1],[AddressLine2],[PIN],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[CityVillageId])
VALUES  ('MG Road','b1 c wing c8','411040',1,getdate(),1,getdate(),78)
GO

INSERT INTO [CAMS].[dbo].[Addresses]([AddressLine1],[AddressLine2],[PIN],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[CityVillageId])
VALUES  ('kothrud','b1 c wing c8','411040',1,getdate(),1,getdate(),45)
GO

INSERT INTO [CAMS].[dbo].[Addresses]([AddressLine1],[AddressLine2],[PIN],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[CityVillageId])
VALUES  ('kondhwa BR','b1 c wing c8','411040',1,getdate(),1,getdate(),44)
GO
/* Script to add APMC to the database table APMC  */
INSERT INTO [CAMS].[dbo].[APMC]([Name],[Email1],[Email2],[Website],[Status],[CreatedBy],[ModifiedBy],[AddressId])
VALUES ('Pune','Puneapmc@gmail.com','Puneapmc@yahoo.com','www.Puneapmc.com','active',1,1,1)
GO

/* Script to add ContactDetails to the database table ContactDetails  */
INSERT INTO [CAMS].[dbo].[ContactDetails]([ContactNo],[ContactNoType],[CountryCallingCode],[STDCode])
VALUES ('2345678','OfficeNo','+91',020)
GO

/* Script to add BankBranchWeeklyHalfDays to the database table BankBranchWeeklyHalfDays  */
INSERT INTO [CAMS].[dbo].[BankBranchWeeklyHalfDays]([IsMonday],[IsTuesday],[IsWednesday],[IsThursday],[IsFriday],[IsSaturday],[IsSunday])
VALUES (0,0,0,0,0,1,0)
GO

INSERT INTO [CAMS].[dbo].[BankBranchWeeklyHalfDays]([IsMonday],[IsTuesday],[IsWednesday],[IsThursday],[IsFriday],[IsSaturday],[IsSunday])
VALUES (0,0,0,0,0,1,0)
GO

INSERT INTO [CAMS].[dbo].[BankBranchWeeklyHalfDays]([IsMonday],[IsTuesday],[IsWednesday],[IsThursday],[IsFriday],[IsSaturday],[IsSunday])
VALUES (0,0,0,0,0,1,0)
GO

INSERT INTO [CAMS].[dbo].[BankBranchWeeklyHalfDays]([IsMonday],[IsTuesday],[IsWednesday],[IsThursday],[IsFriday],[IsSaturday],[IsSunday])
VALUES (0,0,0,0,0,1,0)
GO

INSERT INTO [CAMS].[dbo].[BankBranchWeeklyHalfDays]([IsMonday],[IsTuesday],[IsWednesday],[IsThursday],[IsFriday],[IsSaturday],[IsSunday])
VALUES (0,0,0,0,0,1,0)
GO


/* Script to add BankBranchWeeklyOffs to the database table BankBranchWeeklyOffs  */
INSERT INTO [CAMS].[dbo].[BankBranchWeeklyOffs]([IsMonday],[IsTuesday],[IsWednesday],[IsThursday],[IsFriday],[IsSaturday],[IsSunday])
VALUES (0,0,0,0,0,0,1)
GO

INSERT INTO [CAMS].[dbo].[BankBranchWeeklyOffs]([IsMonday],[IsTuesday],[IsWednesday],[IsThursday],[IsFriday],[IsSaturday],[IsSunday])
VALUES (0,0,0,0,0,0,1)
GO

INSERT INTO [CAMS].[dbo].[BankBranchWeeklyOffs]([IsMonday],[IsTuesday],[IsWednesday],[IsThursday],[IsFriday],[IsSaturday],[IsSunday])
VALUES (0,0,0,0,0,0,1)
GO

INSERT INTO [CAMS].[dbo].[BankBranchWeeklyOffs]([IsMonday],[IsTuesday],[IsWednesday],[IsThursday],[IsFriday],[IsSaturday],[IsSunday])
VALUES (0,0,0,0,0,0,1)
GO

INSERT INTO [CAMS].[dbo].[BankBranchWeeklyOffs]([IsMonday],[IsTuesday],[IsWednesday],[IsThursday],[IsFriday],[IsSaturday],[IsSunday])
VALUES (0,0,0,0,0,0,1)
GO


/* Script to add BankBranches to the database table BankBranches  */
INSERT INTO [CAMS].[dbo].[BankBranches]([Name],[IFSCCode],[Email1],[CreatedBy],[ModifiedBy],[BankId],[AddressId],[WeeklyHalfDayId],[WeeklyOffDayId])
VALUES('Kondhwa' ,'ICIC0000074' ,'info@icicibank.com',1,1,1,2,1,1 )
GO

INSERT INTO [CAMS].[dbo].[BankBranches]([Name],[IFSCCode],[Email1],[CreatedBy],[ModifiedBy],[BankId],[AddressId],[WeeklyHalfDayId],[WeeklyOffDayId])
VALUES('Pune Satare Road' ,'ICIC0000337' ,'info@icicibank.com',1,1 ,1,3,2,2 )
GO

INSERT INTO [CAMS].[dbo].[BankBranches]([Name],[IFSCCode],[Email1],[CreatedBy],[ModifiedBy],[BankId],[AddressId],[WeeklyHalfDayId],[WeeklyOffDayId])
VALUES('Shivajinagar' ,'ICIC0000039' ,'info@icicibank.com',1,1 ,1 ,4,3,3)
GO

INSERT INTO [CAMS].[dbo].[BankBranches]([Name],[IFSCCode],[Email1],[CreatedBy],[ModifiedBy],[BankId],[AddressId],[WeeklyHalfDayId],[WeeklyOffDayId])
VALUES('Camp Pune' ,'ICIC0006488' ,'info@icicibank.com',1,1 ,1 ,5,4,4)
GO

INSERT INTO [CAMS].[dbo].[BankBranches]([Name],[IFSCCode],[Email1],[CreatedBy],[ModifiedBy],[BankId],[AddressId],[WeeklyHalfDayId],[WeeklyOffDayId])
VALUES('Aundh' ,'ICIC0000073' ,'info@icicibank.com',1,1 ,1,6,5,5 )
GO

-- =============================================
-- Script Template
-- =============================================
INSERT INTO [CAMS].[dbo].[Clients](TDSOnSubscriptionPayment,NoOfPartners,AccountmanagerId,CompanyName,Alias, DisplayClientId,[IsActive],[IsDeleted],[Status],[AllowEdit],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate], RegistrationDate, PAN,TAN, APMCLicenseNo ,APMCLicenseValidUpTo)
    VALUES(0,0,1,'Kishore Kunjeer & Co','KKC', 'KKC 11 III 001', 1,0,'Active',1,1,GETDATE(),1,GETDATE(),GETDATE(), 'PAN18','TAN18','APMCLicenseNo1',GETDATE()+100)
INSERT INTO [CAMS].[dbo].[Clients](TDSOnSubscriptionPayment,NoOfPartners,AccountmanagerId,CompanyName,Alias, DisplayClientId,[IsActive],[IsDeleted],[Status],[AllowEdit],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate], RegistrationDate,PAN,TAN, APMCLicenseNo,APMCLicenseValidUpTo)
	VALUES(0,0,1,'S S Nahar','SSN', 'SSN 11 III 003',1,0,'Active',1,1,GETDATE(),1,GETDATE(),GETDATE(),'PAN17','TAN17','APMCLicenseNo2',GETDATE()+280)
INSERT INTO [CAMS].[dbo].[Clients](TDSOnSubscriptionPayment,NoOfPartners,AccountmanagerId,CompanyName,Alias, DisplayClientId,[IsActive],[IsDeleted],[Status],[AllowEdit],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate], RegistrationDate,PAN,TAN, APMCLicenseNo,APMCLicenseValidUpTo)
	VALUES(0,0,1,'G G Katariya','GGK', 'GGK 11 III 002',1,0,'Active',1,1,GETDATE(),1,GETDATE() ,GETDATE(),'PAN16','TAN16','APMCLicenseNo3',GETDATE()+180)
INSERT INTO [CAMS].[dbo].[Clients](TDSOnSubscriptionPayment,NoOfPartners,AccountmanagerId,CompanyName,Alias, DisplayClientId,[IsActive],[IsDeleted],[Status],[AllowEdit],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate], RegistrationDate,PAN,TAN, APMCLicenseNo,APMCLicenseValidUpTo)
	VALUES(0,0,1,'Shiv Shankar Co','SSC', 'SSC 11 III 004',1,0,'Active',1,1,GETDATE(),1,GETDATE(),GETDATE(),'PAN15','TAN15','APMCLicenseNo4',GETDATE()+50)
INSERT INTO [CAMS].[dbo].[Clients](TDSOnSubscriptionPayment,NoOfPartners,AccountmanagerId,CompanyName,Alias, DisplayClientId,[IsActive],[IsDeleted],[Status],[AllowEdit],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate], RegistrationDate,PAN,TAN, APMCLicenseNo,APMCLicenseValidUpTo)
	VALUES(0,0,1,'Waman Laxman Borkar','WLB', 'WLB 11 III 004',1,0,'Active',1,1,GETDATE(),1,GETDATE(),GETDATE(),'PAN14','TAN14','APMCLicenseNo5',GETDATE()+320)
INSERT INTO [CAMS].[dbo].[Clients](TDSOnSubscriptionPayment,NoOfPartners,AccountmanagerId, CompanyName,Alias, DisplayClientId,[IsActive],[IsDeleted],[Status],[AllowEdit],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate], RegistrationDate,PAN,TAN, APMCLicenseNo,APMCLicenseValidUpTo)
	VALUES(0,0,1,'Sanjay Sitaram Talekar','SST', 'SST 11 III 004',1,0,'Active',1,1,GETDATE(),1,GETDATE(),GETDATE(),'PAN13','TAN13','APMCLicenseNo6',GETDATE()+300)
INSERT INTO [CAMS].[dbo].[Clients](TDSOnSubscriptionPayment,NoOfPartners,AccountmanagerId,CompanyName,Alias, DisplayClientId,[IsActive],[IsDeleted],[Status],[AllowEdit],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate], RegistrationDate,PAN,TAN, APMCLicenseNo,APMCLicenseValidUpTo)
	VALUES(0,0,1,'Sairaj Enterprises','SET', 'SET 11 III 004',1,0,'Active',1,1,GETDATE(),1,GETDATE(),GETDATE() ,'PAN12','TAN12','APMCLicenseNo7',GETDATE()+200)        

GO


INSERT INTO [CAMS].[dbo].[UserGroups]
           ([UserGroupName]
           ,[Description]
           ,[CAId]
           ,[IsActive]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[CreatedBy]           
           ,[ModifiedBy])
Select 'ClientAdmin' ,'ClientAdmin Group'
           ,CAID 
           ,1
           ,0
           ,0
           ,0
           ,1           
           ,1
FROM Clients
GO

INSERT INTO [CAMS].[dbo].[UserGroups]
           ([UserGroupName]
           ,[Description]
           ,[CAId]
           ,[IsActive]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[CreatedBy]           
           ,[ModifiedBy])
Select 'Data Entry Operator' ,'Data Entry Operator Group'
           ,CAID 
           ,1
           ,0
           ,0
           ,0
           ,1           
           ,1
FROM Clients
GO 

INSERT INTO [CAMS].[dbo].[UserGroups]
           ([UserGroupName]
           ,[Description]
           ,[CAId]
           ,[IsActive]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[CreatedBy]           
           ,[ModifiedBy])
Select 'Transaction Entry Operator' ,'Transaction Entry Operator Group'
           ,CAID 
           ,1
           ,0
           ,0
           ,0
           ,1           
           ,1
FROM Clients
GO
-- =============================================
-- Script Template
-- =============================================

/*Script to add dummy data into Users table*/
INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('RupaliSane'
		   ,'Ms'
           ,'RupaliSane'
           ,'Rsane@gmail.com'
           ,9888888888
           ,'QWNrU3VwQDEyMw=='
           ,'NirmalaJadhav'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('SanikaKulkarni'
		   ,'Ms'
           ,'Sanika'
           ,'Sanika@gmail.com'
           ,9777777777
           ,'QWNrU3VwQDEyMw=='
           ,'NishaSane'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('RakeshJadhav'
		   ,'Mr'
           ,'Rakesh'
           ,'Rakesh@gmail.com'
           ,9666666666
           ,'QWNrU3VwQDEyMw=='
           ,'MeenaMohite'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('ManojPatil'
		   ,'Mr'
           ,'Manoj'
           ,'ManojJ@gmail.com'
           ,9555555555
           ,'QWNrU3VwQDEyMw=='
           ,'AshaSawant'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('VijayMarne'
		   ,'Mr'
           ,'Vijay'
           ,'Vijay@gmail.com'
           ,9211111111
           ,'QWNrU3VwQDEyMw=='
           ,'SushamaDeshmukh'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('OmPrakashMehra'
		   ,'Mr'
           ,'Om'
           ,'Om@gmail.com'
           ,9333333333
           ,'QWNrU3VwQDEyMw=='
           ,'PoojaMehta'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('RevatiMore'
		   ,'Ms'
           ,'RevatiMane'
           ,'Revati@gmail.com'
           ,9511111111
           ,'QWNrU3VwQDEyMw=='
           ,'nalini'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('AsmaMukherjee'
		   ,'Ms'
           ,'Asma'
           ,'Asma@gmail.com'
           ,8777777777
           ,'QWNrU3VwQDEyMw=='
           ,'KrishnaSmarth'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('OmkarMohite'
		   ,'Mr'
           ,'Omkar'
           ,'Omkar@gmail.com'
           ,1111111111
           ,'QWNrU3VwQDEyMw=='
           ,'UshaMane'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('RajaPansare'
		   ,'Mr'
           ,'Raja'
           ,'Raja@gmail.com'
           ,8999999999
           ,'QWNrU3VwQDEyMw=='
           ,'RadhaPatil'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('PoonamMane'
		   ,'Ms'
           ,'Poonam'
           ,'Poonam@gmail.com'
           ,9911111111
           ,'QWNrU3VwQDEyMw=='
           ,'ArchanaMoghe'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('RajuChaudhary'
		   ,'Mr'
           ,'Raju'
           ,'Raju@gmail.com'
           ,9977777777
           ,'QWNrU3VwQDEyMw=='
           ,'MangalKanitkar'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('PrathamPant'
		   ,'Mr'
           ,'Pratham'
           ,'Pratham@gmail.com'
           ,9966666666
           ,'QWNrU3VwQDEyMw=='
           ,'RemaShinde'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('SupriyaMoghe'
		   ,'Ms'
           ,'Supriya'
           ,'Supriya@gmail.com'
           ,8887777777
           ,'QWNrU3VwQDEyMw=='
           ,'LatikaKulkarni'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('UdayKarmarkar'
		   ,'Mr'
           ,'Uday'
           ,'Uday@gmail.com'
           ,2222222222
           ,'QWNrU3VwQDEyMw=='
           ,'UrmilaDeshpande'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('MaheshGokhale'
		   ,'Mr'
           ,'Mahesh'
           ,'Mahesh@gmail.com'
           ,9876543219
           ,'QWNrU3VwQDEyMw=='
           ,'NishaGore'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('SanjayGupta'
		   ,'Mr'
           ,'Sanjay'
           ,'Sanjay@gmail.com'
           ,8765432198
           ,'QWNrU3VwQDEyMw=='
           ,'MadhuriGupte'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('SagarGhatge'
		   ,'Mr'
           ,'Sagar'
           ,'Sagar@gmail.com'
           ,8765432198
           ,'QWNrU3VwQDEyMw=='
           ,'ManishaShah'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('JaikishanLakhani'
		   ,'Mr'
           ,'Jay'
           ,'Jay@gmail.com'
           ,7654321989
           ,'QWNrU3VwQDEyMw=='
           ,'SwatiBhosale'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('AtulKulkarni'
		   ,'Mr'
           ,'Atul'
           ,'Atul@gmail.com'
           ,5432198964
           ,'QWNrU3VwQDEyMw=='
           ,'AnandiSohani'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('PratikPatil'
		   ,'Mr'
           ,'Pratik'
           ,'Pratik@gmail.com'
           ,4321989111
           ,'QWNrU3VwQDEyMw=='
           ,'PornimaMone'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('PrasadPatil'
		   ,'Mr'
           ,'Prasad'
           ,'Prasad@gmail.com'
           ,3219894444
           ,'QWNrU3VwQDEyMw=='
           ,'SeemaShinde'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('PritamBhosale'
		   ,'Ms'
           ,'Pritam'
           ,'Pritam@gmail.com'
           ,9411111111
           ,'QWNrU3VwQDEyMw=='
           ,'PriyaSarmane'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('SampadaShinde'
		   ,'Ms'
           ,'SampadaPatil'
           ,'Sampada@gmail.com'
           ,3222222222
           ,'QWNrU3VwQDEyMw=='
           ,'kavita'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('KavitaKrishnamurthy'
		   ,'Ms'
           ,'Kavita'
           ,'Kavita@gmail.com'
           ,9755555555
           ,'QWNrU3VwQDEyMw=='
           ,'HetalAnand'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('NileemaPisal'
		   ,'Ms'
           ,'Nileema'
           ,'Nileema@gmail.com'
           ,9444455555
           ,'QWNrU3VwQDEyMw=='
           ,'TinaGupta'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('AmrutaShinde'
		   ,'Ms'
           ,'Amruta'
           ,'Amruta@gmail.com'
           ,8944441111
           ,'QWNrU3VwQDEyMw=='
           ,'MalaMujumdar'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('MohanKulkarni'
		   ,'Mr'
           ,'Mohan'
           ,'Mohan@gmail.com'
           ,9677777777
           ,'QWNrU3VwQDEyMw=='
           ,'DishaKotnis'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('SadhanaSargam'
		   ,'Ms'
           ,'Sadhana'
           ,'Sadhana@gmail.com'
           ,8888888888
           ,'QWNrU3VwQDEyMw=='
           ,'LalitaMarane'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('LatikaPatil'
		   ,'Ms'
           ,'Latika'
           ,'Latika@gmail.com'
           ,6666666666
           ,'QWNrU3VwQDEyMw=='
           ,'TaraSharma'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('TanujaBhise'
		   ,'Ms'
           ,'TanujaKale'
           ,'Tanuja@gmail.com'
           ,5555555555
           ,'QWNrU3VwQDEyMw=='
           ,'namrata'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('AsmitaMore'
		   ,'Ms'
           ,'Asmita'
           ,'Asmita@gmail.com'
           ,3333333333
           ,'QWNrU3VwQDEyMw=='
           ,'AmrutaSubhash'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('NileshMoghe'
		   ,'Mr'
           ,'Nilesh'
           ,'Nilesh@gmail.com'
           ,1278872145
           ,'QWNrU3VwQDEyMw=='
           ,'RohiniGugar'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('AmolGupte'
		   ,'Mr'
           ,'Amol'
           ,'Amol@gmail.com'
           ,8527417894
           ,'QWNrU3VwQDEyMw=='
           ,'JayaPatil'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('SuvarnaSarmane'
		   ,'Ms'
           ,'Suvarna'
           ,'Suvarna@gmail.com'
           ,9638527410
           ,'QWNrU3VwQDEyMw=='
           ,'SavitaSawant'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('MonikaBajaj'
		   ,'Ms'
           ,'Monika'
           ,'Monika@gmail.com'
           ,7894561230
           ,'QWNrU3VwQDEyMw=='
           ,'MonaAgarwal'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('NishantKulkarni'
		   ,'Mr'
           ,'Nishant'
           ,'Nishant@gmail.com'
           ,3219894444
           ,'QWNrU3VwQDEyMw=='
           ,'RadhaKanitkar'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('RohiniKale'
		   ,'Ms'
           ,'Rohini'
           ,'Rohini@gmail.com'
           ,4561237891
           ,'QWNrU3VwQDEyMw=='
           ,'PayalPandit'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('RohanMujumdar'
		   ,'Mr'
           ,'Rohan'
           ,'Rohan@gmail.com'
           ,1234567890
           ,'QWNrU3VwQDEyMw=='
           ,'RoshaniSharma'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

INSERT INTO [CAMS].[dbo].[Users]
           ([Username]
		   ,[Title]
           ,[Name]
           ,[Email]
           ,[MobileNo]
           ,[Password]
           ,[MothersMaidenName]
           ,[CAId]
           ,[CountryCode]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[DateOfBirth]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[IsActive]
           ,[IsLockedOut]
           ,[IsOnLine]
           ,[LastActivityDate]
           ,[LastLockedOutDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[LastPassword]
           ,[SecondLastPassword]
           ,[SecondLastPasswordChangedDate]
           ,[IsDeleted]
           ,[AllowEdit]
           ,[AllowDelete]
           ,[DesignationId]
           ,[UserProfileId])
     VALUES
           ('RamavatiDeshmukh'
		   ,'Ms'
           ,'Rama'
           ,'Rama@gmail.com'
           ,2222222222
           ,'QWNrU3VwQDEyMw=='
           ,'MangalJadhav'
           ,null
           ,+91
           ,-1
           ,GETDATE()
           ,'10-10-1985'
           ,0
           ,GETDATE()
           ,1
           ,0
           ,0
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,1
           ,GETDATE()
           ,'QWNrU3VwQDEyMw=='
           ,'QWNrU3VwQDEyMw=='
           ,GETDATE()
           ,0
           ,0
           ,0
           ,null
           ,null)
GO

/*Script to assign usergroup to user*/
INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 2),(SELECT Users.UserId FROM Users WHERE Userid = 2))
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 3),(SELECT Users.UserId FROM Users WHERE Userid = 3))
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 4),(SELECT Users.UserId FROM Users WHERE Userid = 4)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 2),(SELECT Users.UserId FROM Users WHERE Userid = 5)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 3),(SELECT Users.UserId FROM Users WHERE Userid = 6)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 4),(SELECT Users.UserId FROM Users WHERE Userid = 7)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 2),(SELECT Users.UserId FROM Users WHERE Userid = 8)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 3),(SELECT Users.UserId FROM Users WHERE Userid = 9)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 3),(SELECT Users.UserId FROM Users WHERE Userid = 10)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 3),(SELECT Users.UserId FROM Users WHERE Userid = 11)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 2),(SELECT Users.UserId FROM Users WHERE Userid = 12))
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 3),(SELECT Users.UserId FROM Users WHERE Userid = 13))
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 4),(SELECT Users.UserId FROM Users WHERE Userid = 14)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 2),(SELECT Users.UserId FROM Users WHERE Userid = 15)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 3),(SELECT Users.UserId FROM Users WHERE Userid = 16)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 4),(SELECT Users.UserId FROM Users WHERE Userid = 17)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 2),(SELECT Users.UserId FROM Users WHERE Userid = 18)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 3),(SELECT Users.UserId FROM Users WHERE Userid = 19)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 3),(SELECT Users.UserId FROM Users WHERE Userid = 20)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 3),(SELECT Users.UserId FROM Users WHERE Userid = 21)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 2),(SELECT Users.UserId FROM Users WHERE Userid = 22))
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 3),(SELECT Users.UserId FROM Users WHERE Userid = 23))
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 4),(SELECT Users.UserId FROM Users WHERE Userid = 24)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 2),(SELECT Users.UserId FROM Users WHERE Userid = 25)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 3),(SELECT Users.UserId FROM Users WHERE Userid = 26)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 4),(SELECT Users.UserId FROM Users WHERE Userid = 27)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 2),(SELECT Users.UserId FROM Users WHERE Userid = 28)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 3),(SELECT Users.UserId FROM Users WHERE Userid = 29)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 3),(SELECT Users.UserId FROM Users WHERE Userid = 30)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 3),(SELECT Users.UserId FROM Users WHERE Userid = 31)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 2),(SELECT Users.UserId FROM Users WHERE Userid = 32))
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 3),(SELECT Users.UserId FROM Users WHERE Userid = 33))
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 4),(SELECT Users.UserId FROM Users WHERE Userid = 34)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 2),(SELECT Users.UserId FROM Users WHERE Userid = 35)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 3),(SELECT Users.UserId FROM Users WHERE Userid = 36)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 4),(SELECT Users.UserId FROM Users WHERE Userid = 37)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 2),(SELECT Users.UserId FROM Users WHERE Userid = 38)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 3),(SELECT Users.UserId FROM Users WHERE Userid = 39)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 3),(SELECT Users.UserId FROM Users WHERE Userid = 40)) 
GO

INSERT INTO [CAMS].[dbo].[UserUserGroups]([UserGroupid],[Userid]) VALUES ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupid = 3),(SELECT Users.UserId FROM Users WHERE Userid = 41)) 
GO
