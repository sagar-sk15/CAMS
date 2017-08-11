ALTER TABLE [dbo].[ClientPrimaryContactPerson]
    ADD CONSTRAINT [FK277CD4DE934218F7] FOREIGN KEY ([DesignationId]) REFERENCES [dbo].[Designations] ([DesignationId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

