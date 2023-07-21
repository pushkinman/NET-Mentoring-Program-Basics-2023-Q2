CREATE TRIGGER CreateCompanyOnEmployeeInsert
ON Employee
AFTER INSERT
AS
BEGIN
    DECLARE @AddressId int;
    DECLARE @CompanyName nvarchar(20);

    -- Get the inserted employee's address ID
    SELECT @AddressId = AddressId FROM inserted;

    -- Get the inserted employee's company name
    SELECT @CompanyName = CompanyName FROM inserted;

    -- Check if a company with the same name already exists
    IF NOT EXISTS (SELECT * FROM Company WHERE Name = @CompanyName)
    BEGIN
        -- Insert the new company with the employee's address
        DECLARE @CompanyId int;
        INSERT INTO Company (Name, AddressId)
        VALUES (@CompanyName, @AddressId);
        SET @CompanyId = SCOPE_IDENTITY();
    END
END