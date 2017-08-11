ALTER TABLE [dbo].[UserGroupRoles]
    ADD CONSTRAINT [FK54344AADE80F2A03] FOREIGN KEY ([UserGroupRolePermissionId]) REFERENCES [dbo].[UserGroupRolePermissions] ([UserGroupRolePermissionId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

