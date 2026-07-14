CREATE TABLE [dbo].[TB_Etapa] (
    [Id]      UNIQUEIDENTIFIER NOT NULL,
    [Nome]    NVARCHAR (100)   NOT NULL,
    [Duracao] INT              NOT NULL,
    [Ordem]   INT              NOT NULL,
    [CursoId] UNIQUEIDENTIFIER NOT NULL
);
GO

ALTER TABLE [dbo].[TB_Etapa]
    ADD CONSTRAINT [PK_TBEtapa] PRIMARY KEY CLUSTERED ([Id] ASC);
GO

ALTER TABLE [dbo].[TB_Etapa]
    ADD CONSTRAINT [FK_TB_Etapa_TB_Curso_CursoId] FOREIGN KEY ([CursoId]) REFERENCES [dbo].[TB_Curso] ([Id]) ON DELETE CASCADE;
GO

CREATE NONCLUSTERED INDEX [IX_TB_Etapa_CursoId]
    ON [dbo].[TB_Etapa]([CursoId] ASC);
GO

