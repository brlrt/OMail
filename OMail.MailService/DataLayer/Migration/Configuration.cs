using System.Data.Entity.Migrations;

namespace OMail.MailService.DataLayer.Migration
{
    /// <summary>
    /// Enables database configuration
    /// </summary>
    public class Configuration : DbMigrationsConfiguration<MailServiceDatabaseContext>
    {
        /// <summary>
        /// Enables automatic Migration when migrating the databse
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }
    }
}