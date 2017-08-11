CREATE TABLE [dbo].[EmailMessages] (
    [EmailMessageId]    INT            IDENTITY (1, 1) NOT NULL,
    [MessageFrom]       NVARCHAR (100) NULL,
    [MessageTo]         NVARCHAR (100) NULL,
    [MessageSubject]    NVARCHAR (100) NULL,
    [MessageBody]       NVARCHAR (200) NULL,
    [MessageCC]         NVARCHAR (100) NULL,
    [MessageImportance] NVARCHAR (20)  NULL,
    [MessagePriority]   NVARCHAR (20)  NULL,
    [MessageFlag]       NVARCHAR (20)  NULL,
    [CAId]              INT            NOT NULL,
    [CreatedBy]         BIGINT         NOT NULL,
    [CreatedDate]       DATETIME       DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]        BIGINT         NOT NULL,
    [ModifiedDate]      DATETIME       DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([EmailMessageId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

