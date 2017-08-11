CREATE TABLE [dbo].[BankBranchWeeklyHalfDays] (
    [WeeklyHalfDayId] INT IDENTITY (1, 1) NOT NULL,
    [IsMonday]        BIT NULL,
    [IsTuesday]       BIT NULL,
    [IsWednesday]     BIT NULL,
    [IsThursday]      BIT NULL,
    [IsFriday]        BIT NULL,
    [IsSaturday]      BIT NULL,
    [IsSunday]        BIT NULL,
    PRIMARY KEY CLUSTERED ([WeeklyHalfDayId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

