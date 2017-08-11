CREATE TABLE [dbo].[ClientPartnerGuardianDetails] (
    [ClientPartnerGuardianId] INT            IDENTITY (1, 1) NOT NULL,
    [Title]                   NVARCHAR (10)  NULL,
    [GuardianName]            NVARCHAR (255) NULL,
    [Gender]                  NVARCHAR (5)   NULL,
    [DateOfBirth]             DATETIME       DEFAULT (getdate()) NULL,
    [PAN]                     NVARCHAR (20)  NULL,
    [UID]                     NVARCHAR (20)  NULL,
    [Image]                   NVARCHAR (255) NULL,
    [Email1]                  NVARCHAR (100) NULL,
    [Email2]                  NVARCHAR (100) NULL,
    [CreatedBy]               BIGINT         NOT NULL,
    [CreatedDate]             DATETIME       DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]              BIGINT         NOT NULL,
    [ModifiedDate]            DATETIME       DEFAULT (getdate()) NOT NULL,
    [AddressId]               BIGINT         NULL,
    [RelationshipId]          INT            NULL,
    PRIMARY KEY CLUSTERED ([ClientPartnerGuardianId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

