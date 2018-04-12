IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Contests] (
    [Id] int NOT NULL IDENTITY,
    [EndDate] datetime2 NOT NULL,
    [EventLocation] nvarchar(max) NULL,
    [EventName] nvarchar(max) NULL,
    [FirstPlace] nvarchar(max) NULL,
    [SecondPlace] nvarchar(max) NULL,
    [StartDate] datetime2 NOT NULL,
    [ThirdPlace] nvarchar(max) NULL,
    CONSTRAINT [PK_Contests] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [HomeResorts] (
    [Id] int NOT NULL IDENTITY,
    [Country] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [VerticalMeters] int NOT NULL,
    CONSTRAINT [PK_HomeResorts] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Athletes] (
    [Id] int NOT NULL IDENTITY,
    [Age] int NOT NULL,
    [BirthCountry] nvarchar(max) NULL,
    [ContestId] int NULL,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    CONSTRAINT [PK_Athletes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Athletes_Contests_ContestId] FOREIGN KEY ([ContestId]) REFERENCES [Contests] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [AthleteContest] (
    [AthleteId] int NOT NULL,
    [ContestId] int NOT NULL,
    CONSTRAINT [PK_AthleteContest] PRIMARY KEY ([AthleteId], [ContestId]),
    CONSTRAINT [FK_AthleteContest_Athletes_AthleteId] FOREIGN KEY ([AthleteId]) REFERENCES [Athletes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AthleteContest_Contests_ContestId] FOREIGN KEY ([ContestId]) REFERENCES [Contests] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AthleteHomeResort] (
    [AthleteId] int NOT NULL,
    [HomeResortId] int NOT NULL,
    CONSTRAINT [PK_AthleteHomeResort] PRIMARY KEY ([AthleteId], [HomeResortId]),
    CONSTRAINT [FK_AthleteHomeResort_Athletes_AthleteId] FOREIGN KEY ([AthleteId]) REFERENCES [Athletes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AthleteHomeResort_HomeResorts_HomeResortId] FOREIGN KEY ([HomeResortId]) REFERENCES [HomeResorts] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Snowboards] (
    [Id] int NOT NULL IDENTITY,
    [AthelteId] int NOT NULL,
    [AthleteId] int NULL,
    [Brand] nvarchar(max) NULL,
    [Length] int NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Snowboards] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Snowboards_Athletes_AthleteId] FOREIGN KEY ([AthleteId]) REFERENCES [Athletes] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_AthleteContest_ContestId] ON [AthleteContest] ([ContestId]);

GO

CREATE INDEX [IX_AthleteHomeResort_HomeResortId] ON [AthleteHomeResort] ([HomeResortId]);

GO

CREATE INDEX [IX_Athletes_ContestId] ON [Athletes] ([ContestId]);

GO

CREATE INDEX [IX_Snowboards_AthleteId] ON [Snowboards] ([AthleteId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180404213811_init', N'2.0.2-rtm-10011');

GO

