using System.Runtime.Serialization.Formatters.Binary;

namespace DeepCloningWithSerialization
{
    class Program
    {
        static void Main()
        {
            Department originalDepartment = new Department
            {
                DepartmentName = "HR",
                Employees = new List<Employee>
            {
                new Employee { EmployeeName = "John Doe" },
                new Employee { EmployeeName = "Jane Smith" }
            }
            };

            Department clonedDepartment = DeepClone(originalDepartment);

            clonedDepartment.DepartmentName = "IT";
            clonedDepartment.Employees[0].EmployeeName = "Mike Johnson";

            Console.WriteLine("Original Department:");
            OutputDepartment(originalDepartment);

            Console.WriteLine("\nCloned Department:");
            OutputDepartment(clonedDepartment);
        }

        private static T DeepClone<T>(T originalObject)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, originalObject);
                memoryStream.Position = 0;
                return (T)binaryFormatter.Deserialize(memoryStream);
            }
        }

        private static void OutputDepartment(Department department)
        {
            Console.WriteLine("Department Name: " + department.DepartmentName);
            Console.WriteLine("Employees:");
            foreach (var employee in department.Employees)
            {
                Console.WriteLine("- " + employee.EmployeeName);
            }
        }
    }
}