CREATE TABLE [dbo].[Issues]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Priority] INT NOT NULL, 
    [DepartmentId] BIGINT NOT NULL, 
    [Status] INT NOT NULL, 
    [ResolverId] UNIQUEIDENTIFIER NULL, 
    [ReporterId] UNIQUEIDENTIFIER NOT NULL, 
    [Comment] NVARCHAR(MAX) NULL, 
    [Created] DATETIME NOT NULL, 
    [CreatorId] UNIQUEIDENTIFIER NOT NULL, 
    [ModifiedById] UNIQUEIDENTIFIER NULL, 
    [Modified] DATETIME NULL, 
    CONSTRAINT [FK_Issues_ResolveUser] FOREIGN KEY ([ResolverId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_Issues_ReportUser] FOREIGN KEY ([ReporterId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_Issues_Departments] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments]([Id]), 
    CONSTRAINT [FK_Issues_Creator] FOREIGN KEY ([CreatorId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_Issues_Modifield] FOREIGN KEY ([ModifiedById]) REFERENCES [Users]([Id])
)
