CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [LastName] NCHAR(10) NOT NULL, 
    [FirstName] NCHAR(10) NOT NULL, 
    [NickName] NCHAR(10) NOT NULL,
    [Email] NCHAR(10) NOT NULL, 
    [Psswd] NVARCHAR(MAX) NOT NULL, 
    [RoleId] INT NOT NULL DEFAULT 1
)
