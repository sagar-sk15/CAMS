ALTER TABLE [dbo].[ClientPartnerBankContactPersonContacts]
    ADD CONSTRAINT [FK58862FC317810183] FOREIGN KEY ([ContactDetailsId]) REFERENCES [dbo].[ContactDetails] ([ContactDetailsId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

