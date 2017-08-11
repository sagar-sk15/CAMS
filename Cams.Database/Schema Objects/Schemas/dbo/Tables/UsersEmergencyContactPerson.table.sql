CREATE TABLE [dbo].[UsersEmergencyContactPerson] (
    [UserEmergencyContactPersonId] BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]                         NVARCHAR (255) NOT NULL,
    [Email1]                       NVARCHAR (100) NULL,
    [Email2]                       NVARCHAR (100) NULL,
    [CreatedBy]                    BIGINT         NOT NULL,
    [CreatedDate]                  DATETIME       DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]                   BIGINT         NULL,
    [ModifiedDate]                 DATETIME       DEFAULT (getdate()) NULL,
    [AddressId]                    BIGINT         NULL,
    [RelationshipId]               INT            NULL,
    PRIMARY KEY CLUSTERED ([UserEmergencyContactPersonId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

