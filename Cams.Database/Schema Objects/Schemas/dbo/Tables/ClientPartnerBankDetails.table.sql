CREATE TABLE [dbo].[ClientPartnerBankDetails] (
    [ClientPartnerBankId]   INT            IDENTITY (1, 1) NOT NULL,
    [Accounttype]           NVARCHAR (20)  NULL,
    [AccountNo]             NVARCHAR (40)  NULL,
    [StandingInstructions]  NVARCHAR (100) NULL,
    [BankContactPersonName] NVARCHAR (20)  NULL,
    [Email1]                NVARCHAR (100) NULL,
    [Email2]                NVARCHAR (100) NULL,
    [CreatedBy]             BIGINT         NOT NULL,
    [CreatedDate]           DATETIME       DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]            BIGINT         NOT NULL,
    [ModifiedDate]          DATETIME       DEFAULT (getdate()) NOT NULL,
    [BranchId]              INT            NULL,
    [DesignationId]         INT            NULL,
    PRIMARY KEY CLUSTERED ([ClientPartnerBankId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

