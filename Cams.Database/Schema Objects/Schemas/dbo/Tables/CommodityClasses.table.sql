CREATE TABLE [dbo].[CommodityClasses] (
    [CommodityClassId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (255) NOT NULL,
    [IsActive]         BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([CommodityClassId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

