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
            try
            {
                this.context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
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
