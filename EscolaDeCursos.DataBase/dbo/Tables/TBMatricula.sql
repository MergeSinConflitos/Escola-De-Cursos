CREATE TABLE [dbo].[TBMatricula] (
    [Id]            UNIQUEIDENTIFIER NOT NULL,
    [DataInscricao] DATE             NOT NULL,
    [Situacao]      INT              NOT NULL,
    [AlunoId]       UNIQUEIDENTIFIER NOT NULL,
    [TurmaId]       UNIQUEIDENTIFIER NOT NULL
);
GO

CREATE NONCLUSTERED INDEX [IX_TBMatricula_TurmaId]
    ON [dbo].[TBMatricula]([TurmaId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_TBMatricula_AlunoId]
    ON [dbo].[TBMatricula]([AlunoId] ASC);
GO

ALTER TABLE [dbo].[TBMatricula]
    ADD CONSTRAINT [PK_TBMatricula] PRIMARY KEY CLUSTERED ([Id] ASC);
GO

ALTER TABLE [dbo].[TBMatricula]
    ADD CONSTRAINT [FK_TBMatricula_TBTurma_TurmaId] FOREIGN KEY ([TurmaId]) REFERENCES [dbo].[TBTurma] ([Id]) ON DELETE CASCADE;
GO

ALTER TABLE [dbo].[TBMatricula]
    ADD CONSTRAINT [FK_TBMatricula_TBAluno_AlunoId] FOREIGN KEY ([AlunoId]) REFERENCES [dbo].[TBAluno] ([Id]);
GO

