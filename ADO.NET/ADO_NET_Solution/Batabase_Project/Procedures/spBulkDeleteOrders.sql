CREATE PROCEDURE [dbo].[spBulkDeleteOrders]
    @Year INT = NULL,
    @Month INT = NULL,
    @Status NVARCHAR(50) = NULL,
    @ProductId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @FilterCondition NVARCHAR(MAX) = '1 = 1';

    IF (@Year IS NOT NULL)
    BEGIN
        SET @FilterCondition += ' AND YEAR(CreateDate) = @Year';
    END

    IF (@Month IS NOT NULL)
    BEGIN
        SET @FilterCondition += ' AND MONTH(CreateDate) = @Month';
    END

    IF (@Status IS NOT NULL)
    BEGIN
        SET @FilterCondition += ' AND Status = @Status';
    END

    IF (@ProductId IS NOT NULL)
    BEGIN
        SET @FilterCondition += ' AND ProductId = @ProductId';
    END

    DECLARE @SqlQuery NVARCHAR(MAX) = 'DELETE FROM [Order] WHERE ' + @FilterCondition;

    EXEC sp_executesql @SqlQuery, N'@Year INT, @Month INT, @Status NVARCHAR(50), @ProductId INT', @Year, @Month, @Status, @ProductId;
END;

