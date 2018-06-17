using System;
using OMail.MailService.DataLayer.Models;

namespace OMail.MailService.DataLayer
{
    /// <summary>
    /// Concrete implementation of IUnitOfWork using a DataAppDataBase _context instance to begin and dispose a transaction.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private MailServiceDatabaseContext _context;
        private bool _isDisposed = false;

        /// <summary>
        /// Initializes the the _context variable with a new DataAppDatabaseContext.
        /// </summary>
        public UnitOfWork()
        {
            _context = new MailServiceDatabaseContext();

            Messages = new Repository<Message>(_context);
            Users = new Repository<User>(_context);
        }

        public IRepository<Message> Messages
        {
            get;
        }

        public IRepository<User> Users
        {
            get;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        private void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            if (disposing)
            {
                _context.Dispose();
            }

            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}