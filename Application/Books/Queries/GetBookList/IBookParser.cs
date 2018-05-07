using System.Collections.Generic;

namespace Application.Books.Queries.GetBookList
{
    public interface IBookParser
    {
        List<BookModel> Parse(string html);
    }
}