﻿ALTER TABLE [dbo].[ClientPartnerContacts]
    ADD CONSTRAINT [FK262FA8243078D16] FOREIGN KEY ([PartnerId]) REFERENCES [dbo].[ClientPartnerDetails] ([PartnerId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

