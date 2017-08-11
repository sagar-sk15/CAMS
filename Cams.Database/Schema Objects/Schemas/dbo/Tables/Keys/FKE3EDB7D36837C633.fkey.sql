ALTER TABLE [dbo].[ClientPartnerGuardianContacts]
    ADD CONSTRAINT [FKE3EDB7D36837C633] FOREIGN KEY ([ClientPartnerGuardianId]) REFERENCES [dbo].[ClientPartnerGuardianDetails] ([ClientPartnerGuardianId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

