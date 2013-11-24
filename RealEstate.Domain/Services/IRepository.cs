using System;
using System.Linq;
using System.Linq.Expressions;
using RealEstate.Domain.Entities;

namespace RealEstate.Domain.Services
{
    public interface IRepository
    {
        T First<T>(Expression<Func<T, bool>> query) where T : class, IEntity;
        T GetById<T>(long id) where T : class, IEntity;
        IQueryable<T> Query<T>(Expression<Func<T, bool>> expression) where T : class, IEntity;
        T Create<T>(T itemToCreate) where T : class, IEntity;
        T Update<T>(T itemToUpdate) where T : class, IEntity;
        void Archive<T>(T itemToArchive);
        IQueryable<T> GetAll<T>() where T : class, IEntity;
    }

    
}