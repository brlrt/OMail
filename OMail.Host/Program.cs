using OMail.MailService.DataLayer;
using OMail.MailService.DataLayer.Models;
using OMail.Utilities.Logging;
using System;
using System.Linq;
using System.ServiceModel;

namespace OMail.Host
{
    /// <summary>
    /// Hosts the Service on the localhost and port specified in the app.config file
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Login:
            //Passwort mindestlänge
            //Bessere Fehlermeldung etc.

            //GUI komplett überarbeiten??

            using (var host = new ServiceHost(typeof(MailService.MailService)))
            {
                host.Open();
                Console.ReadKey(true);
            }
        }
    }
}
