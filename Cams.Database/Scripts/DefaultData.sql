-- =============================================
-- Script Template
-- =============================================
delete from useruserGroups
delete from UserRolePermissions
delete from UserGroupRolePermissions
delete from UserGroups
delete from Users
delete from RelationShips
delete from Designations
delete from CommodityClasses
delete from Country
delete from Banks
Go
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
           ,-1           
           ,0           
           ,1
           ,0
           ,0           
           ,-1           
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
           ,-1           
           ,-1)
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
           ,-1           
           ,-1)
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
           ,-1           
           ,-1)
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
           ,-1           
           ,-1)
GO

/*Script to assign SuperAdmin user to SuperAdmin Group*/
INSERT INTO [CAMS].[dbo].[UserUserGroups]
           ([UserGroupid]
           ,[Userid])
     VALUES
           ((SELECT UserGroups.UserGroupId FROM UserGroups WHERE UserGroupName = 'SuperAdmin')
           ,(SELECT Users.UserId FROM Users WHERE Username = 'SuperAdmin'))
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
           ,-1           
           ,-1)
GO

INSERT INTO [CAMS].[dbo].[RelationShips]
           ([Name]
           ,[CAId]
           ,[CreatedBy]           
           ,[ModifiedBy] )
     VALUES
           ('Father'
           ,0
           ,-1           
           ,-1 )
GO

INSERT INTO [CAMS].[dbo].[RelationShips]
           ([Name]
           ,[CAId]
           ,[CreatedBy]          
           ,[ModifiedBy])
     VALUES
           ('Brother'
           ,0
           ,-1           
           ,-1)
GO
INSERT INTO [CAMS].[dbo].[RelationShips]
           ([Name]
           ,[CAId]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('Sister'
           ,0
           ,-1           
           ,-1)
GO
INSERT INTO [CAMS].[dbo].[RelationShips]
           ([Name]
           ,[CAId]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('Son'
           ,0
           ,-1           
           ,-1)
GO
INSERT INTO [CAMS].[dbo].[RelationShips]
           ([Name]
           ,[CAId]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('Friend'
           ,0
           ,-1           
           ,-1)
GO
INSERT INTO [CAMS].[dbo].[RelationShips]
           ([Name]
           ,[CAId]
           ,[CreatedBy]           
           ,[ModifiedBy])
     VALUES
           ('Daughter'
           ,0
           ,-1          
           ,-1)
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
           ,-1           
           ,-1)
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
           ,-1           
           ,-1)
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
           ,-1           
           ,-1)
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
           ,-1           
           ,-1)
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
           ,-1           
           ,-1)
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
           ,-1           
           ,-1)
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
           ,-1           
           ,-1)
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
           ,-1           
           ,-1)
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
           ,-1           
           ,-1)
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
           ,-1           
           ,-1)
GO

/*Script to give full access to SuperAdmin Group */
delete from UserGroupRolePermissions
INSERT INTO UserGroupRolePermissions (AllowAdd,AllowEdit,AllowView,AllowDelete,AllowPrint,RoleId)
select IsAddApplicable, IsEditApplicable,IsViewApplicable,IsDeleteApplicable,IsPrintApplicable, Roleid 
from Roles 
delete from UserGroupRoles
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
           ,10000
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
           ,20000
           ,1           
           ,1 )
GO

/* Script to add BankBranches to the database table BankBranches  */
INSERT INTO [CAMS].[dbo].[BankBranches]([Name],[IFSCCode],[Email1],[CreatedBy],[ModifiedBy],[BankId])
VALUES('Kondhwa' ,'ICIC0000074' ,'info@icicibank.com',1,1 ,1 )
GO

INSERT INTO [CAMS].[dbo].[BankBranches]([Name],[IFSCCode],[Email1],[CreatedBy],[ModifiedBy],[BankId])
VALUES('Pune Satare Road' ,'ICIC0000337' ,'info@icicibank.com',1,1 ,1 )
GO

INSERT INTO [CAMS].[dbo].[BankBranches]([Name],[IFSCCode],[Email1],[CreatedBy],[ModifiedBy],[BankId])
VALUES('Shivajinagar' ,'ICIC0000039' ,'info@icicibank.com',1,1 ,1 )
GO

INSERT INTO [CAMS].[dbo].[BankBranches]([Name],[IFSCCode],[Email1],[CreatedBy],[ModifiedBy],[BankId])
VALUES('Camp Pune' ,'ICIC0006488' ,'info@icicibank.com',1,1 ,1 )
GO

INSERT INTO [CAMS].[dbo].[BankBranches]([Name],[IFSCCode],[Email1],[CreatedBy],[ModifiedBy],[BankId])
VALUES('Aundh' ,'ICIC0000073' ,'info@icicibank.com',1,1 ,1 )
GO