using System.Linq;
using System;

namespace HotDesk.Models.Repositories
{
    public interface IRepository
    {
        T Get<T>(Func<T, bool> predicate) where T : class;
        IQueryable<T> GetAll<T>() where T : class;
        void Add<T>(T item) where T : class;
        void Remove<T>(T item) where T : class;
        void SaveChanges();
    }
}
