using System.Xml.Serialization;

namespace XmlSerialization
{
    public class Department
    {
        public string DepartmentName { get; set; }

        [XmlArray("Employees")]
        [XmlArrayItem("Employee")]
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
