ALTER TABLE [dbo].[ClientPartnerContacts]
    ADD CONSTRAINT [FK262FA82417810183] FOREIGN KEY ([ContactDetailsId]) REFERENCES [dbo].[ContactDetails] ([ContactDetailsId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

