using OMail.MailService.DataLayer;
using OMail.MailService.DataLayer.Models;
using System;
using System.Linq;

namespace testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ServiceReference1.MailServiceClient();

            using (var unitofwork = new UnitOfWork())
            {
                var messages = unitofwork.Messages.GetAllUsers().Where(x => x.Sender.Name == "Oscar").ToList();
             }
        }
    }
}
