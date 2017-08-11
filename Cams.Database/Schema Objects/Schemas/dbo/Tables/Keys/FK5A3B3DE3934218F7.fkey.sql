ALTER TABLE [dbo].[ClientPartnerBankDetails]
    ADD CONSTRAINT [FK5A3B3DE3934218F7] FOREIGN KEY ([DesignationId]) REFERENCES [dbo].[Designations] ([DesignationId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

