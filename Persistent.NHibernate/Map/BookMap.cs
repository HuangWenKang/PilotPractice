using Domain.Book;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistent.NHibernate.Map
{
    public class BookMap : ClassMap<Book>
    {
        public BookMap()
        {
            Id(x=>x.Id);

            Map(x=>x.Title);
            Map(x => x.Url);
            Map(x => x.ISBN);
            Map(x => x.PublishedOn);

            Component(x => x.Author, y =>
            {
                y.Map(x => x.FirstName);
                y.Map(x => x.LastName);
            });
        }
    }
}
