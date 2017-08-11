CREATE TABLE [dbo].[ClientProfileChangeRequests] (
    [RequestId]                        INT            IDENTITY (1, 1) NOT NULL,
    [Reason]                           NVARCHAR (200) NOT NULL,
    [CAId]                             INT            NOT NULL,
    [ClientProfileChangeRequestStatus] NVARCHAR (255) NOT NULL,
    [CreatedBy]                        BIGINT         NOT NULL,
    [CreatedDate]                      DATETIME       DEFAULT (getdate()) NOT NULL,
    [EmailMessageId]                   INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([RequestId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

