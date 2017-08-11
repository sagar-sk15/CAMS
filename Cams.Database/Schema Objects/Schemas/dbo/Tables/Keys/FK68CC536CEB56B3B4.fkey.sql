ALTER TABLE [dbo].[ClientPrimaryContacts]
    ADD CONSTRAINT [FK68CC536CEB56B3B4] FOREIGN KEY ([CAPrimaryContactPersonId]) REFERENCES [dbo].[ClientPrimaryContactPerson] ([CAPrimaryContactPersonId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

