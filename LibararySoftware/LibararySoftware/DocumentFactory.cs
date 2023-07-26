using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibararySoftware
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
                // Add cases for new document types here
                default:
                    throw new NotSupportedException("Unsupported document type");
            }
        }
    }
}
