using System.Text.Json;

namespace JsonSerialization
{
    class Program
    {
        static void Main()
        {
            Department department = new Department
            {
                DepartmentName = "HR",
                Employees = new List<Employee>
            {
                new Employee { EmployeeName = "John Doe" },
                new Employee { EmployeeName = "Jane Smith" }
            }
            };

            string filePath = "department.json";
            string json = JsonSerializer.Serialize(department);
            File.WriteAllText(filePath, json);

            string jsonContent = File.ReadAllText(filePath);
            Department deserializedDepartment = JsonSerializer.Deserialize<Department>(jsonContent);

            Console.WriteLine("Department Name: " + deserializedDepartment.DepartmentName);
            foreach (var employee in deserializedDepartment.Employees)
            {
                Console.WriteLine("Employee Name: " + employee.EmployeeName);
            }
        }
    }
}