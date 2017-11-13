CREATE TABLE [dbo].[DistrictsAndSalesmen] (
    [DistrictId] UNIQUEIDENTIFIER NOT NULL,
    [SalesmanId] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([DistrictId] ASC, [SalesmanId] ASC),
    FOREIGN KEY ([DistrictId]) REFERENCES [dbo].[Districts] ([Id]),
    FOREIGN KEY ([SalesmanId]) REFERENCES [dbo].[Salesmen] ([Id])
);

