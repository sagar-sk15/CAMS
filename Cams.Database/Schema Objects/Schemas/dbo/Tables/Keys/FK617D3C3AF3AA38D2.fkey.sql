﻿ALTER TABLE [dbo].[Users]
    ADD CONSTRAINT [FK617D3C3AF3AA38D2] FOREIGN KEY ([CAId]) REFERENCES [dbo].[Clients] ([CAId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

