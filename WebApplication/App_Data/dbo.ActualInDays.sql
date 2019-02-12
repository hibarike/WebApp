CREATE TABLE [dbo].[ActualInDays] (
    [Id]                INT IDENTITY (1, 1) NOT NULL,
    [NumberOfShipments] INT NOT NULL,
    [ActualInMonthId]   INT NULL,
    CONSTRAINT [PK_dbo.ActualInDays] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ActualInDays_dbo.ActualInMonths_ActualInMonthId] FOREIGN KEY ([ActualInMonthId]) REFERENCES [dbo].[ActualInMonths] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ActualInMonthId]
    ON [dbo].[ActualInDays]([ActualInMonthId] ASC);

