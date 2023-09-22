using Hospital.Repositonries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositonries.Implemantations
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly AppDbContext context;
        private bool dispossed = false;
        public UnitOfWork(AppDbContext _context)
        {
            context = _context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool dispossing)
        {
            if (!this.dispossed)
                if (dispossing)
                    context.Dispose();
            this.dispossed = true;
        }
        public IGenericRepositonries<T> genericRepositonries<T>() where T : class
        {
            IGenericRepositonries<T> repo = new GenericRepositonries<T>(context);
            return repo;
        }
        public void Save()
        {
            context.SaveChanges();
        }

    }
}
