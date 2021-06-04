CREATE TABLE [dbo].[Product]
(
	[ID] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [TypeID] BIGINT NULL, 
    [Description] VARCHAR(500) NULL, 
    [PackageID] BIGINT NULL, 
    [Category] INT NULL, 
    CONSTRAINT [FK_Product_ToProductType] FOREIGN KEY (TypeID) REFERENCES [DBO].Product_Type(ID), 
    CONSTRAINT [FK_Product_ToPackage] FOREIGN KEY ([PackageID]) REFERENCES [Package]([ID])
)
