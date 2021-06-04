CREATE TABLE [dbo].[Sale]
(
	[ID] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Date] DATETIME NULL, 
    [Amount] FLOAT NULL, 
    [Commissions] FLOAT NULL, 
    [Passengers] INT NULL, 
    [PackageID] BIGINT NULL, 
    [ClientID] BIGINT NULL, 
    [SalesmanID] BIGINT NULL, 
    CONSTRAINT [FK_Sale_Salesman] FOREIGN KEY (SalesmanID) REFERENCES [DBO].Salesman(ID), 
    CONSTRAINT [FK_Sale_ToClient] FOREIGN KEY ([ClientID]) REFERENCES [DBO].Client(ID)
)
