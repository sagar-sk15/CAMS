CREATE TABLE [dbo].[MeasuringUnit] (
    [UnitId]          INT           IDENTITY (1, 1) NOT NULL,
    [UnitType]        NVARCHAR (20) NOT NULL,
    [MeasurementUnit] NVARCHAR (30) NOT NULL,
    [EquivalentUnit]  NVARCHAR (30) NOT NULL,
    [CAId]            INT           NOT NULL,
    [CreatedBy]       BIGINT        NOT NULL,
    [CreatedDate]     DATETIME      DEFAULT (getdate()) NOT NULL,
    [ModifiedBy]      BIGINT        NULL,
    [ModifiedDate]    DATETIME      DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([UnitId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

