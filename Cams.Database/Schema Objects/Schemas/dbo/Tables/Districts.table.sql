CREATE TABLE [dbo].[Districts] (
    [DistrictId]   INT            IDENTITY (1, 1) NOT NULL,
    [DistrictName] NVARCHAR (255) NOT NULL,
    [StateId]      INT            NULL,
    PRIMARY KEY CLUSTERED ([DistrictId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

