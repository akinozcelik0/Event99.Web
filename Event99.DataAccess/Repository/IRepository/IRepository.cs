using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Event99.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //Async Methods
        Task<T> GetAsync(int? id); //
        Task<T> GetAsync(Guid? id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, string? includeProperties = null);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<bool> Exists(int id); //
        Task<bool> Exists(Guid id);

        //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-//

        //Non-Async Methods

        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, string? includeProperties = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
        void Update(T entity);

    }
}
