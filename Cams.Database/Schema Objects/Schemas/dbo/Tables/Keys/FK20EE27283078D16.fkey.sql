﻿ALTER TABLE [dbo].[ClientPartnerBanks]
    ADD CONSTRAINT [FK20EE27283078D16] FOREIGN KEY ([PartnerId]) REFERENCES [dbo].[ClientPartnerDetails] ([PartnerId]) ON DELETE NO ACTION ON UPDATE NO ACTION;
