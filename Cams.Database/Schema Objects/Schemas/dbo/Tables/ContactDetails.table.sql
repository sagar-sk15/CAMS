CREATE TABLE [dbo].[ContactDetails] (
    [ContactDetailsId]   BIGINT         IDENTITY (1, 1) NOT NULL,
    [ContactNo]          NVARCHAR (15)  NOT NULL,
    [ContactNoType]      NVARCHAR (255) NULL,
    [CountryCallingCode] NVARCHAR (5)   NOT NULL,
    [STDCode]            NVARCHAR (10)  NULL,
    PRIMARY KEY CLUSTERED ([ContactDetailsId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

