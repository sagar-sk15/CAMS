CREATE TABLE [dbo].[Zones] (
    [ZoneId]       BIGINT         IDENTITY (1, 1) NOT NULL,
    [ZoneFor]      NVARCHAR (20)  NOT NULL,
    [Name]         NVARCHAR (255) NOT NULL,
    [IsActive]     BIT            NOT NULL,
    [CAId]         INT            NOT NULL,
    [CreatedBy]    BIGINT         NOT NULL,
    [CreatedDate]  DATETIME       DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]   BIGINT         NULL,
    [ModifiedDate] DATETIME       DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([ZoneId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

