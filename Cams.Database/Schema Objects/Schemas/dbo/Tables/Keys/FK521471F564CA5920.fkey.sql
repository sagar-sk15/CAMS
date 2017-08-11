ALTER TABLE [dbo].[ClientProfileChangeRequestsWithFields]
    ADD CONSTRAINT [FK521471F564CA5920] FOREIGN KEY ([RequestId]) REFERENCES [dbo].[ClientProfileChangeRequests] ([RequestId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

