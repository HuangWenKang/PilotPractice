using CleanArchitecture.Application.Interfaces;
using NHibernate;
using System;

namespace Persistent.NHibernate.Repository
{
    public class NHibernateUnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;
        private ITransaction _transaction;
        public NHibernateUnitOfWork(ISession session)
        {
            _session = session;
            _transaction = _session.BeginTransaction();
        }
        public void Dispose()
        {
            if (_transaction != null)
                _transaction.Rollback();
        }
        public void SaveChanges()
        {
            if (_transaction == null)
                throw new InvalidOperationException("UnitOfWork have already been saved.");
            _transaction.Commit();
            _transaction = null;
        }
    }
}
