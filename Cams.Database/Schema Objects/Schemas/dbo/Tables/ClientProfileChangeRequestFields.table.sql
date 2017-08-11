CREATE TABLE [dbo].[ClientProfileChangeRequestFields] (
    [ClientProfileCRFieldId]   INT            IDENTITY (1, 1) NOT NULL,
    [FieldName]                NVARCHAR (100) NOT NULL,
    [CurrentValue]             NVARCHAR (200) NOT NULL,
    [NewValue]                 NVARCHAR (200) NOT NULL,
    [FieldOfValue]             NVARCHAR (200) NOT NULL,
    [ObjectNameInDomainEntity] NVARCHAR (200) NOT NULL,
    [CreatedBy]                BIGINT         NOT NULL,
    [CreatedDate]              DATETIME       DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([ClientProfileCRFieldId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

