﻿ALTER TABLE [dbo].[Clients]
    ADD CONSTRAINT [FK3A1EFBEAFC01A4B3] FOREIGN KEY ([CommodityClassId]) REFERENCES [dbo].[CommodityClasses] ([CommodityClassId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

