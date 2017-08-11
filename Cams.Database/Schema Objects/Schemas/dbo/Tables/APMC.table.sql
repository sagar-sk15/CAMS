CREATE TABLE [dbo].[APMC] (
    [APMCId]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (80)  NOT NULL,
    [Email1]       NVARCHAR (50)  NULL,
    [Email2]       NVARCHAR (50)  NULL,
    [Website]      NVARCHAR (100) NULL,
    [Status]       NVARCHAR (10)  NOT NULL,
    [CreatedBy]    BIGINT         NOT NULL,
    [CreatedDate]  DATETIME       DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]   BIGINT         NULL,
    [ModifiedDate] DATETIME       DEFAULT (getdate()) NULL,
    [AddressId]    BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([APMCId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

