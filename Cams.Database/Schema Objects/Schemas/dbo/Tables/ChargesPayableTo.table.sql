CREATE TABLE [dbo].[ChargesPayableTo] (
    [ChargesPayableToId] INT           IDENTITY (1, 1) NOT NULL,
    [PayableTo]          NVARCHAR (30) NOT NULL,
    [IsActive]           BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([ChargesPayableToId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

