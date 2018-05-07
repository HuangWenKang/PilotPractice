using Application.Books.Queries.GetBookList;
using FluentAssertions;
using Infrastructure.NetWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.Books.Queries
{
    public class BookParserTests
    {
        [Fact]
        public void Parse_UsingHtml_ReturnBooks()
        {
            IHttpClientWrapper clientWrapper = new HttpClientWrapper();
            IBookParser parser = new BookParser(clientWrapper);
            string htmlContent = "";

            var books = parser.Parse(htmlContent);

            books.Count.Should().Be(0);

        }
    }
}
