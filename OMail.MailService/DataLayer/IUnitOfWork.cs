using OMail.MailService.DataLayer.Models;
using System;

namespace OMail.MailService.DataLayer
{
    /// <summary>
    /// Interface that defines methods for starting and commiting a transaction. Also defines the outer repositories
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Holds a Repository of type <see cref="Message"/>
        /// </summary>
        IRepository<Message> Messages
        {
            get;
        }

        /// <summary>
        /// Holds a Repository of type <see cref="User"/>
        /// </summary>
        IRepository<User> Users
        {
            get;
        }

        /// <summary>
        /// Commits changes made to the repositories and saves them to the database.
        /// To make large imports faster, set <paramref name="DisableAutoDetectChanges"/> to true
        /// </summary>
        /// <param name="DisableAutoDetectChanges"></param>
        /// <returns>The number of state entries written to the underlying database</returns>
        void Commit();
    }
}
