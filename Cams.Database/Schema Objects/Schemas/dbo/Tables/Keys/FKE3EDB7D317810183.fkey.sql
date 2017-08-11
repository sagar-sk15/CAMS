ALTER TABLE [dbo].[ClientPartnerGuardianContacts]
    ADD CONSTRAINT [FKE3EDB7D317810183] FOREIGN KEY ([ContactDetailsId]) REFERENCES [dbo].[ContactDetails] ([ContactDetailsId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

