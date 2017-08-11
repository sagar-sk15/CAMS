CREATE TABLE [dbo].[RelationShips] (
    [RelationshipId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (255) NOT NULL,
    [CAId]           INT            NULL,
    [CreatedBy]      BIGINT         NOT NULL,
    [CreatedDate]    DATETIME       DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]     BIGINT         NULL,
    [ModifiedDate]   DATETIME       DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([RelationshipId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

