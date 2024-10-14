using CarDealer.DTOs.Import;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Utilities
{
    public class XmlHelper
    {
        public T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute root =
                new XmlRootAttribute(rootName);
            XmlSerializer serializer =
                new XmlSerializer(typeof(T), root);

            StringReader streamReader = new StringReader(inputXml);
            T Dtos = 
                (T)serializer.Deserialize(streamReader)!;
        
            return Dtos;
        }

        //May not be used
        public IEnumerable<T> DeserializeCollection<T>(string inputXml, string rootName)
        {
            XmlRootAttribute root =
                new XmlRootAttribute(rootName);
            XmlSerializer serializer =
                new XmlSerializer(typeof(T[]), root);

            StreamReader streamReader = new StreamReader(inputXml);
            T[] Dtos =
                (T[])serializer.Deserialize(streamReader)!;

            return Dtos;
        }

        // Serialize<ExportDto[]>(ExportDto[], rootName)
        // Serialize<ExportDto>(ExportDto, rootName)
        public string Serialize<T>(T obj, string rootName)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot =
                new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(T), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, obj, namespaces);

            return sb.ToString().TrimEnd();
        }

        // Serialize<ExportDto>(ExportDto[], rootName)
        public string Serialize<T>(T[] obj, string rootName)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot =
                new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(T[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, obj, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
