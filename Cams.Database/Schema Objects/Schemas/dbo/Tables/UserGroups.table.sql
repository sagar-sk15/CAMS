CREATE TABLE [dbo].[UserGroups] (
    [UserGroupId]   INT            IDENTITY (1, 1) NOT NULL,
    [UserGroupName] NVARCHAR (255) NOT NULL,
    [Description]   NVARCHAR (255) NULL,
    [CAId]          INT            NULL,
    [IsActive]      BIT            NULL,
    [IsDeleted]     BIT            NULL,
    [AllowEdit]     BIT            NULL,
    [AllowDelete]   BIT            NULL,
    [CreatedBy]     BIGINT         NULL,
    [CreatedDate]   DATETIME       DEFAULT (getdate()) NULL,
    [ModifiedBy]    BIGINT         NULL,
    [ModifiedDate]  DATETIME       DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([UserGroupId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

