using System;
using System.Linq;
using HotDesk.Data;

namespace HotDesk.Models.Repositories
{
    public class Repository : IRepository
    {
        private readonly HotDeskDbContext _context;

        public Repository(HotDeskDbContext context) => _context = context;

        public T Get<T>(Func<T, bool> predicate) where T : class
        {
            return _context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return _context.Set<T>();
        }

        public void Add<T>(T item) where T : class
        {
           _context.Set<T>().Add(item);
        }

        public void Remove<T>(T item) where T : class
        {
            _context.Set<T>().Remove(item);
        }

        public void SaveChanges() => _context.SaveChanges();
    }
}
