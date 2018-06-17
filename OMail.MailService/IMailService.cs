using OMail.MailService.DataLayer.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace OMail.MailService
{
    [ServiceContract]
    public interface IMailService
    {
        [OperationContract]
        bool RegisterUser(string username, string password);

        [OperationContract]
        bool LoginUser(string username, string password);

        [OperationContract]
        List<Message> GetSendedMessages(string username);

        [OperationContract]
        List<Message> GetReceivedMessages(string username);

        [OperationContract]
        void SendMessage(Message message);

        [OperationContract]
        bool CheckIfUserExists(string username);

        [OperationContract]
        User GetUserByUsername(string username);
    }
}
