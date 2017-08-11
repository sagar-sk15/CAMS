ALTER TABLE [dbo].[Clients]
    ADD CONSTRAINT [FK3A1EFBEAEB56B3B4] FOREIGN KEY ([CAPrimaryContactPersonId]) REFERENCES [dbo].[ClientPrimaryContactPerson] ([CAPrimaryContactPersonId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

