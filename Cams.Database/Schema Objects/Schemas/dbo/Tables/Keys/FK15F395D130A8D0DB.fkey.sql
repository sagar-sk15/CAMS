﻿ALTER TABLE [dbo].[UserProfiles]
    ADD CONSTRAINT [FK15F395D130A8D0DB] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

