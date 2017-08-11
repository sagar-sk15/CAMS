/*
Deployment script for CAMS
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "CAMS"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL10_50.LOCALDB\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL10_50.LOCALDB\MSSQL\DATA\"

GO
USE [master]

GO
:on error exit
GO
IF (DB_ID(N'$(DatabaseName)') IS NOT NULL
    AND DATABASEPROPERTYEX(N'$(DatabaseName)','Status') <> N'ONLINE')
BEGIN
    RAISERROR(N'The state of the target database, %s, is not set to ONLINE. To deploy to this database, its state must be set to ONLINE.', 16, 127,N'$(DatabaseName)') WITH NOWAIT
    RETURN
END

GO
IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [CAMS], FILENAME = '$(DefaultDataPath)$(DatabaseName).mdf', FILEGROWTH = 1024 KB)
    LOG ON (NAME = [CAMS_log], FILENAME = '$(DefaultLogPath)$(DatabaseName)_log.ldf', MAXSIZE = 2097152 MB, FILEGROWTH = 10 %) COLLATE SQL_Latin1_General_CP1_CI_AS
GO
EXECUTE sp_dbcmptlevel [$(DatabaseName)], 100;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
USE [$(DatabaseName)]

GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

GO
PRINT N'Creating [NT AUTHORITY\NETWORK SERVICE]...';


GO
CREATE USER [NT AUTHORITY\NETWORK SERVICE] FOR LOGIN [NT AUTHORITY\NETWORK SERVICE]
    WITH DEFAULT_SCHEMA = [NT AUTHORITY\NETWORK SERVICE];


GO
PRINT N'Creating <unnamed>...';


GO
EXECUTE sp_addrolemember @rolename = N'db_datareader', @membername = N'NT AUTHORITY\NETWORK SERVICE';


GO
PRINT N'Creating <unnamed>...';


GO
EXECUTE sp_addrolemember @rolename = N'db_datawriter', @membername = N'NT AUTHORITY\NETWORK SERVICE';


GO
PRINT N'Creating <unnamed>...';


GO
EXECUTE sp_addrolemember @rolename = N'db_owner', @membername = N'NT AUTHORITY\NETWORK SERVICE';


GO
PRINT N'Creating [NT AUTHORITY\NETWORK SERVICE]...';


GO
CREATE SCHEMA [NT AUTHORITY\NETWORK SERVICE]
    AUTHORIZATION [NT AUTHORITY\NETWORK SERVICE];


GO
PRINT N'Creating [dbo].[ActivityLogs]...';


GO
CREATE TABLE [dbo].[ActivityLogs] (
    [LogId]             INT            IDENTITY (1, 1) NOT NULL,
    [LoggedBy]          NVARCHAR (255) NOT NULL,
    [LoggedDate]        DATETIME       NOT NULL,
    [ActivityRelatedTo] NVARCHAR (50)  NOT NULL,
    [Description]       NVARCHAR (255) NULL,
    [CAId]              INT            NULL,
    [ObjectId]          NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([LogId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[Addresses]...';


GO
CREATE TABLE [dbo].[Addresses] (
    [AddressId]     BIGINT         IDENTITY (1, 1) NOT NULL,
    [AddressLine1]  NVARCHAR (255) NULL,
    [AddressLine2]  NVARCHAR (255) NULL,
    [PIN]           NVARCHAR (10)  NULL,
    [CreatedBy]     BIGINT         NOT NULL,
    [CreatedDate]   DATETIME       NOT NULL,
    [ModifiedBy]    BIGINT         NULL,
    [ModifiedDate]  DATETIME       NULL,
    [CityVillageId] INT            NULL,
    PRIMARY KEY CLUSTERED ([AddressId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[APMC]...';


GO
CREATE TABLE [dbo].[APMC] (
    [APMCId]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (80)  NOT NULL,
    [Email1]       NVARCHAR (50)  NULL,
    [Email2]       NVARCHAR (50)  NULL,
    [Website]      NVARCHAR (100) NULL,
    [Status]       NVARCHAR (10)  NOT NULL,
    [CreatedBy]    BIGINT         NOT NULL,
    [CreatedDate]  DATETIME       NOT NULL,
    [ModifiedBy]   BIGINT         NULL,
    [ModifiedDate] DATETIME       NULL,
    [AddressId]    BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([APMCId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[APMCContacts]...';


GO
CREATE TABLE [dbo].[APMCContacts] (
    [APMCId]           INT    NOT NULL,
    [ContactDetailsId] BIGINT NOT NULL
);


GO
PRINT N'Creating [dbo].[BankBranchContacts]...';


GO
CREATE TABLE [dbo].[BankBranchContacts] (
    [BranchId]         INT    NOT NULL,
    [ContactDetailsId] BIGINT NOT NULL
);


GO
PRINT N'Creating [dbo].[BankBranches]...';


GO
CREATE TABLE [dbo].[BankBranches] (
    [BranchId]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (255) NOT NULL,
    [CAId]             INT            NULL,
    [IFSCCode]         NVARCHAR (50)  NULL,
    [MICRCode]         NVARCHAR (50)  NULL,
    [SWIFTCode]        NVARCHAR (50)  NULL,
    [Email1]           NVARCHAR (100) NULL,
    [Email2]           NVARCHAR (100) NULL,
    [FullDayTimeFrom]  TIME (7)       NULL,
    [FullDayTimeTo]    TIME (7)       NULL,
    [HalfDayTimeFrom]  TIME (7)       NULL,
    [HalfDayTimeTo]    TIME (7)       NULL,
    [FullDayBreakFrom] TIME (7)       NULL,
    [FullDayBreakTo]   TIME (7)       NULL,
    [HalfDayBreakFrom] TIME (7)       NULL,
    [HalfDayBreakTo]   TIME (7)       NULL,
    [BaseBranchId]     INT            NULL,
    [CreatedBy]        BIGINT         NOT NULL,
    [CreatedDate]      DATETIME       NOT NULL,
    [ModifiedBy]       BIGINT         NULL,
    [ModifiedDate]     DATETIME       NULL,
    [BankId]           INT            NULL,
    [AddressId]        BIGINT         NULL,
    [WeeklyHalfDayId]  INT            NULL,
    [WeeklyOffDayId]   INT            NULL,
    PRIMARY KEY CLUSTERED ([BranchId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[BankBranchWeeklyHalfDays]...';


GO
CREATE TABLE [dbo].[BankBranchWeeklyHalfDays] (
    [WeeklyHalfDayId] INT IDENTITY (1, 1) NOT NULL,
    [IsMonday]        BIT NULL,
    [IsTuesday]       BIT NULL,
    [IsWednesday]     BIT NULL,
    [IsThursday]      BIT NULL,
    [IsFriday]        BIT NULL,
    [IsSaturday]      BIT NULL,
    [IsSunday]        BIT NULL,
    PRIMARY KEY CLUSTERED ([WeeklyHalfDayId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[BankBranchWeeklyOffs]...';


GO
CREATE TABLE [dbo].[BankBranchWeeklyOffs] (
    [WeeklyOffDayId] INT IDENTITY (1, 1) NOT NULL,
    [IsMonday]       BIT NULL,
    [IsTuesday]      BIT NULL,
    [IsWednesday]    BIT NULL,
    [IsThursday]     BIT NULL,
    [IsFriday]       BIT NULL,
    [IsSaturday]     BIT NULL,
    [IsSunday]       BIT NULL,
    PRIMARY KEY CLUSTERED ([WeeklyOffDayId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[Banks]...';


GO
CREATE TABLE [dbo].[Banks] (
    [BankId]       INT            IDENTITY (1, 1) NOT NULL,
    [BankName]     NVARCHAR (255) NOT NULL,
    [Alias]        NVARCHAR (15)  NULL,
    [CAId]         INT            NULL,
    [URL]          NVARCHAR (100) NULL,
    [BaseBankId]   INT            NULL,
    [CreatedBy]    BIGINT         NOT NULL,
    [CreatedDate]  DATETIME       NOT NULL,
    [ModifiedBy]   BIGINT         NULL,
    [ModifiedDate] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([BankId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[BusinessConstitutions]...';


GO
CREATE TABLE [dbo].[BusinessConstitutions] (
    [BusinessConstitutionId]   INT           IDENTITY (1, 1) NOT NULL,
    [BusinessConstitutionName] NVARCHAR (50) NOT NULL,
    [IsActive]                 BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([BusinessConstitutionId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[ChargesPayableTo]...';


GO
CREATE TABLE [dbo].[ChargesPayableTo] (
    [ChargesPayableToId] INT           IDENTITY (1, 1) NOT NULL,
    [PayableTo]          NVARCHAR (30) NOT NULL,
    [IsActive]           BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([ChargesPayableToId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[CityVillages]...';


GO
CREATE TABLE [dbo].[CityVillages] (
    [CityVillageId]     INT            IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (255) NOT NULL,
    [CityOrVillage]     NVARCHAR (255) NOT NULL,
    [STDCode]           NVARCHAR (30)  NULL,
    [CAId]              INT            NULL,
    [BaseCityVillageId] INT            NULL,
    [CreatedBy]         BIGINT         NOT NULL,
    [CreatedDate]       DATETIME       NOT NULL,
    [ModifiedBy]        BIGINT         NULL,
    [ModifiedDate]      DATETIME       NULL,
    [DistrictId]        INT            NULL,
    PRIMARY KEY CLUSTERED ([CityVillageId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[ClientBusinessConstitutionHistory]...';


GO
CREATE TABLE [dbo].[ClientBusinessConstitutionHistory] (
    [ClientBusinessConstitutionHistoryId] INT      IDENTITY (1, 1) NOT NULL,
    [CAId]                                INT      NOT NULL,
    [BusinessConstitutionId]              INT      NOT NULL,
    [ModifiedBy]                          BIGINT   NOT NULL,
    [ModifiedDate]                        DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([ClientBusinessConstitutionHistoryId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[ClientCommodities]...';


GO
CREATE TABLE [dbo].[ClientCommodities] (
    [CAId]             INT NOT NULL,
    [CommodityClassId] INT NOT NULL
);


GO
PRINT N'Creating [dbo].[ClientCommoditiesHistory]...';


GO
CREATE TABLE [dbo].[ClientCommoditiesHistory] (
    [ClientCommoditiesHistoryId]  INT      NOT NULL,
    [CAId]                        INT      NOT NULL,
    [CommodityClassId]            INT      NOT NULL,
    [ModifiedBy]                  BIGINT   NOT NULL,
    [ModifiedDate]                DATETIME NOT NULL,
    [ClientWeeklyOffDayHistoryId] INT      IDENTITY (1, 1) NOT NULL,
    [IsMonday]                    BIT      NULL,
    [IsTuesday]                   BIT      NULL,
    [IsWednesday]                 BIT      NULL,
    [IsThursday]                  BIT      NULL,
    [IsFriday]                    BIT      NULL,
    [IsSaturday]                  BIT      NULL,
    [IsSunday]                    BIT      NULL,
    [WithEffectFromDate]          DATETIME NOT NULL,
    [WithEffectToDate]            DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([ClientWeeklyOffDayHistoryId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[ClientContacts]...';


GO
CREATE TABLE [dbo].[ClientContacts] (
    [CAId]             INT    NOT NULL,
    [ContactDetailsId] BIGINT NOT NULL
);


GO
PRINT N'Creating [dbo].[ClientHolidayCalender]...';


GO
CREATE TABLE [dbo].[ClientHolidayCalender] (
    [ClientHolidayCalenderId] INT            IDENTITY (1, 1) NOT NULL,
    [CAId]                    INT            NOT NULL,
    [HolidayFromDate]         DATETIME       NOT NULL,
    [HolidayToDate]           DATETIME       NULL,
    [Reason]                  NVARCHAR (100) NOT NULL,
    [CreatedBy]               BIGINT         NOT NULL,
    [CreatedDate]             DATETIME       NOT NULL,
    [ModifiedBy]              BIGINT         NOT NULL,
    [ModifiedDate]            DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([ClientHolidayCalenderId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[ClientPartnerBankContactPersonContacts]...';


GO
CREATE TABLE [dbo].[ClientPartnerBankContactPersonContacts] (
    [ClientPartnerBankId] INT    NOT NULL,
    [ContactDetailsId]    BIGINT NOT NULL
);


GO
PRINT N'Creating [dbo].[ClientPartnerBankDetails]...';


GO
CREATE TABLE [dbo].[ClientPartnerBankDetails] (
    [ClientPartnerBankId]   INT            IDENTITY (1, 1) NOT NULL,
    [Accounttype]           NVARCHAR (20)  NULL,
    [AccountNo]             NVARCHAR (40)  NULL,
    [StandingInstructions]  NVARCHAR (100) NULL,
    [BankContactPersonName] NVARCHAR (20)  NULL,
    [Email1]                NVARCHAR (100) NULL,
    [Email2]                NVARCHAR (100) NULL,
    [CreatedBy]             BIGINT         NOT NULL,
    [CreatedDate]           DATETIME       NOT NULL,
    [ModifiedBy]            BIGINT         NOT NULL,
    [ModifiedDate]          DATETIME       NOT NULL,
    [BranchId]              INT            NULL,
    [DesignationId]         INT            NULL,
    PRIMARY KEY CLUSTERED ([ClientPartnerBankId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[ClientPartnerBanks]...';


GO
CREATE TABLE [dbo].[ClientPartnerBanks] (
    [ClientPartnerBankId] INT NOT NULL,
    [PartnerId]           INT NOT NULL
);


GO
PRINT N'Creating [dbo].[ClientPartnerContacts]...';


GO
CREATE TABLE [dbo].[ClientPartnerContacts] (
    [PartnerId]        INT    NOT NULL,
    [ContactDetailsId] BIGINT NOT NULL
);


GO
PRINT N'Creating [dbo].[ClientPartnerDetails]...';


GO
CREATE TABLE [dbo].[ClientPartnerDetails] (
    [PartnerId]               INT             IDENTITY (1, 1) NOT NULL,
    [Title]                   NVARCHAR (10)   NULL,
    [PartnerName]             NVARCHAR (255)  NULL,
    [Gender]                  NVARCHAR (5)    NULL,
    [DateOfBirth]             DATETIME        NULL,
    [PAN]                     NVARCHAR (20)   NULL,
    [UID]                     NVARCHAR (20)   NULL,
    [Image]                   NVARCHAR (255)  NULL,
    [Email1]                  NVARCHAR (100)  NULL,
    [Email2]                  NVARCHAR (100)  NULL,
    [JoiningDate]             DATETIME        NULL,
    [RelievingDate]           DATETIME        NULL,
    [PartnerDisplayId]        NVARCHAR (30)   NULL,
    [MaritialStatus]          NVARCHAR (10)   NULL,
    [PassportNo]              NVARCHAR (30)   NULL,
    [Place]                   NVARCHAR (100)  NULL,
    [IssuedOn]                DATETIME        NULL,
    [ValidUpTo]               DATETIME        NULL,
    [PartnerType]             NVARCHAR (10)   NULL,
    [CapitalRatio]            DECIMAL (19, 5) NOT NULL,
    [ProfitRatio]             DECIMAL (19, 5) NOT NULL,
    [SalaryRatio]             DECIMAL (19, 5) NOT NULL,
    [LossRatio]               DECIMAL (19, 5) NOT NULL,
    [OpeningBalance]          DECIMAL (19, 5) NOT NULL,
    [BalanceType]             NVARCHAR (5)    NULL,
    [AsOndate]                DATETIME        NULL,
    [IsActive]                BIT             NOT NULL,
    [CreatedBy]               BIGINT          NOT NULL,
    [CreatedDate]             DATETIME        NOT NULL,
    [ModifiedBy]              BIGINT          NOT NULL,
    [ModifiedDate]            DATETIME        NOT NULL,
    [AddressId]               BIGINT          NULL,
    [DesignationId]           INT             NULL,
    [ClientPartnerGuardianId] INT             NULL,
    [ClientPartnerNomineeId]  INT             NULL,
    PRIMARY KEY CLUSTERED ([PartnerId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[ClientPartnerGuardianContacts]...';


GO
CREATE TABLE [dbo].[ClientPartnerGuardianContacts] (
    [ClientPartnerGuardianId] INT    NOT NULL,
    [ContactDetailsId]        BIGINT NOT NULL
);


GO
PRINT N'Creating [dbo].[ClientPartnerGuardianDetails]...';


GO
CREATE TABLE [dbo].[ClientPartnerGuardianDetails] (
    [ClientPartnerGuardianId] INT            IDENTITY (1, 1) NOT NULL,
    [Title]                   NVARCHAR (10)  NULL,
    [GuardianName]            NVARCHAR (255) NULL,
    [Gender]                  NVARCHAR (5)   NULL,
    [DateOfBirth]             DATETIME       NULL,
    [PAN]                     NVARCHAR (20)  NULL,
    [UID]                     NVARCHAR (20)  NULL,
    [Image]                   NVARCHAR (255) NULL,
    [Email1]                  NVARCHAR (100) NULL,
    [Email2]                  NVARCHAR (100) NULL,
    [CreatedBy]               BIGINT         NOT NULL,
    [CreatedDate]             DATETIME       NOT NULL,
    [ModifiedBy]              BIGINT         NOT NULL,
    [ModifiedDate]            DATETIME       NOT NULL,
    [AddressId]               BIGINT         NULL,
    [RelationshipId]          INT            NULL,
    PRIMARY KEY CLUSTERED ([ClientPartnerGuardianId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[ClientPartnerHistory]...';


GO
CREATE TABLE [dbo].[ClientPartnerHistory] (
    [ClientPartnerHistoryId] INT      IDENTITY (1, 1) NOT NULL,
    [PartnerId]              INT      NOT NULL,
    [BusinessConstitutionId] INT      NOT NULL,
    [CAId]                   INT      NOT NULL,
    [JoiningDate]            DATETIME NOT NULL,
    [RelievingDate]          DATETIME NULL,
    [IsActive]               BIT      NOT NULL,
    [ModifiedBy]             BIGINT   NOT NULL,
    [ModifiedDate]           DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([ClientPartnerHistoryId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[ClientPartnerNomineeContacts]...';


GO
CREATE TABLE [dbo].[ClientPartnerNomineeContacts] (
    [ClientPartnerNomineeId] INT    NOT NULL,
    [ContactDetailsId]       BIGINT NOT NULL
);


GO
PRINT N'Creating [dbo].[ClientPartnerNomineeDetails]...';


GO
CREATE TABLE [dbo].[ClientPartnerNomineeDetails] (
    [ClientPartnerNomineeId] INT            IDENTITY (1, 1) NOT NULL,
    [Title]                  NVARCHAR (10)  NULL,
    [PartnerNomineeName]     NVARCHAR (255) NULL,
    [Gender]                 NVARCHAR (5)   NULL,
    [DateOfBirth]            DATETIME       NULL,
    [PAN]                    NVARCHAR (20)  NULL,
    [UID]                    NVARCHAR (20)  NULL,
    [Image]                  NVARCHAR (255) NULL,
    [Email1]                 NVARCHAR (100) NULL,
    [Email2]                 NVARCHAR (100) NULL,
    [MaritialStatus]         NVARCHAR (10)  NULL,
    [PassportNo]             NVARCHAR (30)  NULL,
    [Place]                  NVARCHAR (100) NULL,
    [IssuedOn]               DATETIME       NULL,
    [ValidUpTo]              DATETIME       NULL,
    [CreatedBy]              BIGINT         NOT NULL,
    [CreatedDate]            DATETIME       NOT NULL,
    [ModifiedBy]             BIGINT         NOT NULL,
    [ModifiedDate]           DATETIME       NOT NULL,
    [AddressId]              BIGINT         NULL,
    [RelationshipId]         INT            NULL,
    PRIMARY KEY CLUSTERED ([ClientPartnerNomineeId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[ClientPartners]...';


GO
CREATE TABLE [dbo].[ClientPartners] (
    [CAId]      INT NOT NULL,
    [PartnerId] INT NOT NULL
);


GO
PRINT N'Creating [dbo].[ClientPhoneCharges]...';


GO
CREATE TABLE [dbo].[ClientPhoneCharges] (
    [ClientPhoneChargesId] INT             IDENTITY (1, 1) NOT NULL,
    [WithEffectFromDate]   DATETIME        NULL,
    [WSFarmerAmount]       DECIMAL (19, 5) NOT NULL,
    [OSFarmerAmount]       DECIMAL (19, 5) NOT NULL,
    [WSTraderAmount]       DECIMAL (19, 5) NOT NULL,
    [OSTraderAmount]       DECIMAL (19, 5) NOT NULL,
    [CreatedBy]            BIGINT          NOT NULL,
    [CreatedDate]          DATETIME        NOT NULL,
    [ModifiedBy]           BIGINT          NOT NULL,
    [ModifiedDate]         DATETIME        NOT NULL,
    PRIMARY KEY CLUSTERED ([ClientPhoneChargesId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[ClientPhoneChargesHistory]...';


GO
CREATE TABLE [dbo].[ClientPhoneChargesHistory] (
    [ClientPhoneChargesHistoryId] INT             IDENTITY (1, 1) NOT NULL,
    [ClientPhoneChargesId]        INT             NOT NULL,
    [CAId]                        INT             NOT NULL,
    [WithEffectFromDate]          DATETIME        NULL,
    [WithEffectToDate]            DATETIME        NULL,
    [WSFarmerAmount]              DECIMAL (19, 5) NOT NULL,
    [OSFarmerAmount]              DECIMAL (19, 5) NOT NULL,
    [WSTraderAmount]              DECIMAL (19, 5) NOT NULL,
    [OSTraderAmount]              DECIMAL (19, 5) NOT NULL,
    [ModifiedBy]                  BIGINT          NOT NULL,
    [ModifiedDate]                DATETIME        NOT NULL,
    PRIMARY KEY CLUSTERED ([ClientPhoneChargesHistoryId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[ClientPrimaryContactPerson]...';


GO
CREATE TABLE [dbo].[ClientPrimaryContactPerson] (
    [CAPrimaryContactPersonId]    INT            IDENTITY (1, 1) NOT NULL,
    [Title]                       NVARCHAR (5)   NULL,
    [CAPrimaryConatactPersonName] NVARCHAR (255) NULL,
    [Gender]                      NVARCHAR (5)   NULL,
    [DateOfBirth]                 DATETIME       NULL,
    [MothersMaidenName]           NVARCHAR (255) NULL,
    [PAN]                         NVARCHAR (20)  NULL,
    [UID]                         NVARCHAR (20)  NULL,
    [Image]                       NVARCHAR (255) NULL,
    [Email1]                      NVARCHAR (100) NULL,
    [Email2]                      NVARCHAR (100) NULL,
    [IsSameAsCompanyAddress]      BIT            NOT NULL,
    [IsSameAsCompanyContact]      BIT            NOT NULL,
    [MobileNo]                    NVARCHAR (255) NULL,
    [CreatedBy]                   BIGINT         NOT NULL,
    [CreatedDate]                 DATETIME       NOT NULL,
    [ModifiedBy]                  BIGINT         NOT NULL,
    [ModifiedDate]                DATETIME       NOT NULL,
    [AddressId]                   BIGINT         NULL,
    [DesignationId]               INT            NULL,
    PRIMARY KEY CLUSTERED ([CAPrimaryContactPersonId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[ClientPrimaryContacts]...';


GO
CREATE TABLE [dbo].[ClientPrimaryContacts] (
    [CAPrimaryContactPersonId] INT    NOT NULL,
    [ContactDetailsId]         BIGINT NOT NULL
);


GO
PRINT N'Creating [dbo].[ClientProfileChangeRequestFields]...';


GO
CREATE TABLE [dbo].[ClientProfileChangeRequestFields] (
    [ClientProfileCRFieldId]   INT            IDENTITY (1, 1) NOT NULL,
    [FieldName]                NVARCHAR (100) NOT NULL,
    [CurrentValue]             NVARCHAR (200) NOT NULL,
    [NewValue]                 NVARCHAR (200) NOT NULL,
    [FieldOfValue]             NVARCHAR (200) NOT NULL,
    [ObjectNameInDomainEntity] NVARCHAR (200) NOT NULL,
    [CreatedBy]                BIGINT         NOT NULL,
    [CreatedDate]              DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([ClientProfileCRFieldId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[ClientProfileChangeRequests]...';


GO
CREATE TABLE [dbo].[ClientProfileChangeRequests] (
    [RequestId]                        INT            IDENTITY (1, 1) NOT NULL,
    [Reason]                           NVARCHAR (200) NOT NULL,
    [CAId]                             INT            NOT NULL,
    [ClientProfileChangeRequestStatus] NVARCHAR (255) NOT NULL,
    [CreatedBy]                        BIGINT         NOT NULL,
    [CreatedDate]                      DATETIME       NOT NULL,
    [EmailMessageId]                   INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([RequestId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[ClientProfileChangeRequestsWithFields]...';


GO
CREATE TABLE [dbo].[ClientProfileChangeRequestsWithFields] (
    [ClientProfileCRFieldId] INT NOT NULL,
    [RequestId]              INT NOT NULL
);


GO
PRINT N'Creating [dbo].[Clients]...';


GO
CREATE TABLE [dbo].[Clients] (
    [CAId]                                 INT             IDENTITY (1, 1) NOT NULL,
    [DisplayClientId]                      NVARCHAR (30)   NOT NULL,
    [CompanyName]                          NVARCHAR (200)  NOT NULL,
    [RegistrationDate]                     DATETIME        NULL,
    [Alias]                                NVARCHAR (10)   NULL,
    [Image]                                NVARCHAR (255)  NULL,
    [PAN]                                  NVARCHAR (20)   NULL,
    [TAN]                                  NVARCHAR (20)   NULL,
    [Email1]                               NVARCHAR (100)  NULL,
    [Email2]                               NVARCHAR (100)  NULL,
    [Website]                              NVARCHAR (100)  NULL,
    [IsActive]                             BIT             NOT NULL,
    [IsDeleted]                            BIT             NOT NULL,
    [Status]                               NVARCHAR (15)   NOT NULL,
    [AllowEdit]                            BIT             NOT NULL,
    [APMCLicenseNo]                        NVARCHAR (255)  NULL,
    [NoOfPartners]                         INT             NOT NULL,
    [TDSOnSubscriptionPayment]             DECIMAL (19, 5) NOT NULL,
    [AdditionalInfoForSubscriptionPayment] NVARCHAR (255)  NULL,
    [APMCLicenseValidUpTo]                 DATETIME        NULL,
    [CreatedBy]                            BIGINT          NOT NULL,
    [CreatedDate]                          DATETIME        NOT NULL,
    [ModifiedBy]                           BIGINT          NOT NULL,
    [ModifiedDate]                         DATETIME        NOT NULL,
    [AccountManagerId]                     BIGINT          NOT NULL,
    [AddressId]                            BIGINT          NULL,
    [APMCId]                               INT             NULL,
    [BusinessConstitutionId]               INT             NULL,
    [ClientSubscriptionId]                 INT             NULL,
    [ClientPhoneChargesId]                 INT             NULL,
    [CAPrimaryContactPersonId]             INT             NULL,
    PRIMARY KEY CLUSTERED ([CAId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[ClientSisterConcern]...';


GO
CREATE TABLE [dbo].[ClientSisterConcern] (
    [ClientSisterConcernId]  INT            IDENTITY (1, 1) NOT NULL,
    [BusinessRelation]       NVARCHAR (30)  NULL,
    [ClientSisterConcerName] NVARCHAR (200) NULL,
    [RelationshipWithEntity] NVARCHAR (200) NULL,
    [EntityId]               INT            NULL,
    [CreatedBy]              BIGINT         NOT NULL,
    [CreatedDate]            DATETIME       NOT NULL,
    [ModifiedBy]             BIGINT         NOT NULL,
    [ModifiedDate]           DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([ClientSisterConcernId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[ClientSisterConcerns]...';


GO
CREATE TABLE [dbo].[ClientSisterConcerns] (
    [CAId]                  INT NOT NULL,
    [ClientSisterConcernId] INT NOT NULL
);


GO
PRINT N'Creating [dbo].[ClientSubscriptionPaymentDetails]...';


GO
CREATE TABLE [dbo].[ClientSubscriptionPaymentDetails] (
    [CASubscriptionPaymentDetailsId] INT             IDENTITY (1, 1) NOT NULL,
    [PaymentMode]                    NVARCHAR (10)   NULL,
    [Amount]                         DECIMAL (19, 5) NOT NULL,
    [IsRTGS]                         BIT             NOT NULL,
    [IsStandardCheque]               BIT             NOT NULL,
    [IsNEFT]                         BIT             NOT NULL,
    [ChequeDDTransationNo]           NVARCHAR (15)   NULL,
    [ChequeDDTransactionDate]        DATETIME        NULL,
    [ChequeDDClearanceDates]         DATETIME        NULL,
    [CreatedBy]                      BIGINT          NOT NULL,
    [CreatedDate]                    DATETIME        NOT NULL,
    [ModifiedBy]                     BIGINT          NOT NULL,
    [ModifiedDate]                   DATETIME        NOT NULL,
    [BranchId]                       INT             NULL,
    PRIMARY KEY CLUSTERED ([CASubscriptionPaymentDetailsId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[ClientSubscriptionPayments]...';


GO
CREATE TABLE [dbo].[ClientSubscriptionPayments] (
    [ClientSubscriptionId]           INT NOT NULL,
    [CASubscriptionPaymentDetailsId] INT NOT NULL
);


GO
PRINT N'Creating [dbo].[ClientSubscriptions]...';


GO
CREATE TABLE [dbo].[ClientSubscriptions] (
    [ClientSubscriptionId]        INT             IDENTITY (1, 1) NOT NULL,
    [SubscriptionPeriod]          INT             NULL,
    [SubscriptionPeriodFromDate]  DATETIME        NULL,
    [SubscriptionPeriodToDate]    DATETIME        NULL,
    [AdditionalNoOfEmployees]     INT             NOT NULL,
    [AdditionalNoOfAuditors]      INT             NOT NULL,
    [AdditionalNoOfAssociates]    INT             NOT NULL,
    [AdditionalCostForEmployees]  DECIMAL (19, 5) NOT NULL,
    [AdditionalCostForAuditors]   DECIMAL (19, 5) NOT NULL,
    [AdditionalCostForAssociates] DECIMAL (19, 5) NOT NULL,
    [DiscountInPercentage]        REAL            NOT NULL,
    [DiscountInRupees]            DECIMAL (19, 5) NOT NULL,
    [ServiceTax]                  DECIMAL (19, 5) NOT NULL,
    [OtherTax]                    DECIMAL (19, 5) NOT NULL,
    [Status]                      NVARCHAR (15)   NOT NULL,
    [AdditionalInfo]              NVARCHAR (255)  NULL,
    [ActivationDate]              DATETIME        NULL,
    [AllowEdit]                   BIT             NOT NULL,
    [CreatedBy]                   BIGINT          NOT NULL,
    [CreatedDate]                 DATETIME        NOT NULL,
    [ModifiedBy]                  BIGINT          NOT NULL,
    [ModifiedDate]                DATETIME        NOT NULL,
    [SubscriptionId]              INT             NULL,
    PRIMARY KEY CLUSTERED ([ClientSubscriptionId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[ClientTaxationAndLicenses]...';


GO
CREATE TABLE [dbo].[ClientTaxationAndLicenses] (
    [CAId]                        INT NOT NULL,
    [ClientTaxationAndLicensesId] INT NOT NULL
);


GO
PRINT N'Creating [dbo].[ClientTaxationAndLicensesDetails]...';


GO
CREATE TABLE [dbo].[ClientTaxationAndLicensesDetails] (
    [ClientTaxationAndLicensesId]    INT            IDENTITY (1, 1) NOT NULL,
    [TaxName]                        NVARCHAR (100) NULL,
    [LicenseNo]                      NVARCHAR (30)  NULL,
    [IsWithEffectFromDateApplicable] BIT            NOT NULL,
    [IsRenewalDateApplicable]        BIT            NOT NULL,
    [WithEffectFromDate]             DATETIME       NULL,
    [RenewalDate]                    DATETIME       NULL,
    [CreatedBy]                      BIGINT         NOT NULL,
    [CreatedDate]                    DATETIME       NOT NULL,
    [ModifiedBy]                     BIGINT         NOT NULL,
    [ModifiedDate]                   DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([ClientTaxationAndLicensesId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[ClientWeeklyOffDay]...';


GO
CREATE TABLE [dbo].[ClientWeeklyOffDay] (
    [ClientWeeklyOffDayId] INT      IDENTITY (1, 1) NOT NULL,
    [IsMonday]             BIT      NULL,
    [IsTuesday]            BIT      NULL,
    [IsWednesday]          BIT      NULL,
    [IsThursday]           BIT      NULL,
    [IsFriday]             BIT      NULL,
    [IsSaturday]           BIT      NULL,
    [IsSunday]             BIT      NULL,
    [WithEffectFromDate]   DATETIME NOT NULL,
    [WithEffectToDate]     DATETIME NOT NULL,
    [CAId]                 INT      NOT NULL,
    [CreatedBy]            BIGINT   NOT NULL,
    [CreatedDate]          DATETIME NOT NULL,
    [ModifiedBy]           BIGINT   NOT NULL,
    [ModifiedDate]         DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([ClientWeeklyOffDayId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[Commodities]...';


GO
CREATE TABLE [dbo].[Commodities] (
    [CommodityId]      INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (255) NOT NULL,
    [BotanicalName]    NVARCHAR (255) NOT NULL,
    [Image]            NVARCHAR (255) NULL,
    [IsActive]         BIT            NOT NULL,
    [CreatedBy]        BIGINT         NOT NULL,
    [CreatedDate]      DATETIME       NOT NULL,
    [ModifiedBy]       BIGINT         NULL,
    [ModifiedDate]     DATETIME       NULL,
    [CommodityClassId] INT            NULL,
    PRIMARY KEY CLUSTERED ([CommodityId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[CommodityClasses]...';


GO
CREATE TABLE [dbo].[CommodityClasses] (
    [CommodityClassId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (255) NOT NULL,
    [IsActive]         BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([CommodityClassId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[ContactDetails]...';


GO
CREATE TABLE [dbo].[ContactDetails] (
    [ContactDetailsId]   BIGINT         IDENTITY (1, 1) NOT NULL,
    [ContactNo]          NVARCHAR (15)  NOT NULL,
    [ContactNoType]      NVARCHAR (255) NULL,
    [CountryCallingCode] NVARCHAR (5)   NOT NULL,
    [STDCode]            NVARCHAR (10)  NULL,
    PRIMARY KEY CLUSTERED ([ContactDetailsId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[Country]...';


GO
CREATE TABLE [dbo].[Country] (
    [CountryId]          INT            IDENTITY (1, 1) NOT NULL,
    [CountryName]        NVARCHAR (50)  NOT NULL,
    [CallingCode]        NVARCHAR (10)  NOT NULL,
    [AgeStd]             INT            NOT NULL,
    [Currency]           NVARCHAR (20)  NOT NULL,
    [CurrencyCode]       NVARCHAR (10)  NOT NULL,
    [Symbol]             NVARCHAR (10)  NOT NULL,
    [TimeZone]           NVARCHAR (255) NOT NULL,
    [FinancialYearStart] NVARCHAR (50)  NOT NULL,
    [FinancialYearEnd]   NVARCHAR (50)  NOT NULL,
    [Status]             NVARCHAR (10)  NOT NULL,
    PRIMARY KEY CLUSTERED ([CountryId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[Designations]...';


GO
CREATE TABLE [dbo].[Designations] (
    [DesignationId]   INT            IDENTITY (1, 1) NOT NULL,
    [DesignationName] NVARCHAR (255) NOT NULL,
    [CAId]            INT            NULL,
    [CreatedBy]       BIGINT         NOT NULL,
    [CreatedDate]     DATETIME       NOT NULL,
    [ModifiedBy]      BIGINT         NULL,
    [ModifiedDate]    DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([DesignationId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[Districts]...';


GO
CREATE TABLE [dbo].[Districts] (
    [DistrictId]   INT            IDENTITY (1, 1) NOT NULL,
    [DistrictName] NVARCHAR (255) NOT NULL,
    [StateId]      INT            NULL,
    PRIMARY KEY CLUSTERED ([DistrictId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[EmailAttachments]...';


GO
CREATE TABLE [dbo].[EmailAttachments] (
    [EmailAttachmentId]  INT            IDENTITY (1, 1) NOT NULL,
    [Attachmentname]     NVARCHAR (100) NULL,
    [AttachmentLocation] NVARCHAR (100) NULL,
    [CreatedBy]          BIGINT         NOT NULL,
    [CreatedDate]        DATETIME       NOT NULL,
    [ModifiedBy]         BIGINT         NOT NULL,
    [ModifiedDate]       DATETIME       NOT NULL,
    [EmailMessageId]     INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([EmailAttachmentId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[EmailMessages]...';


GO
CREATE TABLE [dbo].[EmailMessages] (
    [EmailMessageId]    INT            IDENTITY (1, 1) NOT NULL,
    [MessageFrom]       NVARCHAR (100) NULL,
    [MessageTo]         NVARCHAR (100) NULL,
    [MessageSubject]    NVARCHAR (100) NULL,
    [MessageBody]       NVARCHAR (200) NULL,
    [MessageCC]         NVARCHAR (100) NULL,
    [MessageImportance] NVARCHAR (20)  NULL,
    [MessagePriority]   NVARCHAR (20)  NULL,
    [MessageFlag]       NVARCHAR (20)  NULL,
    [CAId]              INT            NOT NULL,
    [CreatedBy]         BIGINT         NOT NULL,
    [CreatedDate]       DATETIME       NOT NULL,
    [ModifiedBy]        BIGINT         NOT NULL,
    [ModifiedDate]      DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([EmailMessageId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[LabourChargeTypes]...';


GO
CREATE TABLE [dbo].[LabourChargeTypes] (
    [LabourChargeId] INT           IDENTITY (1, 1) NOT NULL,
    [LabourCharge]   NVARCHAR (50) NOT NULL,
    [CAId]           INT           NOT NULL,
    [CreatedBy]      BIGINT        NOT NULL,
    [CreatedDate]    DATETIME      NOT NULL,
    [ModifiedBy]     BIGINT        NULL,
    [ModifiedDate]   DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([LabourChargeId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[MeasuringUnit]...';


GO
CREATE TABLE [dbo].[MeasuringUnit] (
    [UnitId]          INT           IDENTITY (1, 1) NOT NULL,
    [UnitType]        NVARCHAR (20) NOT NULL,
    [MeasurementUnit] NVARCHAR (30) NOT NULL,
    [EquivalentUnit]  NVARCHAR (30) NOT NULL,
    [CAId]            INT           NOT NULL,
    [CreatedBy]       BIGINT        NOT NULL,
    [CreatedDate]     DATETIME      NOT NULL,
    [ModifiedBy]      BIGINT        NULL,
    [ModifiedDate]    DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([UnitId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[Menus]...';


GO
CREATE TABLE [dbo].[Menus] (
    [MenuId]           BIGINT         IDENTITY (1, 1) NOT NULL,
    [MenuName]         NVARCHAR (50)  NOT NULL,
    [MenuDescription]  NVARCHAR (255) NULL,
    [IsMenuActive]     BIT            NOT NULL,
    [IsAckcezioneUser] BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([MenuId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[ParentChildMenus]...';


GO
CREATE TABLE [dbo].[ParentChildMenus] (
    [MenuId]       BIGINT NOT NULL,
    [MenuOrder]    INT    NOT NULL,
    [ParentMenuId] BIGINT NULL,
    [ChildMenuId]  BIGINT NULL,
    PRIMARY KEY CLUSTERED ([MenuId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[RelationShips]...';


GO
CREATE TABLE [dbo].[RelationShips] (
    [RelationshipId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (255) NOT NULL,
    [CAId]           INT            NULL,
    [CreatedBy]      BIGINT         NOT NULL,
    [CreatedDate]    DATETIME       NOT NULL,
    [ModifiedBy]     BIGINT         NULL,
    [ModifiedDate]   DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([RelationshipId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[Roles]...';


GO
CREATE TABLE [dbo].[Roles] (
    [RoleId]                  INT            IDENTITY (1, 1) NOT NULL,
    [RoleName]                NVARCHAR (255) NOT NULL,
    [RoleGroup]               NVARCHAR (255) NULL,
    [IsApplicableForAckUsers] BIT            NULL,
    [IsAddApplicable]         BIT            NULL,
    [IsEditApplicable]        BIT            NULL,
    [IsViewApplicable]        BIT            NULL,
    [IsDeleteApplicable]      BIT            NULL,
    [IsPrintApplicable]       BIT            NULL,
    PRIMARY KEY CLUSTERED ([RoleId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[States]...';


GO
CREATE TABLE [dbo].[States] (
    [StateId]    INT           IDENTITY (1, 1) NOT NULL,
    [RegionType] NVARCHAR (50) NOT NULL,
    [RegionName] NVARCHAR (50) NOT NULL,
    [CountryId]  INT           NULL,
    PRIMARY KEY CLUSTERED ([StateId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[SubscriptionMaster]...';


GO
CREATE TABLE [dbo].[SubscriptionMaster] (
    [SubscriptionId]      INT             IDENTITY (1, 1) NOT NULL,
    [SubscriptionType]    NVARCHAR (15)   NOT NULL,
    [TotalNoOfUsers]      INT             NOT NULL,
    [NoOfEmployees]       INT             NOT NULL,
    [NoOfAuditors]        INT             NOT NULL,
    [NoOfAssociates]      INT             NOT NULL,
    [SubscriptionFees]    DECIMAL (19, 5) NOT NULL,
    [RenewalFeesPerAnnum] DECIMAL (19, 5) NOT NULL,
    [CreatedBy]           BIGINT          NOT NULL,
    [CreatedDate]         DATETIME        NOT NULL,
    [ModifiedBy]          BIGINT          NOT NULL,
    [ModifiedDate]        DATETIME        NOT NULL,
    PRIMARY KEY CLUSTERED ([SubscriptionId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[UserContacts]...';


GO
CREATE TABLE [dbo].[UserContacts] (
    [ContactDetailsId] BIGINT NOT NULL,
    [UserProfileId]    BIGINT NOT NULL
);


GO
PRINT N'Creating [dbo].[UserEmergencyContacts]...';


GO
CREATE TABLE [dbo].[UserEmergencyContacts] (
    [ContactDetailsId]             BIGINT NOT NULL,
    [UserEmergencyContactPersonId] BIGINT NOT NULL
);


GO
PRINT N'Creating [dbo].[UserGroupRolePermissions]...';


GO
CREATE TABLE [dbo].[UserGroupRolePermissions] (
    [UserGroupRolePermissionId] BIGINT IDENTITY (1, 1) NOT NULL,
    [AllowAdd]                  BIT    NOT NULL,
    [AllowEdit]                 BIT    NOT NULL,
    [AllowView]                 BIT    NOT NULL,
    [AllowDelete]               BIT    NOT NULL,
    [AllowPrint]                BIT    NOT NULL,
    [RoleId]                    INT    NOT NULL,
    PRIMARY KEY CLUSTERED ([UserGroupRolePermissionId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[UserGroupRoles]...';


GO
CREATE TABLE [dbo].[UserGroupRoles] (
    [UserGroupId]               INT    NOT NULL,
    [UserGroupRolePermissionId] BIGINT NOT NULL
);


GO
PRINT N'Creating [dbo].[UserGroups]...';


GO
CREATE TABLE [dbo].[UserGroups] (
    [UserGroupId]   INT            IDENTITY (1, 1) NOT NULL,
    [UserGroupName] NVARCHAR (255) NOT NULL,
    [Description]   NVARCHAR (255) NULL,
    [CAId]          INT            NULL,
    [IsActive]      BIT            NULL,
    [IsDeleted]     BIT            NULL,
    [AllowEdit]     BIT            NULL,
    [AllowDelete]   BIT            NULL,
    [CreatedBy]     BIGINT         NULL,
    [CreatedDate]   DATETIME       NULL,
    [ModifiedBy]    BIGINT         NULL,
    [ModifiedDate]  DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([UserGroupId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[UserProfiles]...';


GO
CREATE TABLE [dbo].[UserProfiles] (
    [UserProfileId]                BIGINT         IDENTITY (1, 1) NOT NULL,
    [Gender]                       NVARCHAR (255) NULL,
    [MaritalStatus]                NVARCHAR (255) NULL,
    [UID]                          NVARCHAR (30)  NULL,
    [PAN]                          NVARCHAR (20)  NULL,
    [PassportNo]                   NVARCHAR (20)  NULL,
    [PassportPlace]                NVARCHAR (255) NULL,
    [PassportValidFromDate]        DATETIME       NULL,
    [PassportValidToDate]          DATETIME       NULL,
    [BloodGroup]                   NVARCHAR (255) NULL,
    [DateOfJoining]                DATETIME       NULL,
    [PFNo]                         NVARCHAR (30)  NULL,
    [Email1]                       NVARCHAR (100) NULL,
    [Email2]                       NVARCHAR (100) NULL,
    [CreatedBy]                    BIGINT         NOT NULL,
    [CreatedDate]                  DATETIME       NOT NULL,
    [ModifiedBy]                   BIGINT         NULL,
    [ModifiedDate]                 DATETIME       NULL,
    [AddressId]                    BIGINT         NULL,
    [UserEmergencyContactPersonId] BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([UserProfileId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[UserRolePermissions]...';


GO
CREATE TABLE [dbo].[UserRolePermissions] (
    [UserRolePermissionId] BIGINT IDENTITY (1, 1) NOT NULL,
    [AllowAdd]             BIT    NOT NULL,
    [AllowEdit]            BIT    NOT NULL,
    [AllowView]            BIT    NOT NULL,
    [AllowDelete]          BIT    NOT NULL,
    [AllowPrint]           BIT    NOT NULL,
    [RoleId]               INT    NOT NULL,
    PRIMARY KEY CLUSTERED ([UserRolePermissionId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[UserRoles]...';


GO
CREATE TABLE [dbo].[UserRoles] (
    [UserId]               BIGINT NOT NULL,
    [UserRolePermissionId] BIGINT NOT NULL
);


GO
PRINT N'Creating [dbo].[Users]...';


GO
CREATE TABLE [dbo].[Users] (
    [UserId]                           BIGINT         IDENTITY (1, 1) NOT NULL,
    [Username]                         NVARCHAR (255) NOT NULL,
    [Title]                            NVARCHAR (5)   NOT NULL,
    [Name]                             NVARCHAR (255) NOT NULL,
    [Email]                            NVARCHAR (255) NOT NULL,
    [MobileNo]                         NVARCHAR (255) NOT NULL,
    [Password]                         NVARCHAR (255) NOT NULL,
    [MothersMaidenName]                NVARCHAR (255) NOT NULL,
    [CAId]                             INT            NULL,
    [CountryCode]                      NVARCHAR (255) NOT NULL,
    [CreatedBy]                        BIGINT         NOT NULL,
    [CreatedDate]                      DATETIME       NOT NULL,
    [DateOfBirth]                      DATETIME       NOT NULL,
    [FailedPasswordAttemptCount]       INT            NULL,
    [FailedPasswordAttemptWindowStart] DATETIME       NULL,
    [IsActive]                         BIT            NOT NULL,
    [IsLockedOut]                      BIT            NOT NULL,
    [IsOnLine]                         BIT            NOT NULL,
    [LastActivityDate]                 DATETIME       NULL,
    [LastLockedOutDate]                DATETIME       NULL,
    [LastLoginDate]                    DATETIME       NULL,
    [LastPasswordChangedDate]          DATETIME       NULL,
    [ModifiedBy]                       BIGINT         NULL,
    [ModifiedDate]                     DATETIME       NULL,
    [LastPassword]                     NVARCHAR (255) NULL,
    [SecondLastPassword]               NVARCHAR (255) NULL,
    [SecondLastPasswordChangedDate]    DATETIME       NULL,
    [IsDeleted]                        BIT            NOT NULL,
    [AllowEdit]                        BIT            NOT NULL,
    [AllowDelete]                      BIT            NOT NULL,
    [Image]                            NVARCHAR (255) NULL,
    [UserType]                         NVARCHAR (15)  NULL,
    [DesignationId]                    INT            NULL,
    [UserProfileId]                    BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[UsersEmergencyContactPerson]...';


GO
CREATE TABLE [dbo].[UsersEmergencyContactPerson] (
    [UserEmergencyContactPersonId] BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]                         NVARCHAR (255) NOT NULL,
    [Email1]                       NVARCHAR (100) NULL,
    [Email2]                       NVARCHAR (100) NULL,
    [CreatedBy]                    BIGINT         NOT NULL,
    [CreatedDate]                  DATETIME       NOT NULL,
    [ModifiedBy]                   BIGINT         NULL,
    [ModifiedDate]                 DATETIME       NULL,
    [AddressId]                    BIGINT         NULL,
    [RelationshipId]               INT            NULL,
    PRIMARY KEY CLUSTERED ([UserEmergencyContactPersonId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[UserUserGroups]...';


GO
CREATE TABLE [dbo].[UserUserGroups] (
    [UserGroupId] INT    NOT NULL,
    [UserId]      BIGINT NOT NULL
);


GO
PRINT N'Creating [dbo].[Zones]...';


GO
CREATE TABLE [dbo].[Zones] (
    [ZoneId]       BIGINT         IDENTITY (1, 1) NOT NULL,
    [ZoneFor]      NVARCHAR (20)  NOT NULL,
    [Name]         NVARCHAR (255) NOT NULL,
    [IsActive]     BIT            NOT NULL,
    [CAId]         INT            NOT NULL,
    [CreatedBy]    BIGINT         NOT NULL,
    [CreatedDate]  DATETIME       NOT NULL,
    [ModifiedBy]   BIGINT         NULL,
    [ModifiedDate] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([ZoneId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating On column: LoggedDate...';


GO
ALTER TABLE [dbo].[ActivityLogs]
    ADD DEFAULT (getdate()) FOR [LoggedDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[Addresses]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[Addresses]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[APMC]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[APMC]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[BankBranches]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[BankBranches]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[Banks]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[Banks]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[CityVillages]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[CityVillages]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[ClientBusinessConstitutionHistory]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[ClientCommoditiesHistory]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[ClientHolidayCalender]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[ClientHolidayCalender]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[ClientPartnerBankDetails]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[ClientPartnerBankDetails]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: DateOfBirth...';


GO
ALTER TABLE [dbo].[ClientPartnerDetails]
    ADD DEFAULT (getdate()) FOR [DateOfBirth];


GO
PRINT N'Creating On column: JoiningDate...';


GO
ALTER TABLE [dbo].[ClientPartnerDetails]
    ADD DEFAULT (getdate()) FOR [JoiningDate];


GO
PRINT N'Creating On column: RelievingDate...';


GO
ALTER TABLE [dbo].[ClientPartnerDetails]
    ADD DEFAULT (getdate()) FOR [RelievingDate];


GO
PRINT N'Creating On column: IssuedOn...';


GO
ALTER TABLE [dbo].[ClientPartnerDetails]
    ADD DEFAULT (getdate()) FOR [IssuedOn];


GO
PRINT N'Creating On column: ValidUpTo...';


GO
ALTER TABLE [dbo].[ClientPartnerDetails]
    ADD DEFAULT (getdate()) FOR [ValidUpTo];


GO
PRINT N'Creating On column: AsOndate...';


GO
ALTER TABLE [dbo].[ClientPartnerDetails]
    ADD DEFAULT (getdate()) FOR [AsOndate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[ClientPartnerDetails]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[ClientPartnerDetails]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: DateOfBirth...';


GO
ALTER TABLE [dbo].[ClientPartnerGuardianDetails]
    ADD DEFAULT (getdate()) FOR [DateOfBirth];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[ClientPartnerGuardianDetails]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[ClientPartnerGuardianDetails]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: JoiningDate...';


GO
ALTER TABLE [dbo].[ClientPartnerHistory]
    ADD DEFAULT (getdate()) FOR [JoiningDate];


GO
PRINT N'Creating On column: RelievingDate...';


GO
ALTER TABLE [dbo].[ClientPartnerHistory]
    ADD DEFAULT (getdate()) FOR [RelievingDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[ClientPartnerHistory]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: DateOfBirth...';


GO
ALTER TABLE [dbo].[ClientPartnerNomineeDetails]
    ADD DEFAULT (getdate()) FOR [DateOfBirth];


GO
PRINT N'Creating On column: IssuedOn...';


GO
ALTER TABLE [dbo].[ClientPartnerNomineeDetails]
    ADD DEFAULT (getdate()) FOR [IssuedOn];


GO
PRINT N'Creating On column: ValidUpTo...';


GO
ALTER TABLE [dbo].[ClientPartnerNomineeDetails]
    ADD DEFAULT (getdate()) FOR [ValidUpTo];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[ClientPartnerNomineeDetails]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[ClientPartnerNomineeDetails]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[ClientPhoneCharges]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[ClientPhoneCharges]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[ClientPhoneChargesHistory]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: DateOfBirth...';


GO
ALTER TABLE [dbo].[ClientPrimaryContactPerson]
    ADD DEFAULT (getdate()) FOR [DateOfBirth];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[ClientPrimaryContactPerson]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[ClientPrimaryContactPerson]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[ClientProfileChangeRequestFields]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[ClientProfileChangeRequests]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[Clients]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[Clients]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[ClientSisterConcern]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[ClientSisterConcern]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: ChequeDDTransactionDate...';


GO
ALTER TABLE [dbo].[ClientSubscriptionPaymentDetails]
    ADD DEFAULT (getdate()) FOR [ChequeDDTransactionDate];


GO
PRINT N'Creating On column: ChequeDDClearanceDates...';


GO
ALTER TABLE [dbo].[ClientSubscriptionPaymentDetails]
    ADD DEFAULT (getdate()) FOR [ChequeDDClearanceDates];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[ClientSubscriptionPaymentDetails]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[ClientSubscriptionPaymentDetails]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: SubscriptionPeriodFromDate...';


GO
ALTER TABLE [dbo].[ClientSubscriptions]
    ADD DEFAULT (getdate()) FOR [SubscriptionPeriodFromDate];


GO
PRINT N'Creating On column: SubscriptionPeriodToDate...';


GO
ALTER TABLE [dbo].[ClientSubscriptions]
    ADD DEFAULT (getdate()) FOR [SubscriptionPeriodToDate];


GO
PRINT N'Creating On column: ActivationDate...';


GO
ALTER TABLE [dbo].[ClientSubscriptions]
    ADD DEFAULT (getdate()) FOR [ActivationDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[ClientSubscriptions]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[ClientSubscriptions]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[ClientTaxationAndLicensesDetails]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[ClientTaxationAndLicensesDetails]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[ClientWeeklyOffDay]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[ClientWeeklyOffDay]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[Commodities]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[Commodities]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[Designations]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[Designations]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[EmailAttachments]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[EmailAttachments]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[EmailMessages]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[EmailMessages]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[LabourChargeTypes]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[LabourChargeTypes]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[MeasuringUnit]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[MeasuringUnit]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[RelationShips]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[RelationShips]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[SubscriptionMaster]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[SubscriptionMaster]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[UserGroups]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[UserGroups]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: PassportValidFromDate...';


GO
ALTER TABLE [dbo].[UserProfiles]
    ADD DEFAULT (getdate()) FOR [PassportValidFromDate];


GO
PRINT N'Creating On column: PassportValidToDate...';


GO
ALTER TABLE [dbo].[UserProfiles]
    ADD DEFAULT (getdate()) FOR [PassportValidToDate];


GO
PRINT N'Creating On column: DateOfJoining...';


GO
ALTER TABLE [dbo].[UserProfiles]
    ADD DEFAULT (getdate()) FOR [DateOfJoining];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[UserProfiles]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[UserProfiles]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[Users]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: DateOfBirth...';


GO
ALTER TABLE [dbo].[Users]
    ADD DEFAULT (getdate()) FOR [DateOfBirth];


GO
PRINT N'Creating On column: FailedPasswordAttemptWindowStart...';


GO
ALTER TABLE [dbo].[Users]
    ADD DEFAULT (getdate()) FOR [FailedPasswordAttemptWindowStart];


GO
PRINT N'Creating On column: LastActivityDate...';


GO
ALTER TABLE [dbo].[Users]
    ADD DEFAULT (getdate()) FOR [LastActivityDate];


GO
PRINT N'Creating On column: LastLockedOutDate...';


GO
ALTER TABLE [dbo].[Users]
    ADD DEFAULT (getdate()) FOR [LastLockedOutDate];


GO
PRINT N'Creating On column: LastLoginDate...';


GO
ALTER TABLE [dbo].[Users]
    ADD DEFAULT (getdate()) FOR [LastLoginDate];


GO
PRINT N'Creating On column: LastPasswordChangedDate...';


GO
ALTER TABLE [dbo].[Users]
    ADD DEFAULT (getdate()) FOR [LastPasswordChangedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[Users]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: SecondLastPasswordChangedDate...';


GO
ALTER TABLE [dbo].[Users]
    ADD DEFAULT (getdate()) FOR [SecondLastPasswordChangedDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[UsersEmergencyContactPerson]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[UsersEmergencyContactPerson]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating On column: CreatedDate...';


GO
ALTER TABLE [dbo].[Zones]
    ADD DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating On column: ModifiedDate...';


GO
ALTER TABLE [dbo].[Zones]
    ADD DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating FKEBD48A9EB3F09352...';


GO
ALTER TABLE [dbo].[Addresses] WITH NOCHECK
    ADD CONSTRAINT [FKEBD48A9EB3F09352] FOREIGN KEY ([CityVillageId]) REFERENCES [dbo].[CityVillages] ([CityVillageId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK9DA4BC9730A8D0DB...';


GO
ALTER TABLE [dbo].[APMC] WITH NOCHECK
    ADD CONSTRAINT [FK9DA4BC9730A8D0DB] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKFE634FC217810183...';


GO
ALTER TABLE [dbo].[APMCContacts] WITH NOCHECK
    ADD CONSTRAINT [FKFE634FC217810183] FOREIGN KEY ([ContactDetailsId]) REFERENCES [dbo].[ContactDetails] ([ContactDetailsId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKFE634FC2220FDEAE...';


GO
ALTER TABLE [dbo].[APMCContacts] WITH NOCHECK
    ADD CONSTRAINT [FKFE634FC2220FDEAE] FOREIGN KEY ([APMCId]) REFERENCES [dbo].[APMC] ([APMCId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK7621088117810183...';


GO
ALTER TABLE [dbo].[BankBranchContacts] WITH NOCHECK
    ADD CONSTRAINT [FK7621088117810183] FOREIGN KEY ([ContactDetailsId]) REFERENCES [dbo].[ContactDetails] ([ContactDetailsId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK762108815A66D8C5...';


GO
ALTER TABLE [dbo].[BankBranchContacts] WITH NOCHECK
    ADD CONSTRAINT [FK762108815A66D8C5] FOREIGN KEY ([BranchId]) REFERENCES [dbo].[BankBranches] ([BranchId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKCCCAB1B4200A2312...';


GO
ALTER TABLE [dbo].[BankBranches] WITH NOCHECK
    ADD CONSTRAINT [FKCCCAB1B4200A2312] FOREIGN KEY ([WeeklyOffDayId]) REFERENCES [dbo].[BankBranchWeeklyOffs] ([WeeklyOffDayId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKCCCAB1B430A8D0DB...';


GO
ALTER TABLE [dbo].[BankBranches] WITH NOCHECK
    ADD CONSTRAINT [FKCCCAB1B430A8D0DB] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKCCCAB1B4806E8EBB...';


GO
ALTER TABLE [dbo].[BankBranches] WITH NOCHECK
    ADD CONSTRAINT [FKCCCAB1B4806E8EBB] FOREIGN KEY ([WeeklyHalfDayId]) REFERENCES [dbo].[BankBranchWeeklyHalfDays] ([WeeklyHalfDayId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKCCCAB1B4B5CBFC9B...';


GO
ALTER TABLE [dbo].[BankBranches] WITH NOCHECK
    ADD CONSTRAINT [FKCCCAB1B4B5CBFC9B] FOREIGN KEY ([BankId]) REFERENCES [dbo].[Banks] ([BankId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKE2E64D00EE4A24FE...';


GO
ALTER TABLE [dbo].[CityVillages] WITH NOCHECK
    ADD CONSTRAINT [FKE2E64D00EE4A24FE] FOREIGN KEY ([DistrictId]) REFERENCES [dbo].[Districts] ([DistrictId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKBBD37C1EF3AA38D2...';


GO
ALTER TABLE [dbo].[ClientCommodities] WITH NOCHECK
    ADD CONSTRAINT [FKBBD37C1EF3AA38D2] FOREIGN KEY ([CAId]) REFERENCES [dbo].[Clients] ([CAId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKBBD37C1EFC01A4B3...';


GO
ALTER TABLE [dbo].[ClientCommodities] WITH NOCHECK
    ADD CONSTRAINT [FKBBD37C1EFC01A4B3] FOREIGN KEY ([CommodityClassId]) REFERENCES [dbo].[CommodityClasses] ([CommodityClassId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKEE45DE5817810183...';


GO
ALTER TABLE [dbo].[ClientContacts] WITH NOCHECK
    ADD CONSTRAINT [FKEE45DE5817810183] FOREIGN KEY ([ContactDetailsId]) REFERENCES [dbo].[ContactDetails] ([ContactDetailsId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKEE45DE58F3AA38D2...';


GO
ALTER TABLE [dbo].[ClientContacts] WITH NOCHECK
    ADD CONSTRAINT [FKEE45DE58F3AA38D2] FOREIGN KEY ([CAId]) REFERENCES [dbo].[Clients] ([CAId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK58862FC317810183...';


GO
ALTER TABLE [dbo].[ClientPartnerBankContactPersonContacts] WITH NOCHECK
    ADD CONSTRAINT [FK58862FC317810183] FOREIGN KEY ([ContactDetailsId]) REFERENCES [dbo].[ContactDetails] ([ContactDetailsId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK58862FC36A48C195...';


GO
ALTER TABLE [dbo].[ClientPartnerBankContactPersonContacts] WITH NOCHECK
    ADD CONSTRAINT [FK58862FC36A48C195] FOREIGN KEY ([ClientPartnerBankId]) REFERENCES [dbo].[ClientPartnerBankDetails] ([ClientPartnerBankId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK5A3B3DE35A66D8C5...';


GO
ALTER TABLE [dbo].[ClientPartnerBankDetails] WITH NOCHECK
    ADD CONSTRAINT [FK5A3B3DE35A66D8C5] FOREIGN KEY ([BranchId]) REFERENCES [dbo].[BankBranches] ([BranchId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK5A3B3DE3934218F7...';


GO
ALTER TABLE [dbo].[ClientPartnerBankDetails] WITH NOCHECK
    ADD CONSTRAINT [FK5A3B3DE3934218F7] FOREIGN KEY ([DesignationId]) REFERENCES [dbo].[Designations] ([DesignationId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK20EE27283078D16...';


GO
ALTER TABLE [dbo].[ClientPartnerBanks] WITH NOCHECK
    ADD CONSTRAINT [FK20EE27283078D16] FOREIGN KEY ([PartnerId]) REFERENCES [dbo].[ClientPartnerDetails] ([PartnerId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK20EE27286A48C195...';


GO
ALTER TABLE [dbo].[ClientPartnerBanks] WITH NOCHECK
    ADD CONSTRAINT [FK20EE27286A48C195] FOREIGN KEY ([ClientPartnerBankId]) REFERENCES [dbo].[ClientPartnerBankDetails] ([ClientPartnerBankId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK262FA82417810183...';


GO
ALTER TABLE [dbo].[ClientPartnerContacts] WITH NOCHECK
    ADD CONSTRAINT [FK262FA82417810183] FOREIGN KEY ([ContactDetailsId]) REFERENCES [dbo].[ContactDetails] ([ContactDetailsId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK262FA8243078D16...';


GO
ALTER TABLE [dbo].[ClientPartnerContacts] WITH NOCHECK
    ADD CONSTRAINT [FK262FA8243078D16] FOREIGN KEY ([PartnerId]) REFERENCES [dbo].[ClientPartnerDetails] ([PartnerId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK667CA0E114ED1D9B...';


GO
ALTER TABLE [dbo].[ClientPartnerDetails] WITH NOCHECK
    ADD CONSTRAINT [FK667CA0E114ED1D9B] FOREIGN KEY ([ClientPartnerNomineeId]) REFERENCES [dbo].[ClientPartnerNomineeDetails] ([ClientPartnerNomineeId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK667CA0E130A8D0DB...';


GO
ALTER TABLE [dbo].[ClientPartnerDetails] WITH NOCHECK
    ADD CONSTRAINT [FK667CA0E130A8D0DB] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK667CA0E16837C633...';


GO
ALTER TABLE [dbo].[ClientPartnerDetails] WITH NOCHECK
    ADD CONSTRAINT [FK667CA0E16837C633] FOREIGN KEY ([ClientPartnerGuardianId]) REFERENCES [dbo].[ClientPartnerGuardianDetails] ([ClientPartnerGuardianId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK667CA0E1934218F7...';


GO
ALTER TABLE [dbo].[ClientPartnerDetails] WITH NOCHECK
    ADD CONSTRAINT [FK667CA0E1934218F7] FOREIGN KEY ([DesignationId]) REFERENCES [dbo].[Designations] ([DesignationId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKE3EDB7D317810183...';


GO
ALTER TABLE [dbo].[ClientPartnerGuardianContacts] WITH NOCHECK
    ADD CONSTRAINT [FKE3EDB7D317810183] FOREIGN KEY ([ContactDetailsId]) REFERENCES [dbo].[ContactDetails] ([ContactDetailsId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKE3EDB7D36837C633...';


GO
ALTER TABLE [dbo].[ClientPartnerGuardianContacts] WITH NOCHECK
    ADD CONSTRAINT [FKE3EDB7D36837C633] FOREIGN KEY ([ClientPartnerGuardianId]) REFERENCES [dbo].[ClientPartnerGuardianDetails] ([ClientPartnerGuardianId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK7F595BBC30A8D0DB...';


GO
ALTER TABLE [dbo].[ClientPartnerGuardianDetails] WITH NOCHECK
    ADD CONSTRAINT [FK7F595BBC30A8D0DB] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK7F595BBCE2720DC7...';


GO
ALTER TABLE [dbo].[ClientPartnerGuardianDetails] WITH NOCHECK
    ADD CONSTRAINT [FK7F595BBCE2720DC7] FOREIGN KEY ([RelationshipId]) REFERENCES [dbo].[RelationShips] ([RelationshipId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKB6C67FDB14ED1D9B...';


GO
ALTER TABLE [dbo].[ClientPartnerNomineeContacts] WITH NOCHECK
    ADD CONSTRAINT [FKB6C67FDB14ED1D9B] FOREIGN KEY ([ClientPartnerNomineeId]) REFERENCES [dbo].[ClientPartnerNomineeDetails] ([ClientPartnerNomineeId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKB6C67FDB17810183...';


GO
ALTER TABLE [dbo].[ClientPartnerNomineeContacts] WITH NOCHECK
    ADD CONSTRAINT [FKB6C67FDB17810183] FOREIGN KEY ([ContactDetailsId]) REFERENCES [dbo].[ContactDetails] ([ContactDetailsId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK4E3D921E30A8D0DB...';


GO
ALTER TABLE [dbo].[ClientPartnerNomineeDetails] WITH NOCHECK
    ADD CONSTRAINT [FK4E3D921E30A8D0DB] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK4E3D921EE2720DC7...';


GO
ALTER TABLE [dbo].[ClientPartnerNomineeDetails] WITH NOCHECK
    ADD CONSTRAINT [FK4E3D921EE2720DC7] FOREIGN KEY ([RelationshipId]) REFERENCES [dbo].[RelationShips] ([RelationshipId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKF4CF05863078D16...';


GO
ALTER TABLE [dbo].[ClientPartners] WITH NOCHECK
    ADD CONSTRAINT [FKF4CF05863078D16] FOREIGN KEY ([PartnerId]) REFERENCES [dbo].[ClientPartnerDetails] ([PartnerId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKF4CF0586F3AA38D2...';


GO
ALTER TABLE [dbo].[ClientPartners] WITH NOCHECK
    ADD CONSTRAINT [FKF4CF0586F3AA38D2] FOREIGN KEY ([CAId]) REFERENCES [dbo].[Clients] ([CAId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK277CD4DE30A8D0DB...';


GO
ALTER TABLE [dbo].[ClientPrimaryContactPerson] WITH NOCHECK
    ADD CONSTRAINT [FK277CD4DE30A8D0DB] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK277CD4DE934218F7...';


GO
ALTER TABLE [dbo].[ClientPrimaryContactPerson] WITH NOCHECK
    ADD CONSTRAINT [FK277CD4DE934218F7] FOREIGN KEY ([DesignationId]) REFERENCES [dbo].[Designations] ([DesignationId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK68CC536C17810183...';


GO
ALTER TABLE [dbo].[ClientPrimaryContacts] WITH NOCHECK
    ADD CONSTRAINT [FK68CC536C17810183] FOREIGN KEY ([ContactDetailsId]) REFERENCES [dbo].[ContactDetails] ([ContactDetailsId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK68CC536CEB56B3B4...';


GO
ALTER TABLE [dbo].[ClientPrimaryContacts] WITH NOCHECK
    ADD CONSTRAINT [FK68CC536CEB56B3B4] FOREIGN KEY ([CAPrimaryContactPersonId]) REFERENCES [dbo].[ClientPrimaryContactPerson] ([CAPrimaryContactPersonId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKF91D23544291588...';


GO
ALTER TABLE [dbo].[ClientProfileChangeRequests] WITH NOCHECK
    ADD CONSTRAINT [FKF91D23544291588] FOREIGN KEY ([EmailMessageId]) REFERENCES [dbo].[EmailMessages] ([EmailMessageId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK521471F51E8AD6B8...';


GO
ALTER TABLE [dbo].[ClientProfileChangeRequestsWithFields] WITH NOCHECK
    ADD CONSTRAINT [FK521471F51E8AD6B8] FOREIGN KEY ([ClientProfileCRFieldId]) REFERENCES [dbo].[ClientProfileChangeRequestFields] ([ClientProfileCRFieldId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK521471F564CA5920...';


GO
ALTER TABLE [dbo].[ClientProfileChangeRequestsWithFields] WITH NOCHECK
    ADD CONSTRAINT [FK521471F564CA5920] FOREIGN KEY ([RequestId]) REFERENCES [dbo].[ClientProfileChangeRequests] ([RequestId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK3A1EFBEA1E36A4A1...';


GO
ALTER TABLE [dbo].[Clients] WITH NOCHECK
    ADD CONSTRAINT [FK3A1EFBEA1E36A4A1] FOREIGN KEY ([ClientSubscriptionId]) REFERENCES [dbo].[ClientSubscriptions] ([ClientSubscriptionId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK3A1EFBEA220FDEAE...';


GO
ALTER TABLE [dbo].[Clients] WITH NOCHECK
    ADD CONSTRAINT [FK3A1EFBEA220FDEAE] FOREIGN KEY ([APMCId]) REFERENCES [dbo].[APMC] ([APMCId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK3A1EFBEA2AE5D7C9...';


GO
ALTER TABLE [dbo].[Clients] WITH NOCHECK
    ADD CONSTRAINT [FK3A1EFBEA2AE5D7C9] FOREIGN KEY ([ClientPhoneChargesId]) REFERENCES [dbo].[ClientPhoneCharges] ([ClientPhoneChargesId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK3A1EFBEA30A8D0DB...';


GO
ALTER TABLE [dbo].[Clients] WITH NOCHECK
    ADD CONSTRAINT [FK3A1EFBEA30A8D0DB] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK3A1EFBEA4ACC66F9...';


GO
ALTER TABLE [dbo].[Clients] WITH NOCHECK
    ADD CONSTRAINT [FK3A1EFBEA4ACC66F9] FOREIGN KEY ([BusinessConstitutionId]) REFERENCES [dbo].[BusinessConstitutions] ([BusinessConstitutionId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK3A1EFBEAEB56B3B4...';


GO
ALTER TABLE [dbo].[Clients] WITH NOCHECK
    ADD CONSTRAINT [FK3A1EFBEAEB56B3B4] FOREIGN KEY ([CAPrimaryContactPersonId]) REFERENCES [dbo].[ClientPrimaryContactPerson] ([CAPrimaryContactPersonId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKDEC4948493DBA7F3...';


GO
ALTER TABLE [dbo].[ClientSisterConcerns] WITH NOCHECK
    ADD CONSTRAINT [FKDEC4948493DBA7F3] FOREIGN KEY ([ClientSisterConcernId]) REFERENCES [dbo].[ClientSisterConcern] ([ClientSisterConcernId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKDEC49484F3AA38D2...';


GO
ALTER TABLE [dbo].[ClientSisterConcerns] WITH NOCHECK
    ADD CONSTRAINT [FKDEC49484F3AA38D2] FOREIGN KEY ([CAId]) REFERENCES [dbo].[Clients] ([CAId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK13B864905A66D8C5...';


GO
ALTER TABLE [dbo].[ClientSubscriptionPaymentDetails] WITH NOCHECK
    ADD CONSTRAINT [FK13B864905A66D8C5] FOREIGN KEY ([BranchId]) REFERENCES [dbo].[BankBranches] ([BranchId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKEB394DEB1E36A4A1...';


GO
ALTER TABLE [dbo].[ClientSubscriptionPayments] WITH NOCHECK
    ADD CONSTRAINT [FKEB394DEB1E36A4A1] FOREIGN KEY ([ClientSubscriptionId]) REFERENCES [dbo].[ClientSubscriptions] ([ClientSubscriptionId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKEB394DEB5551111C...';


GO
ALTER TABLE [dbo].[ClientSubscriptionPayments] WITH NOCHECK
    ADD CONSTRAINT [FKEB394DEB5551111C] FOREIGN KEY ([CASubscriptionPaymentDetailsId]) REFERENCES [dbo].[ClientSubscriptionPaymentDetails] ([CASubscriptionPaymentDetailsId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKAD39CFB93E88979F...';


GO
ALTER TABLE [dbo].[ClientSubscriptions] WITH NOCHECK
    ADD CONSTRAINT [FKAD39CFB93E88979F] FOREIGN KEY ([SubscriptionId]) REFERENCES [dbo].[SubscriptionMaster] ([SubscriptionId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKECF75108AE81B485...';


GO
ALTER TABLE [dbo].[ClientTaxationAndLicenses] WITH NOCHECK
    ADD CONSTRAINT [FKECF75108AE81B485] FOREIGN KEY ([ClientTaxationAndLicensesId]) REFERENCES [dbo].[ClientTaxationAndLicensesDetails] ([ClientTaxationAndLicensesId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKECF75108F3AA38D2...';


GO
ALTER TABLE [dbo].[ClientTaxationAndLicenses] WITH NOCHECK
    ADD CONSTRAINT [FKECF75108F3AA38D2] FOREIGN KEY ([CAId]) REFERENCES [dbo].[Clients] ([CAId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKD9D9B611FC01A4B3...';


GO
ALTER TABLE [dbo].[Commodities] WITH NOCHECK
    ADD CONSTRAINT [FKD9D9B611FC01A4B3] FOREIGN KEY ([CommodityClassId]) REFERENCES [dbo].[CommodityClasses] ([CommodityClassId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKEF9C46696BB1821E...';


GO
ALTER TABLE [dbo].[Districts] WITH NOCHECK
    ADD CONSTRAINT [FKEF9C46696BB1821E] FOREIGN KEY ([StateId]) REFERENCES [dbo].[States] ([StateId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKD3D773844291588...';


GO
ALTER TABLE [dbo].[EmailAttachments] WITH NOCHECK
    ADD CONSTRAINT [FKD3D773844291588] FOREIGN KEY ([EmailMessageId]) REFERENCES [dbo].[EmailMessages] ([EmailMessageId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKFB0619BC40604BAC...';


GO
ALTER TABLE [dbo].[ParentChildMenus] WITH NOCHECK
    ADD CONSTRAINT [FKFB0619BC40604BAC] FOREIGN KEY ([ChildMenuId]) REFERENCES [dbo].[Menus] ([MenuId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKFB0619BC7C97897E...';


GO
ALTER TABLE [dbo].[ParentChildMenus] WITH NOCHECK
    ADD CONSTRAINT [FKFB0619BC7C97897E] FOREIGN KEY ([MenuId]) REFERENCES [dbo].[Menus] ([MenuId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKFB0619BCC6318172...';


GO
ALTER TABLE [dbo].[ParentChildMenus] WITH NOCHECK
    ADD CONSTRAINT [FKFB0619BCC6318172] FOREIGN KEY ([ParentMenuId]) REFERENCES [dbo].[Menus] ([MenuId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK74CFC3C0423BF3B4...';


GO
ALTER TABLE [dbo].[States] WITH NOCHECK
    ADD CONSTRAINT [FK74CFC3C0423BF3B4] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Country] ([CountryId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK216270F817810183...';


GO
ALTER TABLE [dbo].[UserContacts] WITH NOCHECK
    ADD CONSTRAINT [FK216270F817810183] FOREIGN KEY ([ContactDetailsId]) REFERENCES [dbo].[ContactDetails] ([ContactDetailsId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK216270F885BBA2FF...';


GO
ALTER TABLE [dbo].[UserContacts] WITH NOCHECK
    ADD CONSTRAINT [FK216270F885BBA2FF] FOREIGN KEY ([UserProfileId]) REFERENCES [dbo].[UserProfiles] ([UserProfileId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKED9B3FC717810183...';


GO
ALTER TABLE [dbo].[UserEmergencyContacts] WITH NOCHECK
    ADD CONSTRAINT [FKED9B3FC717810183] FOREIGN KEY ([ContactDetailsId]) REFERENCES [dbo].[ContactDetails] ([ContactDetailsId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKED9B3FC7A82E65...';


GO
ALTER TABLE [dbo].[UserEmergencyContacts] WITH NOCHECK
    ADD CONSTRAINT [FKED9B3FC7A82E65] FOREIGN KEY ([UserEmergencyContactPersonId]) REFERENCES [dbo].[UsersEmergencyContactPerson] ([UserEmergencyContactPersonId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKDD28E238E80F2A03...';


GO
ALTER TABLE [dbo].[UserGroupRolePermissions] WITH NOCHECK
    ADD CONSTRAINT [FKDD28E238E80F2A03] FOREIGN KEY ([UserGroupRolePermissionId]) REFERENCES [dbo].[UserGroupRolePermissions] ([UserGroupRolePermissionId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKDD28E238F1130D47...';


GO
ALTER TABLE [dbo].[UserGroupRolePermissions] WITH NOCHECK
    ADD CONSTRAINT [FKDD28E238F1130D47] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([RoleId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK54344AAD6E3B9873...';


GO
ALTER TABLE [dbo].[UserGroupRoles] WITH NOCHECK
    ADD CONSTRAINT [FK54344AAD6E3B9873] FOREIGN KEY ([UserGroupId]) REFERENCES [dbo].[UserGroups] ([UserGroupId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK54344AADE80F2A03...';


GO
ALTER TABLE [dbo].[UserGroupRoles] WITH NOCHECK
    ADD CONSTRAINT [FK54344AADE80F2A03] FOREIGN KEY ([UserGroupRolePermissionId]) REFERENCES [dbo].[UserGroupRolePermissions] ([UserGroupRolePermissionId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK15F395D130A8D0DB...';


GO
ALTER TABLE [dbo].[UserProfiles] WITH NOCHECK
    ADD CONSTRAINT [FK15F395D130A8D0DB] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK15F395D1A82E65...';


GO
ALTER TABLE [dbo].[UserProfiles] WITH NOCHECK
    ADD CONSTRAINT [FK15F395D1A82E65] FOREIGN KEY ([UserEmergencyContactPersonId]) REFERENCES [dbo].[UsersEmergencyContactPerson] ([UserEmergencyContactPersonId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK4256C649451CEFCF...';


GO
ALTER TABLE [dbo].[UserRolePermissions] WITH NOCHECK
    ADD CONSTRAINT [FK4256C649451CEFCF] FOREIGN KEY ([UserRolePermissionId]) REFERENCES [dbo].[UserRolePermissions] ([UserRolePermissionId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK4256C649F1130D47...';


GO
ALTER TABLE [dbo].[UserRolePermissions] WITH NOCHECK
    ADD CONSTRAINT [FK4256C649F1130D47] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([RoleId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKDFBBDE7E451CEFCF...';


GO
ALTER TABLE [dbo].[UserRoles] WITH NOCHECK
    ADD CONSTRAINT [FKDFBBDE7E451CEFCF] FOREIGN KEY ([UserRolePermissionId]) REFERENCES [dbo].[UserRolePermissions] ([UserRolePermissionId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FKDFBBDE7E93C772A1...';


GO
ALTER TABLE [dbo].[UserRoles] WITH NOCHECK
    ADD CONSTRAINT [FKDFBBDE7E93C772A1] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK617D3C3A85BBA2FF...';


GO
ALTER TABLE [dbo].[Users] WITH NOCHECK
    ADD CONSTRAINT [FK617D3C3A85BBA2FF] FOREIGN KEY ([UserProfileId]) REFERENCES [dbo].[UserProfiles] ([UserProfileId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK617D3C3A934218F7...';


GO
ALTER TABLE [dbo].[Users] WITH NOCHECK
    ADD CONSTRAINT [FK617D3C3A934218F7] FOREIGN KEY ([DesignationId]) REFERENCES [dbo].[Designations] ([DesignationId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK5B1BEC2430A8D0DB...';


GO
ALTER TABLE [dbo].[UsersEmergencyContactPerson] WITH NOCHECK
    ADD CONSTRAINT [FK5B1BEC2430A8D0DB] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK5B1BEC24E2720DC7...';


GO
ALTER TABLE [dbo].[UsersEmergencyContactPerson] WITH NOCHECK
    ADD CONSTRAINT [FK5B1BEC24E2720DC7] FOREIGN KEY ([RelationshipId]) REFERENCES [dbo].[RelationShips] ([RelationshipId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK969171B26E3B9873...';


GO
ALTER TABLE [dbo].[UserUserGroups] WITH NOCHECK
    ADD CONSTRAINT [FK969171B26E3B9873] FOREIGN KEY ([UserGroupId]) REFERENCES [dbo].[UserGroups] ([UserGroupId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK969171B293C772A1...';


GO
ALTER TABLE [dbo].[UserUserGroups] WITH NOCHECK
    ADD CONSTRAINT [FK969171B293C772A1] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating [dbo].[vwUserUserGroupRolePermissions]...';


GO

CREATE VIEW [dbo].[vwUserUserGroupRolePermissions] 
AS
	SELECT d.UserID AS UserID, RoleId, 
			cast(max(cast(a.AllowAdd as int)) as bit) AS AllowAdd, 
			cast(max(cast (a.Allowedit as int)) as bit) AS AllowEdit, 
			cast(max(cast(a.allowview as int)) as bit) AS AllowView, 
			cast(max(cast(a.allowdelete as int)) as bit) AS AllowDelete, 
			cast(max(cast (a.allowprint as int)) as bit) AS AllowPrint
	FROM UserGroupRolePermissions a
	INNER JOIN UserGroupRoles b ON a.UserGroupRolePermissionId = b.UserGroupRolePermissionId
	INNER JOIN UserUserGroups d ON d.UserGroupId = b.UserGroupId
	INNER JOIN Users u ON d.UserId = u.UserId
	GROUP BY d.UserID,Username, a.RoleID
GO
PRINT N'Creating Permission...';


GO
GRANT CONNECT TO [NT AUTHORITY\NETWORK SERVICE]
    AS [dbo];


GO
-- Refactoring step to update target server with deployed transaction logs
CREATE TABLE  [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
GO
sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
GO

GO
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

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Addresses] WITH CHECK CHECK CONSTRAINT [FKEBD48A9EB3F09352];

ALTER TABLE [dbo].[APMC] WITH CHECK CHECK CONSTRAINT [FK9DA4BC9730A8D0DB];

ALTER TABLE [dbo].[APMCContacts] WITH CHECK CHECK CONSTRAINT [FKFE634FC217810183];

ALTER TABLE [dbo].[APMCContacts] WITH CHECK CHECK CONSTRAINT [FKFE634FC2220FDEAE];

ALTER TABLE [dbo].[BankBranchContacts] WITH CHECK CHECK CONSTRAINT [FK7621088117810183];

ALTER TABLE [dbo].[BankBranchContacts] WITH CHECK CHECK CONSTRAINT [FK762108815A66D8C5];

ALTER TABLE [dbo].[BankBranches] WITH CHECK CHECK CONSTRAINT [FKCCCAB1B4200A2312];

ALTER TABLE [dbo].[BankBranches] WITH CHECK CHECK CONSTRAINT [FKCCCAB1B430A8D0DB];

ALTER TABLE [dbo].[BankBranches] WITH CHECK CHECK CONSTRAINT [FKCCCAB1B4806E8EBB];

ALTER TABLE [dbo].[BankBranches] WITH CHECK CHECK CONSTRAINT [FKCCCAB1B4B5CBFC9B];

ALTER TABLE [dbo].[CityVillages] WITH CHECK CHECK CONSTRAINT [FKE2E64D00EE4A24FE];

ALTER TABLE [dbo].[ClientCommodities] WITH CHECK CHECK CONSTRAINT [FKBBD37C1EF3AA38D2];

ALTER TABLE [dbo].[ClientCommodities] WITH CHECK CHECK CONSTRAINT [FKBBD37C1EFC01A4B3];

ALTER TABLE [dbo].[ClientContacts] WITH CHECK CHECK CONSTRAINT [FKEE45DE5817810183];

ALTER TABLE [dbo].[ClientContacts] WITH CHECK CHECK CONSTRAINT [FKEE45DE58F3AA38D2];

ALTER TABLE [dbo].[ClientPartnerBankContactPersonContacts] WITH CHECK CHECK CONSTRAINT [FK58862FC317810183];

ALTER TABLE [dbo].[ClientPartnerBankContactPersonContacts] WITH CHECK CHECK CONSTRAINT [FK58862FC36A48C195];

ALTER TABLE [dbo].[ClientPartnerBankDetails] WITH CHECK CHECK CONSTRAINT [FK5A3B3DE35A66D8C5];

ALTER TABLE [dbo].[ClientPartnerBankDetails] WITH CHECK CHECK CONSTRAINT [FK5A3B3DE3934218F7];

ALTER TABLE [dbo].[ClientPartnerBanks] WITH CHECK CHECK CONSTRAINT [FK20EE27283078D16];

ALTER TABLE [dbo].[ClientPartnerBanks] WITH CHECK CHECK CONSTRAINT [FK20EE27286A48C195];

ALTER TABLE [dbo].[ClientPartnerContacts] WITH CHECK CHECK CONSTRAINT [FK262FA82417810183];

ALTER TABLE [dbo].[ClientPartnerContacts] WITH CHECK CHECK CONSTRAINT [FK262FA8243078D16];

ALTER TABLE [dbo].[ClientPartnerDetails] WITH CHECK CHECK CONSTRAINT [FK667CA0E114ED1D9B];

ALTER TABLE [dbo].[ClientPartnerDetails] WITH CHECK CHECK CONSTRAINT [FK667CA0E130A8D0DB];

ALTER TABLE [dbo].[ClientPartnerDetails] WITH CHECK CHECK CONSTRAINT [FK667CA0E16837C633];

ALTER TABLE [dbo].[ClientPartnerDetails] WITH CHECK CHECK CONSTRAINT [FK667CA0E1934218F7];

ALTER TABLE [dbo].[ClientPartnerGuardianContacts] WITH CHECK CHECK CONSTRAINT [FKE3EDB7D317810183];

ALTER TABLE [dbo].[ClientPartnerGuardianContacts] WITH CHECK CHECK CONSTRAINT [FKE3EDB7D36837C633];

ALTER TABLE [dbo].[ClientPartnerGuardianDetails] WITH CHECK CHECK CONSTRAINT [FK7F595BBC30A8D0DB];

ALTER TABLE [dbo].[ClientPartnerGuardianDetails] WITH CHECK CHECK CONSTRAINT [FK7F595BBCE2720DC7];

ALTER TABLE [dbo].[ClientPartnerNomineeContacts] WITH CHECK CHECK CONSTRAINT [FKB6C67FDB14ED1D9B];

ALTER TABLE [dbo].[ClientPartnerNomineeContacts] WITH CHECK CHECK CONSTRAINT [FKB6C67FDB17810183];

ALTER TABLE [dbo].[ClientPartnerNomineeDetails] WITH CHECK CHECK CONSTRAINT [FK4E3D921E30A8D0DB];

ALTER TABLE [dbo].[ClientPartnerNomineeDetails] WITH CHECK CHECK CONSTRAINT [FK4E3D921EE2720DC7];

ALTER TABLE [dbo].[ClientPartners] WITH CHECK CHECK CONSTRAINT [FKF4CF05863078D16];

ALTER TABLE [dbo].[ClientPartners] WITH CHECK CHECK CONSTRAINT [FKF4CF0586F3AA38D2];

ALTER TABLE [dbo].[ClientPrimaryContactPerson] WITH CHECK CHECK CONSTRAINT [FK277CD4DE30A8D0DB];

ALTER TABLE [dbo].[ClientPrimaryContactPerson] WITH CHECK CHECK CONSTRAINT [FK277CD4DE934218F7];

ALTER TABLE [dbo].[ClientPrimaryContacts] WITH CHECK CHECK CONSTRAINT [FK68CC536C17810183];

ALTER TABLE [dbo].[ClientPrimaryContacts] WITH CHECK CHECK CONSTRAINT [FK68CC536CEB56B3B4];

ALTER TABLE [dbo].[ClientProfileChangeRequests] WITH CHECK CHECK CONSTRAINT [FKF91D23544291588];

ALTER TABLE [dbo].[ClientProfileChangeRequestsWithFields] WITH CHECK CHECK CONSTRAINT [FK521471F51E8AD6B8];

ALTER TABLE [dbo].[ClientProfileChangeRequestsWithFields] WITH CHECK CHECK CONSTRAINT [FK521471F564CA5920];

ALTER TABLE [dbo].[Clients] WITH CHECK CHECK CONSTRAINT [FK3A1EFBEA1E36A4A1];

ALTER TABLE [dbo].[Clients] WITH CHECK CHECK CONSTRAINT [FK3A1EFBEA220FDEAE];

ALTER TABLE [dbo].[Clients] WITH CHECK CHECK CONSTRAINT [FK3A1EFBEA2AE5D7C9];

ALTER TABLE [dbo].[Clients] WITH CHECK CHECK CONSTRAINT [FK3A1EFBEA30A8D0DB];

ALTER TABLE [dbo].[Clients] WITH CHECK CHECK CONSTRAINT [FK3A1EFBEA4ACC66F9];

ALTER TABLE [dbo].[Clients] WITH CHECK CHECK CONSTRAINT [FK3A1EFBEAEB56B3B4];

ALTER TABLE [dbo].[ClientSisterConcerns] WITH CHECK CHECK CONSTRAINT [FKDEC4948493DBA7F3];

ALTER TABLE [dbo].[ClientSisterConcerns] WITH CHECK CHECK CONSTRAINT [FKDEC49484F3AA38D2];

ALTER TABLE [dbo].[ClientSubscriptionPaymentDetails] WITH CHECK CHECK CONSTRAINT [FK13B864905A66D8C5];

ALTER TABLE [dbo].[ClientSubscriptionPayments] WITH CHECK CHECK CONSTRAINT [FKEB394DEB1E36A4A1];

ALTER TABLE [dbo].[ClientSubscriptionPayments] WITH CHECK CHECK CONSTRAINT [FKEB394DEB5551111C];

ALTER TABLE [dbo].[ClientSubscriptions] WITH CHECK CHECK CONSTRAINT [FKAD39CFB93E88979F];

ALTER TABLE [dbo].[ClientTaxationAndLicenses] WITH CHECK CHECK CONSTRAINT [FKECF75108AE81B485];

ALTER TABLE [dbo].[ClientTaxationAndLicenses] WITH CHECK CHECK CONSTRAINT [FKECF75108F3AA38D2];

ALTER TABLE [dbo].[Commodities] WITH CHECK CHECK CONSTRAINT [FKD9D9B611FC01A4B3];

ALTER TABLE [dbo].[Districts] WITH CHECK CHECK CONSTRAINT [FKEF9C46696BB1821E];

ALTER TABLE [dbo].[EmailAttachments] WITH CHECK CHECK CONSTRAINT [FKD3D773844291588];

ALTER TABLE [dbo].[ParentChildMenus] WITH CHECK CHECK CONSTRAINT [FKFB0619BC40604BAC];

ALTER TABLE [dbo].[ParentChildMenus] WITH CHECK CHECK CONSTRAINT [FKFB0619BC7C97897E];

ALTER TABLE [dbo].[ParentChildMenus] WITH CHECK CHECK CONSTRAINT [FKFB0619BCC6318172];

ALTER TABLE [dbo].[States] WITH CHECK CHECK CONSTRAINT [FK74CFC3C0423BF3B4];

ALTER TABLE [dbo].[UserContacts] WITH CHECK CHECK CONSTRAINT [FK216270F817810183];

ALTER TABLE [dbo].[UserContacts] WITH CHECK CHECK CONSTRAINT [FK216270F885BBA2FF];

ALTER TABLE [dbo].[UserEmergencyContacts] WITH CHECK CHECK CONSTRAINT [FKED9B3FC717810183];

ALTER TABLE [dbo].[UserEmergencyContacts] WITH CHECK CHECK CONSTRAINT [FKED9B3FC7A82E65];

ALTER TABLE [dbo].[UserGroupRolePermissions] WITH CHECK CHECK CONSTRAINT [FKDD28E238E80F2A03];

ALTER TABLE [dbo].[UserGroupRolePermissions] WITH CHECK CHECK CONSTRAINT [FKDD28E238F1130D47];

ALTER TABLE [dbo].[UserGroupRoles] WITH CHECK CHECK CONSTRAINT [FK54344AAD6E3B9873];

ALTER TABLE [dbo].[UserGroupRoles] WITH CHECK CHECK CONSTRAINT [FK54344AADE80F2A03];

ALTER TABLE [dbo].[UserProfiles] WITH CHECK CHECK CONSTRAINT [FK15F395D130A8D0DB];

ALTER TABLE [dbo].[UserProfiles] WITH CHECK CHECK CONSTRAINT [FK15F395D1A82E65];

ALTER TABLE [dbo].[UserRolePermissions] WITH CHECK CHECK CONSTRAINT [FK4256C649451CEFCF];

ALTER TABLE [dbo].[UserRolePermissions] WITH CHECK CHECK CONSTRAINT [FK4256C649F1130D47];

ALTER TABLE [dbo].[UserRoles] WITH CHECK CHECK CONSTRAINT [FKDFBBDE7E451CEFCF];

ALTER TABLE [dbo].[UserRoles] WITH CHECK CHECK CONSTRAINT [FKDFBBDE7E93C772A1];

ALTER TABLE [dbo].[Users] WITH CHECK CHECK CONSTRAINT [FK617D3C3A85BBA2FF];

ALTER TABLE [dbo].[Users] WITH CHECK CHECK CONSTRAINT [FK617D3C3A934218F7];

ALTER TABLE [dbo].[UsersEmergencyContactPerson] WITH CHECK CHECK CONSTRAINT [FK5B1BEC2430A8D0DB];

ALTER TABLE [dbo].[UsersEmergencyContactPerson] WITH CHECK CHECK CONSTRAINT [FK5B1BEC24E2720DC7];

ALTER TABLE [dbo].[UserUserGroups] WITH CHECK CHECK CONSTRAINT [FK969171B26E3B9873];

ALTER TABLE [dbo].[UserUserGroups] WITH CHECK CHECK CONSTRAINT [FK969171B293C772A1];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        DECLARE @VarDecimalSupported AS BIT;
        SELECT @VarDecimalSupported = 0;
        IF ((ServerProperty(N'EngineEdition') = 3)
            AND (((@@microsoftversion / power(2, 24) = 9)
                  AND (@@microsoftversion & 0xffff >= 3024))
                 OR ((@@microsoftversion / power(2, 24) = 10)
                     AND (@@microsoftversion & 0xffff >= 1600))))
            SELECT @VarDecimalSupported = 1;
        IF (@VarDecimalSupported > 0)
            BEGIN
                EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
            END
    END


GO
