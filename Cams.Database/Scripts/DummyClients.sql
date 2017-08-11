-- =============================================
-- Script Template
-- =============================================
INSERT INTO [CAMS].[dbo].[Clients](CompanyName,Alias, DisplayClientId,[IsActive],[IsDeleted],[Status],[AllowEdit],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate], RegistrationDate, PAN,TAN, APMCLicenseNo ,APMCLicenseValidUpTo)
     VALUES('Kishore Kunjeer & Co','KKC', 'KKC 11 III 001', 1,0,'Active',1,1,GETDATE(),1,GETDATE(),GETDATE(), 'PAN18','TAN18','APMCLicenseNo1',GETDATE()+100)
INSERT INTO [CAMS].[dbo].[Clients](CompanyName,Alias, DisplayClientId,[IsActive],[IsDeleted],[Status],[AllowEdit],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate], RegistrationDate,PAN,TAN, APMCLicenseNo,APMCLicenseValidUpTo)
	VALUES('S S Nahar','SSN', 'SSN 11 III 003',1,0,'Active',1,1,GETDATE(),1,GETDATE(),GETDATE(),'PAN17','TAN17','APMCLicenseNo2',GETDATE()+280)
INSERT INTO [CAMS].[dbo].[Clients](CompanyName,Alias, DisplayClientId,[IsActive],[IsDeleted],[Status],[AllowEdit],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate], RegistrationDate,PAN,TAN, APMCLicenseNo,APMCLicenseValidUpTo)
	VALUES('G G Katariya','GGK', 'GGK 11 III 002',1,0,'Active',1,1,GETDATE(),1,GETDATE() ,GETDATE(),'PAN16','TAN16','APMCLicenseNo3',GETDATE()+180)
INSERT INTO [CAMS].[dbo].[Clients](CompanyName,Alias, DisplayClientId,[IsActive],[IsDeleted],[Status],[AllowEdit],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate], RegistrationDate,PAN,TAN, APMCLicenseNo,APMCLicenseValidUpTo)
	VALUES('Shiv Shankar Co','SSC', 'SSC 11 III 004',1,0,'Active',1,1,GETDATE(),1,GETDATE(),GETDATE(),'PAN15','TAN15','APMCLicenseNo4',GETDATE()+50)
INSERT INTO [CAMS].[dbo].[Clients](CompanyName,Alias, DisplayClientId,[IsActive],[IsDeleted],[Status],[AllowEdit],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate], RegistrationDate,PAN,TAN, APMCLicenseNo,APMCLicenseValidUpTo)
	VALUES('Waman Laxman Borkar','WLB', 'WLB 11 III 004',1,0,'Active',1,1,GETDATE(),1,GETDATE(),GETDATE(),'PAN14','TAN14','APMCLicenseNo5',GETDATE()+320)
INSERT INTO [CAMS].[dbo].[Clients](CompanyName,Alias, DisplayClientId,[IsActive],[IsDeleted],[Status],[AllowEdit],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate], RegistrationDate,PAN,TAN, APMCLicenseNo,APMCLicenseValidUpTo)
	VALUES('Sanjay Sitaram Talekar','SST', 'SST 11 III 004',1,0,'Active',1,1,GETDATE(),1,GETDATE(),GETDATE(),'PAN13','TAN13','APMCLicenseNo6',GETDATE()+300)
INSERT INTO [CAMS].[dbo].[Clients](CompanyName,Alias, DisplayClientId,[IsActive],[IsDeleted],[Status],[AllowEdit],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate], RegistrationDate,PAN,TAN, APMCLicenseNo,APMCLicenseValidUpTo)
	VALUES('Sairaj Enterprises','SET', 'SET 11 III 004',1,0,'Active',1,1,GETDATE(),1,GETDATE(),GETDATE() ,'PAN12','TAN12','APMCLicenseNo7',GETDATE()+200)        

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