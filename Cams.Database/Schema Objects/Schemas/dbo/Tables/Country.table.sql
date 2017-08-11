CREATE TABLE [dbo].[Country] (
    [CountryId]          INT            IDENTITY (1, 1) NOT NULL,
    [CountryName]        NVARCHAR (50)  NOT NULL,
    [CallingCode]        NVARCHAR (10)  NOT NULL,
    [AgeStd]             INT            NOT NULL,
    [Currency]           NVARCHAR (20)  NOT NULL,
    [CurrencyCode]       NVARCHAR (10)  NOT NULL,
    [Symbol]             NVARCHAR (10)  NOT NULL,
    [TimeZone]           NVARCHAR (255) NOT NULL,
    [FinancialYearStart] NVARCHAR (50)  NOT NULL,
    [FinancialYearEnd]   NVARCHAR (50)  NOT NULL,
    [Status]             NVARCHAR (10)  NOT NULL,
    PRIMARY KEY CLUSTERED ([CountryId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

