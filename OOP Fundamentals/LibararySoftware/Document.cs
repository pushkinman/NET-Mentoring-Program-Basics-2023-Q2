namespace LibrarySoftware
{
    public abstract class Document
    {
        public string Title { get; set; }
        public string Authors { get; set; }
        public DateTime DatePublished { get; set; }
    }
}
