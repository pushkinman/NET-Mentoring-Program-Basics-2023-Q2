using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerialization
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

            string filePath = "department.bin";
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, department);
            }

            Department deserializedDepartment;
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                deserializedDepartment = (Department)bf.Deserialize(fs);
            }

            Console.WriteLine("Department Name: " + deserializedDepartment.DepartmentName);
            foreach (var employee in deserializedDepartment.Employees)
            {
                Console.WriteLine("Employee Name: " + employee.EmployeeName);
            }
        }
    }
}