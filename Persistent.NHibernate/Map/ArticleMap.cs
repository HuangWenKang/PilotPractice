using Domain.Article;
using FluentNHibernate.Mapping;

namespace Persistent.NHibernate.Map
{
    public class ArticleMap : ClassMap<Article>
    {
        public ArticleMap()
        {
            Id(x=>x.Id);
            Map(x=>x.Title);
            Map(x => x.Description);

            Component(x => x.Author, y => 
            {
                y.Map(x=>x.FirstName);
                y.Map(x => x.LastName);
            });

            Component(x => x.Attach, y =>
            {
                y.Map(x => x.Size);
                y.Map(x => x.Format);
                y.Map(x => x.Url);
            });
        }
    }    
}
