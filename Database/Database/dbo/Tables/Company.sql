﻿CREATE TABLE [dbo].[Company]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(20) NOT NULL, 
    [AddressId] INT NOT NULL, 
    CONSTRAINT [FK_Company_Address] FOREIGN KEY ([AddressId]) REFERENCES [Address]([Id])
)
