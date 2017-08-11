ALTER TABLE [dbo].[ClientProfileChangeRequests]
    ADD CONSTRAINT [FKF91D23544291588] FOREIGN KEY ([EmailMessageId]) REFERENCES [dbo].[EmailMessages] ([EmailMessageId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

