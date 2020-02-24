using System.IO;
using System.Linq;
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
            var doc = XDocument.Parse(writer.ToString());

            // Remove unwanted attributes due to funky XSD (NetworkTransactionID and others that generate as "object"
            foreach (var element in doc.Root.Descendants())
            {
                element.RemoveAttributes();
            }

            // Remove unwanted namespaces and all attributes
            foreach (var element in doc.Descendants())
            {
                element.Name = element.Name.LocalName;
                //// replacing all attributes with attributes that are not namespaces and their names are set to only the localname
                element.ReplaceAttributes((from xattrib in element.Attributes().Where(xa => !xa.IsNamespaceDeclaration) select new XAttribute(xattrib.Name.LocalName, xattrib.Value)));
                element.Attributes().Remove();
            }

            return doc;
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
