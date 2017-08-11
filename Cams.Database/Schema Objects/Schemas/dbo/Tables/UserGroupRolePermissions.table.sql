CREATE TABLE [dbo].[UserGroupRolePermissions] (
    [UserGroupRolePermissionId] BIGINT IDENTITY (1, 1) NOT NULL,
    [AllowAdd]                  BIT    NOT NULL,
    [AllowEdit]                 BIT    NOT NULL,
    [AllowView]                 BIT    NOT NULL,
    [AllowDelete]               BIT    NOT NULL,
    [AllowPrint]                BIT    NOT NULL,
    [RoleId]                    INT    NOT NULL,
    PRIMARY KEY CLUSTERED ([UserGroupRolePermissionId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

