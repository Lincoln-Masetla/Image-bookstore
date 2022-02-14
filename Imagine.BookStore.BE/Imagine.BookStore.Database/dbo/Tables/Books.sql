CREATE TABLE [dbo].[Books] (
    [Id]            UNIQUEIDENTIFIER NOT NULL,
    [Name]          NVARCHAR (MAX)   NOT NULL,
    [PurchasePrice] DECIMAL (18, 2)  NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([Id] ASC)
);

