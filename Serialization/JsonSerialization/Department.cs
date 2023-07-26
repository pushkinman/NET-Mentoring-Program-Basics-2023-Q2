using System.Text.Json.Serialization;

namespace JsonSerialization
{
    public class Department
    {
        public string DepartmentName { get; set; }

        [JsonPropertyName("employees")]
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
