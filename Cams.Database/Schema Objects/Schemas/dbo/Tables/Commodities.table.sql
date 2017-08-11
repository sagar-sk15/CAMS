CREATE TABLE [dbo].[Commodities] (
    [CommodityId]      INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (255) NOT NULL,
    [BotanicalName]    NVARCHAR (255) NOT NULL,
    [Image]            NVARCHAR (255) NULL,
    [IsActive]         BIT            NOT NULL,
    [CreatedBy]        BIGINT         NOT NULL,
    [CreatedDate]      DATETIME       DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]       BIGINT         NULL,
    [ModifiedDate]     DATETIME       DEFAULT (getdate()) NULL,
    [CommodityClassId] INT            NULL,
    PRIMARY KEY CLUSTERED ([CommodityId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

