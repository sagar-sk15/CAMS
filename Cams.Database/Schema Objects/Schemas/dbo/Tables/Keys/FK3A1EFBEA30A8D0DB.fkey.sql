﻿ALTER TABLE [dbo].[Clients]
    ADD CONSTRAINT [FK3A1EFBEA30A8D0DB] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

