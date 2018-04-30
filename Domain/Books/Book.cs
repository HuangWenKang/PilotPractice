using Domain.Common;
using Domain.Courses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Book
{
    public class Book : Entity
    {
        public virtual string Title { get; }
        public virtual string ISBN { get; }
        public virtual string Url { get; }
        public virtual DateTime PublishedOn { get; }
        public virtual Author Author { get; set; }

        protected Book()
        {
        }

        public Book(string title, string iSBN, DateTime publishedOn)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            ISBN = iSBN ?? throw new ArgumentNullException(nameof(iSBN));
            PublishedOn = publishedOn;
        }

        public Book(string title, string iSBN, string url, DateTime publishedOn)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            ISBN = iSBN ?? throw new ArgumentNullException(nameof(iSBN));
            Url = url ?? throw new ArgumentNullException(nameof(url));
            PublishedOn = publishedOn;
        }
    }
}
