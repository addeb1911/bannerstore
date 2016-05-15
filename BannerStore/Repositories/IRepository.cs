using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BannerStore.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Get(string id);
        void Remove(string id);
        void Edit(string id, T entity);
        IEnumerable<T> GetAll();
    }
}