using System;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace WpfMailSender
{
    public partial class MainWindow
    {       
        
        public MainWindow() => InitializeComponent();
        static VariableData vardata = new VariableData(); // экземпляр статического класса, содержит переменные описывающие информацию о отправителе, настройках сервера, получателях.

//Переменные вкладки New Message

        private void MessageChanged(object sender, RoutedEventArgs e)
        {
            vardata.MessageText = message.Text;
        }
        private void MailChanged(object sender, RoutedEventArgs e)
        {            
            vardata.MailAddress = Address.Text;
        }
        private void SubjectChanged(object sender, RoutedEventArgs e)
        {
            vardata.mailSubject = Subject.Text;
        }

//Переменные вкладки Settings

        private void SenderMailChanged(object sender, RoutedEventArgs e)
        {
            vardata.senderAddress = SenderAddress.Text;
        }
        private void UserNameChanged(object sender, RoutedEventArgs e)
        {
            vardata.senderName = SenderUserName.Text;
        }
        private void PasswordChanged(object sender, RoutedEventArgs e)
        {
            vardata.password = Password.SecurePassword;
        }
        private void ServerChanged(object sender, RoutedEventArgs e)
        {
            vardata.server = Server.Text;
        }
        private void PortChanged(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Port.Text, out int P) == true) vardata.port = int.Parse(Port.Text);
            else Port.Text = "Port has to be a number";
        }
        private void ServerTypeChanged(object sender, RoutedEventArgs e)
        {
            vardata.serverType = ServerType.Text;
        }
        
  //Buttons
        private void Exit_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SendButton_OnClick(object sender, RoutedEventArgs e)
        {
            EmailSendServiceClass Sender = new EmailSendServiceClass(vardata.MessageText, vardata.MailAddress, vardata.mailSubject, vardata.senderAddress, vardata.senderName, vardata.password, vardata.server, vardata.serverType, vardata.port);
            Sender.Send();
        }
    }
}
