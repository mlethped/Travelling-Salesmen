CREATE TABLE [dbo].[Districts] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [Name]            NVARCHAR (50)    NOT NULL,
    [PrimarySalesman] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([PrimarySalesman]) REFERENCES [dbo].[Salesmen] ([Id])
);

