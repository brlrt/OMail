namespace OMail.MailService.DataLayer
{
    /// <summary>
    /// Provides project specific connection strings for connecting to databases using EF.
    /// </summary>
    public class ConnectionStrings
    {
        public const string Development = @"Data Source=DESKTOP-BM8CBVN;Initial Catalog=OMailService;Integrated Security=true";
        public const string Production = @"R";

        public const string CompileTimeSwitchedString = Development;
    }
}