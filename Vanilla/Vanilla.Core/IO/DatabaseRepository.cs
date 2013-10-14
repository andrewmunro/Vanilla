namespace Vanilla.Core.IO
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class DatabaseRepository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// Database Context
        /// </summary>
        private DbContext context;

        public DatabaseRepository(DbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Add an entity to the database
        /// </summary>
        /// <param name="value">The entity to add</param>
        public void Add(T value)
        {
            this.context.Set<T>().Add(value);
        }

        /// <summary>
        /// Get any entities which match the filter from the database
        /// </summary>
        /// <param name="filter">Filter to apply to elements</param>
        /// <returns>All entities which matches the filter</returns>
        public IEnumerable<T> Where(Expression<Func<T, bool>> filter)
        {
            return this.context.Set<T>().Where(filter);
        }

        /// <summary>
        /// Return a single element matching this expression or defaults to null if no matching expression is found.
        /// </summary>
        /// <param name="filter">A lambda expression to filter items by</param>
        /// <returns>Returns an individual T that matches the filter or null</returns>
        public T SingleOrDefault(Expression<Func<T, bool>> filter)
        {
            return this.context.Set<T>().SingleOrDefault(filter);
        }

        /// <summary>
        /// Return all the elements to delegate querying to business logic
        /// </summary>
        /// <returns>Returns an object that can be queried</returns>
        public IQueryable<T> AsQueryable()
        {
            return this.context.Set<T>();
        }

        /// <summary>
        /// Remove an item from the database
        /// </summary>
        /// <param name="value">The item to remove</param>
        public void Delete(T value)
        {
            this.context.Set<T>().Remove(value);
        }

        /// <summary>
        /// Commit any changes to the database
        /// </summary>
        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}
