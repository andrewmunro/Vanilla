namespace Vanilla.Core.IO
{
    using System;
    using System.Data.Entity;

    public class DatabaseUnitOfWork<T> : IUnitOfWork where T : DbContext, new()
    {
        private readonly T context;

        public DatabaseUnitOfWork()
        {
            this.context = new T();
        }

        public DatabaseUnitOfWork(T context)
        {
            this.context = context;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new DatabaseRepository<T>(this.context);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.context.Dispose();
            }
        }
    }
}
