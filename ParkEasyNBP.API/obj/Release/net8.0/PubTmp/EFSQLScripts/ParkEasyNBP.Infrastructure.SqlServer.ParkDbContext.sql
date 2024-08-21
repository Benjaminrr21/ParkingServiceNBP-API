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

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [Phone] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        [Role] nvarchar(max) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE TABLE [Zones] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [NumberOfPlaces] int NOT NULL,
        CONSTRAINT [PK_Zones] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE TABLE [RefreshTokens] (
        [Id] int NOT NULL IDENTITY,
        [Token] nvarchar(max) NOT NULL,
        [Expires] datetime2 NOT NULL,
        [Created] datetime2 NOT NULL,
        [Revoked] datetime2 NULL,
        [UserId] nvarchar(450) NULL,
        CONSTRAINT [PK_RefreshTokens] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_RefreshTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE TABLE [Vehicles] (
        [Id] int NOT NULL IDENTITY,
        [Mark] nvarchar(max) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [RegNumber] nvarchar(max) NOT NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_Vehicles] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Vehicles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE TABLE [PublicGarage] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        [NumberOfPlaces] int NOT NULL,
        [NumberOfFreePlaces] int NOT NULL,
        [WorkingTime] nvarchar(max) NOT NULL,
        [ZoneId] int NOT NULL,
        CONSTRAINT [PK_PublicGarage] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_PublicGarage_Zones_ZoneId] FOREIGN KEY ([ZoneId]) REFERENCES [Zones] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE TABLE [Controls] (
        [Id] int NOT NULL IDENTITY,
        [Time] datetime2 NOT NULL,
        [IsPenalty] bit NOT NULL,
        [VehicleId] int NOT NULL,
        [ControllorId] nvarchar(max) NOT NULL,
        [ApplicationUserId] nvarchar(450) NULL,
        CONSTRAINT [PK_Controls] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Controls_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_Controls_Vehicles_VehicleId] FOREIGN KEY ([VehicleId]) REFERENCES [Vehicles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE TABLE [OneOffCards] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(max) NOT NULL,
        [DateTimeSelling] datetime2 NOT NULL,
        [Period] datetime2 NOT NULL,
        [VehicleId] int NOT NULL,
        CONSTRAINT [PK_OneOffCards] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_OneOffCards_Vehicles_VehicleId] FOREIGN KEY ([VehicleId]) REFERENCES [Vehicles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE TABLE [Penalties] (
        [Id] int NOT NULL IDENTITY,
        [Why] nvarchar(max) NOT NULL,
        [IsPay] bit NOT NULL,
        [Price] decimal(18,2) NOT NULL,
        [Reason] nvarchar(max) NULL,
        [DateTime] datetime2 NOT NULL,
        [VehicleId] int NOT NULL,
        CONSTRAINT [PK_Penalties] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Penalties_Vehicles_VehicleId] FOREIGN KEY ([VehicleId]) REFERENCES [Vehicles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE TABLE [SubscriptionCards] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(max) NOT NULL,
        [Period] datetime2 NOT NULL,
        [VehicleId] int NOT NULL,
        CONSTRAINT [PK_SubscriptionCards] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SubscriptionCards_Vehicles_VehicleId] FOREIGN KEY ([VehicleId]) REFERENCES [Vehicles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE TABLE [ParkingPlaces] (
        [Id] int NOT NULL IDENTITY,
        [Status] nvarchar(max) NOT NULL,
        [Street] nvarchar(max) NOT NULL,
        [VehicleId] int NULL,
        [ZoneId] int NOT NULL,
        [PublicGarageId] int NULL,
        [IsUnderground] bit NULL,
        [GarageLevel] int NULL,
        CONSTRAINT [PK_ParkingPlaces] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ParkingPlaces_PublicGarage_PublicGarageId] FOREIGN KEY ([PublicGarageId]) REFERENCES [PublicGarage] ([Id]),
        CONSTRAINT [FK_ParkingPlaces_Vehicles_VehicleId] FOREIGN KEY ([VehicleId]) REFERENCES [Vehicles] ([Id]),
        CONSTRAINT [FK_ParkingPlaces_Zones_ZoneId] FOREIGN KEY ([ZoneId]) REFERENCES [Zones] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE INDEX [IX_Controls_ApplicationUserId] ON [Controls] ([ApplicationUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE INDEX [IX_Controls_VehicleId] ON [Controls] ([VehicleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE INDEX [IX_OneOffCards_VehicleId] ON [OneOffCards] ([VehicleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE INDEX [IX_ParkingPlaces_PublicGarageId] ON [ParkingPlaces] ([PublicGarageId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE INDEX [IX_ParkingPlaces_VehicleId] ON [ParkingPlaces] ([VehicleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE INDEX [IX_ParkingPlaces_ZoneId] ON [ParkingPlaces] ([ZoneId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE INDEX [IX_Penalties_VehicleId] ON [Penalties] ([VehicleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE INDEX [IX_PublicGarage_ZoneId] ON [PublicGarage] ([ZoneId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE INDEX [IX_RefreshTokens_UserId] ON [RefreshTokens] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE INDEX [IX_SubscriptionCards_VehicleId] ON [SubscriptionCards] ([VehicleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Vehicles_UserId] ON [Vehicles] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240704142130_newinit2'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240704142130_newinit2', N'8.0.6');
END;
GO

COMMIT;
GO

