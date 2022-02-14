CREATE TABLE [Identity].[UserRoles] (
    [UserId] NVARCHAR (450) NOT NULL,
    [RoleId] NVARCHAR (450) NOT NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_UserRoles_ApplicationUser_UserId] FOREIGN KEY ([UserId]) REFERENCES [Identity].[ApplicationUser] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserRoles_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Identity].[Role] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserRoles_RoleId]
    ON [Identity].[UserRoles]([RoleId] ASC);

