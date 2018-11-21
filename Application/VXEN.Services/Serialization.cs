using System.IO;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace VXEN.Services
{
    public class Serialization
    {
        public static XDocument Serialize<T>(T data)
        {
            var xsns = GetNameSpaces<T>(data);
            var serializer = new XmlSerializer(data.GetType());
            var writer = new StringWriter();
            serializer.Serialize(writer, data, xsns);
            return XDocument.Parse(writer.ToString());
        }

        public static T Deserialize<T>(string data)
        {
            var serializer = new XmlSerializer(typeof(T));
            var reader = new StringReader(data);
            return (T)serializer.Deserialize(reader);
        }

        private static XmlSerializerNamespaces GetNameSpaces<T>(T data)
        {
            var xsns = new XmlSerializerNamespaces();
            var attributes = data.GetType().GetCustomAttributes();  // Reflection. 
            foreach (var attribute in attributes)
            {
                if (attribute.GetType() == typeof(System.Xml.Serialization.XmlRootAttribute))
                {
                    XmlRootAttribute attrib = attribute as XmlRootAttribute;
                    xsns.Add(string.Empty, attrib.Namespace);
                    break;
                }
            }
            return xsns;
        }
    }
}
