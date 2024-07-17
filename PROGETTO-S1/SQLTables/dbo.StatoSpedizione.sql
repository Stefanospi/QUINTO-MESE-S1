CREATE TABLE [dbo].[StatoSpedizione] (
    [IdStatoSpedizione]    INT            IDENTITY (1, 1) NOT NULL,
    [Stato]                NVARCHAR (50)  NOT NULL,
    [Luogo]                NVARCHAR (50)  NOT NULL,
    [Descrizione]          NVARCHAR (255) NOT NULL,
    [DataOraAggiornamento] DATETIME2 (7)  NOT NULL,
    [FK_IdSpedizione]      INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([IdStatoSpedizione] ASC),
    CONSTRAINT [FK_Spedizione] FOREIGN KEY ([FK_IdSpedizione]) REFERENCES [dbo].[Spedizioni] ([IdSpedizione])
);

