IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Customers] (
    [Id] bigint NOT NULL,
    [Username] nvarchar(max) NOT NULL,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [Address] nvarchar(max) NULL,
    [Country] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Products] (
    [Id] bigint NOT NULL,
    [Name] nvarchar(max) NULL,
    [UnitPrice] decimal(18,2) NOT NULL,
    [PictureUrl] nvarchar(max) NULL,
    [ClothingSizeType] int NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [SizeStocks] (
    [Id] bigint NOT NULL IDENTITY,
    [ProductId] bigint NOT NULL,
    [Size] int NOT NULL,
    [Stock] bigint NOT NULL,
    CONSTRAINT [PK_SizeStocks] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SizeStocks_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [CartProducts] (
    [Id] bigint NOT NULL IDENTITY,
    [CustomerId] bigint NOT NULL,
    [Quantity] int NOT NULL,
    [SizeId] bigint NULL,
    CONSTRAINT [PK_CartProducts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CartProducts_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CartProducts_SizeStocks_SizeId] FOREIGN KEY ([SizeId]) REFERENCES [SizeStocks] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_CartProducts_CustomerId] ON [CartProducts] ([CustomerId]);

GO

CREATE INDEX [IX_CartProducts_SizeId] ON [CartProducts] ([SizeId]);

GO

CREATE INDEX [IX_SizeStocks_ProductId] ON [SizeStocks] ([ProductId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201121164112_Initial', N'3.1.10');

GO

