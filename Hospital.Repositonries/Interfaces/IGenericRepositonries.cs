using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositonries.Interfaces
{
    public interface IGenericRepositonries<T>:IDisposable
    {
        IEnumerable<T> GetAll(Expression<Func<T,bool>> filtter=null,Func<IQueryable<T>,IOrderedQueryable<T>> 
            orderBy=null,string includeProperties =""
            );
        T GetById(object id);
        Task <T> GetByIdAsync( object id);
        void Add(T entity);
        Task<T> AddAsync(T entity);
        void Update(T entity);

        Task<T> UpdateAsync(T entity);
        void Delete(T entity);
        Task<T> DeleteAsync(T entity);
        


    }
}
