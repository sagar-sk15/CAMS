CREATE TABLE [dbo].[Roles] (
    [RoleId]                  INT            IDENTITY (1, 1) NOT NULL,
    [RoleName]                NVARCHAR (255) NOT NULL,
    [RoleGroup]               NVARCHAR (255) NULL,
    [IsApplicableForAckUsers] BIT            NULL,
    [IsAddApplicable]         BIT            NULL,
    [IsEditApplicable]        BIT            NULL,
    [IsViewApplicable]        BIT            NULL,
    [IsDeleteApplicable]      BIT            NULL,
    [IsPrintApplicable]       BIT            NULL,
    PRIMARY KEY CLUSTERED ([RoleId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

