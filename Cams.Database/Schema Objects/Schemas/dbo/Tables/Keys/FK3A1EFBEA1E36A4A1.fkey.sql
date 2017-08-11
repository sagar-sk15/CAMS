ALTER TABLE [dbo].[Clients]
    ADD CONSTRAINT [FK3A1EFBEA1E36A4A1] FOREIGN KEY ([ClientSubscriptionId]) REFERENCES [dbo].[ClientSubscriptions] ([ClientSubscriptionId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

