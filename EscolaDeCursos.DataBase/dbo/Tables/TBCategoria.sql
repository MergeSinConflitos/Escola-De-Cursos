CREATE TABLE [dbo].[TBCategoria] (
    [Id]   UNIQUEIDENTIFIER NOT NULL,
    [Nome] NVARCHAR (100)   NOT NULL
);
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_TBCategoria_Nome]
    ON [dbo].[TBCategoria]([Nome] ASC);
GO

ALTER TABLE [dbo].[TBCategoria]
    ADD CONSTRAINT [PK_TBCategoria] PRIMARY KEY CLUSTERED ([Id] ASC);
GO

