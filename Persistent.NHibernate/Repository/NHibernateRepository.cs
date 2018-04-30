using Application.Interfaces;
using Domain.Common;
using NHibernate;
using NHibernate.Linq;
using System.Linq;

namespace Persistent.NHibernate.Repository
{
    public class NHibernateRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : AggregateRoot
    {
        protected ISession _session;

        public NHibernateRepository(ISession session)
        {
            _session = session;
        }

        protected ISession Session { get { return _session; } }

        public TEntity GetById(TKey id)
        {
            return _session.Get<TEntity>(id);
        }
        public void Create(TEntity entity)
        {
            _session.SaveOrUpdate(entity);
        }
        public void Update(TEntity entity)
        {
            _session.SaveOrUpdate(entity);
        }
        public void Delete(TEntity entity)
        {
            _session.Delete(entity);
        }
    }
}
