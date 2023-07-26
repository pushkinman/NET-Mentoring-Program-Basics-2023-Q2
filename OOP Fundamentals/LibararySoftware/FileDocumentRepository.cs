using LibrarySoftware.Interfaces;
using Newtonsoft.Json.Linq;

namespace LibrarySoftware
{
    public class FileDocumentRepository : IDocumentRepository
    {
        private string documentsFolderPath;
        private Dictionary<string, Document> documentCache;
        private Dictionary<string, TimeSpan> cacheExpirationTimes;

        public FileDocumentRepository(string folderPath)
        {
            documentsFolderPath = folderPath;
            documentCache = new Dictionary<string, Document>();
            cacheExpirationTimes = new Dictionary<string, TimeSpan>
        {
            { "Patent", TimeSpan.FromMinutes(30) },
            { "Book", TimeSpan.FromMinutes(60) },
            { "LocalizedBook", TimeSpan.FromMinutes(45) },
            { "Magazine", TimeSpan.FromMinutes(15) }
        };
        }

        public Document GetDocumentByNumber(string documentNumber)
        {
            
            if (documentCache.TryGetValue(documentNumber, out var cachedDocument))
            {
                if (!IsCacheExpired(documentNumber))
                    return cachedDocument;
                else
                    documentCache.Remove(documentNumber);
            }

            string filePath = Path.Combine(documentsFolderPath, $"{documentNumber}.json");

            if (!File.Exists(filePath))
                return null;

            string jsonContent = File.ReadAllText(filePath);
            JObject documentData = JObject.Parse(jsonContent);

            string documentType = (string)documentData["Type"];
            Document document = null;

            switch (documentType)
            {
                case "Patent":
                    document = documentData.ToObject<Patent>();
                    break;
                case "Book":
                    document = documentData.ToObject<Book>();
                    break;
                case "LocalizedBook":
                    document = documentData.ToObject<LocalizedBook>();
                    break;
                case "Magazine":
                    document = documentData.ToObject<Magazine>();
                    break;
                default:
                    return null;
            }

            if (cacheExpirationTimes.ContainsKey(documentType))
            {
                documentCache[documentNumber] = document;
            }

            return document;
        }

        private bool IsCacheExpired(string documentNumber)
        {
            if (documentCache.TryGetValue(documentNumber, out var cachedDocument))
            {
                string documentType = cachedDocument.GetType().Name;

                if (cacheExpirationTimes.TryGetValue(documentType, out var cacheExpirationTime))
                {
                    DateTime cacheTime = (DateTime)cachedDocument.GetType().GetProperty("DatePublished").GetValue(cachedDocument);
                    DateTime expirationTime = cacheTime.Add(cacheExpirationTime);
                    return DateTime.Now > expirationTime;
                }
            }

            return true;
        }
    }

}
