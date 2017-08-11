CREATE TABLE [dbo].[EmailAttachments] (
    [EmailAttachmentId]  INT            IDENTITY (1, 1) NOT NULL,
    [Attachmentname]     NVARCHAR (100) NULL,
    [AttachmentLocation] NVARCHAR (100) NULL,
    [CreatedBy]          BIGINT         NOT NULL,
    [CreatedDate]        DATETIME       DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]         BIGINT         NOT NULL,
    [ModifiedDate]       DATETIME       DEFAULT (getdate()) NOT NULL,
    [EmailMessageId]     INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([EmailAttachmentId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

