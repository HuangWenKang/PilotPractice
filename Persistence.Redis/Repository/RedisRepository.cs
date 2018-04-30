using Application.Interfaces;
using Domain.Common;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Redis.Repository
{
    public class RedisRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : AggregateRoot
    {
        protected readonly IRedisClient _redisClient;

        public RedisRepository(IRedisClient redisClient)
        {
            _redisClient = redisClient ?? throw new ArgumentNullException(nameof(redisClient));
        }

        public void Create(TEntity entity)
        {
            using (var typedClient = _redisClient.GetTypedClient<TEntity>())
            {
                typedClient.Store(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            using (var typedClient = _redisClient.GetTypedClient<TEntity>())
            {
                typedClient.Delete(entity);
            }
        }

        public TEntity GetById(TKey id)
        {
            using (var typedClient = _redisClient.GetTypedClient<TEntity>())
            {
                return typedClient.GetById(id);
            }
        }

        public void Update(TEntity entity)
        {
            using (var typedClient = _redisClient.GetTypedClient<TEntity>())
            {                
                typedClient.Store(entity);
            }
        }
    }
}
