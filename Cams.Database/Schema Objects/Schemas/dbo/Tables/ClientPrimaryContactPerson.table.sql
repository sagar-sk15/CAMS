CREATE TABLE [dbo].[ClientPrimaryContactPerson] (
    [CAPrimaryContactPersonId]    INT            IDENTITY (1, 1) NOT NULL,
    [Title]                       NVARCHAR (5)   NULL,
    [CAPrimaryConatactPersonName] NVARCHAR (255) NULL,
    [Gender]                      NVARCHAR (5)   NULL,
    [DateOfBirth]                 DATETIME       DEFAULT (getdate()) NULL,
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
    [CreatedDate]                 DATETIME       DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]                  BIGINT         NOT NULL,
    [ModifiedDate]                DATETIME       DEFAULT (getdate()) NOT NULL,
    [AddressId]                   BIGINT         NULL,
    [DesignationId]               INT            NULL,
    PRIMARY KEY CLUSTERED ([CAPrimaryContactPersonId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

