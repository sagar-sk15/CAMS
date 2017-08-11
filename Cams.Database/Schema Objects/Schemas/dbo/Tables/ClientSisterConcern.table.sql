CREATE TABLE [dbo].[ClientSisterConcern] (
    [ClientSisterConcernId]  INT            IDENTITY (1, 1) NOT NULL,
    [BusinessRelation]       NVARCHAR (30)  NULL,
    [ClientSisterConcerName] NVARCHAR (200) NULL,
    [RelationshipWithEntity] NVARCHAR (200) NULL,
    [EntityId]               INT            NULL,
    [CreatedBy]              BIGINT         NOT NULL,
    [CreatedDate]            DATETIME       DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]             BIGINT         NOT NULL,
    [ModifiedDate]           DATETIME       DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([ClientSisterConcernId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

