ALTER TABLE [dbo].[ClientPartnerDetails]
    ADD CONSTRAINT [FK667CA0E16837C633] FOREIGN KEY ([ClientPartnerGuardianId]) REFERENCES [dbo].[ClientPartnerGuardianDetails] ([ClientPartnerGuardianId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

