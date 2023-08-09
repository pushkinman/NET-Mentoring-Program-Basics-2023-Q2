CREATE PROCEDURE dbo.FetchOrders
    @Month INT = NULL,
    @Year INT = NULL,
    @Status NVARCHAR(50) = NULL,
    @ProductId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, Status, CreateDate, UpdateDate, ProductId
    FROM [Order]
    WHERE (@Month IS NULL OR MONTH(CreateDate) = @Month)
        AND (@Year IS NULL OR YEAR(CreateDate) = @Year)
        AND (@Status IS NULL OR Status = @Status)
        AND (@ProductId IS NULL OR ProductId = @ProductId);
END;
