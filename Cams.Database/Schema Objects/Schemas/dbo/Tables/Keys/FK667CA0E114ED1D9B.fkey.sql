ALTER TABLE [dbo].[ClientPartnerDetails]
    ADD CONSTRAINT [FK667CA0E114ED1D9B] FOREIGN KEY ([ClientPartnerNomineeId]) REFERENCES [dbo].[ClientPartnerNomineeDetails] ([ClientPartnerNomineeId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

