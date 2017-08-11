ALTER TABLE [dbo].[UserProfiles]
    ADD CONSTRAINT [FK15F395D1A82E65] FOREIGN KEY ([UserEmergencyContactPersonId]) REFERENCES [dbo].[UsersEmergencyContactPerson] ([UserEmergencyContactPersonId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

