ALTER TABLE [dbo].[ClientPartnerNomineeContacts]
    ADD CONSTRAINT [FKB6C67FDB14ED1D9B] FOREIGN KEY ([ClientPartnerNomineeId]) REFERENCES [dbo].[ClientPartnerNomineeDetails] ([ClientPartnerNomineeId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

