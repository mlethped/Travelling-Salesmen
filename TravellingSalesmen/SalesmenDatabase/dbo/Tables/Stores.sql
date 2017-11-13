CREATE TABLE [dbo].[Stores] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [DistrictId] UNIQUEIDENTIFIER NOT NULL,
    [Name]       NVARCHAR (50)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([DistrictId]) REFERENCES [dbo].[Districts] ([Id])
);

