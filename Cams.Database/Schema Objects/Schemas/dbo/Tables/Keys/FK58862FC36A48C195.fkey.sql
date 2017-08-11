ALTER TABLE [dbo].[ClientPartnerBankContactPersonContacts]
    ADD CONSTRAINT [FK58862FC36A48C195] FOREIGN KEY ([ClientPartnerBankId]) REFERENCES [dbo].[ClientPartnerBankDetails] ([ClientPartnerBankId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

