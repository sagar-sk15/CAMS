﻿ALTER TABLE [dbo].[Users]
    ADD CONSTRAINT [FK617D3C3A85BBA2FF] FOREIGN KEY ([UserProfileId]) REFERENCES [dbo].[UserProfiles] ([UserProfileId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

