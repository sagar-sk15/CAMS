ALTER TABLE [dbo].[UsersEmergencyContactPerson]
    ADD CONSTRAINT [FK5B1BEC24E2720DC7] FOREIGN KEY ([RelationshipId]) REFERENCES [dbo].[RelationShips] ([RelationshipId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

