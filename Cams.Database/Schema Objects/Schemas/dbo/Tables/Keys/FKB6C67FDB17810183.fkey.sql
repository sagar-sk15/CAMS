ALTER TABLE [dbo].[ClientPartnerNomineeContacts]
    ADD CONSTRAINT [FKB6C67FDB17810183] FOREIGN KEY ([ContactDetailsId]) REFERENCES [dbo].[ContactDetails] ([ContactDetailsId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

