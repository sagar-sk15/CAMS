CREATE TABLE [dbo].[Menus] (
    [MenuId]           BIGINT         IDENTITY (1, 1) NOT NULL,
    [MenuName]         NVARCHAR (50)  NOT NULL,
    [MenuDescription]  NVARCHAR (255) NULL,
    [IsMenuActive]     BIT            NOT NULL,
    [IsackUser] BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([MenuId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

