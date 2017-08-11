CREATE TABLE [dbo].[ClientHolidayCalender] (
    [ClientHolidayCalenderId] INT            IDENTITY (1, 1) NOT NULL,
    [CAId]                    INT            NOT NULL,
    [HolidayFromDate]         DATETIME       NOT NULL,
    [HolidayToDate]           DATETIME       NULL,
    [Reason]                  NVARCHAR (100) NOT NULL,
    [CreatedBy]               BIGINT         NOT NULL,
    [CreatedDate]             DATETIME       DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]              BIGINT         NOT NULL,
    [ModifiedDate]            DATETIME       DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([ClientHolidayCalenderId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

