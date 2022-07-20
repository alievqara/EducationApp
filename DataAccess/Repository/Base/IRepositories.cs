using Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Base
{
    public interface IRepositories<T> where T : IEntity
    {
        T Create(T entity);
        void Update(T entity);
        void Delete(T entity);

        T Get(Predicate<T> filter);
        List<T> GetAll(Predicate<T> filter = null);

    }
}
