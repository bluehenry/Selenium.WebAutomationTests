using System;
using System.Configuration;
using WebApp.Test.Framework.Support.Security;

namespace WebApp.Test.Framework.Support
{
    public static class TestEnvironment
    {
        private static string _baseUrl;
        public static string BaseUrl => _baseUrl;
        

        private static string _dbConnectionString;
        public static string DbConnectionString => _dbConnectionString;
        

        private static string _userName;
        public static string UserName => _userName;
        

        private static string _password;
        public static string Password => _password;
        

        public static void Initialize()
        {
            string testEnv = ConfigurationManager.AppSettings["TestEnvironment"];

            if (testEnv.Equals("Dev"))
            {
                _baseUrl = ConfigurationManager.AppSettings["Dev_BaseUrl"];
                _dbConnectionString = ConfigurationManager.AppSettings["Dev_DBConnectString"];
            }
            else if (testEnv.Equals("Test"))
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

            _userName = ConfigurationManager.AppSettings["UserName"];
            string encryptedPassword = ConfigurationManager.AppSettings["Password"];

            string key = ConfigurationManager.AppSettings["EncryptionKey"];

            _password = EncrytpDecrypt.Decrypt(encryptedPassword, key);
           
        }

    }
}
