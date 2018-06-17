using OMail.MailService.DataLayer.Models;
using System;
using System.Linq;

namespace OMail.MailService.DataLayer.Importers
{
    public class UserImporter
    {
        private IUnitOfWork unitOfWork;

        public UserImporter(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public bool RegisterUser(string username, string password)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                if (unitOfWork.Users.GetAllUsers().Where(x => x.Name == username).Count() > 0)
                {
                    return false;
                }

                var salt = Guid.NewGuid().ToString();
                var user = new User
                {
                    Name = username,
                    Salt = salt,
                    HashedPassword = (password.GetHashCode() + salt).GetHashCode(),
                    Registered_Date = DateTime.Now
                };

                unitOfWork.Users.Add(user);
                unitOfWork.Commit();

                return true;
            }
        }

        public bool LoginUser(string username, string password)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                if (unitOfWork.Users.GetAllUsers().Where(x => x.Name == username).Count() == 0)
                {
                    return false;
                }

                var user = unitOfWork.Users.GetAllUsers().Where(x => x.Name == username).First();

                if (!(user.HashedPassword == HashPasswordWithSalt(password, user.Salt)))
                {
                    return false;
                }

                return true;
            }
        }

        public long HashPasswordWithSalt(string password, string salt)
        {
            return (password.GetHashCode() + salt).GetHashCode();
        }
    }
}