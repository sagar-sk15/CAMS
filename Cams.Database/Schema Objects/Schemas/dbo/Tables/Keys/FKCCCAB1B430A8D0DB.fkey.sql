﻿ALTER TABLE [dbo].[BankBranches]
    ADD CONSTRAINT [FKCCCAB1B430A8D0DB] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId]) ON DELETE NO ACTION ON UPDATE NO ACTION;
