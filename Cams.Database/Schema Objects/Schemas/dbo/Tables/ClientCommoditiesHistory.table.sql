CREATE TABLE [dbo].[ClientCommoditiesHistory] (
    [ClientCommoditiesHistoryId]  INT      NOT NULL,
    [CAId]                        INT      NOT NULL,
    [CommodityClassId]            INT      NOT NULL,
    [ModifiedBy]                  BIGINT   NOT NULL,
    [ModifiedDate]                DATETIME DEFAULT (getdate()) NOT NULL,
    [ClientWeeklyOffDayHistoryId] INT      IDENTITY (1, 1) NOT NULL,
    [IsMonday]                    BIT      NULL,
    [IsTuesday]                   BIT      NULL,
    [IsWednesday]                 BIT      NULL,
    [IsThursday]                  BIT      NULL,
    [IsFriday]                    BIT      NULL,
    [IsSaturday]                  BIT      NULL,
    [IsSunday]                    BIT      NULL,
    [WithEffectFromDate]          DATETIME NOT NULL,
    [WithEffectToDate]            DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([ClientWeeklyOffDayHistoryId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

