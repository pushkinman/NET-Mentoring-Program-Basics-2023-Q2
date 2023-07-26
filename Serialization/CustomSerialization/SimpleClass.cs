using System.Runtime.Serialization;

namespace CustomSerialization
{
    [Serializable]
    public class SimpleClass : ISerializable
    {
        public int Property1 { get; set; }
        public string Property2 { get; set; }

        public SimpleClass(int property1, string property2)
        {
            Property1 = property1;
            Property2 = property2;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Property1", Property1);
            info.AddValue("Property2", Property2);
        }

        public SimpleClass(SerializationInfo info, StreamingContext context)
        {
            Property1 = info.GetInt32("Property1");
            Property2 = info.GetString("Property2");
        }
    }
}
