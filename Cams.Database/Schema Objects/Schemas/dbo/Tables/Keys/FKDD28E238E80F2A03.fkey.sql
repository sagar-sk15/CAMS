ALTER TABLE [dbo].[UserGroupRolePermissions]
    ADD CONSTRAINT [FKDD28E238E80F2A03] FOREIGN KEY ([UserGroupRolePermissionId]) REFERENCES [dbo].[UserGroupRolePermissions] ([UserGroupRolePermissionId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

