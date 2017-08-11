ALTER TABLE [dbo].[UserEmergencyContacts]
    ADD CONSTRAINT [FKED9B3FC717810183] FOREIGN KEY ([ContactDetailsId]) REFERENCES [dbo].[ContactDetails] ([ContactDetailsId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

