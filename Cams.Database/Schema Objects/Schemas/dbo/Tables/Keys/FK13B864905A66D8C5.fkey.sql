﻿ALTER TABLE [dbo].[ClientSubscriptionPaymentDetails]
    ADD CONSTRAINT [FK13B864905A66D8C5] FOREIGN KEY ([BranchId]) REFERENCES [dbo].[BankBranches] ([BranchId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

