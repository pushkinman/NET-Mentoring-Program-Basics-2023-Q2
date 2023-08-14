CREATE TABLE Product (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(255),
    Description NVARCHAR(MAX),
    Weight DECIMAL(10, 2),
    Height DECIMAL(10, 2),
    Width DECIMAL(10, 2),
    Length DECIMAL(10, 2)
);
