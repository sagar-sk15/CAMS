﻿ALTER TABLE [dbo].[APMC]
    ADD CONSTRAINT [FK9DA4BC9730A8D0DB] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

