﻿CREATE TABLE [dbo].[BankBranches] (
    [BranchId]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (255) NOT NULL,
    [CAId]             INT            NULL,
    [IFSCCode]         NVARCHAR (50)  NULL,
    [MICRCode]         NVARCHAR (50)  NULL,
    [SWIFTCode]        NVARCHAR (50)  NULL,
    [Email1]           NVARCHAR (100) NULL,
    [Email2]           NVARCHAR (100) NULL,
    [FullDayTimeFrom]  TIME (7)       NULL,
    [FullDayTimeTo]    TIME (7)       NULL,
    [HalfDayTimeFrom]  TIME (7)       NULL,
    [HalfDayTimeTo]    TIME (7)       NULL,
    [FullDayBreakFrom] TIME (7)       NULL,
    [FullDayBreakTo]   TIME (7)       NULL,
    [HalfDayBreakFrom] TIME (7)       NULL,
    [HalfDayBreakTo]   TIME (7)       NULL,
    [BaseBranchId]     INT            NULL,
    [CreatedBy]        BIGINT         NOT NULL,
    [CreatedDate]      DATETIME       DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]       BIGINT         NULL,
    [ModifiedDate]     DATETIME       DEFAULT (getdate()) NULL,
    [BankId]           INT            NULL,
    [AddressId]        BIGINT         NULL,
    [WeeklyHalfDayId]  INT            NULL,
    [WeeklyOffDayId]   INT            NULL,
    PRIMARY KEY CLUSTERED ([BranchId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

