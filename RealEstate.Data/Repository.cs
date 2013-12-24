using System;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Services;

namespace RealEstate.Data
{
    public class Repository : IRepository
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public T First<T>(Expression<Func<T, bool>> query) where T : class, IEntity
        {
            T firstOrDefault = _session.Query<T>().FirstOrDefault(query);
            
            
            return firstOrDefault;
        }

        public T GetById<T>(long id) where T : class, IEntity
        {
            var item = _session.Get<T>(id);
            return item;
        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> expression) where T : class, IEntity
        {
            return _session.Query<T>().Where(expression);
        }

        public T Create<T>(T itemToCreate) where T : class, IEntity
        {
            _session.Save(itemToCreate);
            return itemToCreate;
        }
        public void Delete<T>(T itemToDelete) where T : class, IEntity
        {
            _session.Delete(itemToDelete);
            _session.Flush();
            _session.Clear();
            
        }
        public T Update<T>(T itemToUpdate) where T : class, IEntity
        {
            _session.Update(itemToUpdate);
            _session.Flush();
            _session.Clear();
            return itemToUpdate;
        }

        public void Archive<T>(T itemToArchive)
        {
           
        }

        public IQueryable<T> GetAll<T>() where T : class, IEntity
        {
            return _session.Query<T>();
        }
        
    }
}
