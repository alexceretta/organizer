using System;
using System.Linq;
using System.Threading.Tasks;

namespace organizer_web.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        Task<T> Get(Guid id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task Delete(Guid id);
    }
}