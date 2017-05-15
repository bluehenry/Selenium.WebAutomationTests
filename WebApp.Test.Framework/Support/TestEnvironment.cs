using System;
using System.Configuration;
using WebApp.Test.Framework.Support.Security;

namespace WebApp.Test.Framework.Support
{
    public static class TestEnvironment
    {
        private static string baseUrl;
        public static string BaseUrl
        {
            get { return baseUrl; }
        }

        private static string dbConnectionString;
        public static string DBConnectionString
        {
            get { return dbConnectionString; }
        }

        private static string userName;
        public static string UserName
        {
            get { return userName; }
        }

        private static string password;
        public static string Password
        {
            get { return password; }
        }

        public static void Initialize()
        {
            string testEnv;

            testEnv = ConfigurationManager.AppSettings["TestEnvironment"];

            if (testEnv.Equals("Dev"))
            {
                baseUrl = ConfigurationManager.AppSettings["Dev_BaseUrl"];
                dbConnectionString = ConfigurationManager.AppSettings["Dev_DBConnectString"];
            }
            else if (testEnv.Equals("Test"))
            {
                baseUrl = ConfigurationManager.AppSettings["Test_BaseUrl"];
                dbConnectionString = ConfigurationManager.AppSettings["Test_DBConnectString"];
            }
            else if (testEnv.Equals("QA"))
            {
                baseUrl = ConfigurationManager.AppSettings["QA_BaseUrl"];
                dbConnectionString = ConfigurationManager.AppSettings["QA_DBConnectString"];
            }
            else
            {
                throw new ArgumentException();
            }

            //userName = ConfigurationManager.AppSettings["UserName"];
            //string encryptedPassword = ConfigurationManager.AppSettings["Password"];

            //string key = ConfigurationManager.AppSettings["EncryptionKey"];

            //password = EncrytpDecrypt.Decrypt(encryptedPassword, key);
        }

    }
}
