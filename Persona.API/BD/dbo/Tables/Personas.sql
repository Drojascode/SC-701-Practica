CREATE TABLE [dbo].[Personas] (
    [Id]             UNIQUEIDENTIFIER NOT NULL,
    [Identificacion] NVARCHAR (MAX)   NOT NULL,
    [Nombre]         NVARCHAR (MAX)   NOT NULL,
    [Apellido]       NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED ([Id] ASC)
);

