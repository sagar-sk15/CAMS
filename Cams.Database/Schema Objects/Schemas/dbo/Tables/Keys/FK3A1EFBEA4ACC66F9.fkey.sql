ALTER TABLE [dbo].[Clients]
    ADD CONSTRAINT [FK3A1EFBEA4ACC66F9] FOREIGN KEY ([BusinessConstitutionId]) REFERENCES [dbo].[BusinessConstitutions] ([BusinessConstitutionId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

