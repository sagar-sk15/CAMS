﻿ALTER TABLE [dbo].[Clients]
    ADD CONSTRAINT [FK3A1EFBEA220FDEAE] FOREIGN KEY ([APMCId]) REFERENCES [dbo].[APMC] ([APMCId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

