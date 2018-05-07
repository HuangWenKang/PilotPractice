using Infrastructure.NetWork;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Application.Books.Queries.GetBookList
{
    public class GetBookListQuery : IGetBookListQuery
    {
        private const string UriString = @"http://www.allitebooks.com/";        
        private IBookParser parser;
        private IHttpClientWrapper clientWrapper;
        public GetBookListQuery(IBookParser parser, IHttpClientWrapper clientWrapper)
        {
            this.parser = parser;
            this.clientWrapper = clientWrapper;            
        }
        public List<BookModel> Execute(string keyword)
        {
            List<BookModel> books = new List<BookModel>();
            //int pageSize = 100;
            string path = string.Format(@"{0}?s={1}",UriString, keyword);
            string mainHtml= clientWrapper.Get(path,new KeyValuePair<string, string>());

            books = parser.Parse(mainHtml);
            return books;
        }        
    }

}