CREATE TABLE [dbo].[UserProfiles] (
    [UserProfileId]                BIGINT         IDENTITY (1, 1) NOT NULL,
    [Gender]                       NVARCHAR (255) NULL,
    [MaritalStatus]                NVARCHAR (255) NULL,
    [UID]                          NVARCHAR (30)  NULL,
    [PAN]                          NVARCHAR (20)  NULL,
    [PassportNo]                   NVARCHAR (20)  NULL,
    [PassportPlace]                NVARCHAR (255) NULL,
    [PassportValidFromDate]        DATETIME       DEFAULT (getdate()) NULL,
    [PassportValidToDate]          DATETIME       DEFAULT (getdate()) NULL,
    [BloodGroup]                   NVARCHAR (255) NULL,
    [DateOfJoining]                DATETIME       DEFAULT (getdate()) NULL,
    [PFNo]                         NVARCHAR (30)  NULL,
    [Email1]                       NVARCHAR (100) NULL,
    [Email2]                       NVARCHAR (100) NULL,
    [CreatedBy]                    BIGINT         NOT NULL,
    [CreatedDate]                  DATETIME       DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]                   BIGINT         NULL,
    [ModifiedDate]                 DATETIME       DEFAULT (getdate()) NULL,
    [AddressId]                    BIGINT         NULL,
    [UserEmergencyContactPersonId] BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([UserProfileId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

