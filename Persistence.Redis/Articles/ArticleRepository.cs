using Application.Articles;
using Domain.Article;
using Persistence.Redis.Repository;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Redis.Articles
{
    public class ArticleRepository : RedisRepository<Article, int>, IArticleRepository
    {
        public ArticleRepository(IRedisClient redisClient)
        : base(redisClient)
        {
        }

        public Article Find(string title)
        {
            throw new NotImplementedException();
        }

        public IList<Article> FindAll()
        {
            using (var typedClient = _redisClient.GetTypedClient<Article>())
            {
                return typedClient.GetAll();
            }
        }
    }
}
