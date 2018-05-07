using Domain.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Articles
{
    public interface IArticleRepository
    {
        Article Find(String title);

        IList<Article> FindAll();
    }
}
