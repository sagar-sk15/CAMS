ALTER TABLE [dbo].[Commodities]
    ADD CONSTRAINT [FKD9D9B611FC01A4B3] FOREIGN KEY ([CommodityClassId]) REFERENCES [dbo].[CommodityClasses] ([CommodityClassId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

