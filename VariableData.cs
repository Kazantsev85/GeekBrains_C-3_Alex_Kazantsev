using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfMailSender
{
     class VariableData
    {
        private string Message;
        private string Address;
        private string MailSubject;
        private string SenderAddress;
        private string SenderName;
        private SecureString UserPassword;
        private string Server;
        private string ServerType = "smtp";
        private int Port = 25;

        public string MessageText
        {
            get { return Message; }
            set { Message = value; }
        }
        public string MailAddress
        {
            get { return Address; }
            set { Address = value; }
        }
        public string mailSubject
        {
            get { return MailSubject; }
            set { MailSubject = value; }
        }
        public string senderAddress
        {
            get { return SenderAddress; }
            set { SenderAddress = value; }
        }
        public string senderName
        {
            get { return SenderName; }
            set { SenderName = value; }
        }
        public SecureString password
        {
            get { return UserPassword; }
            set { UserPassword = value; }
        }
        public string server
        {
            get { return Server; }
            set { Server = value; }
        }
        public int port
        {
            get { return Port; }
            set { Port = value; }
        }
        public string serverType
        {
            get { return ServerType; }
            set { ServerType = value; }
        }

    }
}
