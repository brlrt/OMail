using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace OMail.MailService.DataLayer.Models
{
    public class User
    {
        [Key]
        public string Name
        {
            get;
            set;
        }

        public DateTime Registered_Date
        {
            get;
            set;
        }

        public long HashedPassword
        {
            get;
            set;
        }

        public string Salt
        {
            get;
            set;
        }
    }
}