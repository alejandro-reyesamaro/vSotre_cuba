using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;


namespace EMailTaskProvider
{
    public class EMialClient
    {
        #region Propiedades

        #region email
        private string name;
        private List<string> to;
        private string subject;
        private string body;        
        private string replyTo;
        public string ReplyTo
        {
            get { return replyTo; }
            set { replyTo = value; }
        }
        public string Body
        {
            get { return body; }
            set { body = value; }
        }
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        public List<string> To
        {
            get { return to; }
            set { to = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        #endregion

        #region SSL & port
        private bool ssl;
        private int port;
        public int Port
        {
            get { return port; }
            set { port = value; }
        }
        public bool SSL
        {
            get { return ssl; }
            set { ssl = value; }
        }
        #endregion
                
        #region membership
        private string password;
        private string user_name;
        public string User_Name
        {
            get { return user_name; }
            set { user_name = value; }
        }
        public string Password
        {
            set { password = value; }
        }
        #endregion

        #region smtp server
        private string server_name;
        public string Server_Name
        {
            get { return server_name; }
            set { server_name = value; }
        }
        private string server_address;
        public string Server_Address
        {
            get { return server_address; }
            set { server_address = value; }
        }
        private string mail_address;
        public string Mail_Address
        {
            get { return mail_address; }
            set { mail_address = value; }
        }
        #endregion

        #endregion


        public EMialClient(string path)
        {
            this.to = new List<string>();
            SMTP_ConfigProvider prov = new SMTP_ConfigProvider(path);
            this.server_address = prov.Server_Address;
            this.server_name = prov.Server_Name;
            this.mail_address = prov.Mail_Address;
            this.user_name = prov.User_Name;
            this.password = prov.Password;
            this.to.Add(prov.Admin);
            this.replyTo = prov.Admin;
            if(prov.SSL == 1)
            {
                this.SSL = true;
                this.port = prov.Port;
            }
        }
        

        public string Send()
        {            
            //Create MailMessage Object
            MailMessage email_msg = new MailMessage();
            //Specifying From,Sender & Reply to address
            email_msg.From = new MailAddress(mail_address, name);
            email_msg.Sender = new MailAddress(mail_address, name);
            email_msg.ReplyTo = new MailAddress(replyTo, name);                      

            foreach (string str_to in this.to)
            {
                email_msg.To.Add(str_to);
            }

            email_msg.Subject = subject;//Subject of email
            email_msg.Body = body;
            email_msg.Priority = MailPriority.Normal;

            //Create an object for SmtpClient class
            SmtpClient mail_client = new SmtpClient();

            //Providing Credentials (Username & password)
            NetworkCredential network_cdr = new NetworkCredential();
            network_cdr.UserName = user_name;
            network_cdr.Password = password;

            mail_client.Host = server_address; //SMTP host    
            mail_client.UseDefaultCredentials = false;
            mail_client.Credentials = network_cdr;
            //mail_client.EnableSsl = smtp_server.Smtp_SSL;
            //int port = smtp_server.Smtp_port;
            //if (port > 0)
            //    mail_client.Port = port;

            //Now Send the message
            mail_client.Send(email_msg);
            return "El mensaje se envió satisfactoriamente";            
        }
    }
}
