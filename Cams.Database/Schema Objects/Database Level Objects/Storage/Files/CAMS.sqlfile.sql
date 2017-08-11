ALTER DATABASE [$(DatabaseName)]
    ADD FILE (NAME = [CAMS], FILENAME = '$(DefaultDataPath)$(DatabaseName).mdf', FILEGROWTH = 1024 KB) TO FILEGROUP [PRIMARY];

