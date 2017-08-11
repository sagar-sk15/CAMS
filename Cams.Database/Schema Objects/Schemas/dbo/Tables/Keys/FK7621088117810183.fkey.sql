ALTER TABLE [dbo].[BankBranchContacts]
    ADD CONSTRAINT [FK7621088117810183] FOREIGN KEY ([ContactDetailsId]) REFERENCES [dbo].[ContactDetails] ([ContactDetailsId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

