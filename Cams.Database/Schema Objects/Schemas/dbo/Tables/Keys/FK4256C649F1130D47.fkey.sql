﻿ALTER TABLE [dbo].[UserRolePermissions]
    ADD CONSTRAINT [FK4256C649F1130D47] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([RoleId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

