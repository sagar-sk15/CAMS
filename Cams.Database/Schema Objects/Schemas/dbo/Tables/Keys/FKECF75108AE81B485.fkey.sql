ALTER TABLE [dbo].[ClientTaxationAndLicenses]
    ADD CONSTRAINT [FKECF75108AE81B485] FOREIGN KEY ([ClientTaxationAndLicensesId]) REFERENCES [dbo].[ClientTaxationAndLicensesDetails] ([ClientTaxationAndLicensesId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

