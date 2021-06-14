using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows;

namespace WpfMailSender
{
    class EmailSendServiceClass
    {
        string Message;
        string Address;
        string MailSubject;
        string SenderAddress;
        string SenderName;
        SecureString UserPassword;
        string Server;
        string ServerType;
        int Port;
        public EmailSendServiceClass(string message, string address, string mailSub, string senderAddress, string senderName, SecureString userPassword, string server, string serverType, int port)
        {
            Message = message;
            Address = address;
            MailSubject = mailSub;
            SenderAddress = senderAddress;
            SenderName = senderName;
            UserPassword = userPassword;
            Server = server;
            ServerType = serverType;
            Port = port;
        }
        public void Send()
        {
            using var message = new MailMessage(SenderAddress, Address);
            message.Subject = MailSubject + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ff");
            message.Body = Message + DateTime.Now.ToString("F");

            //message.Attachments.Add(new Attachment());

            using var client = new SmtpClient(ServerType + "." + Server, Port)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential
                {
                    UserName = SenderName,
                    SecurePassword = UserPassword,
                }
            };

            try
            {
                client.Send(message);
                SendEndWindow sew = new SendEndWindow();
                sew.ShowDialog();
            }
            catch (SmtpException smtp_exception)
            {
                ErrorWindow error = new ErrorWindow();
                error.ShowDialog();
            }
        }
    }
}
