using System;
using System.Collections.Generic;
using System.Data.Entity;
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

    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private SchoolContext Context { get; set; }
        public GenericRepository(SchoolContext context)
        {
            Context = context;
        }

        protected DbSet<T> DbSet
        {
            get
            {
                if (_dbSet == null)
                    _dbSet = Context.Set<T>();
                return _dbSet;
            }
        }
        private DbSet<T> _dbSet;

        public void Commit()
        {
            Context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await Context.SaveChangesAsync();
        }

        public void Delete(object id, bool saveChanges = false)
        {
            var item = GetById(id);
            this.DbSet.Remove(item);
            if (saveChanges)
            {
                Context.SaveChanges();
            }
        }

        public void Delete(T entity, bool saveChanges = false)
        {
            this.DbSet.Attach(entity);
            this.DbSet.Remove(entity);
            if (saveChanges)
            {
                Context.SaveChanges();
            }
        }

        public async Task DeleteAsync(object id, bool saveChanges = false)
        {
            this.DbSet.Remove(GetById(id));
            if (saveChanges)
            {
                await Context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(T entity, bool saveChanges = false)
        {
            this.DbSet.Attach(entity);
            this.DbSet.Remove(entity);
            if (saveChanges)
            {
                await Context.SaveChangesAsync();
            }
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return DbSet.FirstOrDefault(match);
        }

        public Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return this.DbSet.FirstOrDefaultAsync(match);
        }

        public IQueryable<T> GetAllPaged(int pageIndex, int pageSize, out int totalCount)
        {
            totalCount = this.DbSet.Count();
            return this.DbSet.Skip(pageSize * pageIndex).Take(pageSize);
        }

        public IQueryable<T> GetByExpression(Expression<Func<T, bool>> match)
        {
            if (match != null)
                return this.DbSet.Where(match);
            return this.DbSet;

        }

        public async Task<IList<T>> GetByExpressionAsync(Expression<Func<T, bool>> match)
        {
            return await this.DbSet.Where(match).ToListAsync();
        }

        public T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await this.DbSet.FindAsync(id);
        }

        public object Insert(T entity, bool saveChanges = false)
        {
            var rtn = this.DbSet.Add(entity);
            if (saveChanges)
            {
                Context.SaveChanges();
            }
            return rtn;
        }

        public void Update(T entity, bool saveChanges = false)
        {
            var entry = Context.Entry(entity);
            this.DbSet.Attach(entity);
            entry.State = EntityState.Modified;
            if (saveChanges)
            {
                Context.SaveChanges();
            }
        }

        public T Update(T entity, object key, bool saveChanges = false)
        {
            if (entity == null)
                return null;
            var exist = this.DbSet.Find(key);
            if (exist != null)
            {
                Context.Entry(exist).CurrentValues.SetValues(entity);
                if (saveChanges)
                {
                    Context.SaveChanges();
                }
            }
            return exist;
        }

        public async Task UpdateAsync(T entity, bool saveChanges = false)
        {
            var entry = Context.Entry(entity);
            this.DbSet.Attach(entity);
            entry.State = EntityState.Modified;
            if (saveChanges)
            {
                await Context.SaveChangesAsync();
            };
        }

        public async Task<T> UpdateAsync(T entity, object key, bool saveChanges = false)
        {
            if (entity == null)
                return null;
            var exist = await this.DbSet.FindAsync(key);
            if (exist != null)
            {
                Context.Entry(exist).CurrentValues.SetValues(entity);
                if (saveChanges)
                {
                    await Context.SaveChangesAsync();
                }
            }
            return exist;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IQueryable<T> GetAllIncluding(Expression<Func<T, bool>> match, params string[] includeProperties)
        {
            IQueryable<T> queryable;
            if (match != null)
                queryable = this.DbSet.Where(match);
            else
                queryable = this.DbSet;

            foreach (var includeProperty in includeProperties)
            {

                queryable = queryable.Include(includeProperty);


            }
            return queryable;
        }

        public async Task<IList<T>> GetAllIncludingAsync(Expression<Func<T, bool>> match, params string[] includeProperties)
        {
            IQueryable<T> queryable;
            if (match != null)
                queryable = this.DbSet.Where(match);
            else
                queryable = this.DbSet;

            foreach (var includeProperty in includeProperties)
            {

                queryable = queryable.Include(includeProperty);


            }
            return await queryable.ToListAsync();
        }

        public T GetByIdMultipleKeys(params object[] keyValues)
        {
            return this.DbSet.Find(keyValues);
        }
    }
}
