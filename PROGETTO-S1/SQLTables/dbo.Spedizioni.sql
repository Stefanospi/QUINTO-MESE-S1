CREATE TABLE [dbo].[Spedizioni] (
    [IdSpedizione]      INT             IDENTITY (1, 1) NOT NULL,
    [FK_ClienteAzienda] INT             NULL,
    [FK_ClientePrivato] INT             NULL,
    [NumId]             INT             NOT NULL,
    [DataSpedizione]    DATETIME2 (7)   NOT NULL,
    [Peso]              DECIMAL (18, 2) NOT NULL,
    [CittaDestinatario] NVARCHAR (50)   NOT NULL,
    [Indirizzo]         NVARCHAR (50)   NOT NULL,
    [NomeDestinatario]  NVARCHAR (50)   NOT NULL,
    [CostoSpedizione]   DECIMAL (18, 2) NOT NULL,
    [DataConsegnaPrev]  DATETIME2 (7)   NOT NULL,
    PRIMARY KEY CLUSTERED ([IdSpedizione] ASC),
    CONSTRAINT [FK_Azienda] FOREIGN KEY ([FK_ClienteAzienda]) REFERENCES [dbo].[ClientiAzienda] ([IdClienteAzienda]),
    CONSTRAINT [FK_Privato] FOREIGN KEY ([FK_ClientePrivato]) REFERENCES [dbo].[ClientiPrivato] ([IdClientePriv])
);

