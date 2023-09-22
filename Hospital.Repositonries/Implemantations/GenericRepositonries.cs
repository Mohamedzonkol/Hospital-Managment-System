using Hospital.Repositonries.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositonries.Implemantations
{
    public class GenericRepositonries<T> : IDisposable, IGenericRepositonries<T> where T : class
    {
        private bool disposed =false;
        private readonly AppDbContext context;
        internal DbSet<T> dbSet;

        public GenericRepositonries(AppDbContext _context)
        {
            context = _context;
            dbSet =context.Set<T>();
        }
    
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public async Task<T> AddAsync(T entity) {

            dbSet.AddAsync(entity);
            return entity;
        }
        public void Delete(T entity) {
            if(context.Entry(entity).State==EntityState.Detached)
                dbSet.Attach(entity);

            dbSet.Remove(entity);

        }
        public async Task<T> DeleteAsync(T entity) {
            if (context.Entry(entity).State == EntityState.Detached)
                dbSet.Attach(entity);

            dbSet.Remove(entity);
            return entity;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filtter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>>
            orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;
            if(filtter is not null)
                query = query.Where(filtter);
            foreach(var includeProprty in includeProperties.Split(new char[] {',' },StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProprty);
            if(orderBy is not null)
                return orderBy(query).ToList();
            else
                return query.ToList();
        }

        public T GetById(object id) {
            return dbSet.Find(id);
        }
        public async Task<T> GetByIdAsync(object id) {
            return await dbSet.FindAsync(id);
        }


        public void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
        public async Task<T> UpdateAsync(T entity)
        {

            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
                }
        public void Dispose(bool dispossing)
        {
            if(!this.disposed)
                if(dispossing)
                    context.Dispose();
            this.disposed = true;    
         }
    }
}
