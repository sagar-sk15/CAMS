﻿ALTER TABLE [dbo].[UserGroupRoles]
    ADD CONSTRAINT [FK54344AAD6E3B9873] FOREIGN KEY ([UserGroupId]) REFERENCES [dbo].[UserGroups] ([UserGroupId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

