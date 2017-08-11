CREATE TABLE [dbo].[SubscriptionMaster] (
    [SubscriptionId]      INT             IDENTITY (1, 1) NOT NULL,
    [SubscriptionType]    NVARCHAR (15)   NOT NULL,
    [TotalNoOfUsers]      INT             NOT NULL,
    [NoOfEmployees]       INT             NOT NULL,
    [NoOfAuditors]        INT             NOT NULL,
    [NoOfAssociates]      INT             NOT NULL,
    [SubscriptionFees]    DECIMAL (19, 5) NOT NULL,
    [RenewalFeesPerAnnum] DECIMAL (19, 5) NOT NULL,
    [CreatedBy]           BIGINT          NOT NULL,
    [CreatedDate]         DATETIME        DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]          BIGINT          NOT NULL,
    [ModifiedDate]        DATETIME        DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([SubscriptionId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

