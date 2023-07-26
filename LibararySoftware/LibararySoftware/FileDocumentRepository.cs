using LibararySoftware.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibararySoftware
{
    public class FileDocumentRepository : IDocumentRepository
    {
        private string documentsFolderPath;

        public FileDocumentRepository(string folderPath)
        {
            documentsFolderPath = folderPath;
        }

        public Document GetDocumentByNumber(string documentNumber)
        {
            string filePath = Path.Combine(documentsFolderPath, $"{documentNumber}.json");

            if (!File.Exists(filePath))
                return null;
            string jsonContent = File.ReadAllText(filePath);
            JObject documentData = JObject.Parse(jsonContent);

            string documentType = (string)documentData["Type"];

            // Deserialize based on the document type
            if (documentType == "Patent")
                return documentData.ToObject<Patent>();
            else if (documentType == "Book")
                return documentData.ToObject<Book>();
            else if (documentType == "LocalizedBook")
                return documentData.ToObject<LocalizedBook>();

            return null;
        }
    }

}
