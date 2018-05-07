namespace Application.Books.Queries.GetBookList
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Year { get; set; }
        public string Author { get; internal set; }
        public string ISBN { get; internal set; }
        public string Pages { get; internal set; }
        public string Language { get; internal set; }
        public string FileSize { get; internal set; }
        public string FileFormat { get; internal set; }
        public string Category { get; internal set; }
        public string Description { get; internal set; }
        public string HtmlDescription { get; internal set; }
        public string PdfUrl { get; internal set; }
    }
}