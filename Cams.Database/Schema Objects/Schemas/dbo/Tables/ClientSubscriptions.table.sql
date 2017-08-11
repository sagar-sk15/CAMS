﻿CREATE TABLE [dbo].[ClientSubscriptions] (
    [ClientSubscriptionId]        INT             IDENTITY (1, 1) NOT NULL,
    [SubscriptionPeriod]          INT             NULL,
    [SubscriptionPeriodFromDate]  DATETIME        DEFAULT (getdate()) NULL,
    [SubscriptionPeriodToDate]    DATETIME        DEFAULT (getdate()) NULL,
    [AdditionalNoOfEmployees]     INT             NOT NULL,
    [AdditionalNoOfAuditors]      INT             NOT NULL,
    [AdditionalNoOfAssociates]    INT             NOT NULL,
    [AdditionalCostForEmployees]  DECIMAL (19, 5) NOT NULL,
    [AdditionalCostForAuditors]   DECIMAL (19, 5) NOT NULL,
    [AdditionalCostForAssociates] DECIMAL (19, 5) NOT NULL,
    [DiscountInPercentage]        REAL            NOT NULL,
    [DiscountInRupees]            DECIMAL (19, 5) NOT NULL,
    [ServiceTax]                  DECIMAL (19, 5) NOT NULL,
    [OtherTax]                    DECIMAL (19, 5) NOT NULL,
    [Status]                      NVARCHAR (15)   NOT NULL,
    [AdditionalInfo]              NVARCHAR (255)  NULL,
    [ActivationDate]              DATETIME        DEFAULT (getdate()) NULL,
    [AllowEdit]                   BIT             NOT NULL,
    [CreatedBy]                   BIGINT          NOT NULL,
    [CreatedDate]                 DATETIME        DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]                  BIGINT          NOT NULL,
    [ModifiedDate]                DATETIME        DEFAULT (getdate()) NOT NULL,
    [SubscriptionId]              INT             NULL,
    PRIMARY KEY CLUSTERED ([ClientSubscriptionId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);
