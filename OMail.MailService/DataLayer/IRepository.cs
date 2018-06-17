using System.Collections.Generic;
using System.Linq;

namespace OMail.MailService.DataLayer
{
    /// <summary>
    /// Provides an abstraction layer for reading and writing to tables.
    /// </summary>
    /// <typeparam name="TEntity">An entity's reference type</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get's the entire table of the <see cref="TEntity"/>
        /// Note that we return a <see cref="IQueryable"/> here to let filtering happen in the database instead of the memory. 
        /// To work with the data we have to call .ToList().
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAllUsers();

        IQueryable<TEntity> GetAllMessages();

        /// <summary>
        /// Inserts an item into the repository.
        /// </summary>
        /// <param name="item">An item to insert into the repository</param>
        void Add(TEntity item);

        /// <summary>
        /// Inserts a range of items into the repository.
        /// </summary>
        /// <param name="entities">A list of <see cref="TEntity"/> to add</param>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Deletes the given item from the repository.
        /// </summary>
        /// <param name="item">An item to delete</param>
        void Remove(TEntity item);

        /// <summary>
        /// Removes a range of items from the repository.
        /// </summary>
        /// <param name="entities">A list of <see cref="TEntity"/> to remove</param>
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
