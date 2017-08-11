ALTER TABLE [dbo].[ClientPartnerBanks]
    ADD CONSTRAINT [FK20EE27286A48C195] FOREIGN KEY ([ClientPartnerBankId]) REFERENCES [dbo].[ClientPartnerBankDetails] ([ClientPartnerBankId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

