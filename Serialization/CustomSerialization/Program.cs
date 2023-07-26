using System.Runtime.Serialization.Formatters.Binary;

namespace CustomSerialization
{
    class Program
    {
        static void Main()
        {
            SimpleClass originalObject = new SimpleClass(42, "Hello, Custom Serialization!");

            byte[] serializedData = SerializeObject(originalObject);

            SimpleClass deserializedObject = DeserializeObject(serializedData);

            Console.WriteLine("Property1: " + deserializedObject.Property1);
            Console.WriteLine("Property2: " + deserializedObject.Property2);
        }

        private static byte[] SerializeObject(SimpleClass obj)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, obj);
                return memoryStream.ToArray();
            }
        }

        private static SimpleClass DeserializeObject(byte[] data)
        {
            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                return (SimpleClass)binaryFormatter.Deserialize(memoryStream);
            }
        }
    }
}