ALTER TABLE [dbo].[UserEmergencyContacts]
    ADD CONSTRAINT [FKED9B3FC7A82E65] FOREIGN KEY ([UserEmergencyContactPersonId]) REFERENCES [dbo].[UsersEmergencyContactPerson] ([UserEmergencyContactPersonId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

