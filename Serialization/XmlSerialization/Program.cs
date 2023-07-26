using System.Xml.Serialization;

namespace XmlSerialization
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

            string filePath = "department.xml";
            XmlSerializer xs = new XmlSerializer(typeof(Department));
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                xs.Serialize(sw, department);
            }

            Department deserializedDepartment;
            using (StreamReader sr = new StreamReader(filePath))
            {
                deserializedDepartment = (Department)xs.Deserialize(sr);
            }

            Console.WriteLine("Department Name: " + deserializedDepartment.DepartmentName);
            foreach (var employee in deserializedDepartment.Employees)
            {
                Console.WriteLine("Employee Name: " + employee.EmployeeName);
            }
        }
    }
}