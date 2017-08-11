CREATE TABLE [dbo].[ClientSubscriptionPaymentDetails] (
    [CASubscriptionPaymentDetailsId] INT             IDENTITY (1, 1) NOT NULL,
    [PaymentMode]                    NVARCHAR (10)   NULL,
    [Amount]                         DECIMAL (19, 5) NOT NULL,
    [IsRTGS]                         BIT             NOT NULL,
    [IsStandardCheque]               BIT             NOT NULL,
    [IsNEFT]                         BIT             NOT NULL,
    [ChequeDDTransationNo]           NVARCHAR (15)   NULL,
    [ChequeDDTransactionDate]        DATETIME        DEFAULT (getdate()) NULL,
    [ChequeDDClearanceDates]         DATETIME        DEFAULT (getdate()) NULL,
    [CreatedBy]                      BIGINT          NOT NULL,
    [CreatedDate]                    DATETIME        DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]                     BIGINT          NOT NULL,
    [ModifiedDate]                   DATETIME        DEFAULT (getdate()) NOT NULL,
    [BranchId]                       INT             NULL,
    PRIMARY KEY CLUSTERED ([CASubscriptionPaymentDetailsId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

