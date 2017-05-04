using System;
using System.Configuration;
using WebApp.Test.Framework.Support.Security;

namespace WebApp.Test.Framework.Support
{
    public static class TestEnvironment
    {
        public static string TestEnv { get; set; }
        public static string BaseUrl { get; set; }
        public static string DBConnectionString { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static void Initialize()
        {
            TestEnv = ConfigurationManager.AppSettings["TestEnvironment"];

            if (TestEnv.Equals("Dev"))
            {
                BaseUrl = ConfigurationManager.AppSettings["Dev_BaseUrl"];
                DBConnectionString = ConfigurationManager.AppSettings["Dev_DBConnectString"];
            }
            else if (TestEnv.Equals("Test"))
            {
                BaseUrl = ConfigurationManager.AppSettings["Test_BaseUrl"];
                DBConnectionString = ConfigurationManager.AppSettings["Test_DBConnectString"];
            }
            else if (TestEnv.Equals("QA"))
            {
                BaseUrl = ConfigurationManager.AppSettings["QA_BaseUrl"];
                DBConnectionString = ConfigurationManager.AppSettings["QA_DBConnectString"];
            }
            else
            {
                throw new ArgumentException();
            }

            //UserName = ConfigurationManager.AppSettings["UserName"];
            //string encryptedPassword = ConfigurationManager.AppSettings["Password"];

            //string key = ConfigurationManager.AppSettings["EncryptionKey"];

            //Password = EncrytpDecrypt.Decrypt(encryptedPassword, key);
        }

    }
}
