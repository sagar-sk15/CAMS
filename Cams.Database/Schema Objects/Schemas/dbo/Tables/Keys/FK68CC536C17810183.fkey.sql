ALTER TABLE [dbo].[ClientPrimaryContacts]
    ADD CONSTRAINT [FK68CC536C17810183] FOREIGN KEY ([ContactDetailsId]) REFERENCES [dbo].[ContactDetails] ([ContactDetailsId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

