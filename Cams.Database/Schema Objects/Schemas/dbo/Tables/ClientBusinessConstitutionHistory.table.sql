CREATE TABLE [dbo].[ClientBusinessConstitutionHistory] (
    [ClientBusinessConstitutionHistoryId] INT      IDENTITY (1, 1) NOT NULL,
    [CAId]                                INT      NOT NULL,
    [BusinessConstitutionId]              INT      NOT NULL,
    [ModifiedBy]                          BIGINT   NOT NULL,
    [ModifiedDate]                        DATETIME DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([ClientBusinessConstitutionHistoryId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

