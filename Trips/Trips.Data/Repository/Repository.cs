using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.Entities;
using Trips.Core.IRepositories;
using Trips.Core.IRepository;

namespace Trips.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> _dataSet;
        protected readonly IRepositoryManager _iManager;
        public Repository(DataContext dataContex)
        {
            _dataSet = dataContex.Set<T>();
        }
        public List<T> Get()
        {
            return _dataSet.ToList();
        }
        public T? GetById(int id)
        {
            return _dataSet.Find(id);
        }

        public T Add(T t)
        {
            _dataSet.Add(t);
            return t;
        }
        public bool Delete(int id)
        {
            T find = _dataSet.Find(id);
            if (find != null)
            {
                _dataSet.Remove(find);
                return true;
            }
            return false;
        }

        public T Update(int id, T updatedEntity)
        {
            var existingEntity = _dataSet.Find(id);
            if (existingEntity == null)
            {
                return null;
            }
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                      .Where(prop => prop.Name != "Id");

            foreach (var property in properties)
            {
                var updatedValue = property.GetValue(updatedEntity);
                if (updatedValue != null)
                {
                    property.SetValue(existingEntity, updatedValue);
                }
            }
            return existingEntity;
        }
    }
}
