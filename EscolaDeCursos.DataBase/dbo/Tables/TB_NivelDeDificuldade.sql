CREATE TABLE [dbo].[TB_NivelDeDificuldade] (
    [Id]            UNIQUEIDENTIFIER NOT NULL,
    [Nome]          NVARCHAR (50)    NOT NULL,
    [Descricao]     NVARCHAR (255)   NULL,
    [Classificacao] INT              NOT NULL
);
GO

ALTER TABLE [dbo].[TB_NivelDeDificuldade]
    ADD CONSTRAINT [PK_TBNivelDeDificuldade] PRIMARY KEY CLUSTERED ([Id] ASC);
GO

