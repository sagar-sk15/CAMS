CREATE TABLE [dbo].[ClientWeeklyOffDay] (
    [ClientWeeklyOffDayId] INT      IDENTITY (1, 1) NOT NULL,
    [IsMonday]             BIT      NULL,
    [IsTuesday]            BIT      NULL,
    [IsWednesday]          BIT      NULL,
    [IsThursday]           BIT      NULL,
    [IsFriday]             BIT      NULL,
    [IsSaturday]           BIT      NULL,
    [IsSunday]             BIT      NULL,
    [WithEffectFromDate]   DATETIME NOT NULL,
    [WithEffectToDate]     DATETIME NOT NULL,
    [CAId]                 INT      NOT NULL,
    [CreatedBy]            BIGINT   NOT NULL,
    [CreatedDate]          DATETIME DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]           BIGINT   NOT NULL,
    [ModifiedDate]         DATETIME DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([ClientWeeklyOffDayId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

