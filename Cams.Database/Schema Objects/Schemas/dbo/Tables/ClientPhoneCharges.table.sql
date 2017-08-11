CREATE TABLE [dbo].[ClientPhoneCharges] (
    [ClientPhoneChargesId] INT             IDENTITY (1, 1) NOT NULL,
    [WithEffectFromDate]   DATETIME        NULL,
    [WSFarmerAmount]       DECIMAL (19, 5) NOT NULL,
    [OSFarmerAmount]       DECIMAL (19, 5) NOT NULL,
    [WSTraderAmount]       DECIMAL (19, 5) NOT NULL,
    [OSTraderAmount]       DECIMAL (19, 5) NOT NULL,
    [CreatedBy]            BIGINT          NOT NULL,
    [CreatedDate]          DATETIME        DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]           BIGINT          NOT NULL,
    [ModifiedDate]         DATETIME        DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([ClientPhoneChargesId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

