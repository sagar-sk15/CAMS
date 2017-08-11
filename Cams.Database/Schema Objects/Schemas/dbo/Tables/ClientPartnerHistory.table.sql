CREATE TABLE [dbo].[ClientPartnerHistory] (
    [ClientPartnerHistoryId] INT      IDENTITY (1, 1) NOT NULL,
    [PartnerId]              INT      NOT NULL,
    [BusinessConstitutionId] INT      NOT NULL,
    [CAId]                   INT      NOT NULL,
    [JoiningDate]            DATETIME DEFAULT (getdate()) NOT NULL,
    [RelievingDate]          DATETIME DEFAULT (getdate()) NULL,
    [IsActive]               BIT      NOT NULL,
    [ModifiedBy]             BIGINT   NOT NULL,
    [ModifiedDate]           DATETIME DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([ClientPartnerHistoryId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

