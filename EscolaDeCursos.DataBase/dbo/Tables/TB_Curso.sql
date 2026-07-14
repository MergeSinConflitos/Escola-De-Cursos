CREATE TABLE [dbo].[TB_Curso] (
    [Id]                   UNIQUEIDENTIFIER NOT NULL,
    [Nome]                 NVARCHAR (100)   NOT NULL,
    [CargaHoraria]         INT              NOT NULL,
    [CategoriaId]          UNIQUEIDENTIFIER NOT NULL,
    [NivelDeDificuldadeId] UNIQUEIDENTIFIER NOT NULL
);
GO

CREATE NONCLUSTERED INDEX [IX_TB_Curso_NivelDeDificuldadeId]
    ON [dbo].[TB_Curso]([NivelDeDificuldadeId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_TB_Curso_CategoriaId]
    ON [dbo].[TB_Curso]([CategoriaId] ASC);
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_TB_Curso_Nome]
    ON [dbo].[TB_Curso]([Nome] ASC);
GO

ALTER TABLE [dbo].[TB_Curso]
    ADD CONSTRAINT [FK_TB_Curso_TBCategoria_CategoriaId] FOREIGN KEY ([CategoriaId]) REFERENCES [dbo].[TBCategoria] ([Id]) ON DELETE CASCADE;
GO

ALTER TABLE [dbo].[TB_Curso]
    ADD CONSTRAINT [FK_TB_Curso_TB_NivelDeDificuldade_NivelDeDificuldadeId] FOREIGN KEY ([NivelDeDificuldadeId]) REFERENCES [dbo].[TB_NivelDeDificuldade] ([Id]) ON DELETE CASCADE;
GO

ALTER TABLE [dbo].[TB_Curso]
    ADD CONSTRAINT [PK_TBCurso] PRIMARY KEY CLUSTERED ([Id] ASC);
GO

