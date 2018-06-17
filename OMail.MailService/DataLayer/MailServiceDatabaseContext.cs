using OMail.MailService.DataLayer.Models;
using System.Data.Entity;
using OMail.MailService.DataLayer.Migration;

namespace OMail.MailService.DataLayer
{
    /// <summary>
    /// A representation of the database's model schema.
    /// </summary>
    public class MailServiceDatabaseContext : DbContext
    {
        /// <summary>
        /// Initializes the context using the compile time switched string <seealso cref="ConnectionStrings.CompileTimeSwitchedString"/>.
        /// </summary>
        public MailServiceDatabaseContext() : base(ConnectionStrings.CompileTimeSwitchedString)
        {
            Configuration.ProxyCreationEnabled = false; 
            
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MailServiceDatabaseContext, Configuration>(true));
        }
       
        public DbSet<Message> Messages
        {
            get;
            set;
        }

        public DbSet<User> Users
        {
            get;
            set;
        }
    }
}