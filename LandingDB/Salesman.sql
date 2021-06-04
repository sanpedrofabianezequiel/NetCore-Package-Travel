CREATE TABLE [dbo].[Salesman]
(
	[ID] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [FullName] VARCHAR(50) NULL, 
    [UserName] VARCHAR(50) NULL, 
    [StartDate] DATETIME NULL, 
    [IsActive] BIT NULL DEFAULT 1 , 
    [Password] VARCHAR(50) NULL, 
    [IsAdmin] BIT NULL DEFAULT 0
)
