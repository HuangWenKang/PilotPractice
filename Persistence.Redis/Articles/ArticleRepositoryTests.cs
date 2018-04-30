using Domain.Article;
using Domain.Courses;
using FluentAssertions;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Persistence.Redis.Articles
{
    public class ArticleRepositoryTests
    {
        [Fact]
        public void Save_Article()
        {
            IRedisClient redisClient = new RedisClient();
            Article article = new Article("Demo Article","Demo Description");
            article.Author = new Author("FirstName","LastName");

            ArticleRepository repository = new ArticleRepository(redisClient);
            repository.Create(article);

        }

        [Fact]
        public void Get_All_Articles()
        {
            IRedisClient redisClient = new RedisClient();            
            ArticleRepository repository = new ArticleRepository(redisClient);
            var articles = repository.FindAll();

            articles.Count().Should().BeGreaterThan(0);
        }
    }
}
