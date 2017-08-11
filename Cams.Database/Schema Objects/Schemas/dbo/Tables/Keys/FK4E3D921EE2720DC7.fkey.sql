ALTER TABLE [dbo].[ClientPartnerNomineeDetails]
    ADD CONSTRAINT [FK4E3D921EE2720DC7] FOREIGN KEY ([RelationshipId]) REFERENCES [dbo].[RelationShips] ([RelationshipId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

