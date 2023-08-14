CREATE TABLE [Order] (
    Id INT PRIMARY KEY IDENTITY,
    Status NVARCHAR(50),
    CreateDate DATETIME,
    UpdateDate DATETIME,
    ProductId INT,
    FOREIGN KEY (ProductId) REFERENCES Product(Id)
);
