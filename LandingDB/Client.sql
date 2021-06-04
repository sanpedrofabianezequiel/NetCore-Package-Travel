CREATE TABLE [dbo].[Client]
(
	[ID] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NULL, 
    [LastName] VARCHAR(50) NULL, 
    [TypeID] INT NULL, 
    CONSTRAINT [FK_Client_ToType] FOREIGN KEY ([TypeID]) REFERENCES [dbo].Client_Type([ID])
)
