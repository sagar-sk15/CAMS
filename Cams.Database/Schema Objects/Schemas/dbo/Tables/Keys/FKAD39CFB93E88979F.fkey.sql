ALTER TABLE [dbo].[ClientSubscriptions]
    ADD CONSTRAINT [FKAD39CFB93E88979F] FOREIGN KEY ([SubscriptionId]) REFERENCES [dbo].[SubscriptionMaster] ([SubscriptionId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

