using System;
using HotDesk.Models.Repositories;
using System.Collections.Generic;

namespace HotDesk.Models.Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepository _repository;

        public AdminService(IRepository repository) => _repository = repository;

        public T Get<T>(Func<T, bool> predicate) where T : class
        {
            return _repository.Get(predicate);
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            return _repository.GetAll<T>();
        }

        public void Add<T>(T item) where T : class
        {
            _repository.Add(item);
            _repository.SaveChanges();
        }

        public void Remove<T>(T item) where T : class
        {
            _repository.Remove(item);
            _repository.SaveChanges();
        }

        public IEnumerable<Device> UpdateDevices(int[] deviceIds)
        {
            var output = new List<Device>();

            foreach (var id in deviceIds)
            {
                output.Add(_repository.Get<Device>(d => d.Id == id));
            }

            return output;
        }
    }
}
