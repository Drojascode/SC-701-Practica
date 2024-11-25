CREATE TABLE [dbo].[Documentos] (
    [Id]     UNIQUEIDENTIFIER NOT NULL,
    [Nombre] VARCHAR (MAX)    NOT NULL,
    [Ruta]   VARCHAR (MAX)    NOT NULL,
    [Tipo]   VARCHAR (MAX)    NOT NULL,
    CONSTRAINT [PK_Documentos] PRIMARY KEY CLUSTERED ([Id] ASC)
);

