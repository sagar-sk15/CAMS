CREATE TABLE [dbo].[Addresses] (
    [AddressId]     BIGINT         IDENTITY (1, 1) NOT NULL,
    [AddressLine1]  NVARCHAR (255) NULL,
    [AddressLine2]  NVARCHAR (255) NULL,
    [PIN]           NVARCHAR (10)  NULL,
    [CreatedBy]     BIGINT         NOT NULL,
    [CreatedDate]   DATETIME       DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]    BIGINT         NULL,
    [ModifiedDate]  DATETIME       DEFAULT (getdate()) NULL,
    [CityVillageId] INT            NULL,
    PRIMARY KEY CLUSTERED ([AddressId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

