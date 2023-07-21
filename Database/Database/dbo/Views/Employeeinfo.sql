CREATE VIEW EmployeeInfo AS
SELECT e.Id AS EmployeeId,
       COALESCE(e.EmployeeName, p.FirstName + ' ' + p.LastName) AS EmployeeFullName,
       a.ZipCode + '_' + COALESCE(a.State, '') + ', ' + COALESCE(a.City, '') + '-' + COALESCE(a.Street, '') AS EmployeeFullAddress,
       e.CompanyName + '(' + COALESCE(e.Position, '') + ')' AS EmployeeCompanyInfo
FROM Employee e
INNER JOIN Person p ON e.PersonId = p.Id
INNER JOIN Address a ON e.AddressId = a.Id
