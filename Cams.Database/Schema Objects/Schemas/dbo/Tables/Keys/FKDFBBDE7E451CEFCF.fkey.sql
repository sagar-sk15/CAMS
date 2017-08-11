ALTER TABLE [dbo].[UserRoles]
    ADD CONSTRAINT [FKDFBBDE7E451CEFCF] FOREIGN KEY ([UserRolePermissionId]) REFERENCES [dbo].[UserRolePermissions] ([UserRolePermissionId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

