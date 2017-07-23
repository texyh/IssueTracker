CREATE TABLE [dbo].[Departments]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [AdminId] UNIQUEIDENTIFIER NOT NULL, 
    [Created] DATETIME NOT NULL, 
    [CreatorId] UNIQUEIDENTIFIER NOT NULL, 
    [ModifiedById] UNIQUEIDENTIFIER NULL, 
    [Modified] DATETIME NULL, 
    CONSTRAINT [FK_Departments_Users] FOREIGN KEY ([AdminId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_Departments_Createduser] FOREIGN KEY ([CreatorId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_Departments_Modifieduser] FOREIGN KEY ([ModifiedById]) REFERENCES [Users]([Id])
)
