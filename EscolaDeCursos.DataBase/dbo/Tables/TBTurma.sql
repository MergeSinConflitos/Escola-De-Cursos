CREATE TABLE [dbo].[TBTurma] (
    [Id]                  UNIQUEIDENTIFIER NOT NULL,
    [Nome]                NVARCHAR (100)   NOT NULL,
    [Periodo]             INT              NOT NULL,
    [DataInicio]          DATE             NOT NULL,
    [DataTermino]         DATE             NOT NULL,
    [QuantidadeMaxAlunos] INT              NOT NULL,
    [CursoId]             UNIQUEIDENTIFIER NOT NULL,
    [InstrutorId]         UNIQUEIDENTIFIER NOT NULL
);
GO

ALTER TABLE [dbo].[TBTurma]
    ADD CONSTRAINT [PK_TBTurma] PRIMARY KEY CLUSTERED ([Id] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_TBTurma_InstrutorId]
    ON [dbo].[TBTurma]([InstrutorId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_TBTurma_CursoId]
    ON [dbo].[TBTurma]([CursoId] ASC);
GO

ALTER TABLE [dbo].[TBTurma]
    ADD CONSTRAINT [FK_TBTurma_TBInstrutor_InstrutorId] FOREIGN KEY ([InstrutorId]) REFERENCES [dbo].[TBInstrutor] ([Id]);
GO

ALTER TABLE [dbo].[TBTurma]
    ADD CONSTRAINT [FK_TBTurma_TB_Curso_CursoId] FOREIGN KEY ([CursoId]) REFERENCES [dbo].[TB_Curso] ([Id]);
GO

