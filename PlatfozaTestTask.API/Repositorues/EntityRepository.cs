using System;
using System.Linq;
using NHibernate;
using PlatfozaTestTask.API.Providers;

namespace PlatfozaTestTask.API.Repositorues
{
    public class EntityRepository<T> : IRepository<T>
    {
        private readonly ISession _session;

        public EntityRepository(SessionProvider sessionProvider) => 
            _session = sessionProvider.GetSession();
        
        public IQueryable<T> Get() => 
            _session.Query<T>();

        public T GetById(Guid id) 
            => _session.Get<T>(id);

        public void Change(T item)
        {
            using var transaction = _session.BeginTransaction();
            _session.Update(item);
            transaction.Commit();
        }

        public void Delete(T item)
        {
            using var transaction = _session.BeginTransaction();
            _session.Delete(item);
            transaction.Commit();
        }

        public void Create(T item)
        {
            using var transaction = _session.BeginTransaction();
            _session.Save(item);
            transaction.Commit();
        }
    }
}