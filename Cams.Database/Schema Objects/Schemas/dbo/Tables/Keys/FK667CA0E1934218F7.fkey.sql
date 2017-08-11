ALTER TABLE [dbo].[ClientPartnerDetails]
    ADD CONSTRAINT [FK667CA0E1934218F7] FOREIGN KEY ([DesignationId]) REFERENCES [dbo].[Designations] ([DesignationId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

