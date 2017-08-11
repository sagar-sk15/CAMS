ALTER TABLE [dbo].[ClientProfileChangeRequestsWithFields]
    ADD CONSTRAINT [FK521471F51E8AD6B8] FOREIGN KEY ([ClientProfileCRFieldId]) REFERENCES [dbo].[ClientProfileChangeRequestFields] ([ClientProfileCRFieldId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

