CREATE TABLE [dbo].[Roles] (
    [Id]       INT           NOT NULL,
    [RoleName] NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([RoleName] ASC)
);

