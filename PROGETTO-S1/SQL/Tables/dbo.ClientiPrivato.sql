CREATE TABLE [dbo].[ClientiPrivato] (
    [IdClientePriv] INT           IDENTITY (1, 1) NOT NULL,
    [Nome]          NVARCHAR (50) NOT NULL,
    [Cognome]       NVARCHAR (50) NOT NULL,
    [DataNascita]   DATETIME2 (7) NOT NULL,
    [CF]            NCHAR (16)    NOT NULL,
    PRIMARY KEY CLUSTERED ([IdClientePriv] ASC)
);

