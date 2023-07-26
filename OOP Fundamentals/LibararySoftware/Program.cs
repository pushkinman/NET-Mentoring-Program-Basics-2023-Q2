using LibrarySoftware.Interfaces;

namespace LibrarySoftware
{
    class Program
    {
        static void Main()
        {
            string documentsFolderPath = "C:\\Users\\Anton\\Documents\\NET\\NET-Mentoring-Program-Basics-2023-Q2\\OOP Fundamentals\\LibararySoftware\\Data\\";

            IDocumentRepository documentRepository = new FileDocumentRepository(documentsFolderPath);

            Console.WriteLine("Enter the document number to search:");
            string documentNumber = Console.ReadLine();

            Document document = documentRepository.GetDocumentByNumber(documentNumber);

            if (document == null)
            {
                Console.WriteLine("Document not found!");
            }
            else
            {
                Console.WriteLine($"Document Type: {document.GetType().Name}");
                Console.WriteLine($"Title: {document.Title}");
                Console.WriteLine($"Authors: {document.Authors}");
                Console.WriteLine($"Date Published: {document.DatePublished}");

                if (document is Patent patent)
                {
                    Console.WriteLine($"Expiration Date: {patent.ExpirationDate}");
                    Console.WriteLine($"Unique ID: {patent.UniqueId}");
                }
                else if (document is Book book)
                {
                    Console.WriteLine($"ISBN: {book.ISBN}");
                    Console.WriteLine($"Number of Pages: {book.NumberOfPages}");
                    Console.WriteLine($"Publisher: {book.Publisher}");
                }
                else if (document is LocalizedBook localizedBook)
                {
                    Console.WriteLine($"ISBN: {localizedBook.ISBN}");
                    Console.WriteLine($"Number of Pages: {localizedBook.NumberOfPages}");
                    Console.WriteLine($"Original Publisher: {localizedBook.OriginalPublisher}");
                    Console.WriteLine($"Country of Localization: {localizedBook.CountryOfLocalization}");
                    Console.WriteLine($"Local Publisher: {localizedBook.LocalPublisher}");
                }
            }
        }
    }
}