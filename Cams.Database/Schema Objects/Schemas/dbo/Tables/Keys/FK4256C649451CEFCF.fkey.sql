ALTER TABLE [dbo].[UserRolePermissions]
    ADD CONSTRAINT [FK4256C649451CEFCF] FOREIGN KEY ([UserRolePermissionId]) REFERENCES [dbo].[UserRolePermissions] ([UserRolePermissionId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

