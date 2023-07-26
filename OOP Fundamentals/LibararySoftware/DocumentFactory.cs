using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySoftware
{
    public static class DocumentFactory
    {
        public static Document CreateDocument(string documentType)
        {
            switch (documentType)
            {
                case "Patent":
                    return new Patent();
                case "Book":
                    return new Book();
                case "LocalizedBook":
                    return new LocalizedBook();
                case "Magazine":
                    return new Magazine();
                // Add cases for other document types here
                default:
                    throw new NotSupportedException("Unsupported document type");
            }
        }
    }
}
