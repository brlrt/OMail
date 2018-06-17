using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using OMail.MailService.DataLayer;
using OMail.MailService.DataLayer.Importers;
using OMail.MailService.DataLayer.Models;
using OMail.Utilities.Logging;

namespace OMail.MailService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class MailService : IMailService
    {
        private static OLogger logger = new OLogger("OMailService.log", true);
        private UserImporter userImporter;

        private IUnitOfWork unitOfWork = new UnitOfWork();

        public MailService()
        {
            unitOfWork = new UnitOfWork();
            userImporter = new UserImporter(unitOfWork);
        }

        public List<Message> GetReceivedMessages(string username)
        {
            logger.Info("GetReceivedMessages() called", GetType());
            var z =  unitOfWork.Messages.GetAllMessages().Where(x => x.Receiver.Name == username).ToList();
            return z;
        }

        public List<Message> GetSendedMessages(string username)
        {
            logger.Info("GetSendedMessages() called", GetType());
            var z= unitOfWork.Messages.GetAllMessages().Where(x => x.Sender.Name == username).ToList();
            return z;
        }

        public User GetUserByUsername(string username)
        {
            return unitOfWork.Users.GetAllUsers().Where(x => x.Name == username).First();
        }

        public bool CheckIfUserExists(string username)
        {
            return unitOfWork.Users.GetAllUsers().Where(x => x.Name == username).Count() > 0;
        }

        public bool LoginUser(string username, string password)
        {
            logger.Info("LoginUser() called", GetType());
            return userImporter.LoginUser(username, password);
        }

        public bool RegisterUser(string username, string password)
        {
            logger.Info("RegisterUser() called", GetType());
            return userImporter.RegisterUser(username, password);
        }

        public void SendMessage(Message message)
        {
            logger.Info("SendMessage() called", GetType());

            message.Sender = GetUserByUsername(message.Sender.Name);
            message.Receiver = GetUserByUsername(message.Receiver.Name);

            unitOfWork.Messages.Add(message);
            unitOfWork.Commit();
        }
    }
}
