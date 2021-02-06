using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAllIncluding(Expression<Func<T, bool>> match, params string[] includeProperties);

        IQueryable<T> GetByExpression(Expression<Func<T, bool>> match);

        T GetById(object id);

        T GetByIdMultipleKeys(params Object[] keyValues);


        T Find(Expression<Func<T, bool>> match);

        IQueryable<T> GetAllPaged(int pageIndex, int pageSize, out int totalCount);

        object Insert(T entity, bool saveChanges = false);
        void Delete(object id, bool saveChanges = false);
        void Delete(T entity, bool saveChanges = false);
        void Update(T entity, bool saveChanges = false);
        T Update(T entity, object key, bool saveChanges = false);
        void Commit();

        Task<IList<T>> GetAllIncludingAsync(Expression<Func<T, bool>> match, params string[] includeProperties);


        Task<IList<T>> GetByExpressionAsync(Expression<Func<T, bool>> match);
        Task<T> GetByIdAsync(object id);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        Task DeleteAsync(object id, bool saveChanges = false);
        Task DeleteAsync(T entity, bool saveChanges = false);
        Task UpdateAsync(T entity, bool saveChanges = false);
        Task<T> UpdateAsync(T entity, object key, bool saveChanges = false);
        Task CommitAsync();

        void Dispose();
    }

}
