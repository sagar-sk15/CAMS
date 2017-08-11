ALTER TABLE [dbo].[ClientSubscriptionPayments]
    ADD CONSTRAINT [FKEB394DEB1E36A4A1] FOREIGN KEY ([ClientSubscriptionId]) REFERENCES [dbo].[ClientSubscriptions] ([ClientSubscriptionId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

