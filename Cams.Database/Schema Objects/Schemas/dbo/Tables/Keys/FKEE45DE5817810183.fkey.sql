﻿ALTER TABLE [dbo].[ClientContacts]
    ADD CONSTRAINT [FKEE45DE5817810183] FOREIGN KEY ([ContactDetailsId]) REFERENCES [dbo].[ContactDetails] ([ContactDetailsId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

