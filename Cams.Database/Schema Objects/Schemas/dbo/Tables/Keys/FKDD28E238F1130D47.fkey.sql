﻿ALTER TABLE [dbo].[UserGroupRolePermissions]
    ADD CONSTRAINT [FKDD28E238F1130D47] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([RoleId]) ON DELETE NO ACTION ON UPDATE NO ACTION;
