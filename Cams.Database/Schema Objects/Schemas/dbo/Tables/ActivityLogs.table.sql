CREATE TABLE [dbo].[ActivityLogs] (
    [LogId]             INT            IDENTITY (1, 1) NOT NULL,
    [LoggedBy]          NVARCHAR (255) NOT NULL,
    [LoggedDate]        DATETIME       DEFAULT (getdate()) NOT NULL,
    [ActivityRelatedTo] NVARCHAR (50)  NOT NULL,
    [Description]       NVARCHAR (255) NULL,
    [CAId]              INT            NULL,
    [ObjectId]          NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([LogId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

