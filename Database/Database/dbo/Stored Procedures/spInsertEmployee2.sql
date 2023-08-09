CREATE PROCEDURE InsertEmployeeInfo2
    @EmployeeName nvarchar(100) = NULL,
    @FirstName nvarchar(50) = NULL,
    @LastName nvarchar(50) = NULL,
    @CompanyName nvarchar(20),
    @Position nvarchar(30) = NULL,
    @Street nvarchar(50),
    @City nvarchar(20) = NULL,
    @State nvarchar(50) = NULL,
    @ZipCode nvarchar(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @FullName nvarchar(100);

    -- Check that at least one name field is not null, empty, or only spaces
    IF (LEN(ISNULL(@EmployeeName, '')) + LEN(ISNULL(@FirstName, '')) + LEN(ISNULL(@LastName, ''))) = 0
    BEGIN
        RAISERROR('At least one name field must be provided', 16, 1);
        RETURN;
    END

    -- Construct the full name from the provided name fields
    SET @FullName = COALESCE(@EmployeeName, '') + ' ' + COALESCE(@FirstName, '') + ' ' + COALESCE(@LastName, '');

    -- Truncate the company name if it is longer than 20 characters
    SET @CompanyName = LEFT(@CompanyName, 20);

    -- Insert the address into the Address table
    DECLARE @AddressId int;
    INSERT INTO Address (Street, City, State, ZipCode)
    VALUES (@Street, @City, @State, @ZipCode);
    SET @AddressId = SCOPE_IDENTITY();

    -- Insert the person into the Person table
    DECLARE @PersonId int;
    INSERT INTO Person (FirstName, LastName)
    VALUES (@FirstName, @LastName);
    SET @PersonId = SCOPE_IDENTITY();

    -- Insert the employee into the Employee table
    INSERT INTO Employee (AddressId, PersonId, CompanyName, Position, EmployeeName)
    VALUES (@AddressId, @PersonId, @CompanyName, @Position, @FullName);
END