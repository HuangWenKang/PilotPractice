using FluentAssertions;
using Infrastructure.NetWork;
using Xunit;

namespace Application.Books.Queries.GetBookList
{
    public class GetBookListQueryTests
    {
        [Fact]
        public void GetBookList_UsingKeyword_ReturnBookList()
        {
            IHttpClientWrapper clientWrapper = new HttpClientWrapper();
            string keyWord = "Spring";
            IBookParser parser = new BookParser(clientWrapper);
            IGetBookListQuery query = new GetBookListQuery(parser,clientWrapper);

            var bookList = query.Execute(keyWord);

            bookList.Count.Should().BeGreaterThan(1);
        }
    }
}
