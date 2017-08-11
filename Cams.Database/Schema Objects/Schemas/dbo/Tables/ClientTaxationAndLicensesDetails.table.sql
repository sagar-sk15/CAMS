CREATE TABLE [dbo].[ClientTaxationAndLicensesDetails] (
    [ClientTaxationAndLicensesId]    INT            IDENTITY (1, 1) NOT NULL,
    [TaxName]                        NVARCHAR (100) NULL,
    [LicenseNo]                      NVARCHAR (30)  NULL,
    [IsWithEffectFromDateApplicable] BIT            NOT NULL,
    [IsRenewalDateApplicable]        BIT            NOT NULL,
    [WithEffectFromDate]             DATETIME       NULL,
    [RenewalDate]                    DATETIME       NULL,
    [CreatedBy]                      BIGINT         NOT NULL,
    [CreatedDate]                    DATETIME       DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]                     BIGINT         NOT NULL,
    [ModifiedDate]                   DATETIME       DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([ClientTaxationAndLicensesId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

