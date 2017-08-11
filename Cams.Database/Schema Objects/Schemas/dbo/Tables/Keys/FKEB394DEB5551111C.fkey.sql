ALTER TABLE [dbo].[ClientSubscriptionPayments]
    ADD CONSTRAINT [FKEB394DEB5551111C] FOREIGN KEY ([CASubscriptionPaymentDetailsId]) REFERENCES [dbo].[ClientSubscriptionPaymentDetails] ([CASubscriptionPaymentDetailsId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

