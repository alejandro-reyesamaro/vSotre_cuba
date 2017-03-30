using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EMailTaskProvider
{
    public class SMTP_ConfigProvider
    {
        private XmlDocument config;

        #region membership
        private string user_name;
        public string User_Name
        {
            get { return user_name; }
            set { user_name = value; }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        #endregion

        #region smtp_Server
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

        #region SSL
        private int ssl;        
        public int SSL
        {
            get { return ssl; }
            set { ssl = value; }
        }
        #endregion

        #region port
        private int port;
        public int Port
        {
            get { return port; }
            set { port = value; }
        }
        #endregion

        #region administrador
        private string admin;
        public string Admin
        {
            get { return admin; }
            set { admin = value; }
        }
        #endregion

        public SMTP_ConfigProvider(string path)
        {
            loadConfig(path);
        }
        private void loadConfig(string path)
        {            
            this.config = new XmlDocument();
            config.Load(path);
            XmlNode n_smtp = this.config["xml"]["smtp_server"];
            this.server_address = n_smtp["server_address"].InnerText;
            this.mail_address = n_smtp["mail_address"].InnerText;
            this.server_name = n_smtp["server_name"].InnerText;

            XmlNode n_user = this.config["xml"]["membership"];
            this.user_name = n_user["user_name"].InnerText;
            this.password = n_user["password"].InnerText;

            XmlNode n_ssl = this.config["xml"]["SSL"];
            this.ssl = int.Parse(n_ssl.InnerText);

            XmlNode n_port = this.config["xml"]["port"];
            this.port = int.Parse(n_port.InnerText);

            XmlNode n_admin = this.config["xml"]["admin"];
            this.admin = n_admin.InnerText;
        }
    }
}
