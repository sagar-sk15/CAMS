ALTER TABLE [dbo].[ClientSisterConcerns]
    ADD CONSTRAINT [FKDEC4948493DBA7F3] FOREIGN KEY ([ClientSisterConcernId]) REFERENCES [dbo].[ClientSisterConcern] ([ClientSisterConcernId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

