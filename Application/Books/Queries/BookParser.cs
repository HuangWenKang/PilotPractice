using Application.Books.Queries.GetBookList;
using Infrastructure.NetWork;
using NSoup;
using NSoup.Nodes;
using NSoup.Select;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Queries
{
    public class BookParser : IBookParser
    {
        private IHttpClientWrapper clientWrapper;

        public BookParser(IHttpClientWrapper clientWrapper)
        {
            this.clientWrapper = clientWrapper ?? throw new ArgumentNullException(nameof(clientWrapper));
        }

        public List<BookModel> Parse(string mainHtml)
        {
            List<BookModel> books = new List<BookModel>();

            Document doc = NSoupClient.Parse(mainHtml);
            Element p = doc.Body.Child(0);

            Elements entries = doc.GetElementsByClass("entry-body");
            foreach (Element entry in entries)
            {
                Element header = entry.Select("header.entry-header").First;
                Element href = header.Select("a").First;
                String title = href.Text();
                String link = href.Attr("href");
                BookModel book = new BookModel()
                {
                    Name = title,
                    Url = string.Empty
                };

                string detailHtml = clientWrapper.Get(link,new KeyValuePair<string, string>());
                ParseAdditional(detailHtml,ref book);

                books.Add(book);
            }

            return books;

        }

        private void ParseAdditional(string html,ref BookModel book)
        {                        
            Document bookDocument = NSoupClient.Parse(html);

            Element bookDetail = bookDocument.GetElementsByClass("book-detail").First();            
            Element dd = bookDetail.Child(0);            
            Element authorElement = dd.Children[1];
            String author = authorElement.Text();
            book.Author = author;

            Element isbnElement = dd.Children[3];
            String isbn = isbnElement.Text();
            book.ISBN = isbn;

            Element yearElement = dd.Children[5];
            String year = yearElement.Text();
            book.Year = year;

            Element pageElement = dd.Children[7];
            String page = pageElement.Text();
            book.Pages = page;

            Element langeuageElement = dd.Children[9];
            String language = langeuageElement.Text();
            book.Language = language;

            Element fileSizeElement = dd.Children[11];
            String fileSize = fileSizeElement.Text();
            book.FileSize = fileSize;

            Element fileFormatElement = dd.Children[13];
            String fileFormat = fileFormatElement.Text();
            book.FileFormat = fileFormat;

            Element categoryElement = dd.Children[15];
            String category = categoryElement.Text();
            book.Category = category;

            Element entryContent = bookDocument.GetElementsByClass("entry-content").First;
            String bookDescription = entryContent.Text();
            book.Description = bookDescription;

            String bookHtmlDescription = entryContent.Html();
            book.HtmlDescription = bookHtmlDescription;

            Element downloadLink = bookDocument.GetElementsByClass("download-links").First;
            Element link = downloadLink.GetElementsByTag("a").First;

            string pdfDownloadLink = link.Attr("href");
            book.PdfUrl = pdfDownloadLink;            
        }
    }
}
