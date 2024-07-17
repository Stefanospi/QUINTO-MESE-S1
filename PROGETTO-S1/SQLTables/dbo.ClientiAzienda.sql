CREATE TABLE [dbo].[ClientiAzienda] (
    [IdClienteAzienda] INT           IDENTITY (1, 1) NOT NULL,
    [Nome]             NVARCHAR (50) NOT NULL,
    [Sede]             NVARCHAR (50) NOT NULL,
    [Intestatario]     NVARCHAR (50) NOT NULL,
    [PIVA]             NCHAR (20)    NOT NULL,
    PRIMARY KEY CLUSTERED ([IdClienteAzienda] ASC)
);

