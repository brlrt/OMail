using System.Collections.Generic;
using System.Linq;

namespace OMail.MailService.DataLayer
{
    /// <summary>
    /// A concrete implementation of the IRepository interface using an EF DatabaseContext connection.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public sealed class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly MailServiceDatabaseContext _context;

        /// <summary>
        /// Initializes the repository with the given EF database context.
        /// </summary>
        /// <param name="databaseContext">A context to use for accessing the database's table schema</param>
        public Repository(MailServiceDatabaseContext context)
        {
            _context = context;
        }

        public void Add(TEntity item)
        {
            _context.Set<TEntity>().Add(item);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public IQueryable<TEntity> GetAllMessages()
        {
            return _context.Set<TEntity>().Include("Sender").Include("Receiver");
        }

        public IQueryable<TEntity> GetAllUsers()
        {
            return _context.Set<TEntity>();
        }

        public void Remove(TEntity item)
        {
            _context.Set<TEntity>().Remove(item);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }
    }
}