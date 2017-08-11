ALTER TABLE [dbo].[Clients]
    ADD CONSTRAINT [FK3A1EFBEA2AE5D7C9] FOREIGN KEY ([ClientPhoneChargesId]) REFERENCES [dbo].[ClientPhoneCharges] ([ClientPhoneChargesId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

