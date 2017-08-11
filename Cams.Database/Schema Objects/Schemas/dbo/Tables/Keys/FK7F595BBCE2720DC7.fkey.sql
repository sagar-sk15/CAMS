ALTER TABLE [dbo].[ClientPartnerGuardianDetails]
    ADD CONSTRAINT [FK7F595BBCE2720DC7] FOREIGN KEY ([RelationshipId]) REFERENCES [dbo].[RelationShips] ([RelationshipId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

