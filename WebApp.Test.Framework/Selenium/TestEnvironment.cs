using System;
using System.Configuration;

namespace WebApp.Test.Framework.Selenium
{
    public static class TestEnvironment
    {
        private static string _baseUrl;
        public static string BaseUrl
        {
            get { return _baseUrl; }
        }

        private static string _dbConnectionString;
        public static string DBConnectionString
        {
            get { return _dbConnectionString; }
        }

        private static string _userName;
        public static string UserName
        {
            get { return _userName; }
        }

        private static string _password;
        public static string Password
        {
            get { return _password; }
        }

        public static void Initialize()
        {
            string testEnv = ConfigurationManager.AppSettings["TestEnvironment"];

            if (testEnv.Equals("DEV") || testEnv.Equals("Dev"))
            {
                _baseUrl = ConfigurationManager.AppSettings["Dev_BaseUrl"];
                _dbConnectionString = ConfigurationManager.AppSettings["Dev_DBConnectString"];
            }
            else if (testEnv.Equals("TEST") || testEnv.Equals("Test"))
            {
                _baseUrl = ConfigurationManager.AppSettings["Test_BaseUrl"];
                _dbConnectionString = ConfigurationManager.AppSettings["Test_DBConnectString"];
            }
            else if (testEnv.Equals("QA"))
            {
                _baseUrl = ConfigurationManager.AppSettings["QA_BaseUrl"];
                _dbConnectionString = ConfigurationManager.AppSettings["QA_DBConnectString"];
            }
            else
            {
                throw new ArgumentException();
            }

            //_userName = ConfigurationManager.AppSettings["UserName"];
            //string encryptedPassword = ConfigurationManager.AppSettings["Password"];

            //string key = ConfigurationManager.AppSettings["EncryptionKey"];

            //_password = EncrytpDecrypt.Decrypt(encryptedPassword, key);
        }

    }
}
