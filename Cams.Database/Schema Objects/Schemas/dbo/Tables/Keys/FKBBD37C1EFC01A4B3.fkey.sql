ALTER TABLE [dbo].[ClientCommodities]
    ADD CONSTRAINT [FKBBD37C1EFC01A4B3] FOREIGN KEY ([CommodityClassId]) REFERENCES [dbo].[CommodityClasses] ([CommodityClassId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

