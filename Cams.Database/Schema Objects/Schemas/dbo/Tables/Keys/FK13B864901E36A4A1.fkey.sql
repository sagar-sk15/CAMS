ALTER TABLE [dbo].[ClientSubscriptionPaymentDetails]
    ADD CONSTRAINT [FK13B864901E36A4A1] FOREIGN KEY ([ClientSubscriptionId]) REFERENCES [dbo].[ClientSubscriptions] ([ClientSubscriptionId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

