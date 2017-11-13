CREATE TABLE [dbo].[StoresAndSalesmen] (
    [StoreId]    UNIQUEIDENTIFIER NOT NULL,
    [SalesmanId] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([StoreId] ASC, [SalesmanId] ASC),
    FOREIGN KEY ([SalesmanId]) REFERENCES [dbo].[Salesmen] ([Id]),
    FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Stores] ([Id])
);

