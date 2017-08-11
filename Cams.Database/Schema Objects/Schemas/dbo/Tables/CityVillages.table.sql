CREATE TABLE [dbo].[CityVillages] (
    [CityVillageId]     INT            IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (255) NOT NULL,
    [CityOrVillage]     NVARCHAR (255) NOT NULL,
    [STDCode]           NVARCHAR (30)  NULL,
    [CAId]              INT            NULL,
    [BaseCityVillageId] INT            NULL,
    [CreatedBy]         BIGINT         NOT NULL,
    [CreatedDate]       DATETIME       DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]        BIGINT         NULL,
    [ModifiedDate]      DATETIME       DEFAULT (getdate()) NULL,
    [DistrictId]        INT            NULL,
    PRIMARY KEY CLUSTERED ([CityVillageId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

