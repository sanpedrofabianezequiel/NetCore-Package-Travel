CREATE TABLE [dbo].[Sale_Package]
(
	[ID] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [PackageID] BIGINT NULL, 
    [SaleID] BIGINT NULL, 
    [AmountOfNights] INT NULL, 
    CONSTRAINT [FK_Sale_Package_ToSale] FOREIGN KEY ([SaleID]) REFERENCES [DBO].Sale(ID), 
    CONSTRAINT [FK_Sale_Package_ToPackage] FOREIGN KEY ([PackageID]) REFERENCES [DBO].Package(ID)
)
