namespace Vanilla.Core.IO
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;

        void SaveChanges();
    }
}
