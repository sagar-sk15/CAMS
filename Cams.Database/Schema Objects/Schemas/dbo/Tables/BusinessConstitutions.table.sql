CREATE TABLE [dbo].[BusinessConstitutions] (
    [BusinessConstitutionId]   INT           IDENTITY (1, 1) NOT NULL,
    [BusinessConstitutionName] NVARCHAR (50) NOT NULL,
    [IsActive]                 BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([BusinessConstitutionId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

