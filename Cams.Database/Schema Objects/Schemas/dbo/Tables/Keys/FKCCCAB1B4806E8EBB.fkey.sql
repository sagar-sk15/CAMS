﻿ALTER TABLE [dbo].[BankBranches]
    ADD CONSTRAINT [FKCCCAB1B4806E8EBB] FOREIGN KEY ([WeeklyHalfDayId]) REFERENCES [dbo].[BankBranchWeeklyHalfDays] ([WeeklyHalfDayId]) ON DELETE NO ACTION ON UPDATE NO ACTION;
