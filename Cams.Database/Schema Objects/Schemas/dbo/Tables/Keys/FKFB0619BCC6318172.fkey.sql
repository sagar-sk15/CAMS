﻿ALTER TABLE [dbo].[ParentChildMenus]
    ADD CONSTRAINT [FKFB0619BCC6318172] FOREIGN KEY ([ParentMenuId]) REFERENCES [dbo].[Menus] ([MenuId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

