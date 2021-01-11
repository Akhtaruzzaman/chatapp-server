IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [BlogLog] (
    [Id] uniqueidentifier NOT NULL,
    [LogDetails] nvarchar(max) NULL,
    [IsArchived] bit NOT NULL,
    [CreatedBy] uniqueidentifier NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [CreatedFrom] nvarchar(max) NULL,
    [UpdatedBy] uniqueidentifier NOT NULL,
    [UpdatedAt] datetime2 NULL,
    [UpdatedFrom] nvarchar(max) NULL,
    CONSTRAINT [PK_BlogLog] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Blogs] (
    [Id] uniqueidentifier NOT NULL,
    [Details] nvarchar(max) NULL,
    [IsArchived] bit NOT NULL,
    [CreatedBy] uniqueidentifier NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [CreatedFrom] nvarchar(max) NULL,
    [UpdatedBy] uniqueidentifier NOT NULL,
    [UpdatedAt] datetime2 NULL,
    [UpdatedFrom] nvarchar(max) NULL,
    CONSTRAINT [PK_Blogs] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Mobile] nvarchar(max) NULL,
    [Address] nvarchar(max) NULL,
    [LoginId] nvarchar(450) NULL,
    [Password] nvarchar(max) NULL,
    [UserType] int NOT NULL,
    [IsActive] bit NOT NULL,
    [IsArchived] bit NOT NULL,
    [CreatedBy] uniqueidentifier NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [CreatedFrom] nvarchar(max) NULL,
    [UpdatedBy] uniqueidentifier NOT NULL,
    [UpdatedAt] datetime2 NULL,
    [UpdatedFrom] nvarchar(max) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [BlogComment] (
    [Id] uniqueidentifier NOT NULL,
    [BlogId] uniqueidentifier NOT NULL,
    [Comment] nvarchar(max) NULL,
    [Like] int NOT NULL,
    [Dislike] int NOT NULL,
    [IsArchived] bit NOT NULL,
    [CreatedBy] uniqueidentifier NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [CreatedFrom] nvarchar(max) NULL,
    [UpdatedBy] uniqueidentifier NOT NULL,
    [UpdatedAt] datetime2 NULL,
    [UpdatedFrom] nvarchar(max) NULL,
    CONSTRAINT [PK_BlogComment] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_BlogComment_Blogs_BlogId] FOREIGN KEY ([BlogId]) REFERENCES [Blogs] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedAt', N'CreatedBy', N'CreatedFrom', N'Details', N'IsArchived', N'UpdatedAt', N'UpdatedBy', N'UpdatedFrom') AND [object_id] = OBJECT_ID(N'[Blogs]'))
    SET IDENTITY_INSERT [Blogs] ON;
INSERT INTO [Blogs] ([Id], [CreatedAt], [CreatedBy], [CreatedFrom], [Details], [IsArchived], [UpdatedAt], [UpdatedBy], [UpdatedFrom])
VALUES ('063b287a-378e-4c98-950d-27e437b98dc3', '2021-01-03T22:56:41.5454568+06:00', 'fadede5d-1c91-4d95-92e4-f447ea6edade', N'', N'Post 1', CAST(0 AS bit), NULL, '00000000-0000-0000-0000-000000000000', NULL),
('52315bc2-0192-43da-88ec-669076082158', '2021-01-03T22:56:41.5463023+06:00', 'fadede5d-1c91-4d95-92e4-f447ea6edade', N'', N'Post 2', CAST(0 AS bit), NULL, '00000000-0000-0000-0000-000000000000', NULL),
('6676ec8a-1206-4a4b-ab55-47cbb240c467', '2021-01-03T22:56:41.5463077+06:00', 'fadede5d-1c91-4d95-92e4-f447ea6edade', N'', N'Post 3', CAST(0 AS bit), NULL, '00000000-0000-0000-0000-000000000000', NULL),
('e3294815-c42c-466b-876b-5f5a25374a58', '2021-01-03T22:56:41.5463123+06:00', 'fadede5d-1c91-4d95-92e4-f447ea6edade', N'', N'Post 4', CAST(0 AS bit), NULL, '00000000-0000-0000-0000-000000000000', NULL),
('46627a50-505b-47cf-8a43-d6205664a730', '2021-01-03T22:56:41.5463170+06:00', 'fadede5d-1c91-4d95-92e4-f447ea6edade', N'', N'Post 5', CAST(0 AS bit), NULL, '00000000-0000-0000-0000-000000000000', NULL),
('0a4e9d08-7b82-4aed-a265-b79856fed0a2', '2021-01-03T22:56:41.5463230+06:00', 'fadede5d-1c91-4d95-92e4-f447ea6edade', N'', N'Post 6', CAST(0 AS bit), NULL, '00000000-0000-0000-0000-000000000000', NULL),
('6d9f8068-7ca1-4330-8994-87f4d2d2c49f', '2021-01-03T22:56:41.5463278+06:00', 'fadede5d-1c91-4d95-92e4-f447ea6edade', N'', N'Post 7', CAST(0 AS bit), NULL, '00000000-0000-0000-0000-000000000000', NULL),
('b79ff025-1080-40db-91db-12a9a3c98398', '2021-01-03T22:56:41.5463324+06:00', 'fadede5d-1c91-4d95-92e4-f447ea6edade', N'', N'Post 8', CAST(0 AS bit), NULL, '00000000-0000-0000-0000-000000000000', NULL),
('2db68295-22e6-40bf-a9f5-6b235c0e336b', '2021-01-03T22:56:41.5463369+06:00', 'fadede5d-1c91-4d95-92e4-f447ea6edade', N'', N'Post 9', CAST(0 AS bit), NULL, '00000000-0000-0000-0000-000000000000', NULL),
('c8716822-42e9-45e8-8b3a-2a8f411e3019', '2021-01-03T22:56:41.5463420+06:00', 'fadede5d-1c91-4d95-92e4-f447ea6edade', N'', N'Post 10', CAST(0 AS bit), NULL, '00000000-0000-0000-0000-000000000000', NULL),
('546bfd3f-dd57-4900-9b13-7022053a6d18', '2021-01-03T22:56:41.5463465+06:00', 'fadede5d-1c91-4d95-92e4-f447ea6edade', N'', N'Post 11', CAST(0 AS bit), NULL, '00000000-0000-0000-0000-000000000000', NULL),
('614b3568-94cd-42e3-b02f-7c5a74469583', '2021-01-03T22:56:41.5463509+06:00', 'fadede5d-1c91-4d95-92e4-f447ea6edade', N'', N'Post 12', CAST(0 AS bit), NULL, '00000000-0000-0000-0000-000000000000', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedAt', N'CreatedBy', N'CreatedFrom', N'Details', N'IsArchived', N'UpdatedAt', N'UpdatedBy', N'UpdatedFrom') AND [object_id] = OBJECT_ID(N'[Blogs]'))
    SET IDENTITY_INSERT [Blogs] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'CreatedAt', N'CreatedBy', N'CreatedFrom', N'IsActive', N'IsArchived', N'LoginId', N'Mobile', N'Name', N'Password', N'UpdatedAt', N'UpdatedBy', N'UpdatedFrom', N'UserType') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([Id], [Address], [CreatedAt], [CreatedBy], [CreatedFrom], [IsActive], [IsArchived], [LoginId], [Mobile], [Name], [Password], [UpdatedAt], [UpdatedBy], [UpdatedFrom], [UserType])
VALUES ('fadede5d-1c91-4d95-92e4-f447ea6edade', N'Dhaka, Banlgadesh', '2021-01-03T22:56:41.5317355+06:00', 'fadede5d-1c91-4d95-92e4-f447ea6edade', N'', CAST(1 AS bit), CAST(0 AS bit), N'admin@gmail.com', N'013xxxxxxxx', N'Admin', N'8cb2237d0679ca88db6464eac60da96345513964', NULL, '00000000-0000-0000-0000-000000000000', NULL, 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'CreatedAt', N'CreatedBy', N'CreatedFrom', N'IsActive', N'IsArchived', N'LoginId', N'Mobile', N'Name', N'Password', N'UpdatedAt', N'UpdatedBy', N'UpdatedFrom', N'UserType') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BlogId', N'Comment', N'CreatedAt', N'CreatedBy', N'CreatedFrom', N'Dislike', N'IsArchived', N'Like', N'UpdatedAt', N'UpdatedBy', N'UpdatedFrom') AND [object_id] = OBJECT_ID(N'[BlogComment]'))
    SET IDENTITY_INSERT [BlogComment] ON;
INSERT INTO [BlogComment] ([Id], [BlogId], [Comment], [CreatedAt], [CreatedBy], [CreatedFrom], [Dislike], [IsArchived], [Like], [UpdatedAt], [UpdatedBy], [UpdatedFrom])
VALUES ('063b287a-378e-4c98-950d-27e437b98dc3', '063b287a-378e-4c98-950d-27e437b98dc3', N'Comment 1', '2021-01-03T22:56:41.5462219+06:00', 'fadede5d-1c91-4d95-92e4-f447ea6edade', N'', 2, CAST(0 AS bit), 5, NULL, '00000000-0000-0000-0000-000000000000', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BlogId', N'Comment', N'CreatedAt', N'CreatedBy', N'CreatedFrom', N'Dislike', N'IsArchived', N'Like', N'UpdatedAt', N'UpdatedBy', N'UpdatedFrom') AND [object_id] = OBJECT_ID(N'[BlogComment]'))
    SET IDENTITY_INSERT [BlogComment] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BlogId', N'Comment', N'CreatedAt', N'CreatedBy', N'CreatedFrom', N'Dislike', N'IsArchived', N'Like', N'UpdatedAt', N'UpdatedBy', N'UpdatedFrom') AND [object_id] = OBJECT_ID(N'[BlogComment]'))
    SET IDENTITY_INSERT [BlogComment] ON;
INSERT INTO [BlogComment] ([Id], [BlogId], [Comment], [CreatedAt], [CreatedBy], [CreatedFrom], [Dislike], [IsArchived], [Like], [UpdatedAt], [UpdatedBy], [UpdatedFrom])
VALUES ('52315bc2-0192-43da-88ec-669076082158', '063b287a-378e-4c98-950d-27e437b98dc3', N'Comment 2', '2021-01-03T22:56:41.5462923+06:00', 'fadede5d-1c91-4d95-92e4-f447ea6edade', N'', 21, CAST(0 AS bit), 45, NULL, '00000000-0000-0000-0000-000000000000', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BlogId', N'Comment', N'CreatedAt', N'CreatedBy', N'CreatedFrom', N'Dislike', N'IsArchived', N'Like', N'UpdatedAt', N'UpdatedBy', N'UpdatedFrom') AND [object_id] = OBJECT_ID(N'[BlogComment]'))
    SET IDENTITY_INSERT [BlogComment] OFF;
GO

CREATE INDEX [IX_BlogComment_BlogId] ON [BlogComment] ([BlogId]);
GO

CREATE UNIQUE INDEX [IX_Users_LoginId] ON [Users] ([LoginId]) WHERE [LoginId] IS NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210103165642_V.01', N'5.0.1');
GO

COMMIT;
GO

