namespace Vanilla.Core.IO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Interface representing the Repository pattern
    /// </summary>
    /// <typeparam name="T">The type of the Repository</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Add an item to the repository
        /// </summary>
        /// <param name="value">The item to add</param>
        void Add(T value);

        /// <summary>
        /// Get items matching this expression
        /// </summary>
        /// <param name="filter">A lambda expression to filter items by</param>
        /// <returns>Returns an IEnumerable of T that match the filter</returns>
        IEnumerable<T> Where(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Return a single element matching this expression or defaults to null if no matching expression is found.
        /// </summary>
        /// <param name="filter">A lambda expression to filter items by</param>
        /// <returns>Returns an individual T that matches the filter or null</returns>
        T SingleOrDefault(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Return all the elements to delegate querying to business logic
        /// </summary>
        /// <returns>Returns an object that can be queried</returns>
        IQueryable<T> AsQueryable();

        /// <summary>
        /// Remove an item from the repository
        /// </summary>
        /// <param name="value">The item to remove</param>
        void Delete(T value);
    }
}
