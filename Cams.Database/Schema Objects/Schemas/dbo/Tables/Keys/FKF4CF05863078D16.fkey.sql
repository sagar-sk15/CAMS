﻿ALTER TABLE [dbo].[ClientPartners]
    ADD CONSTRAINT [FKF4CF05863078D16] FOREIGN KEY ([PartnerId]) REFERENCES [dbo].[ClientPartnerDetails] ([PartnerId]) ON DELETE NO ACTION ON UPDATE NO ACTION;
