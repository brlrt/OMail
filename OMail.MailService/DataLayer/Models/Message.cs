using System;
using System.ComponentModel.DataAnnotations;

namespace OMail.MailService.DataLayer.Models
{
    public class Message
    {
        [Key]
        public long ID
        {
            get;
            protected set;
        }

        public virtual User Sender
        {
            get;
            set;
        }

        public virtual User Receiver
        {
            get;
            set;
        }

        public DateTime SendTimeStamp
        {
            get;
            set;
        }

        public string Content
        {
            get;
            set;
        }

        public string Subject
        {
            get;
            set;
        }
    }
}