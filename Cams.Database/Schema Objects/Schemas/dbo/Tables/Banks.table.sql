CREATE TABLE [dbo].[Banks] (
    [BankId]       INT            IDENTITY (1, 1) NOT NULL,
    [BankName]     NVARCHAR (255) NOT NULL,
    [Alias]        NVARCHAR (15)  NULL,
    [CAId]         INT            NULL,
    [URL]          NVARCHAR (100) NULL,
    [BaseBankId]   INT            NULL,
    [CreatedBy]    BIGINT         NOT NULL,
    [CreatedDate]  DATETIME       DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]   BIGINT         NULL,
    [ModifiedDate] DATETIME       DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([BankId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

